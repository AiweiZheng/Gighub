var NotificationService = function () {

    var getNotifications = function(done) {
        $.getJSON("/api/Notifications",done);
    }

    var markAsRead = function(done,fail) {
        $.post("/api/notifications/markAsRead")
            .done(done)
            .fail(fail);
    }

    return {
        getNotifications: getNotifications,
         markAsRead: markAsRead
    }

}();