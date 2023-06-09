sap.ui.define([
	"sap/ui/core/mvc/Controller",
	"sap/m/MessageToast",
    "sap/ui/model/json/JSONModel",
	"sap/ui/model/Filter",
	"sap/ui/model/FilterOperator",
	"sap/ui/core/BusyIndicator"

], function (Controller, MessageToast, JSONModel, Filter, FilterOperator, BusyIndicator) {
	"use strict";

	return Controller.extend("sap.ui.gerenciamento.cliente.controller.TabelaClientes", {
        onInit: function () {
			var oRouter = this.getOwnerComponent().getRouter();
            oRouter.getRoute("overview").attachPatternMatched(this.obterTodos, this);
        },

        obterTodos: function () {
			BusyIndicator.show();
            fetch('/api/Cliente').then((response) => {
                return response.json();
            }).then((data) =>{
                let oModel = new JSONModel(data);
                this.getView().setModel(oModel, "clientes");
                MessageToast.show("Dados carregados com sucesso!");

            }).catch(() =>{
                MessageToast.show("Falha ao obter os dados.");
            }).finally(()=>{
				BusyIndicator.hide();
			});

        },

		aoFiltrarClientes : function (oEvent) {

			let aFilterNome = [];
            let aFilterEmail = [];
			let sQuery = oEvent.getParameter("query");
			if (sQuery) {
				aFilterNome.push(new Filter("nome", FilterOperator.Contains, sQuery));
				aFilterEmail.push(new Filter("email", FilterOperator.Contains, sQuery));
			}
            
			let oList = this.byId("table");
			let oBinding = oList.getBinding("items");
			oBinding.filter(aFilterNome);
			oBinding.filter(aFilterEmail);
		},

		aoClicar: function (oEvent) {
			BusyIndicator.show();
			let oItem = oEvent.getSource();
			let lista = oItem.getBindingContext("clientes");
			let oRouter = this.getOwnerComponent().getRouter();
			let idObjetoSelecionado = lista.getProperty("id");
			
			oRouter.navTo("detalhes", {
				clienteCaminho: window.encodeURIComponent(idObjetoSelecionado)
			});
			BusyIndicator.hide();
		},

		aoClicarEmNovo: function (oEvent) {
			BusyIndicator.show();
			let oRouter = this.getOwnerComponent().getRouter();
			oRouter.navTo("formCriar");
			BusyIndicator.hide();
		},

	});

});