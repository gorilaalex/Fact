function NavigationModel1() {
    var self = this;

    if (arguments.callee.instance)
        return arguments.callee.instance;
    arguments.callee.instance = self;

    self.IsHomeSelected = ko.observable(false);
    self.IsProfileSelected = ko.observable(false);
    self.IsFactsSelected = ko.observable(false);
    self.IsReportsSelected = ko.observable(false);

    self.SetToHome = function () {
        self.IsHomeSelected(true);
        self.IsProfileSelected(false);
        self.IsFactsSelected(false);
        self.IsReportsSelected(false);
    };
    self.SetToProfile = function () {
        self.IsHomeSelected(false);
        self.IsProfileSelected(true);
        self.IsFactsSelected(false);
        self.IsReportsSelected(false);
    };
    self.SetToFacts = function () {
        self.IsHomeSelected(false);
        self.IsProfileSelected(false);
        self.IsFactsSelected(true);
        self.IsReportsSelected(false);
    };
    self.SetToReports = function () {
        self.IsHomeSelected(false);
        self.IsProfileSelected(false);
        self.IsFactsSelected(false);
        self.IsReportsSelected(true);
    };
};

NavigationModel1.getInstance = function () {
    var singletonClass = new NavigationModel1();
    return singletonClass;
};
