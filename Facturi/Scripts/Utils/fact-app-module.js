/// <reference path="../Settings/settings-module.js" />
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

    self.init = function () {
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
                        ProfileModule.getInstance().init();
                        self.BindingContext = ProfileModule.getInstance();
                       // UserSession.getInstance().NavigationModel.SetToProfile();
                        self.CurrentTemplate('tmpl-profile');
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
       // self.BindingContext = DashboardModule.getInstance();
        self.CurrentTemplate('tmpl-dashboard');
    };

    self.runDashboard = function () {
        NavigationModel.getInstance().SetToDashboard();
       // self.BindingContext = DashboardModule.getInstance();
        self.CurrentTemplate('tmpl-dashboard');
    };

    self.runProfile = function () {
        NavigationModel.getInstance().SetToProfile();
        //self.BindingContext = ProfileModule.getInstance();
        self.CurrentTemplate('tmpl-profile');
    };
    //#endregion

}

FactAppModule.getInstance = function () {
    var instance = new FactAppModule();
    return instance;
}

$(document).ready(function () {

});