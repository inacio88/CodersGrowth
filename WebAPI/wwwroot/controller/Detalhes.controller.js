sap.ui.define([
	"sap/ui/core/mvc/Controller",
    "sap/ui/model/json/JSONModel",
	"sap/m/MessageToast",
	"sap/ui/core/routing/History",


], function (Controller, JSONModel,MessageToast, History) {
	"use strict";
	return Controller.extend("sap.ui.gerenciamento.cliente.controller.Detalhes", {
		onInit: function () {
			var oRouter = this.getOwnerComponent().getRouter();
			oRouter.getRoute("detalhes").attachPatternMatched(this._onObjectMatched, this);
            
		},
		obterPorId: function (id) {
            fetch(`/api/Cliente/${id}`).then((response) => {
                return response.json();
            }).then((data) =>{
                var oModel = new JSONModel(data);
                this.getView().setModel(oModel, "clienteSelecionado");
                MessageToast.show("Dados carregados com sucesso!");

            }).catch(() =>{
                MessageToast.show("Falha ao obter os dados.");
            });

        },
		_onObjectMatched: function (oEvent) {
			var id = oEvent.getParameter("arguments").clienteCaminho;
			this.getView().bindElement({
				path: "/" + window.decodeURIComponent(oEvent.getParameter("arguments").clienteCaminho),
				model: "clientes"
			});
			this.obterPorId(id);
		},

		onclicarEmVoltar: function () {
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
});