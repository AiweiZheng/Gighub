﻿
var ChangeAccountRoleController = function (changeAccountRoleService) {

    var selectRoleId = null;
    var selectRoleName = null;

    var link;

    var done = function() {
        link.text(selectRoleName);
    }

    var fail = function (error) {
        alertDialog(error.responseJSON);
    }

    var sendChangeRoleRequest = function (e) {
        link = $(e.target);

        var userId = link.attr("data-user-id");
        var data = { Id: selectRoleId };

        if (selectRoleId != null) 
            changeAccountRoleService.changeAccountRole(userId,data, done, fail);
        
        selectRoleId = null;//should reset 
    }

    var roleChangeListener = function () {
        selectRoleId = $(this).attr("js-data-role-id");
        selectRoleName = $(this).attr("js-data-role-name");
    }

    var bindListenerToRoleDom = function () {
        $(document).on("click", ".js-change-role", roleChangeListener);
    }

    var init = function () {
        bindListenerToRoleDom();
    }

    return {
        init: init,
        sendChangeRoleRequest: sendChangeRoleRequest
    }

}(ChangeAccountRoleService)