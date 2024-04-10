const darkModeToggle = document.querySelector('.btn-switch input[type="checkbox"]');
let darkMode = localStorage.getItem('darkMode');

function updateImageSource(imageId, src) {
    const image = document.getElementById(imageId);
    if (image) {
        image.src = src;
    }
}

const enableDarkMode = () => {
  document.body.classList.add('dark-mode');

    updateImageSource('logo-img', '/images/header/logo-dark.svg');
    updateImageSource('appstore', '/images/home/app/appstore-dark.svg');
    updateImageSource('googleplay', '/images/home/app/googleplay-dark.svg');
    updateImageSource('404page', '/images/home/404page/404-dark.svg');
  
  localStorage.setItem('darkMode', 'enabled');
}

const disableDarkMode = () => {
  document.body.classList.remove('dark-mode');

    updateImageSource('logo-img', '/images/header/logo-light.svg');
    updateImageSource('appstore', '/images/home/app/appstore-light.svg');
    updateImageSource('googleplay', '/images/home/app/googleplay-light.svg');
    updateImageSource('404page', '/images/home/404page/404-light.svg');

  localStorage.setItem('darkMode', null);
}
 

if (darkMode === 'enabled') {
  darkModeToggle.checked = true;
  enableDarkMode();
}

darkModeToggle.addEventListener('change', () => {

    if (darkModeToggle.checked) {
        const appstoreImg = document.getElementById('appstore');
        console.log(appstoreImg);
        enableDarkMode();
  } else {  
        disableDarkMode();
  }
});