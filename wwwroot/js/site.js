// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.


$(document).ready(() => {

    $("#btnLogout").click(() => {
        $.ajax({
            url: '/Account/Logout',
            method: 'POST',
            success: function (response) {
                window.location.href="/Account/SignIn"                
            },
            error: function (error) {
                console.log(error)
            }
        });
    })

})