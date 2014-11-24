/// <reference path="../Utils/entities.js" />
function FactModule() {
    var self = this;
    self.Id = ko.observable();
    self.Expeditor = ko.observable();//new expeditor
    self.Buyer = ko.observable(new Company());
    self.TotalSum = ko.observable();
    self.TotalTVA = ko.observable();
    self.Products = ko.observableArray();
};