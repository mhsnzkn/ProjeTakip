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
                txt += `<li class="list-group-item">
                <div class="d-flex justify-content-between">
                  <div>` + elm.adi + `</div>
                  <div>
                <a href="/files/` + elm.aciklama + `" class="btn btn-sm btn-primary" target="_blank">Görüntüle</a>
                <a href="/Home/GetRapor/` + elm.id + `" class="btn btn-sm btn-danger">İndir</a>
                <span title="` + (new Date(elm.tarih)).toLocaleDateString() + `"><i class="fas fa-info-circle" style="color:#17a2b8"></i></span>
                  </div>
                </div>
                </li>`;
            });
            $('#modal_body').html(txt);
        },
        error: function (res) {
            toastr.error("Bir hata oluştu!");
        }
    })

})