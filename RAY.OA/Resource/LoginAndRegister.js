/// <reference path="jquery-3.2.1.min.js" />

$(function() {
    $("#LoginBtn").click(function () {
        var formData = $("#LoginForm").serialize();

        $.ajax({
            url: "/Login/Login",
            type: "POST",
            data: formData,
            success:function(backData) {
                if (backData == "登陆成功") {
                    window.location.href = "/OAUserInfo/Index";
                } else {
                    alert(backData);
                }
            }
        });
    });

});

