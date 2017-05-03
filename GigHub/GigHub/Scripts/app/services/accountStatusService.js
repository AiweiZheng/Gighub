var AccountStatusService = function () {

    var changeAccountStatus = function (userId,data, done, fail) {
        $.ajax({
            url: "/api/accountStatus/" + userId,
            method: "PUT",
            data: data

            }).done(done)
          .fail(fail);
    }

    return {
        changeAccountStatus: changeAccountStatus
    }
}();