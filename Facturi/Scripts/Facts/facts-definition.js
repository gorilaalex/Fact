/// <reference path="../Utils/entities.js" />
function FactViewModel() {
    var self = this;
    self.Id = ko.observable();
    self.Expeditor = ko.observable();//new expeditor
    self.Buyer = ko.observable(new Company());
    self.TotalSum = ko.observable();
    self.TotalTVA = ko.observable();
    self.Products = ko.observableArray();
};

function FactModule() {
    var self = this;

    if (arguments.callee.instance != null) return arguments.callee.instance;
    arguments.callee.instance = self;

    self.addFact = function () { };

    self.addFactSuccess = function () { };

    self.editFact = function () { };

    self.editFactSuccess = function () { };

    self.deleteFact = function () { };

};


FactModule.getInstance = function () {
    var singletonClass = new FactModule();
    return singletonClass;
};