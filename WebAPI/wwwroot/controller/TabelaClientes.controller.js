sap.ui.define([
	"sap/ui/core/mvc/Controller",
	"sap/m/MessageToast",
    "sap/ui/model/json/JSONModel",
	"sap/ui/model/Filter",
	"sap/ui/model/FilterOperator"

], function (Controller, MessageToast, JSONModel, Filter, FilterOperator) {
	"use strict";

	return Controller.extend("sap.ui.gerenciamento.cliente.controller.TabelaClientes", {
        onInit: function () {
            this.obterTodos();
        },

        obterTodos: function () {

            fetch('/api/Cliente').then((response) => {
                return response.json();
            }).then((data) =>{
                var oModel = new JSONModel(data);
                this.getView().setModel(oModel, "clientes");
                MessageToast.show("Dados carregados com sucesso!");

            }).catch(() =>{
                MessageToast.show("Falha ao obter os dados.");
            });

        },

		onFiltrarClientes : function (oEvent) {

			var aFilterNome = [];
            var aFilterEmail = [];
			var sQuery = oEvent.getParameter("query");
			if (sQuery) {
				aFilterNome.push(new Filter("nome", FilterOperator.Contains, sQuery));
				aFilterEmail.push(new Filter("email", FilterOperator.Contains, sQuery));
			}
            
			var oList = this.byId("table");
			var oBinding = oList.getBinding("items");
			oBinding.filter(aFilterNome);
			oBinding.filter(aFilterEmail);
		}
	});

});