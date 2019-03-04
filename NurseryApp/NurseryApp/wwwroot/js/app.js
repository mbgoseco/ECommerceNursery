$('.has-dropdown').on('click', function (event) {
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

console.log("We're running!");