# BinaryTree Nursery
BinaryTree Nursery is a Ecommerce site that sells plants, such as Dwarf Apple Trees and Giant Sunflowers. We picked plants because many nurseries do not have good Ecommerce sites, and because we believed a lot of fun styling could be used thanks to how pretty the plants are. View the deployed BinaryTreeNursery [here](https://binarytreenursery.azurewebsites.net/).


## Technologies
#### Languages
- C#
- Javascript
- CSS
- HTML5
#### Technologies and FrameWorks
- ASP.net
- Microsoft Entity Framework
- JQuery
- Azure Dev Ops
- Git
- SQL
- Microsoft Identity Framework

## Claims and Policies
#### Claims
- First and Last Name
	- Used for greetings, invoices, and user information.
- Birthday
	- Used for birthday promotions and discounts. 
- Landscaper (bool) 
	- Used to grant access to landscaper features and discounts.

#### Policies
- Landscape
	- Only landscapers are allowed to access to bulk quantity products.

## OAuth
- Micrsoft OAuth
- Google OAuth

## Schema
![Database Schema](/Assets/DataFlow.PNG)
A Basket has an ID, a UserID, a Total, and many BasketProducts. BasketProducts have a composite key of the BasketID and a Product ID. It has a property of Quantity. BasketProducts are created when a Product is added to a Basket. A Basket is made when a new user registers.  
A Checkout has an ID, UserID and Total, much like a basket. It includes CheckoutProducts, with a composite key of CheckoutID and a Product ID, and a property of Quantity.
Products had a Primary Key of ID, and properties of Image, Name, Description, Bulk, Type, and Sku. 

## Change Log
v.0.1.0 - Sprint 1  
	Created Inventory Database and User Database. Created Home page, a Login Page, and Register page that capture necessary claims, and a shopping page that renders all products. Custom Claim based policy implamented.   
v 0.2.0 - Sprint 2  
    Add OAuth using Microsoft and Google. Added the ability for users to add products to card. Created cart view. 
## Contributors
Michael Goseco and Clarice Costello