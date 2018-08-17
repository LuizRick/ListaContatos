

$(function () {
    $("#nome").on("blur", function () {
        let nome = $(this).val();
        if (nome.length <= 0)
            $(this).parent().find("span").show();
        else
            $(this).parent().find("span").hide();
    });
})