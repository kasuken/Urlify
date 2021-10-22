$(document).ready(() => {
    const $clipboardIcon = $('.landing__short--icon');
    const $footer = $('.footer');
    const $greyBg = $('.bg');
    const $chain = $('.bg--img');
    const $navbarElements = $('.navbar__wrp .stagger');
    const $landingElements = $('.landing__wrp .stagger');
    const $loader = $('.loader');

    const tl = gsap.timeline({defaults: { duration: .7, ease: Back.easeOut.config(0), opacity: 0 }});
    tl.set($greyBg, { right: 0, top: 0 });
    tl.set($chain, { bottom: 0 });

    tl
    .set($loader, { pointerEvents: "none", zIndex: -1 })
    .fromTo($greyBg, { opacity: 0 }, { opacity: 1 })
    .from($chain, { bottom: 50 }, "-=.25")
    .from($navbarElements, { y: -20, stagger: { amount: 0.25, from: "start" }}, "+=.3")
    .from($footer, { y: 20 }, "<")

    $clipboardIcon.on('click', () => {
        let $shortenedUrl = $('.landing__short--link');
        copyToClipboard($shortenedUrl.text());
    });

    const copyToClipboard = str => {
        navigator.clipboard.writeText(str).then(() => displayToast());
    };
});

function displayToast() {
    const $toast = $('.toast');
    $toast.text("Successfully copied to clipboard");
    $toast.toggleClass('visible');

    setTimeout(() => {
        $toast.toggleClass('visible');
    }, 3000);
}