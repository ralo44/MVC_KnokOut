$(function () {
    setInterval("carruselImagenes()", 3000);
});
function carruselImagenes() {
    var fotoActual = $('#carrusel div.actual');
    var fotoSig = fotoActual.next();
    if (fotoSig.length == 0) {
        fotoSig = $('#carrusel div:first');
    }
    fotoActual.removeClass('actual').addClass('anterior');
    fotoSig.css({ opacity: 0.0 }).addClass('actual')
        .animate({ opacity: 1.0 }, 1000,
            function () { fotoActual.removeClass('anterior'); });
}
