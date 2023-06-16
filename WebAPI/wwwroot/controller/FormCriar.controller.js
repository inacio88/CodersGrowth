sap.ui.define([
    'sap/ui/core/mvc/Controller',
    'sap/ui/model/json/JSONModel',
	"sap/ui/core/routing/History",
    "sap/m/MessageToast",
    "sap/m/MessageBox",



], function(Controller, JSONModel, History, MessageToast, MessageBox) {
"use strict";

var PageController = Controller.extend("sap.ui.gerenciamento.cliente.controller.FormCriar", {

    onInit: function (oEvent) {
        let data_de_hoje_milisegundos = Date.now();
        let data_de_hoje = new Date(data_de_hoje_milisegundos);
        
        let oData = {
            "nome": "",
            "email": "",
            "cpf": "",
            "dataNascimento": data_de_hoje,
        };

        let oModel = new JSONModel(oData);
        this.getView().setModel(oModel, "dadosFormularioCriar");


    },

    _enviarRequisicaoCriar: async function () {
        let dadosFormularioCriar = this.getView().getModel("dadosFormularioCriar");
        let data = dadosFormularioCriar.oData;

        return fetch('/api/Cliente', {
                method: "POST",
                body: JSON.stringify(data),
                headers: {"Content-type": "application/json; charset=UTF-8"}
        })
        .catch(err => console.log(err));
    },
    
    aoClicarEmSalvar: async function () {
                
        if (this._checarCamposValidados()) {
            let resposta = this._enviarRequisicaoCriar()
                .then(resp => resp.json())
                .then(id => {
                    if(id == undefined){
                        MessageToast.show("Erro ao cadastrar");
                        return;
                    }

                    MessageToast.show("Cadastro realizado com sucesso!");
                    this._navegarParaDetalhes(id);
            });
        }
        else{
            MessageBox.error("Verifique novamente se todos os campos estão corretos!")
        }
    },
    
    aoMudarCampo: function (oEvent) {
		let oItem = oEvent.getSource();

        if (oItem.getName() === "inputNome") {
            let erros = this._validarNome(oItem.getValue());
            this._addMensagensErro(oItem, erros);
        }

        else if (oItem.getName() === "inputEmail") {
            let erros = this._validarEmail(oItem.getValue());
            this._addMensagensErro(oItem, erros);
        }

        else if (oItem.getName() === "inputCpf") {
            const quantidadeCaracteresComMascara = 14;
            if (oItem.getValue().length === quantidadeCaracteresComMascara ) {
                let erros = this._validarCpf(oItem.getValue());
                this._addMensagensErro(oItem, erros);   
            }
        }

        else if (oItem.getName() === "inputDataNascimento") {
            let erros = this.__validarDataNascimento(oItem.getValue())
            this._addMensagensErro(oItem, erros);
        }


    },
    _checarCamposValidados: function () {
        const quantidadeDecamposCorretos = 4;
        let elementosComSucesso = document.getElementsByClassName("sapMInputBaseContentWrapperSuccess");

        if (elementosComSucesso.length == quantidadeDecamposCorretos) {
            return true;
        }
        else{
            return false;
        }
        
    },

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
    
    _navegarParaDetalhes: function(id){
        const rotaDetalhes = "detalhes";
        let oRouter = this.getOwnerComponent().getRouter();
        oRouter.navTo(rotaDetalhes, {clienteCaminho: window.encodeURIComponent(id)});
        
    },

    aoclicarEmVoltar: function () {
        let oHistory = History.getInstance();
        let sPreviousHash = oHistory.getPreviousHash();

        if (sPreviousHash !== undefined) {
            window.history.go(-1);
        } else {
            let oRouter = this.getOwnerComponent().getRouter();
            oRouter.navTo("overview", {}, true);
        }
    }

});

return PageController;

});