sap.ui.define([
    'sap/ui/core/mvc/Controller',
    'sap/ui/model/json/JSONModel',
	"sap/ui/core/routing/History",
    "sap/m/MessageToast",
    "sap/m/MessageBox",
    "../servicos/Validacao"

], function(Controller, JSONModel, History, MessageToast, MessageBox, Validacao) {
"use strict";

return Controller.extend("sap.ui.gerenciamento.cliente.controller.FormCriar", {
        onInit: function (oEvent) {
            let oRouter = this.getOwnerComponent().getRouter();
            oRouter.getRoute("formCriarEditar").attachPatternMatched(this._onObjectMatched, this);
                    
            this._iniciarCamposVazios();
        },

        _onObjectMatched: function (oEvent) {
            let id = oEvent.getParameter("arguments").clienteCaminho;

            if(id){
                this.obterPorId(id);
            }
        },

        _iniciarCamposVazios: function () {
            let dataAtualMilisegundos = Date.now();
            let dataAtual = new Date(dataAtualMilisegundos);
            
            let oData = {
                "nome": "",
                "email": "",
                "cpf": "",
                "dataNascimento": dataAtual,
            };    
            
            let oModel = new JSONModel(oData);
            this.getView().setModel(oModel, "dadosFormularioCriar");
        },

        obterPorId: function (id) {
            fetch(`/api/Cliente/${id}`)
            .then(response => response.json())
            .then((cliente) => {
                cliente.dataNascimento = new Date(cliente.dataNascimento);

                let oModel = new JSONModel(cliente);
                this.getView().setModel(oModel, "dadosFormularioCriar");
                MessageToast.show("Dados carregados com sucesso!");

            }).catch(() =>{
                MessageToast.show("Falha ao obter os dados.");
            });

        },

        _criar: async function () {
            let cliente = this.getView().getModel("dadosFormularioCriar").getData();

            return fetch('/api/Cliente', {
                    method: "POST",
                    body: JSON.stringify(cliente),
                    headers: {"Content-type": "application/json; charset=UTF-8"}
            })
            .catch(err => console.log(err));
        },
        
        _atualizar: async function (idCliente) {
            let cliente = this.getView().getModel("dadosFormularioCriar").getData();

            return fetch(`/api/Cliente/${idCliente}`, {
                    method: "PUT",
                    body: JSON.stringify(cliente),
                    headers: {"Content-type": "application/json; charset=UTF-8"}
            })
        },
        
        aoClicarEmSalvar: async function () {
            let oHistory = History.getInstance();
            let sPreviousHash = oHistory.getPreviousHash();
            let dadosFormularioCriar = this.getView().getModel("dadosFormularioCriar");
            let idCliente = dadosFormularioCriar.getProperty("/id");
            let paginaAnteriorRef = `detalhes/${idCliente}`;

            // if(sPreviousHash == paginaAnteriorRef){
            //     //nevega pra tela inicial ou tenta carregar esse cara com o id digitado no url
            //     return;
            // }

            //verifica esse cara aqui - sPreviousHash
            debugger
            console.log(idCliente);
            if (1 == 1) {
                if (idCliente) {
                    this._atualizar(idCliente)
                        .then(resp => resp.json())
                        .then(id => {
                            MessageToast.show("Cadastro atualizado com sucesso!");
                            this._navegarParaDetalhes(id);
                    }).catch(() => {
                        MessageToast.show("Deu ruim");
                    });
                }
                else{
                    this._criar()
                        .then(resp => resp.json())
                        .then(id => {
                            MessageToast.show("Cadastro realizado com sucesso!");
                            this._navegarParaDetalhes(id);
                        }).catch(() => {
                            MessageToast.show("Erro ao cadastrar");
                    });
                }
                
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
});