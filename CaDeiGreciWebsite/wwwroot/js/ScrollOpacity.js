(function () {

    /**
     * @param {number} range
     **/
    function GetScrollPercentage(range) {
        if (!isNaN(Number)) { throw "range should be a number"; }
        let scrollTop = window.scrollY;
        let percentage = 1 / range * scrollTop;
        console.log(percentage);

        percentage = percentage > 1 ? 1 : percentage < 0 ? 0 : percentage;
        return percentage;
    }
    /**
     * @param {HTMLElement} firstSlide
     * @param {HTMLElement} navbarTop
     * @param {HTMLElement} maincollassablemenu
     **/
    function GetOpacity(firstSlide, navbarTop, maincollassablemenu) {
        if (maincollassablemenu.classList.contains('show')) return 1;
        let range = firstSlide.getBoundingClientRect().height - navbarTop.getBoundingClientRect().height;
        return GetScrollPercentage(range);
    }

    document.addEventListener('DOMContentLoaded', function () {
        let firstSlide = document.getElementById('slide-first');
        let navbarTop = document.getElementById('navbar-top');
        let bg = navbarTop.getElementsByClassName('background')[0];
        let navbarTogglerButtons = document.getElementsByClassName('navbar-toggler');
        let maincollassablemenu = document.getElementById('main-collassable-menu');
        if (!(bg instanceof HTMLDivElement)) { throw "navbartop isn't a div"; }

        if (firstSlide == null) { return; }
        window.addEventListener("resize", function (ev) {
            bg.style.opacity = GetOpacity(firstSlide, navbarTop, maincollassablemenu);
        });
        window.addEventListener('scroll', function () {
            bg.style.opacity = GetOpacity(firstSlide, navbarTop, maincollassablemenu);
        });
        for (var navbarTogglerButton of navbarTogglerButtons) {
            navbarTogglerButton.addEventListener('click', function () {
                setTimeout(function () {
                    bg.style.opacity = GetOpacity(firstSlide, navbarTop, maincollassablemenu);
                }, 352);
            });
        }
        bg.style.opacity = GetOpacity(firstSlide, navbarTop, maincollassablemenu);
    });
})();