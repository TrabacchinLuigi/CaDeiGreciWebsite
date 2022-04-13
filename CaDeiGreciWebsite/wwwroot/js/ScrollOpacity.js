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

    document.addEventListener('DOMContentLoaded', function () {
        let firstSlide = document.getElementById('slide-first');
        let navbarTop = document.getElementById('navbar-top');
        let bg = navbarTop.getElementsByClassName('background')[0];
        if (!(bg instanceof HTMLDivElement)) { throw "navbartop isn't a div"; }
        let range = firstSlide.getBoundingClientRect().height - navbarTop.getBoundingClientRect().height;

        window.addEventListener("resize", function (ev) {
            range = firstSlide.getBoundingClientRect().height - navbarTop.getBoundingClientRect().height;
            bg.style.opacity = GetScrollPercentage(range);
        });
        window.addEventListener('scroll', function () {
            bg.style.opacity = GetScrollPercentage(range);
        });
    });
})();