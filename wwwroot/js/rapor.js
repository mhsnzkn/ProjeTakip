// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

$('.link_index').click(function () {
    $('#modal_header').text($(this).text());
    var elm_id = $(this).data("id");
    var model = {
        id: elm_id
    };

    $.ajax({
        url: "/Services/GetRapor",
        type: "GET",
        dataType: "json",
        contentType: 'application/json; charset=utf-8',
        data: model,
        success: function (res) {
            var txt = "";
            res.forEach(elm => {
                txt += `<a href="/files/` + elm.aciklama + `" class="list-group-item list-group-item-action">` + elm.adi + `</a>`;
            });
            $('#modal_body').html(txt);
        },
        error: function (res) {
            toastr.error("Bir hata oluştu!");
        }
    })

})