﻿function DashboardModule() {
    var self = this;
    if (arguments.callee.instance)
        return arguments.callee.instance;
    arguments.callee.instance = self;


    //here will go logic for dashboard
    return self;
};

DashboardModule.getInstance = function () {
    var instance = new DashboardModule();
    return instance;
}