document.addEventListener("DOMContentLoaded", function() {
    const currentPath = window.location.pathname;
    const profileLinks = document.querySelectorAll(".profile-link");

    profileLinks.forEach(link => {
        if (link.getAttribute("href") === currentPath) {
            link.classList.add("active");
        }
    });
});