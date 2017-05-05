var AccountStatusController = function (accountStatusService) {
    var link;
    var status;
    var activate = "Activate";
    var deactivate = "Deactivate";


    var done = function() {
        var text = status ? deactivate : activate;
        link.text(text);
      
        text = status ? true : false;
        var statusLabel = $("#" + link.attr("data-user-id") + "_status");
        statusLabel.text(text);
    };

    var fail = function(error) {
        alertDialog(error.responseJSON);
    };

    var toggleActivateAccount = function (e) {
        link = $(e.target);

        status = link.text().trim() === activate ? true : false; 
        accountStatusService.changeAccountStatus(link.attr("data-user-id"), {Activated:status}, done, fail);
    }

    var init = function (container) {
        $(container).on("click", ".js-toggle-changeStatus", toggleActivateAccount);

    }

    return {
        init: init
    };
}(AccountStatusService)