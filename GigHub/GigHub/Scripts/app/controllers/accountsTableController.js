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
                    data: "activated",
                    render: function (data, type, user) {
                        return "<label id = " +
                            user.id +
                            "_status>" +
                            data +
                            "</label>";
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
                }
            ]
        });
    }

    return {
        init:init
    }
}();