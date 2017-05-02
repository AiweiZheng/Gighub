var deleteDialog = function(yesCallBack) {
    return bootbox.dialog({
        message: "Are you sure you want to cancel this gig?",
        title: "Confirm",
        buttons: {
            no: {
                label: "No",
                className: "btn-default",
                callback: function() {
                    bootbox.hideAll();
                }
            },
            danger: {
                label: "Yes",
                className: "btn-danger",
                callback: yesCallBack
            }
        }
    });
};

var alertDialog = function(message) {
    bootbox.alert(message);
}