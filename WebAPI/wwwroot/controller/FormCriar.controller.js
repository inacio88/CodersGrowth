sap.ui.define([
    'sap/ui/core/mvc/Controller',
    'sap/ui/model/json/JSONModel',
	"sap/ui/core/routing/History",

], function(Controller, JSONModel, History) {
"use strict";

var PageController = Controller.extend("sap.ui.gerenciamento.cliente.controller.FormCriar", {

    onInit: function (oEvent) {
        
        var oData = {
            "nome": "naaaa",
            "email": "mail",
            "cpf": "000.000.000-32",
            "dataNascimento": "",
        };

        var oModel = new JSONModel(oData);
        this.getView().setModel(oModel, "dadosFormularioCriar");

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