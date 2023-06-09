﻿using FluentValidation;
using System;

namespace Dominio
{
    public class ValidacaoPessoa : AbstractValidator<Pessoa>
    {
        IRepositorioPessoa _repositorioPessoa;
        public ValidacaoPessoa(IRepositorioPessoa pessoa)
        {
            _repositorioPessoa = pessoa;
            RuleFor(pessoa => pessoa.Nome)
                .NotEmpty()
                .Length(1, 50)
                .Matches(@"^[a-zA-ZÀ-ÖØ-öø-ÿ ]+$")
                .WithMessage("O campo {PropertyName} precisa ser fornecido");

            RuleFor(pessoa => pessoa.Email)
                .NotEmpty()
                .Length(1, 150)
                .EmailAddress()
                .Matches(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$")
                .WithMessage("Erro no formato do email");

            RuleFor(pessoa => pessoa.DataNascimento)
                .NotEmpty()
                .Must(dataNascimento => ValidacaoDataNascimento(dataNascimento))
                .WithMessage("Erro na data de nascimento: Idade precisa ser menor que 120 anos e maior que um dia");
     
            RuleFor(pessoa => pessoa)
                .NotEmpty()
                .Must(pessoa => ValidacaoCpf(pessoa.Cpf))
                .WithMessage("Erro no cpf: - Cpf inválido")
                .Must(pessoa => JaExisteCpf(pessoa))
                .WithMessage("Erro no cpf: - Cpf já existente");
        }
        
        public bool JaExisteCpf(Pessoa pessoa)
        {
            
            if (_repositorioPessoa.ObterPessoaPorCpf(pessoa.Cpf, pessoa.Id))
                return true;

            return false;
        }
        public bool ValidacaoCpf(string cpfMascara)
        {
            string cpf = cpfMascara.Replace(".", "").Replace("-", "").Replace(" ", "");

            int[] multiplicador1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicador2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };

            if (cpf.Length != 11)
            {
                return false;
            }

            for (int j = 0; j < 10; j++)
                if (j.ToString().PadLeft(11, char.Parse(j.ToString())) == cpf)
                    return false;

            string tempCpf = cpf.Substring(0, 9);
            int soma = 0;

            for (int i = 0; i < 9; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador1[i];

            int resto = soma % 11;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;

            string digito = resto.ToString();
            tempCpf = tempCpf + digito;
            soma = 0;
            for (int i = 0; i < 10; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador2[i];

            resto = soma % 11;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;

            digito = digito + resto.ToString();
            
            return cpf.EndsWith(digito);

        }

        public bool ValidacaoDataNascimento(DateTime dataNascimento)
        {
            const int IdadeMaximaEmAnos = 120;
            const int IdadeMinimaEmDias = 1;
            var diferencaAnos = DateTime.Now.Year - dataNascimento.Year;
            var diferencaDias = DateTime.Now - dataNascimento;
            if (diferencaAnos > IdadeMaximaEmAnos || diferencaDias.Days < IdadeMinimaEmDias)
            {
                return false;
            }
            else
            {
                return true;
            }

        }

    }
}
