$(function () {
    verificaMenuAtivo();

    $('.list-menu li').on('click', function () {
        sessionStorage.setItem('active-menu', $(this).attr('id'));
    });
    
    $("#btnCollapse").on("click", function () {
        $("#sidebar").toggleClass("active");
    });

    $(".actives-menu-top:last-of-type").hover(
        function () {
            $(this).find('i').removeClass("fas fa-angle-up");
            $(this).find('i').addClass("fas fa-angle-down");
            $(".info-user").addClass("active");
        },
        function () {
            $(this).find('i').removeClass("fas fa-angle-down");
            $(this).find('i').addClass("fas fa-angle-up");
            $(".info-user").removeClass("active");
        }
    );

    $('#relatorios-tab').click(function () {
        $('#filtros-dashboard').css('display', 'none');
    });

    $('#painel-tab').click(function () {
        $('#filtros-dashboard').css('display', 'block');
    });

    function verificaMenuAtivo() {
        var idMenuAtivo = sessionStorage.getItem('active-menu');

        if (idMenuAtivo === "dashboard-menu-item") {
            $('.list-menu li').removeClass('active-menu');
            $('#' + idMenuAtivo).addClass('active-menu');
        } else if (idMenuAtivo === "pedidos-menu-item") {
            $('.list-menu li').removeClass('active-menu');
            $('#' + idMenuAtivo).addClass('active-menu');
        } else if (idMenuAtivo === "clientes-menu-item") {
            $('.list-menu li').removeClass('active-menu');
            $('#' + idMenuAtivo).addClass('active-menu');
        } else if (idMenuAtivo === "representadas-menu-item") {
            $('.list-menu li').removeClass('active-menu');
            $('#' + idMenuAtivo).addClass('active-menu');
        } else {
            $('.list-menu li').removeClass('active-menu');
            $('#dashboard-menu-item').addClass('active-menu');
        }
    }
});
