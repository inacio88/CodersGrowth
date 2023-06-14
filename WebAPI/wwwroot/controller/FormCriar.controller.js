sap.ui.define([
    'sap/ui/core/mvc/Controller',
    'sap/ui/model/json/JSONModel',
	"sap/ui/core/routing/History",
    "sap/m/MessageToast",


], function(Controller, JSONModel, History, MessageToast) {
"use strict";

var PageController = Controller.extend("sap.ui.gerenciamento.cliente.controller.FormCriar", {

    onInit: function (oEvent) {
        
        var oData = {
            "nome": "",
            "email": "",
            "cpf": "",
            "dataNascimento": "",
        };

        var oModel = new JSONModel(oData);
        this.getView().setModel(oModel, "dadosFormularioCriar");

    },

    _enviarRequisicaoCriar: async function () {
        var dadosFormularioCriar = this.getView().getModel("dadosFormularioCriar");
        var data = dadosFormularioCriar.oData;

        return fetch('/api/Cliente', {
                method: "POST",
                body: JSON.stringify(data),
                headers: {"Content-type": "application/json; charset=UTF-8"}
        })
        .catch(err => console.log(err));
    },
    
    aoClicarEmSalvar: async function () {
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
    },
    
    _navegarParaDetalhes: function(id){
        const rotaDetalhes = "detalhes";
        var oRouter = this.getOwnerComponent().getRouter();
        oRouter.navTo(rotaDetalhes, {clienteCaminho: window.encodeURIComponent(id)});
        
    },

    aoclicarEmVoltar: function () {
        var oHistory = History.getInstance();
        var sPreviousHash = oHistory.getPreviousHash();

        if (sPreviousHash !== undefined) {
            window.history.go(-1);
        } else {
            var oRouter = this.getOwnerComponent().getRouter();
            oRouter.navTo("overview", {}, true);
        }
    }

});

return PageController;

});