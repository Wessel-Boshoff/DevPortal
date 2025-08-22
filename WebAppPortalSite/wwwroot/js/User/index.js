$(document).ready(function () {
    $(document).on("click", ".btnDeleteUser", Delete)
    $(document).on("click", "#deleteUserConfirm", DeleteConfirm)

});

function Delete() {
    var moniker = $(this).data("moniker");
    $("#deleteUserConfirm").data("moniker", moniker);
    $("#deleteUserModal").modal("show");
}

function DeleteConfirm() {
    $(this).prop("disabled", true);
    var moniker = $(this).data("moniker");
    $.ajax({
        url: '/User/Delete?moniker=' + moniker,
        type: 'POST',
        success: function (response) {
            if (response.responseCode == 1) {
                SetErrors("#deleteUserValidation", response.errors);
                return;
            }

            if (response.responseCode != 2) {
                alert(response.message);
                return;
            }

            window.location.reload();
        },
        error: function (xhr) {
            alert("Error deleting user");
        },
        complete: function () {
            $("#deleteUserConfirm").prop("disabled", false);
        }
    });
} 