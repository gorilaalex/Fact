/// <reference path="../Utils/fact-app-navigation.js" />
function UserSession() {
    var self = this;
    debugger;
    if (arguments.callee.instance != null) return arguments.callee.instance;
    arguments.callee.instance = self;

    self.NavigationModel;

    self.init = function () {
        self.NavigationModel = NavigationModel.getInstance();
        console.log("init");
    };

    self.logoutBeforeSend = function () {
        //TODO: remove other session related data
    };

    self.doLogoutSuccess = function (data) {
        debugger;
        if (data.IsSuccess) {
            if (data.ReturnUrl) window.location.href = data.ReturnUrl;
        }
    };

    self.doLogout = function () {
        console.log("running");
        Utils.getOnServer($("#LogOutUrl").val(), self.logoutBeforeSend, self.doLogoutSuccess, null, null);
    };


};

UserSession.getInstance = function () {
    var singletonClass = new UserSession();
    return singletonClass;
};