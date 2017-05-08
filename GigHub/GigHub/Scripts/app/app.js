var App = function () {

    var antiForgeryToken = $("input[name=__RequestVerificationToken]").val();

    var addVerificaitonTokenToHeader = function (request) {
        request.setRequestHeader("__RequestVerificationToken", antiForgeryToken);
    }


    return {
        addVerificaitonTokenToHeader: addVerificaitonTokenToHeader
    }
}()

