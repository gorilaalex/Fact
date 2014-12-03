define(['require'], function (require) {
    var ClientDataProxy;
    (function (ClientDataProxy) {
        var Session = (function () {
            function Session() {
                if (Session._instance) {
                    throw new Error("Error: Instantiation failed: Use Session.getInstance() instead of new.");
                }
                Session._instance = this;
                console.log("Session initialiazed, resuming...");
            }


            Session.getInstance = function () {
                if (Session._instance === null) {
                    Session._instance = new Session();
                }
                return Session._instance;
            };

            Session._instance = null;
            return Session;
        })();
        ClientDataProxy.Session = Session;
    })(ClientDataProxy || (ClientDataProxy = {}));
    return ClientDataProxy;
});