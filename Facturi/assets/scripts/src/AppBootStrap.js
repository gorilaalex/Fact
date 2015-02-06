require(['ViewModel/ViewModel', 'jquery', 'knockout','utils'
], function (ViewModel, $, ko,utils) {
    'use strict';

    $(document).ready(function () {
        var loginVM = new ViewModel.LoginViewModel();
        // personVM.Init();
        loginVM.Init();
        console.log("PersonViewModel loaded, applying bindings...");

        utils.init();

        var rememberMeValue = utils.pullFromLocalStore("rememberMe");
        if (rememberMeValue && rememberMeValue != null) {
            loginVM.Model().RememberMe(true);
            loginVM.Model().Username(rememberMeValue);
        }
        utils.bindData(loginVM, document.getElementById("container"));
        console.log("bind success");

        console.log("bind success");
        console.log("bind success");
    });
});