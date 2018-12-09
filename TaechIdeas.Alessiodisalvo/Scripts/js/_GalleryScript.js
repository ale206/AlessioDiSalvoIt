var navigationContainer = $('#filter-nav'),
    mainNavigation = navigationContainer.find('#filter-main-nav ul');

$('.filter-nav-trigger').on('click', function(event) {
    event.preventDefault();
    $(this).toggleClass('menu-is-open');
    mainNavigation.off('webkitTransitionEnd otransitionend oTransitionEnd msTransitionEnd transitionend').toggleClass('is-visible');
});

new CBPGridGallery(document.getElementById('grid-gallery'), { isotope: true });