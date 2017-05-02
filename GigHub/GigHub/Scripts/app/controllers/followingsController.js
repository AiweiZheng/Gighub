var FollowingController = function (followService) {
    var button;

    var done = function () {
        var text = button.text().trim() === "Following" ? "Follow" : "Following";

        button.toggleClass("btn-default").toggleClass("btn-info");
        button.text(text);
    }

    var fail = function (error) {
        alertDialog(error.responseJSON);
    }

    var toggoleFollowing = function(e) {
        button = $(e.target);
        var id = button.attr("data-user-id");

        if (button.hasClass("btn-default")) {
            followService.follow(id, done, fail);

        } else if (button.hasClass("btn-info")) {
            followService.unfollow(id, done, fail);
        }
    }
    var init = function (container) {
        $(container).on("click", ".js-toggle-follow", toggoleFollowing);
    }
    return { init: init }

}(FollowingService)

