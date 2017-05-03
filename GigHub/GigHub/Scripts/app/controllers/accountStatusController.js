var AccountStatusController = function (accountStatusService) {
    var link;
    var activate = "Activate";
    var deactivate = "Deactivate";


    var done = function() {
        var text = link.text().trim() === activate ? deactivate : activate;
        link.text(text);
    };

    var fail = function(error) {
        alertDialog(error.responseJSON);
    };

    var toggleActivateAccount = function (e) {
        link = $(e.target);
        var status = link.text().trim() === activate ? false : true; 
        accountStatusService.changeAccountStatus(link.attr("data-user-id"), {Activated:status}, done, fail);
    }

    var init = function (container) {
        $(container).on("click", ".js-toggle-activateAccount", toggleActivateAccount);
    }

    return {
        init: init
    };
}(AccountStatusService)