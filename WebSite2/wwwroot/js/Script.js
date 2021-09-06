/*!
* Start Bootstrap - Simple Sidebar v6.0.3 (https://startbootstrap.com/template/simple-sidebar)
* Copyright 2013-2021 Start Bootstrap
* Licensed under MIT (https://github.com/StartBootstrap/startbootstrap-simple-sidebar/blob/master/LICENSE)
*/
// 
// Scripts
// 

window.addEventListener('DOMContentLoaded', event => {

    // Toggle the side navigation
    const sidebarToggle = document.body.querySelector('#sidebarToggle');
    if (sidebarToggle) {
        // Uncomment Below to persist sidebar toggle between refreshes
        // if (localStorage.getItem('sb|sidebar-toggle') === 'true') {
        //     document.body.classList.toggle('sb-sidenav-toggled');
        // }
        sidebarToggle.addEventListener('click', event => {
            event.preventDefault();
            document.body.classList.toggle('sb-sidenav-toggled');
            localStorage.setItem('sb|sidebar-toggle', document.body.classList.contains('sb-sidenav-toggled'));
        });
    }

});






/* ===== Variables ===== */
var header = document.querySelectorAll(".panel-header"),
    item = document.querySelectorAll(".item"),
    hoverPanelTl = [],
    openedPanel = {};

Array.prototype.forEach.call(header, function (el, i) {
    var arrow = el.querySelector(".arrow"),
        spacer = el.querySelector(".spacer"),
        panel = el.parentNode,
        content = panel.querySelector(".panel-content");

    hoverPanelTl[i] = new TimelineLite({ paused: true });

    /* ============= Define hover animation ============= */
    hoverPanelTl[i].to(el, 0.2, {
        css: {
            color: "#4f7351",
            background: "rgba(203, 228, 205, 0.6)",
            textIndent: "25px"
        },
        ease: Linear.easeNone
    });

    /* ============= Add event listeners ============= */
    el.addEventListener("mouseenter", function () {
        if (!hoverPanelTl[i].paused() || panel.classList.contains("closed")) {
            hoverPanelTl[i].timeScale(1).play();
            TweenLite.to(spacer, .5, { width: '100%' });
        }
    });

    el.addEventListener("mouseleave", function () {
        if (!hoverPanelTl[i].paused()) {
            hoverPanelTl[i].timeScale(3).reverse();
            TweenLite.to(spacer, .1, { width: 0 });
        }
    });

    el.addEventListener("click", function () {
        /* ============= If panel open ============= */
        if (!panel.classList.contains("closed")) {
            hoverPanelTl[i].paused(false);
            TweenLite.set(spacer, { width: "100%" });
            TweenLite.to(content, 0.3, { height: 0, borderTopWidth: 0 });
            TweenMax.to(arrow, 0.3, { rotation: 0, transformOrigin: "25% 50%" });
            panel.classList.add("closed");
            openedPanel = {};
        } else {

            /* ============= Auto close open panels ============= */
            if (openedPanel.el != undefined) {
                console.log(openedPanel);
                var openArrow = openedPanel.el.querySelector(".arrow"),
                    openPanel = openedPanel.el.parentNode,
                    openContent = openPanel.querySelector(".panel-content");

                hoverPanelTl[openedPanel.hoverTl].paused(false);
                hoverPanelTl[openedPanel.hoverTl].timeScale(3).reverse();

                TweenLite.to(openContent, 0.3, { height: 0, borderTopWidth: 0 });
                TweenMax.to(openArrow, 0.3, {
                    rotation: 0,
                    transformOrigin: "25% 50%"
                });
                openPanel.classList.add("closed");
            }

            /* ============= If panel closed ============= */
            hoverPanelTl[i].paused(true);
            TweenLite.set(spacer, { width: 0 });
            TweenLite.set(content, { height: "auto", borderTopWidth: "2px" });
            TweenLite.from(content, 0.5, {
                height: 0,
                borderTopWidth: 0,
                ease: Back.easeOut.config(1.4)
            });
            TweenMax.to(arrow, 0.5, {
                rotation: 90,
                transformOrigin: "25% 50%",
                ease: Back.easeOut.config(1.4)
            });
            panel.classList.remove("closed");
            openedPanel.el = el;
            openedPanel.hoverTl = i;
        }
    });
});

Array.prototype.forEach.call(item, function (el, i) {
    el.addEventListener("click", function () {
        console.log("The " + el.innerText + " button was clicked.");
    });
});