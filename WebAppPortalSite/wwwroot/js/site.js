function SetErrors(id, errors) {
    $(id).html("");
    $(id).removeClass("d-none");
    for (var i = 0; i < errors.length; i++) {
        let item = errors[i];
        $(id).append("<li>" + item + "</li>");
    }  
}