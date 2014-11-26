/// <reference path="../Settings/settings-module.js" />
/// <reference path="../Home/dashboard-module.js" />
/// <reference path="../Account/user-session.js" />
/// <reference path="../Home/profile-module.js" />
/// <reference path="Constants.js" />
/// <reference path="fact-app-navigation.js" />
//this is the main module for authenticated user. Here we will define routes for sammy and will take care of comunication between modules. Also it will be a sort of business layer.

function FactAppModule() {
    var self = this;

    if (arguments.callee.instance != null) return arguments.callee.instance;
    arguments.callee.instance = self;

    //#region constructors

    self.CurrentTemplate = ko.observable('');
    self.BindingContext;
    debugger;
    self.init = function () {
        console.log("fact app module - init ");
        self.initBindingContext();
        setSammy();
    };


    function setSammy() {
        var app = Sammy('#body-wrapper', function () {

            this.get(Constants.getInstance().DASHBOARD_URL, function () {
                Utils.doJSONGetWithLoad($("#DashboardUrl").val(), function (data) {
                    if (data.IsSuccess) {
                        self.runDashboard();
                    }
                    else window.location.href = '/Error/NotFound';
                });
            });

            this.get(Constants.getInstance().PROFILE_URL, function () {

                Utils.doJSONGetWithLoad($("#MyProfileUrl").val(), function (data) {
                    if (data.IsSuccess) {
                        self.runProfile();
                    }
                    else window.location.href = '/Error/NotFound';
                });
            });

            this.get(Constants.getInstance().COMPANY_URL, function () {

                Utils.doJSONGetWithLoad($("#MyCompanyUrl").val(), function (data) {
                    if (data.IsSuccess) {
                        self.runCompany();
                    }
                    else window.location.href = '/Error/NotFound';
                });
            });

            this.get(Constants.getInstance().ACCOUNT_URL, function () {

                Utils.doJSONGetWithLoad($("#MyAccountUrl").val(), function (data) {
                    if (data.IsSuccess) {
                        self.runAccount();
                    }
                    else window.location.href = '/Error/NotFound';
                });
            });

            this.get(Constants.getInstance().LOGOUT_URL, function () {

                Utils.doJSONGetWithLoad($("#LogOutUrl").val(), function (data) {
                    if (data.IsSuccess) {
                        self.runLogout();
                    }
                    else window.location.href = '/Error/NotFound';
                });
            });

        });

        app.run(Constants.getInstance().DASHBOARD_URL);
    }

    //#endregion

    //#region Methods

    self.initBindingContext = function () {
        self.runDashboard();
        debugger;
    };

    self.runDashboard = function () {
        UserSession.getInstance().NavigationModel.SetToDashboard();
        self.BindingContext = DashboardModule.getInstance();
        self.CurrentTemplate('tmpl-dashboard');
    };

    self.runProfile = function () {
        UserSession.getInstance().NavigationModel.SetToProfile();
        self.BindingContext = ProfileModule.getInstance();
        self.BindingContext.init();
        self.CurrentTemplate('tmpl-profile');
    };

    self.runCompany = function () {
        UserSession.getInstance().NavigationModel.SetToCompany();
        self.CurrentTemplate('tmpl-company');
        self.BindingContext = ProfileModule.getInstance();
    };

    self.runAccount = function () {
        UserSession.getInstance().NavigationModel.SetToAccount();
        self.CurrentTemplate('tmpl-account');
       // self.BindingContext = .getInstance();
    };

    self.runLogout = function () {
        window.location.href = "/";
    };
    //#endregion

}

FactAppModule.getInstance = function () {
    var instance = new FactAppModule();
    return instance;
}

$(document).ready(function () {

});