using DomainValidation.Validation;
using UNIFAFIBE.TCC._4Sales.Dominio.Entidades;
using UNIFAFIBE.TCC._4Sales.Dominio.Especificacoes.PessoasJuridicas;
using UNIFAFIBE.TCC._4Sales.Dominio.Interfaces.Repositorios;

namespace UNIFAFIBE.TCC._4Sales.Dominio.Validacoes.PessoasJuridicas
{
    public class PessoaJuridicaEstaAptaValidation : Validator<PessoaJuridica>
    {
        public PessoaJuridicaEstaAptaValidation(IPessoaJuridicaRepositorio pessoaJuridicaRepositorio)
        {
            var cnpj = new PessoaJuridicaDevePossuirCNPJUnicoSpecification(pessoaJuridicaRepositorio);
            var inscricaoEstadual = new PessoaJuridicaDevePossuirInscricaoEstadualUnicaSpecification(pessoaJuridicaRepositorio);
            var razaoSocial = new PessoaJuridicaDevePossuirRazaoSocialUnicaSpecification(pessoaJuridicaRepositorio);

            this.Add("CNPJDuplicada", new Rule<PessoaJuridica>(cnpj, "Esse CPNJ já esta em uso!"));
            this.Add("InscricaoEstadualDuplicada", new Rule<PessoaJuridica>(cnpj, "Essa Inscrição estadual pertence a outra empresa!"));
            this.Add("RazaoSocialDuplicada", new Rule<PessoaJuridica>(cnpj, "Essa razão social pertence a outra empresa!"));
        }
    }
}
