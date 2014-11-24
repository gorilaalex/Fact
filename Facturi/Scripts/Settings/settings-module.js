function SettingsModule() {
    var self = this;

    if (arguments.callee.instance != null) return arguments.callee.instance;
    arguments.callee.instance = self;

    self.templateLoaded = function (element) {
        console.log("here you will code logic for specific template, after load!!!");
    };

}

SettingsModule.getInstance = function () {
    var singletonClass = new SettingsModule();
    return singletonClass;
};