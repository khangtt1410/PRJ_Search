function resetForm() {
    $('#errtaikhoan').hide();
    $('#errmatkhau').hide();
    $('#errten').hide();
    $('#erremail').hide();
    $('#id').val("0");
    $('#varTaiKhoan').val("");
    $('#varMatKhau').val("");
    $('#varHoTen').val("");
    $('#varEmail').val("");
    $('#varPhone').val("");
    $('#varDiaChi').val("");
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
                   /* $('#varMatKhau').val(result.data.MatKhau);*/
                    $('#varHoTen').val(result.data.HoTen);
                    $('#varEmail').val(result.data.Email);
                    $('#varPhone').val(result.dataSoDienThoai);
                    $('#varDiaChi').val(result.data.DiaChi);
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
    if (id == 0) {
        if (matkhau == "") {
            isSave = false;
            document.getElementById('errmatkhau').innerHTML = "Không được để trống.";
            $('#errmatkhau').show();
        }
        else {
            if (!isPass(matkhau)) {
                isSave = false;
                document.getElementById('errmatkhau').innerHTML = "Tối thiểu 4 ký tự, tối đa 8 ký tự, ít nhất 1 chữ cái và 1 số.";
                $('#errmatkhau').show();
            }
        }
    }

    if ($('#varEmail').val() != "") {
        if (!isEmail($('#varEmail').val())) {
            isSave = false;
            document.getElementById('erremail').innerHTML = "Email sai định dạng";
            $('#erremail').show();
        }
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
                        $('#noidung').text('Thêm mới người dùng thành công.')
                        
                    }
                    else {
                        $('#noidung').text('Cập nhật người dùng thành công.')
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

var idND = "";
function Link_DeleteTT_onclick(DID) {
    idND = DID;
    if (idND != "")//view popup xác nhận xóa
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
            //hideLoadingScreen();
            if (rs.status == true) {
                $("#DeleteND").modal("hide");
                var mangIdDaXoa = JSON.parse(rs.data);
                for (var i = 0; i < mangIdDaXoa.length; i++) {
                    $('#tblNguoiDung > tbody > tr[data-id="' + mangIdDaXoa[i] + '"]').remove();
                }
                $('#noidung').text('Xóa người dùng thành công.')
                $('#modalThongBao').modal('show');
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
        }
    })
}

//hàm xử lý khi nhấn chuyển trang 
$(document).on('click', '#tblNguoiDung .paginationNavigator li a', function (e) {
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
            $('#tblNguoiDung').html(res);

            $('#DataTables_Table_0_paginate ul li.currentPage').addClass('currentpage');
            //Lấy thông tin tại các ô tìm kiếm
            $('#txtSearch').val(ten);
        }
    });
});

$("#varTaiKhoan").keyup(function () {
    var ten = $('#varTaiKhoan').val().trim();
    if (ten != "") {
        $('#TenError').hide();
    }
    else {
        document.getElementById('errtaikhoan').innerHTML = "Không được để trống.";
        $('#errtaikhoan').show();
    }
})

$("#varHoTen").keyup(function () {
    var ten = $('#varHoTen').val().trim();
    if (ten != "") {
        $('#errten').hide();
    }
    else {
        document.getElementById('errten').innerHTML = "Không được để trống.";
        $('#errten').show();
    }
})

$("#varMatKhau").keyup(function () {
    var ten = $('#varMatKhau').val().trim();
    if (ten != "") {
        if (!isPass(ten)) {
            document.getElementById('errmatkhau').innerHTML = "Tối thiểu 4 ký tự, tối đa 8 ký tự, ít nhất 1 chữ cái và 1 số.";
            $('#errmatkhau').show();
        }
        else {
            $('#errmatkhau').hide();
        }
    }
    else {
        document.getElementById('errmatkhau').innerHTML = "Không được để trống.";
        $('#errmatkhau').show();
    }
})
$("#varEmail").keyup(function () {
    var ten = $('#varEmail').val().trim();
    if (ten != "") {
        if (!isEmail(ten)) {
            document.getElementById('erremail').innerHTML = "Email sai định dạng";
            $('#erremail').show();
        }
        else {
            $('#erremail').hide();
        }
    }
})
function isEmail(email) {
    var regex = /^([a-zA-Z0-9_.+-])+\@(([a-zA-Z0-9-])+\.)+([a-zA-Z0-9]{2,4})+$/;
    return regex.test(email);
}

function isPass(pass) {
    var regex = /^(?=.*[A-Za-z])(?=.*\d)[A-Za-z\d]{4,8}$/;
    return regex.test(pass);
}
