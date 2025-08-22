$(document).ready(function () {
    $(document).on("change", "#ImageUpload", UpdateImage)
});

function UpdateImage(e) {
    const file = this.files[0];
    if (!file) return;

    const reader = new FileReader();
    reader.onload = function (e) {
        $("input[name='ImageBase64']").val(
            e.target.result
        );
    };
    reader.readAsDataURL(file);
}