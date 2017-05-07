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
                    //<button type="button" class="btn btn-lg btn-success" data-toggle="modal" data-target=".modal" data-paragraphs="10">Go</button>
                    data: "id",
                    render: function (data, type, user) {
                        return "<a  data-toggle='modal' data-target='#descriptionModel' data-user-id= " +
                            user.id + "  data-user-email="+user.email+
                            " class='js-toggle-user-description'>Edit</a>";
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