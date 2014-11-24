require(['moduleC/ViewModel', 'jquery', 'knockout'
], function (ViewModel, $, ko) {
    'use strict';

    $(document).ready(function () {
        var personVM = new ViewModel.PersonViewModel();
       // personVM.Init();
        console.log("PersonViewModel loaded, applying bindings...");
        ko.applyBindings(personVM, document.getElementById('ko-wrapper'));
    });
});