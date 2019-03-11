using AuthorizeNet.Api.Contracts.V1;
using AuthorizeNet.Api.Controllers;
using AuthorizeNet.Api.Controllers.Bases;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using NurseryApp.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NurseryApp.Models
{
    public class Payment
    {
        private IConfiguration _configuration;

        /// <summary>
        /// Constructor method that brings in configuration strings to be used by the Payment class
        /// </summary>
        /// <param name="configuration">Configuration strings from user secrets</param>
        public Payment(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        /// <summary>
        /// Creates a transaction instance built from the checkout input from the form. Sends the transaction to the third party AuthNet service for authorization. Returns a response based on the validation of the checkout data.
        /// </summary>
        /// <param name="cvm">Checkout View Model created from form</param>
        /// <returns>Validation response from AuthNet</returns>
        [Authorize]
        public string Run(CheckoutViewModel cvm)
        {
            ApiOperationBase<ANetApiRequest, ANetApiResponse>.RunEnvironment = AuthorizeNet.Environment.SANDBOX;

            ApiOperationBase<ANetApiRequest, ANetApiResponse>.MerchantAuthentication = new merchantAuthenticationType()
            {
                name = _configuration["AuthNetAPILogin"],
                ItemElementName = ItemChoiceType.transactionKey,
                Item = _configuration["AuthNetTransactionKey"]
            };

            var creditCard = new creditCardType
            {
                cardNumber = cvm.CC,
                expirationDate = cvm.ExpirationDateMonth + cvm.ExpirationDateYear
            };

            paymentType paymentType = new paymentType { Item = creditCard };
            customerAddressType billingAddress = new customerAddressType
            {
                address = cvm.Address,
                city = cvm.City,
                state = cvm.State,
                zip = cvm.ZipCode.ToString()
            };

            transactionRequestType transactionRequest = new transactionRequestType
            {
                transactionType = transactionTypeEnum.authCaptureTransaction.ToString(),
                amount = cvm.Total,
                payment = paymentType,
                billTo = billingAddress
            };

            createTransactionRequest request = new createTransactionRequest
            {
                transactionRequest = transactionRequest
            };

            var controller = new createTransactionController(request);
            controller.Execute();

            var response = controller.GetApiResponse();

            if (response.messages.resultCode == messageTypeEnum.Ok)
            {
                if (response.transactionResponse != null)
                {
                    return "Payment Successful";
                }
            }
            else
            {
                Console.WriteLine("Error: " + response.messages.message[0].code + "  " + response.messages.message[0].text);
                if (response.transactionResponse.errors != null)
                {
                    Console.WriteLine("Transaction Error : " + response.transactionResponse.errors[0].errorCode + " " + response.transactionResponse.errors[0].errorText);
                }
            }

            return "Payment error!";
        }
    }
}
