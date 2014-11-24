/// <reference path="../Utils/entities.js" />
/// <reference path="../Utils/fact-app-module.js" />
/// <reference path="../Utils/fact-app-navigation.js" />
function ProfileModule() 
{
    if (arguments.callee.instance)
        return arguments.callee.instance;
    arguments.callee.instance = self;



    var self = this;
    self.User = ko.observable(new User());
    self.Company = ko.observable(new CompanyModel());
    self.init = function (data) {
       // self.User().init(data.UserVM);
       // self.Company().initModel(data.CompanyVM);
       // console.log(data.UserVM.Username);
       // console.log(data.CompanyVM.ContractorName);
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

    self.updateProfile = function () {
        self.bindValidation();

        if (!$('#updateProfile').valid()) {
            return;
        }

        Utils.postOnServer(self.Model,
            $("#UpdateUrl").val(), self.updateProfileSuccess
        );
    };

    self.updateProfileSuccess = function (data) {
        if (data.IsSuccess) {
        }
    };

    self.bindValidation = function () {

    };

    
};

ProfileModule.getInstance = function () {
    var singletonClass = new ProfileModule();
    return singletonClass;
};

function UserModel() {
    var self = this;
    self.Model = ko.observable(new User());
    self.initModel = function (data) {
        self.Model().init(data);
    };
    self.update = function () {
          };
    self.updateSuccess = function (data) {

    };
    return self;
};

function CompanyModel() {
    var self = this;
    self.Model = ko.observable(new Company());
    self.initModel = function (data) {
        self.Model().init(data);
    };
    self.update = function () {
        Utils.postOnServer(self.Model(), $("#InsertUpdateCompanyUrl").val(), self.updateSuccess);
    };
    self.updateSuccess = function (data) {
        if (data.IsSuccess) {
            console.log("done.");
        }
        else {
            console.log("bad update company.");
        }
    };
};