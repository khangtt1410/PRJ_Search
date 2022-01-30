function resetForm() {
    $('#errtaikhoan').hide();
    $('#errmatkhau').hide();
    $('#errten').hide();
    $('#id').val("0");
    $('#varTaiKhoan').val("");
    $('#varMatKhau').val("");
    $('#varHoTen').val("");
    $('#varEmail').val("");
    $('#varPhone').val("");
    $('#varDiaChi').val("");
    $('#varGhiChu').val("");
}

function ShowModalAddEdit(id) {
    resetForm();
    if (id == null || id == 0) {
        document.getElementById('TieuDe').innerHTML = "Thêm mới người dùng";
    }
    else {
        document.getElementById('TieuDe').innerHTML = "Cập nhật thông tin người dùng";
        $.ajax({
            url: "/NguoiDung/GetData",
            data: {
                id: id
            },
            type: 'post',
            success: function (result) {
                if (result.status == true) {
                    $('#id').val(id);
                    $('#varTaiKhoan').val(result.data.TenDangNhap);
                    $('#varMatKhau').val(result.data.MatKhau);
                    $('#varHoTen').val(result.data.HoTen);
                    $('#varEmail').val(result.data.Email);
                    $('#varPhone').val(result.dataSoDienThoai);
                    $('#varDiaChi').val(result.data.DiaChi);
                    $('#varGhiChu').val(result.data.DoPhuCTap);
                }
            }
        });
    }
    $("#mdlNguoiDung_AddEdit").modal("show");
}

function Save() {
    var isSave = true;
    var hoten = $('#varHoTen').val().trim();
    var taikhoan = $('#varTaiKhoan').val().trim();
    var matkhau = $('#varMatKhau').val().trim();
    var id = $('#id').val();
    if (hoten == "") {
        isSave = false;
        document.getElementById('errten').innerHTML = "Không được để trống.";
        $('#errten').show();
    }
    if (taikhoan == "") {
        isSave = false;
        document.getElementById('errtaikhoan').innerHTML = "Không được để trống.";
        $('#errtaikhoan').show();
    }
    if (matkhau == "") {
        isSave = false;
        document.getElementById('errmatkhau').innerHTML = "Không được để trống.";
        $('#errmatkhau').show();
    }
    if (isSave == true) {
        var formData = new FormData();
        formData.append("HoTen", hoten);
        formData.append("TenDangNhap", taikhoan);
        formData.append("MatKhau", matkhau);
        formData.append("Phone", $('#varPhone').val());
        formData.append("DiaChi", $('#varDiaChi').val());
        formData.append("Email", $('#varEmail').val());
        formData.append("ID", id);
        formData.append("DoPhucTap", $('#varGhiChu').val());

        $.ajax({
            async: false,
            type: 'POST',
            url: "/NguoiDung/Save",
            data: formData,
            cache: false,
            contentType: false,
            processData: false,
            success: function (response) {
                if (response.status == true) {
                    $('#mdlNguoiDung_AddEdit').modal('hide');
                    if (id == 0) {
                        alert('Thêm mới người dùng thành công.')
                    }
                    else {
                        alert('Cập nhật người dùng thành công.')
                    }
                    loadPartial();
                   
                }
            },
            error: function (err) {
                console.log(err);
            }
        });
    }
}

var idND = "";
function Link_DeleteTT_onclick(DID) {
    idND = DID;
    if (ListCTLID != "")//view popup xác nhận xóa
    {
        $("#DeleteND").modal("show");
    }
}

function deleteOne() {
    $.ajax({
        url: '/NguoiDung/DeleteAll',
        dataType: 'json',
        type: 'post',
        data: { lstIdString: idND },
        success: function (rs) {
            //location.reload();
            hideLoadingScreen();
            if (rs.status == true) {
                var mangIdDaXoa = JSON.parse(rs.data);
                for (var i = 0; i < mangIdDaXoa.length; i++) {
                    $('#tblNguoiDung > tbody > tr[data-id="' + mangIdDaXoa[i] + '"]').remove();
                }
                var message = 'Xóa thành công người dùng.';
                alert(message);
                loadPartial();

            }
        }
    })
}

function loadPartial() {
    var trangHienTai = 1;
    var strKeyWord = $('#txtSearch').val('');
    mangId = [];
    $.ajax({
        url: '/NguoiDung/GetListData?page=' + trangHienTai,
        data:
        {
            keyword: strKeyWord.val(),
        },
        type: 'GET',
        success: function (res) {
            $('#tblNguoiDung').html(res);
            //$('#tblNguoiDung').find('tbody  tr[data-id]').each(function () {
            //    idOfIiem = $(this).attr('data-id');
            //    if ($.inArray(Number(idOfIiem), mangId) >= 0) {
            //        $(this).find('.one-delete-js').prop('checked', true);
            //    }
            //})
        },
        error: function () {
           
        }
    });
}

function Search() {
    //Lấy thông tin tại các ô tìm kiếm
    var ten = $('#txtSearch').val();
    //Gọi hàm ajax
    $.ajax({
        url: '/NguoiDung/GetListData',
        data:
        {
            keyword: ten,
        },
        success: function (res) {
            $('#tblNguoiDung').html(res);
            //Lấy thông tin tại các ô tìm kiếm
            $('#txtSearch').val(ten);
        }
    })
}
