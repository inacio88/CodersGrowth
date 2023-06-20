sap.ui.define([
    
], function() {
	"use strict";

	return  {
        
    _validarNome: function (nome) {
        const quantidadeNulaCaracteres = 0;
        let erros = [];
        let formatoNome = /^[a-zA-ZÀ-ÖØ-öø-ÿ ]*$/;
        nome = nome.trim();
        if (nome.length === quantidadeNulaCaracteres) {
            erros.push("Nome deve ter no mínimo 1 caractere");
        }

        if (!nome.match(formatoNome)){
            erros.push("Não pode ter caracteres especiais ou números");
        }

        return erros;
    },
    
    _validarEmail: function (string_para_validar) {
        let erros = [];
        let formato = /^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$/;
        string_para_validar = string_para_validar.trim();
        
        if (!string_para_validar.match(formato)){
            erros.push("Esse formato de email não é válido!");
        }

        return erros;
    },

    _validarCpf: function (string_para_validar) {
        const maximoTamanCaracteresRepetidos = 11;
        let strCPF = string_para_validar.replaceAll(".", "").replace("-", "").replace(" ", "");
        let erros = [];
        let expressaoRegular = new RegExp(`${strCPF[0]}`, 'g');
        let Soma;
        let Resto;
        let tamanhoCaracteresRepetidos = (strCPF.match(expressaoRegular)||[]).length;
        Soma = 0;
        
        
        if (tamanhoCaracteresRepetidos === maximoTamanCaracteresRepetidos)
            erros.push("Esse formato de cpf não é válido!");
        
        for (let i=1; i<=9; i++) Soma = Soma + parseInt(strCPF.substring(i-1, i)) * (11 - i);
        Resto = (Soma * 10) % 11;

        if ((Resto == 10) || (Resto == 11))  Resto = 0;
        if (Resto != parseInt(strCPF.substring(9, 10)) ) erros.push("Esse formato de cpf não é válido!");

        Soma = 0;
        for (let i = 1; i <= 10; i++) Soma = Soma + parseInt(strCPF.substring(i-1, i)) * (12 - i);
        Resto = (Soma * 10) % 11;

        if ((Resto == 10) || (Resto == 11))  Resto = 0;
        if (Resto != parseInt(strCPF.substring(10, 11) ) ) erros.push("Esse formato de cpf não é válido!");
        return erros;

    },

    __validarDataNascimento: function (data_validar) {
        let erros = [];
        data_validar = new Date(data_validar);
        let data_hoje = new Date(Date.now());

        if (data_hoje.getFullYear() - data_validar.getFullYear() > 120) {
            erros.push("A idade máxima é 120 anos!");
        }
        if (data_hoje.getFullYear() - data_validar.getFullYear() < 18) {
            erros.push("A idade mínima é 18 anos!"); 
        }

        return erros;
    },

    _addMensagensErro: function (oItem, erros) {
        if (erros.length > 0) {
            let estadosErro = '';
            oItem.setValueState("Error");
            
            erros.forEach(erro =>{
                estadosErro = estadosErro +  "\n" + erro;
            })

            oItem.setValueStateText(estadosErro);
        }
        else {
            oItem.setValueState("Success");
        }
    },

    };
});