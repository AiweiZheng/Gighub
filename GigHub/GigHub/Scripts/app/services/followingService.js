﻿var FollowingService = function () {

    var follow = function (id, done, fail) {
        $.ajax({
            url: "/api/followings",
            method: "POST",
            data: { followeeId: id },
                beforeSend: App.addVerificaitonTokenToHeader
            }).done(done)
            .fail(fail);
    }
     
    var unfollow = function (id, done, fail) {
        $.ajax({
            url: "/api/followings/" + id,
            method: "DELETE",
            beforeSend: App.addVerificaitonTokenToHeader
            }).done(done)
            .fail(fail);
    }

    return {
        follow: follow,
        unfollow:unfollow
    }
}();