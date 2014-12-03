var Constants = function () {
    var self = this;

    if (arguments.callee.instance != null) return arguments.callee.instance;
    arguments.callee.instance = self;

    self.DASHBOARD_URL = "#/dashboard";
    self.PROFILE_URL = "#/profile";
    self.COMPANY_URL = "#/company";
    self.ACCOUNT_URL = "#/account";
    self.LOGOUT_URL = "#/logout";

    return self;
}

Constants.getInstance = function () {
    var singletonClass = new Constants();
    return singletonClass;
};