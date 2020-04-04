var ViewModel = function () {
    var self = this;
    self.services = ko.observableArray();
    self.error = ko.observable();
    self.detail = ko.observable();
    self.clientes = ko.observableArray();

    var servicesuri = '/api/servicios/';
    var clientesuri = '/api/clientes/';

    function ajaxHelper(uri, method, data) {
        self.error('');
        return $.ajax({
            type: method,
            url: uri,
            datatype: 'json',
            contentType: 'application/json',
            data: data ? JSON.stringify(data) : null
        }).fail(function (jqXHR, textStatus, errorThrown) {
            self.error(errorThrown);
        });
    }
    function getAllClients() {
        ajaxHelper(clientesuri, 'GET').done(function (data) {
            self.clientes(data);
        });
    }
    function getServices() {
        ajaxHelper(servicesuri, 'GET').done(function (data) {
            self.services(data);
        });
    }
    self.getServiceDetail = function (item) {
        ajaxHelper(servicesuri + item.Id, 'GET').done(function (data) {
            self.detail(data);
        });
    }
    self.newCliente = {
        Servicio: ko.observable(),
        Nombre: ko.observable(),
        Telefono: ko.observable(),
        Email: ko.observable(),
        Otros: ko.observable()
    }

    self.addCliente = function (formElement) {
        var cliente = {
            ServicioId: self.newCliente.Servicio().Id,
            Nombre: self.newCliente.Nombre(),
            Telefono: self.newCliente.Telefono(),
            Email: self.newCliente.Email(),
            Otros: self.newCliente.Otros()
        };
        ajaxHelper(clientesuri, 'POST', cliente).done(function (item) {
            self.clientes.push(item);
        });
    }

    getAllClients();
    getServices();
};
ko.applyBindings(new ViewModel());