window.addEventListener('DOMContentLoaded', event => {

    // Toggle the side navigation
    const sidebarToggle = document.body.querySelector('#sidebarToggle');
    if (sidebarToggle) {
        if (localStorage.getItem('sb|sidebar-toggle') === 'true') {
            document.body.classList.toggle('sb-sidenav-toggled');
        }
        sidebarToggle.addEventListener('click', event => {
            event.preventDefault();
            document.body.classList.toggle('sb-sidenav-toggled');
            localStorage.setItem('sb|sidebar-toggle', document.body.classList.contains('sb-sidenav-toggled'));
        });
    }

});

document.querySelector('.left-btn').addEventListener('click', function() {
    document.querySelector('.scrollable-row').scrollBy({
        left: -300, // Adjust this value to change scroll amount
        behavior: 'smooth'
    });
});

document.querySelector('.right-btn').addEventListener('click', function() {
    document.querySelector('.scrollable-row').scrollBy({
        left: 300, // Adjust this value to change scroll amount
        behavior: 'smooth'
    });
});
