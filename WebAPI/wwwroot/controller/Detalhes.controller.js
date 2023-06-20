sap.ui.define([
	"sap/ui/core/mvc/Controller",
    "sap/ui/model/json/JSONModel",
	"sap/m/MessageToast",
	"sap/ui/core/routing/History",
    "sap/m/MessageBox",
], function (Controller, JSONModel, MessageToast, History, MessageBox) {
	"use strict";
	const ROTA_LISTA = "overview";
	return Controller.extend("sap.ui.gerenciamento.cliente.controller.Detalhes", {

		onInit: function () {
			let oRouter = this.getOwnerComponent().getRouter();
			oRouter.getRoute("detalhes").attachPatternMatched(this._onObjectMatched, this);
		},
		
		_carregarCliente: function (id) {
			fetch(`/api/Cliente/${id}`)
				.then((response) => {
					if (response.ok) {
						return response.json();
					}
					MessageToast.show("Erro no servidor");
					this._navegar(ROTA_LISTA);
				})
				.then((data) => {
					if(data?.id){
						let oModel = new JSONModel(data);
						this.getView().setModel(oModel, "clienteSelecionado");
						MessageToast.show("Dados carregados com sucesso!");
					}
				})
				.catch((error) => {
					MessageToast.show(error.toString());
					this._navegar(ROTA_LISTA);
				});
        },

		_onObjectMatched: function (oEvent) {
			let id = oEvent.getParameter("arguments").clienteCaminho;
			this.getView().bindElement({
				path: "/" + window.decodeURIComponent(oEvent.getParameter("arguments").clienteCaminho),
				model: "clientes"
			});

			this._carregarCliente(id);
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
		},

		aoClicarEmEditar: function () {
			let dadosFormularioCriar = this.getView().getModel("clienteSelecionado");
			var idCliente = dadosFormularioCriar.getProperty("/id");
			let oRouter = this.getOwnerComponent().getRouter();
			
			oRouter.navTo("formCriarEditar", {
				clienteCaminho: window.encodeURIComponent(idCliente)
			});
		},

		aoClicarEmExcluir: function () {
			let dadosClienteSelecionado = this.getView().getModel("clienteSelecionado");
            let idCliente = dadosClienteSelecionado.getProperty("/id");

			if(idCliente){
				MessageBox.alert("Deseja mesmo exlcuir?", {
					emphasizedAction: MessageBox.Action.YES,
					initialFocus: MessageBox.Action.NO,
					icon: MessageBox.Icon.WARNING,
					actions: [MessageBox.Action.YES, MessageBox.Action.NO], onClose: (acao) => {
						if (acao == MessageBox.Action.YES) {
							debugger
							const id = this._remover(idCliente);
							if(id){
								this._navegar(ROTA_LISTA)
							}
						}
					}
				})
			}else{
				MessageToast.show("Erro ao encontrar o id do usuário!");
				this._navegar(ROTA_LISTA);
			}
        },
		
		_navegar: function(rota){
			let oRouter = this.getOwnerComponent().getRouter();
			oRouter.navTo(rota);
		},

		_remover: async function (id) {
			fetch(`/api/Cliente/${id}`, {
				method: "DELETE",
				headers: {"Content-type": "application/json; charset=UTF-8"}
			})
			.then(() =>{
                MessageToast.show("Excluido com sucesso!");
            }).catch(() =>{
                MessageToast.show("Falha ao deletar.");
            });
		}
	});
});