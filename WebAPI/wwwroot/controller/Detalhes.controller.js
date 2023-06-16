sap.ui.define([
	"sap/ui/core/mvc/Controller",
    "sap/ui/model/json/JSONModel",
	"sap/m/MessageToast",
	"sap/ui/core/routing/History",


], function (Controller, JSONModel, MessageToast, History) {
	"use strict";
	return Controller.extend("sap.ui.gerenciamento.cliente.controller.Detalhes", {

		onInit: function () {
			let oRouter = this.getOwnerComponent().getRouter();
			oRouter.getRoute("detalhes").attachPatternMatched(this._onObjectMatched, this);
            
		},
		
		obterPorId: function (id) {
            fetch(`/api/Cliente/${id}`).then((response) => {
                return response.json();
            }).then((data) =>{
                let oModel = new JSONModel(data);
                this.getView().setModel(oModel, "clienteSelecionado");
                MessageToast.show("Dados carregados com sucesso!");

            }).catch(() =>{
                MessageToast.show("Falha ao obter os dados.");
            });

        },

		_onObjectMatched: function (oEvent) {
			let id = oEvent.getParameter("arguments").clienteCaminho;
			this.getView().bindElement({
				path: "/" + window.decodeURIComponent(oEvent.getParameter("arguments").clienteCaminho),
				model: "clientes"
			});
			this.obterPorId(id);
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
});