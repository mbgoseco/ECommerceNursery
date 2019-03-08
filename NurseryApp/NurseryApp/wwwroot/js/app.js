$('#basket-dropdown').on('click', function (event) {
    console.log('also firing');
    $('.has-dropdown').toggleClass('is-active');
})

$('.img1').on('click', function (event) {
    console.log('also firing');
    $('.img1-img').toggleClass('hidden');
    $('.img1-div').toggleClass('hidden');
})

$('.img2').on('click', function (event) {
    console.log('also firing');
    $('.img2-img').toggleClass('hidden');
    $('.img2-div').toggleClass('hidden');
})

$('.img3').on('click', function (event) {
    console.log('also firing');
    $('.img3-img').toggleClass('hidden');
    $('.img3-div').toggleClass('hidden');
})

$('.img4').on('click', function (event) {
    console.log('also firing');
    $('.img4-img').toggleClass('hidden');
    $('.img4-div').toggleClass('hidden');
})

$('#name-change').on('click', function (event) {
    event.preventDefault();
    $('#first-name-input').toggleClass('hidden');
    $('#first-name').toggleClass('hidden');
    $('#submit-name').toggleClass('hidden');
    $('#name-change').toggleClass('hidden');
    $('#name-cancel').toggleClass('hidden');
})

$('#name-cancel').on('click', function (event) {
    event.preventDefault();
    $('#first-name-input').toggleClass('hidden');
    $('#first-name').toggleClass('hidden');
    $('#submit-name').toggleClass('hidden');
    $('#name-change').toggleClass('hidden');
    $('#name-cancel').toggleClass('hidden');
})

$('#change-pw').on('click', function (event) {
    event.preventDefault();
    $('.pw').toggleClass('hidden');
    if ($('#change-pw').text() == 'CHANGE PASSWORD') {
        $('#change-pw').text('CANCEL');
    } else if ($('#change-pw').text() == 'CANCEL') {
        $('#change-pw').text('CHANGE PASSWORD');
    }
})

console.log("We're running!");