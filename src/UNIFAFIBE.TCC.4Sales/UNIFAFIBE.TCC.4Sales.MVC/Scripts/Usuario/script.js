var functionsUsuario = {
    Listar: function () {
        fGlobal.Ajax(gHostProjeto + "Usuario/Listar", "GET", null, functionsUsuario.HtmlUsuario, null, null, null);
    },
    HtmlUsuario: function (data) {
        var json = $.parseJSON(data.usuario);
        if (fGlobal.IsNotEmpty(json)) {
            functionsUsuario.CardFill(json);
        }
    },
    CardFill: function (data) {
        functionsUsuario.CardsClear();
        var html = "";
        var htmlUsuario = "";

        $.each(data, function (index, value) {
            console.log(value);
            
            if (value.UsuarioResponsavel === true) {
                html += '<div class="card-lista col-md-6 mb-3" style="display:inline-block;">';
                html += '<div class="card-usuario d-flex">';
                html += '<div class="container-img-usuario-tab-usuarios">';
                html += '<img src="' + (value.FotoPerfil === null ? "/assets/img/user-default.png" : value.FotoPerfil) +
                                    '" class="img-usuario-tab-usuarios alt="imagem-usuario" >';
                html += '</div>';
                html += '<div class="container-info-usuario-tab-usuarios">';
                html += '<p class="nome-user-tab-usuarios">' + value.Nome + '</p>';
                html += '<span class="perfil-responsavel">Responsável pelo sistema</span>';
                html += '<div class="contato-tab-usuarios">';
                html += '<span>';
                html += '<i class="fas fa-envelope usuario-icone"></i>' + value.Email;
                html += '</span>';
                html += '<span>';
                html += '<i class="fas fa-phone usuario-icone"></i>' + value.Telefone;
                html += '</span>';
                html += '<a href="Usuario/Alterar/' + value.UsuarioId + '" class="btn btn-sm btn-warning mt-3 mr-1">';
                html += '<i class="fas fa-pencil-alt icone-edit"></i>Alterar</a>';
                html += '<a href="Usuario/Desativar/' + value.UsuarioId + '" class="btn btn-sm btn-danger mt-3">';
                html += '<i class="fas fa-trash icone-edit"></i>Desativar</a>';
                html += '</div>';
                html += '</div>';
                html += '</div>';
                html += '</div>';
            } else {
                htmlUsuario += '<div class="col-md-6 mb-3" style="display:inline-block;">';
                htmlUsuario += '<div class="card-usuario d-flex">';
                htmlUsuario += '<div class="container-img-usuario-tab-usuarios">';
                htmlUsuario += '<img src="' + (value.FotoPerfil === null ? "/assets/img/user-default.png" : value.FotoPerfil) +
                    '" class="img-usuario-tab-usuarios alt="imagem-usuario" >';
                htmlUsuario += '</div>';
                htmlUsuario += '<div class="container-info-usuario-tab-usuarios">';
                htmlUsuario += '<p class="nome-user-tab-usuarios">' + value.Nome + '</p>';
                htmlUsuario += '<div class="contato-tab-usuarios">';
                htmlUsuario += '<span>';
                htmlUsuario += '<i class="fas fa-envelope usuario-icone"></i>' + value.Email;
                htmlUsuario += '</span>';
                htmlUsuario += '<span>';
                htmlUsuario += '<i class="fas fa-phone usuario-icone"></i>' + value.Telefone;
                htmlUsuario += '</span>';
                htmlUsuario += '<a href="Usuario/Alterar/' + value.UsuarioId + '" class="btn btn-sm btn-warning mt-3 mr-1">';
                htmlUsuario += '<i class="fas fa-pencil-alt icone-edit"></i>Alterar</a>';
                htmlUsuario += '<a href="Usuario/Desativar/' + value.UsuarioId + '" class="btn btn-sm btn-danger mt-3">';
                htmlUsuario += '<i class="fas fa-trash icone-edit"></i>Desativar</a>';
                htmlUsuario += '</div>';
                htmlUsuario += '</div>';
                htmlUsuario += '</div>';
                htmlUsuario += '</div>';
            }
        });

        $("#content-responsavel").append(html);
        $("#content-usuarios").append(htmlUsuario);
    },
    CardsClear: function () {
        $("#content-responsavel").find(".card-lista").remove();
        $("#content-usuarios").find(".card-lista").remove();
    },
    AlterarSenha: function (id, senha) {
        fGlobal.Ajax(gHostProjeto + "Usuario/AlterarSenha", "POST", { usuarioId: id, novaSenha: senha }, functionsUsuario.HtmlSenha, null, null, null);
    },
    HtmlSenha: function (data) {
        console.log(data);
        //var json = JSON.parse(data.ValidationResult);
        if (data.validationResult.IsValid === true) {
            fGlobal.EmitirNotificacao("Alteração Senha", "Senha alterada com sucesso", "info");
        } else {
            fGlobal.ExibirNotificaoErrosValidacao(data.validationResult);
        }
        functionsUsuario.HideModal();
        $('#Senha').val('');
    },
    HideModal: function () {
        $('#alterarSenha').modal('hide');
    }
};

$(function () {
    functionsUsuario.Listar();
    
    $('#file').change(function (event) {
        var form = new FormData();
        form.append('fileUpload', event.target.files[0]); // para apenas 1 arquivo
        //var name = event.target.files[0].content.name; // para capturar o nome do arquivo com sua extenção

        $.ajax({
            url: gHostProjeto + 'Usuario/SalvarImagem', 
            data: form,
            processData: false,
            contentType: false,
            type: 'POST',
            success: function (data) {
                if (fGlobal.IsNotEmpty(data.caminhoImagem)) {
                    var caminho = data.caminhoImagem.split('~');
                    $("#FotoPerfil").val(caminho[1]);
                    $("#imagem-usuario").attr('src', caminho[1]);
                }
            }
        });
    });

    $('#confirmarAlteracaoSenha').on('click', function () {
        var usuarioId = $('#UsuarioId').val();
        var novaSenha = $('#Senha').val();
        functionsUsuario.AlterarSenha(usuarioId, novaSenha);
    });
});