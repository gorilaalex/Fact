function NavigationModel() {
    var self = this;

    if (arguments.callee.instance)
        return arguments.callee.instance;
    arguments.callee.instance = self;

    self.BindingContext;

    self.IsDashboardSelected = ko.observable(false);
    self.IsProfileSelected = ko.observable(false);

    self.SetToDashboard = function () {
        self.IsDashboardSelected(true);
        self.IsProfileSelected(false);
    };

    self.SetToProfile = function () {
        self.IsDashboardSelected(false);
        self.IsProfileSelected(true);
    };
  
};

NavigationModel.getInstance = function () {
    var singletonClass = new NavigationModel();
    return singletonClass;
};