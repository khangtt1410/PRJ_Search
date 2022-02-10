function resetForm() {
    $('#errorNameCourse').hide();
    $('#id').val("0");
    $('#txtten').val("");
}

$("#txtten").keyup(function () {
    var ten = $('#txtten').val().trim();
    if (ten != "") {
        $('#errorNameCourse').hide();
    }
    else {
        document.getElementById('errorNameCourse').innerHTML = "Không được để trống.";
        $('#errorNameCourse').show();
    }
})

function ShowModalAddEdit(id) {
    resetForm();
    if (id == null || id == 0) {
        document.getElementById('TieuDe').innerHTML = "Thêm mới ngôn ngữ";
    }
    else {
        document.getElementById('TieuDe').innerHTML = "Cập nhật thông tin ngôn ngữ";
        $.ajax({
            url: "/NgonNgu/GetData",
            data: {
                id: id
            },
            type: 'post',
            success: function (result) {
                if (result.status == true) {
                    $('#id').val(id);
                    $('#txtten').val(result.data.TenNgonNgu);
                }
            }
        });
    }
    $("#mdlNgonNgu_AddEdit").modal("show");
}

function Search() {
    //Lấy thông tin tại các ô tìm kiếm
    var ten = $('#txtSearch').val();
    //Gọi hàm ajax
    $.ajax({
        url: '/NgonNgu/GetListData',
        data:
        {
            keyword: ten,
        },
        success: function (res) {
            $('#tblNgonNgu').html(res);
        }
    })
}

//hàm xử lý khi nhấn chuyển trang 
$(document).on('click', '#tblNgonNgu .paginationNavigator li a', function (e) {
    e.preventDefault();
    if ($(this).attr('href') == undefined || $.trim($(this).attr('href')) == "") return;
    //Lấy thông tin tại các ô tìm kiếm
    var ten = $('#txtSearch').val();
    $.ajax({
        url: $(this).attr('href'),
        data:
        {
            keyword: ten
        },
        type: 'GET',
        success: function (res) {
            $('#tblNgonNgu').html(res);

            $('#DataTables_Table_0_paginate ul li.currentPage').addClass('currentpage');
            //Lấy thông tin tại các ô tìm kiếm
            $('#txtSearch').val(ten);
        }
    });
});

function loadPartial() {
    var trangHienTai = 1;
    var strKeyWord = $('#txtSearch').val('');
    mangId = [];
    $.ajax({
        url: '/NgonNgu/GetListData?page=' + trangHienTai,
        data:
        {
            keyword: strKeyWord.val(),
        },
        type: 'GET',
        success: function (res) {
            $('#tblNgonNgu').html(res);
        },
        error: function () {

        }
    });
}

function Save() {
    var isSave = true;
    var ten = $('#txtten').val().trim();
    var id = $('#id').val();
    if (ten == "") {
        isSave = false;
        document.getElementById('errorNameCourse').innerHTML = "Không được để trống.";
        $('#errorNameCourse').show();
    }
    if (isSave == true) {
        var formData = new FormData();
        formData.append("TenNgonNgu", ten);
        formData.append("ID", id);

        $.ajax({
            async: false,
            type: 'POST',
            url: "/NgonNgu/Save",
            data: formData,
            cache: false,
            contentType: false,
            processData: false,
            success: function (response) {
                if (response.status == true) {
                    $('#mdlNgonNgu_AddEdit').modal('hide');
                    if (id == 0) {
                        $('#noidung').text('Thêm mới ngôn ngữ thành công.')

                    }
                    else {
                        $('#noidung').text('Cập nhật ngôn ngữ thành công.')
                    }
                    $('#modalThongBao').modal('show');
                    loadPartial();
                }
            },
            error: function (err) {
                console.log(err);
            }
        });
    }
}

var idNN = "";
function Link_DeleteTT_onclick(ID) {
    idNN = ID;
    if (idNN != "")//view popup xác nhận xóa
    {
        $("#Delete").modal("show");
    }
}

function deleteOne() {
    $.ajax({
        url: '/NgonNgu/Delete',
        dataType: 'json',
        type: 'post',
        data: { ID: idNN },
        success: function (rs) {
            if (rs.status == true) {
                $("#Delete").modal("hide");
                $('#noidung').text('Xóa ngôn ngữ thành công.')
                $('#modalThongBao').modal('show');
                loadPartial();
            }
        }
    })
}