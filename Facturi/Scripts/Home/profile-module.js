/// <reference path="../Utils/entities.js" />
/// <reference path="../Utils/fact-app-module.js" />
/// <reference path="../Utils/fact-app-navigation.js" />
function UserModel() {
    var self = this;
    self.Model = ko.observable(new User());
    self.initModel = function (data) {
        self.Model().init(data);
    };
    return self;
};

function ProfileModule()
{
    if (arguments.callee.instance)
        return arguments.callee.instance;
    arguments.callee.instance = self;

    var self = this;
    self.User = ko.observable(new User());
    self.Message = ko.observable();
   
    self.init = function () {
        console.log("log from profile module");
        self.getUserDetails();
    };
  
    self.getUserDetails = function () {
        Utils.postOnServer(self.User().Model,
            $("#GetDetails").val(), self.getUserDetailsSuccess
        );
    };

    self.getUserDetailsSuccess = function (data) {
        if (data.IsSuccess) {
            console.log(data);
            self.User().init(data);
        }
    };

    self.updateProfile = function () {
        self.bindValidation();

        /*if (!$('#updateProfile').valid()) {
            return;
        }*/

        Utils.postOnServer(self.User,
            $("#UpdateUrl").val(), self.updateProfileSuccess
        );
    };

    self.updateProfileSuccess = function (data) {
        if (data.IsSuccess) {
            console.log("yey!");
        }

        self.Message(data.Message);
    };

    self.bindValidation = function () {
        $.validator.setDefaults({
            submitHandler: function () { }
        });

        $("#user-profile").validate({
            rules: {
                firstname: {
                    required: true
                },
                lastname: {
                    required: true
                }
            },
            messages: {
                firstname: {
                    email: "Please enter firstname."
                },
                lastname: { required: "Please enter lastname." }
            },
            errorElement: "div",
            errorPlacement: function (error, element) {
                Utils.StyleValidationError(error, element);
            },
            highlight: function (element, errorClass, validClass) {
                $(element).addClass('mandatory').removeClass('valid');
            },
            unhighlight: function (element, errorClass, validClass) {
                $(element).removeClass('mandatory').addClass('valid');
            }
        });
    };

    
};

ProfileModule.getInstance = function () {
    var singletonClass = new ProfileModule();
    return singletonClass;
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