//used for popup a dialog when user want to cancel a gig
var GigActionsController = function (gigActionsService) {

    var link;

    var deleteDone = function() {
        link.parents("li").fadeOut(function() {
            this.remove();
        });
    };

    var deleteFail = function(error) {
        alertDialog(error.responseJSON);
    };

    var yesCallBack = function() {
        gigActionsService.cancel(link.attr("data-gig-id"),deleteDone,deleteFail);
    };

    var cancelGig = function (e) {
        link = $(e.target);
        deleteDialog(yesCallBack);
    }

    var init = function (container) {
        $(container).on("click", ".js-cancel-gig", cancelGig);
    };

    return {
        init: init
    }

}(GigActionsService);

