//used for popup a dialog when user want to cancel a gig
var GigActionsController = function (gigActionsService) {

    var link;
    var gigId;

    var toggleElements = function (gigDom) {
        gigDom.removeAttr("style");

        gigDom.find(".js-cancel-ribbon").toggleClass("hidden").toggleClass("show");
        gigDom.find(".js-cancel-gig").toggleClass("hidden").toggleClass("show");
        gigDom.find(".js-edit-gig").toggleClass("hidden").toggleClass("show");
        gigDom.find(".js-resume-gig").toggleClass("hidden").toggleClass("show");
    }

    var deleteDone = function() {
        link.parents("li").fadeOut(function () {

            $("#cancelledGigs").append($(this));
            toggleElements($(this));
        });
    };

    var resumeDone = function () {
  
        link.parents("li").fadeOut(function () {

            $("#upCommingGigs").append($(this));
            toggleElements($(this));
        });
    };

    var deleteFail = function(error) {
        alertDialog(error.responseJSON);
    };

    var cancelComfirmedCallBack = function () {
        gigId = link.attr("data-gig-id");

        gigActionsService.cancel(gigId,deleteDone,deleteFail);
    };

    var cancelGig = function(e) {
        link = $(e.target);
        deleteDialog(cancelComfirmedCallBack);
    };

    var resumeComfirmedCallBack = function () {
        gigId = link.attr("data-gig-id");

        gigActionsService.resume(gigId, resumeDone, deleteFail);
    };

    var resumeGig = function (e) {
        link = $(e.target);
        deleteDialog(resumeComfirmedCallBack);
    }

    var init = function (container) {
        $(container).on("click", ".js-cancel-gig", cancelGig);
        $(container).on("click", ".js-resume-gig", resumeGig);
    };

    return {
        init: init
    }

}(GigActionsService);

