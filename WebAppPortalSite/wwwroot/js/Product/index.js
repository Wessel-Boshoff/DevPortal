$(document).ready(function () {
    $(document).on("click", ".btnDeleteProduct", Delete)
    $(document).on("click", "#deleteProductConfirm", DeleteConfirm)

});

function Delete() {
    var moniker = $(this).data("moniker");
    $("#deleteProductConfirm").data("moniker", moniker);
    $("#deleteProductModal").modal("show");
}

function DeleteConfirm() {
    $(this).prop("disabled", true);
    var moniker = $(this).data("moniker");
    $.ajax({
        url: '/Product/Delete?moniker=' + moniker,
        type: 'POST',
        success: function (response) {
            if (response.responseCode == 1) {
                SetErrors("#deleteProductValidation", response.errors);
                return;
            }

            if (response.responseCode != 2) {
                alert(response.message);
                return;
            }

            window.location.reload();
        },
        error: function (xhr) {
            alert("Error deleting product");
        },
        complete: function () {
            $("#deleteProductConfirm").prop("disabled", false);
        }
    });
} 