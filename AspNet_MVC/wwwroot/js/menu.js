const openButton = document.querySelector('.btn-mobile');
const closeButton = document.querySelector('.close-btn');
const toggleMenu = document.querySelector('#mobile-menu');

openButton.addEventListener('click', function() {
    // Toggle the .open class on the mobile menu
    toggleMenu.setAttribute("class","mobile-menu-open");
});

closeButton.addEventListener('click', function() {
    // Toggle the .open class on the mobile menu
    toggleMenu.setAttribute("class","mobile-menu-closed");

});