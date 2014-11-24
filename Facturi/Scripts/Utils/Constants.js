var Constants = function () {
    var self = this;

    if (arguments.callee.instance != null) return arguments.callee.instance;
    arguments.callee.instance = self;

    self.DASHBOARD_URL = "#/dashboard";
    self.PROFILE_URL = "#/profile";

    return self;
}

Constants.getInstance = function () {
    var singletonClass = new Constants();
    return singletonClass;
};