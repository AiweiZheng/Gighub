var GigActionsService = function () {

    var cancel = function (id, done, fail) {
        $.ajax({
                url: "/api/gigs/" + id,
                method: "DELETE",
                beforeSend: App.addVerificaitonTokenToHeader
            })
            .done(done)
            .fail(fail);
    }

    return {
        cancel: cancel
    }
}();