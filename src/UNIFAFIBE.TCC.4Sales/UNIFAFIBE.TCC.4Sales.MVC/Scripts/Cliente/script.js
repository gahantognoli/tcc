var functionsCliente = {
    ConsultarCep: function (cep, id) {
        fGlobal.Ajax(gHostProjeto + "Cliente/ConsultarCEP?cep=" + cep + "&id=" + id, "GET", null, functionsCliente.HtmlConsultarCep, null, functionsCliente.EscondeModal, functionsCliente.MostraModal);
    },
    HtmlConsultarCep: function (data) {
        var dados = JSON.parse(data.retorno);
        var id = JSON.parse(data.id);

        document.getElementById("pessoaJuridicaViewModels.EnderecosCliente[" + id + "].Endereco").value = dados.logradouro;
        document.getElementById("pessoaJuridicaViewModels.EnderecosCliente[" + id + "].Cidade").value = dados.localidade;
        document.getElementById("pessoaJuridicaViewModels.EnderecosCliente[" + id + "].Complemento").value = dados.complemento;
        document.getElementById("pessoaJuridicaViewModels.EnderecosCliente[" + id + "].Bairro").value = dados.bairro;
        document.getElementById("pessoaJuridicaViewModels.EnderecosCliente[" + id + "].Estado").value = dados.uf;
    },
    ConsultarCepPF: function (cep, id) {
        fGlobal.Ajax(gHostProjeto + "Cliente/ConsultarCEP?cep=" + cep + "&id=" + id, "GET", null, functionsCliente.HtmlConsultarCepPF, null, functionsCliente.EscondeModal, functionsCliente.MostraModal);
    },
    HtmlConsultarCepPF: function (data) {
        var dados = JSON.parse(data.retorno);
        var id = JSON.parse(data.id);

        document.getElementById("pessoaFisicaViewModels.EnderecosCliente[" + id + "].Endereco").value = dados.logradouro;
        document.getElementById("pessoaFisicaViewModels.EnderecosCliente[" + id + "].Cidade").value = dados.localidade;
        document.getElementById("pessoaFisicaViewModels.EnderecosCliente[" + id + "].Complemento").value = dados.complemento;
        document.getElementById("pessoaFisicaViewModels.EnderecosCliente[" + id + "].Bairro").value = dados.bairro;
        document.getElementById("pessoaFisicaViewModels.EnderecosCliente[" + id + "].Estado").value = dados.uf;
    },
    MostraModal: function () {
        $('#modal-cep').modal('show');
    },
    EscondeModal: function () {
        $('#modal-cep').modal('hide');
    },
    CriarHTMLEnderecoPJ: function (i) {
        var html = "";
        if (i !== 0) {
            html += '<div class="enderecoPessoaJuridica" style="margin-top:50px;"> ';
            html += '<div class="d-flex justify-content-start align-items-center">';
            html += '<h3 class="mr-3">Endereço</h3>';
            html += '<button type="button" class="btn btn-danger mt-1 mb-2 btnRemoverEnderecoPessoaJuridica"><i class="fas fa-trash-alt"></i></button> ';
            html += '</div>';
        } else {
            html += '<div class="enderecoPessoaJuridica">';
        }
        html += '<div class="form-group"> ';
        html += '<div class="col-md-2"> ';
        html += '<label class="control-label" for="">CEP</label><span class="span-obrigatorio">*</span> ';
        html += '</div> ';
        html += '<div class="col-md-3"> ';
        html += '<input type="text" class="form-control cepPJ" name="pessoaJuridicaViewModels.EnderecosCliente[' + i + '].CEP" id="pessoaJuridicaViewModels.EnderecosCliente[' + i + '].CEP" /> ';
        html += '<span class="field-validation-valid text-danger" data-valmsg-for="CEP" data-valmsg-replace="true"></span> ';
        html += '</div> ';
        html += '</div> ';
        html += '<div class="form-group"> ';
        html += '<div class="col-md-2"> ';
        html += '<label class="control-label" for="Endereco">Endereço</label><span class="span-obrigatorio">*</span> ';
        html += '</div> ';
        html += '<div class="col-md-8"> ';
        html += '<input type="text" class="form-control" name="pessoaJuridicaViewModels.EnderecosCliente[' + i + '].Endereco" id="pessoaJuridicaViewModels.EnderecosCliente[' + i + '].Endereco" /> ';
        html += '<span class="field-validation-valid text-danger" data-valmsg-for="Endereco" data-valmsg-replace="true"></span> ';
        html += '</div> ';
        html += '</div> ';
        html += '<div class="form-group"> ';
        html += '<div class="col-md-2"> ';
        html += '<label class="control-label" for="Numero">Número</label><span class="span-obrigatorio">*</span> ';
        html += '</div> ';
        html += '<div class="col-md-3"> ';
        html += '<input type="number" class="form-control" name="pessoaJuridicaViewModels.EnderecosCliente[' + i + '].Numero" id="pessoaJuridicaViewModels.EnderecosCliente[' + i + '].Numero" /> ';
        html += '<span class="field-validation-valid text-danger" data-valmsg-for="Numero" data-valmsg-replace="true"></span> ';
        html += '</div> ';
        html += '</div> ';
        html += '<div class="form-group"> ';
        html += '<div class="col-md-2"> ';
        html += '<label class="control-label" for="Complemento">Complemento</label> ';
        html += '</div> ';
        html += '<div class="col-md-4"> ';
        html += '<input type="text" class="form-control" name="pessoaJuridicaViewModels.EnderecosCliente[' + i + '].Complemento" id="pessoaJuridicaViewModels.EnderecosCliente[' + i + '].Complemento" /> ';
        html += '<span class="field-validation-valid text-danger" data-valmsg-for="Complemento" data-valmsg-replace="true"></span> ';
        html += '</div> ';
        html += '</div> ';
        html += '<div class="form-group"> ';
        html += '<div class="col-md-2"> ';
        html += '<label class="control-label" for="Cidade">Cidade</label><span class="span-obrigatorio">*</span> ';
        html += '</div> ';
        html += '<div class="col-md-6"> ';
        html += '<input type="text" class="form-control" name="pessoaJuridicaViewModels.EnderecosCliente[' + i + '].Cidade" id="pessoaJuridicaViewModels.EnderecosCliente[' + i + '].Cidade" /> ';
        html += '<span class="field-validation-valid text-danger" data-valmsg-for="Cidade" data-valmsg-replace="true"></span> ';
        html += '</div> ';
        html += '</div> ';
        html += '<div class="form-group"> ';
        html += '<div class="col-md-2"> ';
        html += '<label class="control-label" for="Bairro">Bairro</label><span class="span-obrigatorio">*</span> ';
        html += '</div> ';
        html += '<div class="col-md-6"> ';
        html += '<input type="text" class="form-control" name="pessoaJuridicaViewModels.EnderecosCliente[' + i + '].Bairro" id="pessoaJuridicaViewModels.EnderecosCliente[' + i + '].Bairro" /> ';
        html += '<span class="field-validation-valid text-danger" data-valmsg-for="Bairro" data-valmsg-replace="true"></span> ';
        html += '</div> ';
        html += '</div> ';
        html += '<div class="form-group"> ';
        html += '<div class="col-md-2"> ';
        html += '<label class="control-label" for="Estado">Estado</label><span class="span-obrigatorio">*</span> ';
        html += '</div> ';
        html += '<div class="col-md-3"> ';
        html += '<select name="pessoaJuridicaViewModels.EnderecosCliente[' + i + '].Estado" id="pessoaJuridicaViewModels.EnderecosCliente[' + i + '].Estado" class="form-control"> ';
        html += '<option value="">-------</option> ';
        html += '<option value="AC">Acre</option> ';
        html += '<option value="AL">Alagoas</option> ';
        html += '<option value="AP">Amapá</option> ';
        html += '<option value="AM">Amazonas</option> ';
        html += '<option value="BA">Bahia</option> ';
        html += '<option value="CE">Ceará</option> ';
        html += '<option value="DF">Distrito Federal</option> ';
        html += '<option value="ES">Espírito Santo</option> ';
        html += '<option value="GO">Goiás</option> ';
        html += '<option value="MA">Maranhão</option> ';
        html += '<option value="MT">Mato Grosso</option> ';
        html += '<option value="MS">Mato Grosso do Sul</option> ';
        html += '<option value="MG">Minas Gerais</option> ';
        html += '<option value="PA">Pará</option> ';
        html += '<option value="PB">Paraíba</option> ';
        html += '<option value="PR">Paraná</option> ';
        html += '<option value="PE">Pernambuco</option> ';
        html += '<option value="PI">Piauí</option> ';
        html += '<option value="RJ">Rio de Janeiro</option> ';
        html += '<option value="RN">Rio Grande do Norte</option> ';
        html += '<option value="RS">Rio Grande do Sul</option> ';
        html += '<option value="RO">Rondônia</option> ';
        html += '<option value="RR">Roraima</option> ';
        html += '<option value="SC">Santa Catarina</option> ';
        html += '<option value="SP">São Paulo</option> ';
        html += '<option value="SE">Sergipe</option> ';
        html += '<option value="TO">Tocantins</option> ';
        html += '</select> ';
        html += '<span class="field-validation-valid text-danger" data-valmsg-for="Estado" data-valmsg-replace="true"></span> ';
        html += '</div> ';
        html += '</div> ';
        html += '</div> ';

        $("#enderecosPessoaJuridica").append(html);
    },
    CriaHTMLContatoPJ: function (i) {
        var html = "";
        if (i !== 0) {
            html += '<div class="contatoPessoaJuridica" style="margin-top:50px;"> ';
            html += '<div class="d-flex justify-content-start align-items-center">';
            html += '<h3 class="mr-3">Contato</h3>';
            html += '<button type="button" class="btn btn-danger mt-1 mb-2 btnRemoverContatoPessoaJuridica"><i class="fas fa-trash-alt"></i></button> ';
            html += '</div>';
        } else {
            html += '<div class="contatoPessoaJuridica"> ';
        }
        html += '<div class="form-group"> ';
        html += '<div class="col-md-2"> ';
        html += '<label class="control-label" for="">Nome</label><span class="span-obrigatorio">*</span> ';
        html += '</div> ';
        html += '<div class="col-md-8"> ';
        html += '<input type="text" class="form-control nomePJ" name="pessoaJuridicaViewModels.ContatosCliente[' + i + '].Nome" id="pessoaJuridicaViewModels.ContatosCliente[' + i + '].Nome" /> ';
        html += '<span class="field-validation-valid text-danger" data-valmsg-for="pessoaJuridicaViewModels.ContatosCliente[' + i + '].Nome" data-valmsg-replace="true"></span> ';
        html += '</div> ';
        html += '</div> ';
        html += '<div class="form-group"> ';
        html += '<div class="col-md-2"> ';
        html += '<label class="control-label" for="">Cargo</label><span class="span-obrigatorio">*</span> ';
        html += '</div> ';
        html += '<div class="col-md-4"> ';
        html += '<input type="text" class="form-control" name="pessoaJuridicaViewModels.ContatosCliente[' + i + '].Cargo" id="pessoaJuridicaViewModels.ContatosCliente[' + i + '].Cargo" /> ';
        html += '<span class="field-validation-valid text-danger" data-valmsg-for="pessoaJuridicaViewModels.ContatosCliente[' + i + '].Cargo" data-valmsg-replace="true"></span> ';
        html += '</div> ';
        html += '</div> ';
        html += '<div class="form-group"> ';
        html += '<div class="col-md-2"> ';
        html += '<label class="control-label" for="">Telefone</label><span class="span-obrigatorio">*</span> ';
        html += '</div> ';
        html += '<div class="col-md-4"> ';
        html += '<input type="text" class="form-control" name="pessoaJuridicaViewModels.ContatosCliente[' + i + '].Telefone" id="pessoaJuridicaViewModels.ContatosCliente[' + i + '].Telefone" /> ';
        html += '<span class="field-validation-valid text-danger" data-valmsg-for="pessoaJuridicaViewModels.ContatosCliente[' + i + '].Telefone" data-valmsg-replace="true"></span> ';
        html += '</div> ';
        html += '</div> ';
        html += '<div class="form-group"> ';
        html += '<div class="col-md-2"> ';
        html += '<label class="control-label" for="">E-mail</label><span class="span-obrigatorio">*</span> ';
        html += '</div> ';
        html += '<div class="col-md-6"> ';
        html += '<input type="text" class="form-control" name="pessoaJuridicaViewModels.ContatosCliente[' + i + '].Email" id="pessoaJuridicaViewModels.ContatosCliente[' + i + '].Email" /> ';
        html += '<span class="field-validation-valid text-danger" data-valmsg-for="pessoaJuridicaViewModels.ContatosCliente[' + i + '].Email" data-valmsg-replace="true"></span> ';
        html += '</div> ';
        html += '</div> ';
        html += '</div> ';

        $("#contatosPessoaJuridica").append(html);
    },
    CriaHTMLEnderecoPF: function (i) {
        var html = "";
        if (i !== 0) {
            html += '<div class="enderecoPessoaFisica" style="margin-top:50px;"> ';
            html += '<div class="d-flex justify-content-start align-items-center">';
            html += '<h3 class="mr-3">Endereço</h3>';
            html += '<button type="button" class="btn btn-danger mt-1 mb-2 btnRemoverEnderecoPessoaFisica"><i class="fas fa-trash-alt"></i></button> ';
            html += '</div>';
        } else {
            html += '<div class="enderecoPessoaFisica"> ';    
        }
        html += '<div class="form-group"> ';
        html += '<div class="col-md-2"> ';
        html += '<label class="control-label" for="">CEP</label><span class="span-obrigatorio">*</span> ';
        html += '</div> ';
        html += '<div class="col-md-3"> ';
        html += '<input type="text" class="form-control cepPF" name="pessoaFisicaViewModels.EnderecosCliente[' + i + '].CEP" id="pessoaFisicaViewModels.EnderecosCliente[' + i + '].CEP" /> ';
        html += '<span class="field-validation-valid text-danger" data-valmsg-for="CEP" data-valmsg-replace="true"></span> ';
        html += '</div> ';
        html += '</div> ';
        html += '<div class="form-group"> ';
        html += '<div class="col-md-2"> ';
        html += '<label class="control-label" for="Endereco">Endereço</label><span class="span-obrigatorio">*</span> ';
        html += '</div> ';
        html += '<div class="col-md-8"> ';
        html += '<input type="text" class="form-control" name="pessoaFisicaViewModels.EnderecosCliente[' + i + '].Endereco" id="pessoaFisicaViewModels.EnderecosCliente[' + i + '].Endereco" /> ';
        html += '<span class="field-validation-valid text-danger" data-valmsg-for="Endereco" data-valmsg-replace="true"></span> ';
        html += '</div> ';
        html += '</div> ';
        html += '<div class="form-group"> ';
        html += '<div class="col-md-2"> ';
        html += '<label class="control-label" for="Numero">Número</label><span class="span-obrigatorio">*</span> ';
        html += '</div> ';
        html += '<div class="col-md-3"> ';
        html += '<input type="number" class="form-control" name="pessoaFisicaViewModels.EnderecosCliente[' + i + '].Numero" id="pessoaFisicaViewModels.EnderecosCliente[' + i + '].Numero" /> ';
        html += '<span class="field-validation-valid text-danger" data-valmsg-for="Numero" data-valmsg-replace="true"></span> ';
        html += '</div> ';
        html += '</div> ';
        html += '<div class="form-group"> ';
        html += '<div class="col-md-2"> ';
        html += '<label class="control-label" for="Complemento">Complemento</label> ';
        html += '</div> ';
        html += '<div class="col-md-4"> ';
        html += '<input type="text" class="form-control" name="pessoaFisicaViewModels.EnderecosCliente[' + i + '].Complemento" id="pessoaFisicaViewModels.EnderecosCliente[' + i + '].Complemento" /> ';
        html += '<span class="field-validation-valid text-danger" data-valmsg-for="Complemento" data-valmsg-replace="true"></span> ';
        html += '</div> ';
        html += '</div> ';
        html += '<div class="form-group"> ';
        html += '<div class="col-md-2"> ';
        html += '<label class="control-label" for="Cidade">Cidade</label><span class="span-obrigatorio">*</span> ';
        html += '</div> ';
        html += '<div class="col-md-6"> ';
        html += '<input type="text" class="form-control" name="pessoaFisicaViewModels.EnderecosCliente[' + i + '].Cidade" id="pessoaFisicaViewModels.EnderecosCliente[' + i + '].Cidade" /> ';
        html += '<span class="field-validation-valid text-danger" data-valmsg-for="Cidade" data-valmsg-replace="true"></span> ';
        html += '</div> ';
        html += '</div> ';
        html += '<div class="form-group"> ';
        html += '<div class="col-md-2"> ';
        html += '<label class="control-label" for="Bairro">Bairro</label><span class="span-obrigatorio">*</span> ';
        html += '</div> ';
        html += '<div class="col-md-6"> ';
        html += '<input type="text" class="form-control" name="pessoaFisicaViewModels.EnderecosCliente[' + i + '].Bairro" id="pessoaFisicaViewModels.EnderecosCliente[' + i + '].Bairro" /> ';
        html += '<span class="field-validation-valid text-danger" data-valmsg-for="Bairro" data-valmsg-replace="true"></span> ';
        html += '</div> ';
        html += '</div> ';
        html += '<div class="form-group"> ';
        html += '<div class="col-md-2"> ';
        html += '<label class="control-label" for="Estado">Estado</label><span class="span-obrigatorio">*</span> ';
        html += '</div> ';
        html += '<div class="col-md-3"> ';
        html += '<select name="pessoaFisicaViewModels.EnderecosCliente[' + i + '].Estado" id="pessoaFisicaViewModels.EnderecosCliente[' + i + '].Estado" class="form-control"> ';
        html += '<option value="">-------</option> ';
        html += '<option value="AC">Acre</option> ';
        html += '<option value="AL">Alagoas</option> ';
        html += '<option value="AP">Amapá</option> ';
        html += '<option value="AM">Amazonas</option> ';
        html += '<option value="BA">Bahia</option> ';
        html += '<option value="CE">Ceará</option> ';
        html += '<option value="DF">Distrito Federal</option> ';
        html += '<option value="ES">Espírito Santo</option> ';
        html += '<option value="GO">Goiás</option> ';
        html += '<option value="MA">Maranhão</option> ';
        html += '<option value="MT">Mato Grosso</option> ';
        html += '<option value="MS">Mato Grosso do Sul</option> ';
        html += '<option value="MG">Minas Gerais</option> ';
        html += '<option value="PA">Pará</option> ';
        html += '<option value="PB">Paraíba</option> ';
        html += '<option value="PR">Paraná</option> ';
        html += '<option value="PE">Pernambuco</option> ';
        html += '<option value="PI">Piauí</option> ';
        html += '<option value="RJ">Rio de Janeiro</option> ';
        html += '<option value="RN">Rio Grande do Norte</option> ';
        html += '<option value="RS">Rio Grande do Sul</option> ';
        html += '<option value="RO">Rondônia</option> ';
        html += '<option value="RR">Roraima</option> ';
        html += '<option value="SC">Santa Catarina</option> ';
        html += '<option value="SP">São Paulo</option> ';
        html += '<option value="SE">Sergipe</option> ';
        html += '<option value="TO">Tocantins</option> ';
        html += '</select> ';
        html += '<span class="field-validation-valid text-danger" data-valmsg-for="Estado" data-valmsg-replace="true"></span> ';
        html += '</div> ';
        html += '</div> ';
        html += '</div> ';

        $("#enderecosPessoaFisica").append(html);
    },
    CriaHTMLContatoPF: function (i) {
        var html = "";
        if (i !== 0) {
            html += '<div class="contatoPessoaFisica" style="margin-top:50px;"> ';
            html += '<div class="d-flex justify-content-start align-items-center"> ';
            html += '<h3 class="mr-3">Contato</h3> ';
            html += '<button type="button" class="btn btn-danger mt-1 mb-2 btnRemoverContatoPessoaFisica"> ';
            html += '<i class="fas fa-trash-alt"></i></button> ';
            html += '</div> ';
        } else {
            html += '<div class="contatoPessoaFisica"> ';
        }
        html += '<div class="form-group"> ';
        html += '<label class="control-label col-md-2" for="Nome">Nome</label> ';
        html += '<div class="col-md-8"> ';
        html += '<input type="text" class="form-control nomePF" name="pessoaFisicaViewModels.ContatosCliente[' + i + '].Nome" id="pessoaFisicaViewModels.ContatosCliente[' + i + '].Nome" /> ';
        html += '<span class="field-validation-valid text-danger" data-valmsg-for="Nome" data-valmsg-replace="true"></span> ';
        html += '</div> ';
        html += '</div> ';
        html += '<div class="form-group"> ';
        html += '<label class="control-label col-md-2" for="Cargo">Cargo</label> ';
        html += '<div class="col-md-4"> ';
        html += '<input type="text" class="form-control" name="pessoaFisicaViewModels.ContatosCliente[' + i + '].Cargo" id="pessoaFisicaViewModels.ContatosCliente[' + i + '].Cargo" /> ';
        html += '<span class="field-validation-valid text-danger" data-valmsg-for="Cargo" data-valmsg-replace="true"></span> ';
        html += '</div> ';
        html += '</div> ';
        html += '<div class="form-group"> ';
        html += '<label class="control-label col-md-2" for="Telefone">Telefone</label> ';
        html += '<div class="col-md-4"> ';
        html += '<input type="text" class="form-control" name="pessoaFisicaViewModels.ContatosCliente[' + i + '].Telefone" id="pessoaFisicaViewModels.ContatosCliente[' + i + '].Telefone" /> ';
        html += '<span class="field-validation-valid text-danger" data-valmsg-for="Telefone" data-valmsg-replace="true"></span> ';
        html += '</div> ';
        html += '</div> ';
        html += '<div class="form-group"> ';
        html += '<label class="control-label col-md-2" for="Email">E-mail</label> ';
        html += '<div class="col-md-4"> ';
        html += '<input type="text" class="form-control" name="pessoaFisicaViewModels.ContatosCliente[' + i + '].Email" id="pessoaFisicaViewModels.ContatosCliente[' + i + '].Email" /> ';
        html += '<span class="field-validation-valid text-danger" data-valmsg-for="Email" data-valmsg-replace="true"></span> ';
        html += '</div> ';
        html += '</div> ';
        html += '</div > ';

        $("#contatosPessoaFisica").append(html);
    }
};

$(function () {
    $("#pessoaJuridicaViewModels_CNPJ").mask("99.999.999/9999-99");
    $("#pessoaFisicaViewModels_CPF").mask("999.999.999-99");

    if (sessionStorage.getItem('tab-ativa-cliente') !== null) {
        var id = sessionStorage.getItem('tab-ativa-cliente');
        $('#' + id).trigger('click');
    }

    $(document).on('blur', '.cepPJ', function () {
        var cep = $(this).val();
        if (fGlobal.IsNotEmpty(cep)) {
            id = $(this).attr('id').split('[')[1].substring(0, 1);
            functionsCliente.ConsultarCep(cep, id);
        }
    });

    $(document).on('blur', '.cepPF', function () {
        var cep = $(this).val();
        if (fGlobal.IsNotEmpty(cep)) {
            id = $(this).attr('id').split('[')[1].substring(0, 1);
            functionsCliente.ConsultarCepPF(cep, id);
        }
    });

    if ($('.enderecoPessoaJuridica').length <= 0) {
        functionsCliente.CriarHTMLEnderecoPJ(0);
    }

    if ($('.contatoPessoaJuridica').length <= 0) {
        functionsCliente.CriaHTMLContatoPJ(0);
    }

    if ($('.enderecoPessoaFisica').length <= 0) {
        functionsCliente.CriaHTMLEnderecoPF(0);
    }

    if ($('.contatoPessoaFisica').length <= 0) {
        functionsCliente.CriaHTMLContatoPF(0);
    }

    $('.nav-link').on('click', function () {
        sessionStorage.setItem('tab-ativa-cliente', $(this).attr('id'));
    });

});

$("#btnCriarEnderecoPessoaJuridica").on('click', function () {
    var i = Number($('#enderecosPessoaJuridica').find('.enderecoPessoaJuridica').last().find('.cepPJ').attr('id').split('[')[1].substring(0, 1)) + 1;
    functionsCliente.CriarHTMLEnderecoPJ(i);
});

$("#btnCriarContatoPessoaJuridica").on('click', function () {
    var i = Number($('#contatosPessoaJuridica').find('.contatoPessoaJuridica').last().find('.nomePJ').attr('id').split('[')[1].substring(0, 1)) + 1;
    functionsCliente.CriaHTMLContatoPJ(i);
});

$(document).on('click', '.btnRemoverEnderecoPessoaJuridica', function () {
    var linhaAtual = Number($(this).parent().parent().remove().find('.cepPJ').attr('id').split('[')[1].substring(0, 1));
    var qtdLinhas = $('#enderecosPessoaJuridica').find('.enderecoPessoaJuridica').length;
    for (var i = linhaAtual + 1; i <= qtdLinhas; i++) {
        document.getElementById('pessoaJuridicaViewModels.EnderecosCliente[' + i + '].CEP').name =
            "pessoaJuridicaViewModels.EnderecosCliente[" + (i - 1).toString() + "].CEP";
        document.getElementById('pessoaJuridicaViewModels.EnderecosCliente[' + i + '].CEP').id =
            "pessoaJuridicaViewModels.EnderecosCliente[" + (i - 1).toString() + "].CEP";
        document.getElementById('pessoaJuridicaViewModels.EnderecosCliente[' + i + '].Endereco').name =
            "pessoaJuridicaViewModels.EnderecosCliente[" + (i - 1).toString() + "].Endereco";
        document.getElementById('pessoaJuridicaViewModels.EnderecosCliente[' + i + '].Endereco').id =
            "pessoaJuridicaViewModels.EnderecosCliente[" + (i - 1).toString() + "].Endereco";
        document.getElementById('pessoaJuridicaViewModels.EnderecosCliente[' + i + '].Numero').name =
            "pessoaJuridicaViewModels.EnderecosCliente[" + (i - 1).toString() + "].Numero";
        document.getElementById('pessoaJuridicaViewModels.EnderecosCliente[' + i + '].Numero').id =
            "pessoaJuridicaViewModels.EnderecosCliente[" + (i - 1).toString() + "].Numero";
        document.getElementById('pessoaJuridicaViewModels.EnderecosCliente[' + i + '].Complemento').name =
            "pessoaJuridicaViewModels.EnderecosCliente[" + (i - 1).toString() + "].Complemento";
        document.getElementById('pessoaJuridicaViewModels.EnderecosCliente[' + i + '].Complemento').id =
            "pessoaJuridicaViewModels.EnderecosCliente[" + (i - 1).toString() + "].Complemento";
        document.getElementById('pessoaJuridicaViewModels.EnderecosCliente[' + i + '].Cidade').name =
            "pessoaJuridicaViewModels.EnderecosCliente[" + (i - 1).toString() + "].Cidade";
        document.getElementById('pessoaJuridicaViewModels.EnderecosCliente[' + i + '].Cidade').id =
            "pessoaJuridicaViewModels.EnderecosCliente[" + (i - 1).toString() + "].Cidade";
        document.getElementById('pessoaJuridicaViewModels.EnderecosCliente[' + i + '].Bairro').name =
            "pessoaJuridicaViewModels.EnderecosCliente[" + (i - 1).toString() + "].Bairro";
        document.getElementById('pessoaJuridicaViewModels.EnderecosCliente[' + i + '].Bairro').id =
            "pessoaJuridicaViewModels.EnderecosCliente[" + (i - 1).toString() + "].Bairro";
        document.getElementById('pessoaJuridicaViewModels.EnderecosCliente[' + i + '].Estado').name =
            "pessoaJuridicaViewModels.EnderecosCliente[" + (i - 1).toString() + "].Estado";
        document.getElementById('pessoaJuridicaViewModels.EnderecosCliente[' + i + '].Estado').id =
            "pessoaJuridicaViewModels.EnderecosCliente[" + (i - 1).toString() + "].Estado";
    }
    $(this).parent().parent().remove();
});

$(document).on('click', '.btnRemoverContatoPessoaJuridica', function () {
    var linhaAtual = Number($(this).parent().parent().remove().find('.nomePJ').attr('id').split('[')[1].substring(0, 1));
    var qtdLinhas = $('#contatosPessoaJuridica').find('.contatoPessoaJuridica').length;
    for (var i = linhaAtual + 1; i <= qtdLinhas; i++) {
        document.getElementById('pessoaJuridicaViewModels.ContatosCliente[' + i + '].Nome').name =
            "pessoaJuridicaViewModels.ContatosCliente[" + (i + - 1).toString() + "].Nome";
        document.getElementById('pessoaJuridicaViewModels.ContatosCliente[' + i + '].Nome').id =
            "pessoaJuridicaViewModels.ContatosCliente[" + (i + - 1).toString() + "].Nome";
        document.getElementById('pessoaJuridicaViewModels.ContatosCliente[' + i + '].Cargo').name =
            "pessoaJuridicaViewModels.ContatosCliente[" + (i + - 1).toString() + "].Cargo";
        document.getElementById('pessoaJuridicaViewModels.ContatosCliente[' + i + '].Cargo').id =
            "pessoaJuridicaViewModels.ContatosCliente[" + (i + - 1).toString() + "].Cargo";
        document.getElementById('pessoaJuridicaViewModels.ContatosCliente[' + i + '].Telefone').name =
            "pessoaJuridicaViewModels.ContatosCliente[" + (i + - 1).toString() + "].Telefone";
        document.getElementById('pessoaJuridicaViewModels.ContatosCliente[' + i + '].Telefone').id =
            "pessoaJuridicaViewModels.ContatosCliente[" + (i + - 1).toString() + "].Telefone";
        document.getElementById('pessoaJuridicaViewModels.ContatosCliente[' + i + '].Email').name =
            "pessoaJuridicaViewModels.ContatosCliente[" + (i + - 1).toString() + "].Email";
        document.getElementById('pessoaJuridicaViewModels.ContatosCliente[' + i + '].Email').id =
            "pessoaJuridicaViewModels.ContatosCliente[" + (i + - 1).toString() + "].Email";
    }
    $(this).parent().parent().remove();
});

$("#btnCriarEnderecoPessoaFisica").on('click', function () {
    var i = Number($('#enderecosPessoaFisica').find('.enderecoPessoaFisica').last().find('.cepPF').attr('id').split('[')[1].substring(0, 1)) + 1;
    functionsCliente.CriaHTMLEnderecoPF(i);
});

$("#btnCriarEnderecoPessoaFisicaAlterar").on('click', function () {
    var i = Number($('#enderecosPessoaFisica').find('.enderecoPessoaFisica').last().find('.cepPF').attr('id').split('[')[1].substring(0, 1)) + 1;
    functionsCliente.CriarHTMLAlterarEnderecoPF(i);
});

$("#btnCriarContatoPessoaFisica").on('click', function () {
    var i = Number($('#contatosPessoaFisica').find('.contatoPessoaFisica').last().find('.nomePF').attr('id').split('[')[1].substring(0, 1)) + 1;
    functionsCliente.CriaHTMLContatoPF(i);
});

$("#btnCriarContatoPessoaFisicaAlterar").on('click', function () {
    var i = Number($('#contatosPessoaFisica').find('.contatoPessoaFisica').last().find('.nomePF').attr('id').split('[')[1].substring(0, 1)) + 1;
    functionsCliente.CriaHTMLAlterarContatoPF(i);
});

$(document).on('click', '.btnRemoverEnderecoPessoaFisica', function () {
    var linhaAtual = Number($(this).parent().parent().remove().find('.cepPF').attr('id').split('[')[1].substring(0, 1));
    var qtdLinhas = $('#enderecosPessoaFisica').find('.enderecoPessoaFisica').length;
    for (var i = linhaAtual + 1; i <= qtdLinhas; i++) {
        document.getElementById('pessoaFisicaViewModels.EnderecosCliente[' + i + '].CEP').name =
            "pessoaFisicaViewModels.EnderecosCliente[" + (i - 1).toString() + "].CEP";
        document.getElementById('pessoaFisicaViewModels.EnderecosCliente[' + i + '].CEP').id =
            "pessoaFisicaViewModels.EnderecosCliente[" + (i - 1).toString() + "].CEP";
        document.getElementById('pessoaFisicaViewModels.EnderecosCliente[' + i + '].Endereco').name =
            "pessoaFisicaViewModels.EnderecosCliente[" + (i - 1).toString() + "].Endereco";
        document.getElementById('pessoaFisicaViewModels.EnderecosCliente[' + i + '].Endereco').id =
            "pessoaFisicaViewModels.EnderecosCliente[" + (i - 1).toString() + "].Endereco";
        document.getElementById('pessoaFisicaViewModels.EnderecosCliente[' + i + '].Numero').name =
            "pessoaFisicaViewModels.EnderecosCliente[" + (i - 1).toString() + "].Numero";
        document.getElementById('pessoaFisicaViewModels.EnderecosCliente[' + i + '].Numero').id =
            "pessoaFisicaViewModels.EnderecosCliente[" + (i - 1).toString() + "].Numero";
        document.getElementById('pessoaFisicaViewModels.EnderecosCliente[' + i + '].Complemento').name =
            "pessoaFisicaViewModels.EnderecosCliente[" + (i - 1).toString() + "].Complemento";
        document.getElementById('pessoaFisicaViewModels.EnderecosCliente[' + i + '].Complemento').id =
            "pessoaFisicaViewModels.EnderecosCliente[" + (i - 1).toString() + "].Complemento";
        document.getElementById('pessoaFisicaViewModels.EnderecosCliente[' + i + '].Cidade').name =
            "pessoaFisicaViewModels.EnderecosCliente[" + (i - 1).toString() + "].Cidade";
        document.getElementById('pessoaFisicaViewModels.EnderecosCliente[' + i + '].Cidade').id =
            "pessoaFisicaViewModels.EnderecosCliente[" + (i - 1).toString() + "].Cidade";
        document.getElementById('pessoaFisicaViewModels.EnderecosCliente[' + i + '].Bairro').name =
            "pessoaFisicaViewModels.EnderecosCliente[" + (i - 1).toString() + "].Bairro";
        document.getElementById('pessoaFisicaViewModels.EnderecosCliente[' + i + '].Bairro').id =
            "pessoaFisicaViewModels.EnderecosCliente[" + (i - 1).toString() + "].Bairro";
        document.getElementById('pessoaFisicaViewModels.EnderecosCliente[' + i + '].Estado').name =
            "pessoaFisicaViewModels.EnderecosCliente[" + (i - 1).toString() + "].Estado";
        document.getElementById('pessoaFisicaViewModels.EnderecosCliente[' + i + '].Estado').id =
            "pessoaFisicaViewModels.EnderecosCliente[" + (i - 1).toString() + "].Estado";
    }
    $(this).parent().parent().remove();
});

$(document).on('click', '.btnRemoverContatoPessoaFisica', function () {
    var linhaAtual = Number($(this).parent().parent().remove().find('.nomePF').attr('id').split('[')[1].substring(0, 1));
    var qtdLinhas = $('#contatosPessoaFisica').find('.contatoPessoaFisica').length;
    for (var i = linhaAtual + 1; i <= qtdLinhas; i++) {
        document.getElementById('pessoaFisicaViewModels.ContatosCliente[' + i + '].Nome').name =
            "pessoaFisicaViewModels.ContatosCliente[" + (i - 1).toString() + "].Nome";
        document.getElementById('pessoaFisicaViewModels.ContatosCliente[' + i + '].Nome').id =
            "pessoaFisicaViewModels.ContatosCliente[" + (i - 1).toString() + "].Nome";
        document.getElementById('pessoaFisicaViewModels.ContatosCliente[' + i + '].Cargo').name =
            "pessoaFisicaViewModels.ContatosCliente[" + (i - 1).toString() + "].Cargo";
        document.getElementById('pessoaFisicaViewModels.ContatosCliente[' + i + '].Cargo').id =
            "pessoaFisicaViewModels.ContatosCliente[" + (i - 1).toString() + "].Cargo";
        document.getElementById('pessoaFisicaViewModels.ContatosCliente[' + i + '].Telefone').name =
            "pessoaFisicaViewModels.ContatosCliente[" + (i - 1).toString() + "].Telefone";
        document.getElementById('pessoaFisicaViewModels.ContatosCliente[' + i + '].Telefone').id =
            "pessoaFisicaViewModels.ContatosCliente[" + (i - 1).toString() + "].Telefone";
        document.getElementById('pessoaFisicaViewModels.ContatosCliente[' + i + '].Email').name =
            "pessoaFisicaViewModels.ContatosCliente[" + (i - 1).toString() + "].Email";
        document.getElementById('pessoaFisicaViewModels.ContatosCliente[' + i + '].Email').id =
            "pessoaFisicaViewModels.ContatosCliente[" + (i - 1).toString() + "].Email";
    }
    $(this).parent().parent().remove();
});