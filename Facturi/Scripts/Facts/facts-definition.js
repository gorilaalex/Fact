/// <reference path="../Utils/entities.js" />
function FactViewModel() {
    var self = this;
    self.Model = ko.observable(new FactModel());
    self.initModel = function (data) {
        self.Model().init(data);
    };
    //self.Products = ko.observableArray();
    return self;
};

function FactModule() {
    var self = this;

    if (arguments.callee.instance != null) return arguments.callee.instance;
    arguments.callee.instance = self;

    self.Facts = ko.observableArray();
    self.ViewModel = ko.observable(new FactModel());
    self.Message = ko.observable();

    self.init = function () {
        Utils.postOnServer("1", $("#GetFactsUrl").val(), self.getFacts);
    };

    self.addFact = function () {
        console.log("yey,add in progress");
            Utils.postOnServer(self.ViewModel, $("#AddFactUrl").val(), self.addFactSuccess);
        
    };

    self.addFactSuccess = function (data) {
        if (data != null && data.IsSuccess) {
            console.log("yey");
        }

        self.Message(data.Message);
    };

    self.editFact = function () { };

    self.editFactSuccess = function () { };

    self.deleteFact = function () { };

    self.getFacts = function (data) {
        console.log("here will be facts");
        var factsVM = null;
        if (data != null && data.Facts != null) {
            factsVM = ko.utils.arrayMap(data.Facts, function (item) {
                var aux = new FactViewModel();
                aux.initModel(item);
                aux.Model().Date(new Date());
                return aux;
            });
            self.Facts.push.apply(self.Facts, factsVM);
        }
    };

};

FactModule.getInstance = function () {
    var singletonClass = new FactModule();
    return singletonClass;
};