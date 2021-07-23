$(function () {
    $("#register").on('submit', function (e) {
        e.preventDefault();
        var formData = $("#register").serializeArray();
        $.ajax({
            type: 'POST',
            data: formData,
            dataType: 'json',
            url: url.register,
            success: function (response) {
                if (response.isSuccess === true) {
                    Swal.fire({
                        allowOutsideClick: false,
                        title: 'Success!',
                        html: response.msg,
                        icon: 'success'
                    }).then(function () {
                        deleteField(),
                            window.location.href = "Login";
                    });
                }
                else {
                    Swal.fire({
                        allowOutsideClick: false,
                        title: 'Failed!',
                        html: response.msg,
                        icon: 'warning'
                    }).then(function () {
                        deleteField();
                    });
                }
            }
        });
    });
});
function deleteField() {
    $('#fname').val('');
    $('#lname').val('');
    $('#gender').val('');
    $('#email').val('');
    $('#user').val('');
    $('#pass').val('');
    $('#compass').val('');
}