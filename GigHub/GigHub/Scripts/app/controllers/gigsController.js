var GigsController = function (attendanceService) {
    var button;
    var going;
    var notGoingYet;

    var fail = function (error) {
        alertDialog(error.responseJSON);
    }

    var done = function () {
        var text = (button.text().trim() === going) ? notGoingYet : going;
        button.text(text);
        button.toggleClass("btn-info").toggleClass("btn-default");
    }

    var toggleAttendance = function (e) {
        e.preventDefault();

        button = $(e.target);

        var gigId = button.attr("data-gig-id");

        if (button.hasClass("btn-default"))
            attendanceService.createAttendance(gigId, done, fail);
        else
            attendanceService.deleteAttendance(gigId, done, fail);
    };

    var init = function (container, goingText, notGoingYetText) {
        going = goingText;
        notGoingYet = notGoingYetText;

        $(container).on("click", ".js-toggle-attendance", toggleAttendance);
    };

    return {
        init: init
    }

}(AttendanceService);