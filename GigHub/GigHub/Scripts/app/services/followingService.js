var FollowingService = function () {

    var follow = function (id, done, fail) {
        $.post("/api/followings", { followeeId: id })
            .done(done)
            .fail(fail);
    }
     
    var unfollow = function (id, done, fail) {
        $.ajax({
            url: "/api/followings/" + id,
                method: "DELETE"
            }).done(done)
            .fail(fail);
    }

    return {
        follow: follow,
        unfollow:unfollow
    }
}();