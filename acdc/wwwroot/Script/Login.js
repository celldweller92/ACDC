$(function () {
    $("#logindata").on('submit', function (e) {
        e.preventDefault();
        var formData = $("#logindata").serializeArray();
        $.ajax({
            type: 'POST',
            data: formData,
            dataType: 'json',
            url: url.login,
            success: function (response) {
                if (response.isSuccess === true) {
                    Swal.fire({
                        allowOutsideClick: false,
                        title: 'Success!',
                        html: response.msg,
                        icon: 'success'
                    }).then(function () {
                        window.location.href = url.home;
                    });
                }
                else {
                    Swal.fire({
                        allowOutsideClick: false,
                        title: 'Failed!',
                        html: response.msg,
                        icon: 'warning'
                    }).then(function () {

                    });
                }
            }
        });
    });
});