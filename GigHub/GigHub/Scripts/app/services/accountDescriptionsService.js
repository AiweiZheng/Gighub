var AccountDescriptionService = function () {

    var getDescription = function(id, done, fail) {
        $.ajax({
                url: "/api/accounts/" + id,
                method: "GET"
            }).done(done)
            .fail(fail);
    };

    var updateDescription = function(id, data, done, fail) {
        $.ajax({
                url: "/api/accounts/" + id,
                method: "PUT",
                data: data
            }).done(done)
            .fail(fail);
    };

    return {
        getDescription: getDescription,
        updateDescription: updateDescription
    }

}()