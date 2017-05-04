var ChangeAccountRoleService = function () {
    var changeAccountRole = function (userId,data, done, fail) {
        $.ajax({
                url: "/api/accountRole/" + userId,
                method: "PUT",
                data: data
            }).done(done)
            .fail(fail);
    }

    return {
        changeAccountRole: changeAccountRole
    }
}();