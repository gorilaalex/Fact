function NavigationModel() {
    var self = this;

    if (arguments.callee.instance)
        return arguments.callee.instance;
    arguments.callee.instance = self;

    self.BindingContext;

    self.IsDashboardSelected = ko.observable(false);
    self.IsProfileSelected = ko.observable(false);
    self.IsCompanySelected = ko.observable(false);
    self.IsAccountSelected = ko.observable(false);

    self.SetToDashboard = function () {
            self.IsDashboardSelected(true);
            self.IsProfileSelected(false);
            self.IsCompanySelected(false);
            self.IsAccountSelected(false);
        
    };

    self.SetToProfile = function () {
            self.IsDashboardSelected(false);
            self.IsProfileSelected(true);
            self.IsCompanySelected(false);
            self.IsAccountSelected(false);
    };


    self.SetToCompany = function () {
        self.IsDashboardSelected(false);
        self.IsProfileSelected(false);
        self.IsCompanySelected(true);
        self.IsAccountSelected(false);
    };


    self.SetToAccount = function () {
        self.IsDashboardSelected(false);
        self.IsProfileSelected(false);
        self.IsCompanySelected(false);
        self.IsAccountSelected(true);
    };
  
};

NavigationModel.getInstance = function () {
    var singletonClass = new NavigationModel();
    return singletonClass;
};