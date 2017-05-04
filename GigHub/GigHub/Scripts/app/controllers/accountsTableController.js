var AccountTableController = function () {

    var init = function(container) {
        $(container).DataTable({
            ajax: {
                url: "/api/accounts",
                dataSrc: ""
            },
            columns: [
                {
                    data: "email"
                },
                {
                    data: "name"
                },
                {
                    data: "role",
                    render: function (data, type, user) {
                        return "<a rel='popover' data-user-id = " +
                            user.id +
                            " class='role' href='#'>" +
                            data +
                            "</a>";
                    }
                },
                {
                    data: "activated",
                    render: function (data, type, user) {
                        return "<a data-user-id = " +
                            user.id +
                            " class='js-toggle-changeStatus' href='#'>" +
                            user.accountStatus +
                            "</a>";
                    }
                }
            ]
        });
    }

    return {
        init:init
    }
}();