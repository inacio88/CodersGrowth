sap.ui.define([
    'sap/ui/core/mvc/Controller',
    'sap/ui/model/json/JSONModel',
	"sap/ui/core/routing/History",
    "sap/m/MessageToast",
    "sap/m/MessageBox",
    "../servicos/Validacao"

], function(Controller, JSONModel, History, MessageToast, MessageBox, Validacao) {
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
            let erros = Validacao._validarNome(oItem.getValue());
            Validacao._addMensagensErro(oItem, erros);
        }

        else if (oItem.getName() === "inputEmail") {
            let erros = Validacao._validarEmail(oItem.getValue());
            Validacao._addMensagensErro(oItem, erros);
        }

        else if (oItem.getName() === "inputCpf") {
            const quantidadeCaracteresComMascara = 14;
            if (oItem.getValue().length === quantidadeCaracteresComMascara ) {
                let erros = Validacao._validarCpf(oItem.getValue());
                Validacao._addMensagensErro(oItem, erros);   
            }
        }

        else if (oItem.getName() === "inputDataNascimento") {
            let erros = Validacao.__validarDataNascimento(oItem.getValue())
            Validacao._addMensagensErro(oItem, erros);
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
    
    _navegarParaDetalhes: function(id){
        const rotaDetalhes = "detalhes";
        let oRouter = this.getOwnerComponent().getRouter();
        oRouter.navTo(rotaDetalhes, {clienteCaminho: window.encodeURIComponent(id)});
        
    },

    _limparCampos: function () {
        let campoNome = this.byId("inputNome");
        let campoEmail = this.byId("inputEmail");
        let campoCpf = this.byId("inputCpf");
        let campoDataNascimento = this.byId("inputDataNascimento");
        let campos = [campoNome, campoEmail, campoCpf, campoDataNascimento];
        
        campos.forEach(campo => {
            campo.setValue('');
            campo.setValueState("None");
        });

    },

    aoclicarEmVoltar: function () {
        let oHistory = History.getInstance();
        let sPreviousHash = oHistory.getPreviousHash();

        this._limparCampos();
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