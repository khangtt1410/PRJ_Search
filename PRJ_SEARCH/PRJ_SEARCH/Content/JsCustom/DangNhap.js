//Hàm xử lý đăng nhập
function DangNhap() {
    var taiKhoan = $('#txtTenDangNhap').val();
    var matKhau = $('#txtMatKhau').val();
    $.ajax({
        url: '/CheckValidAccount/DangNhap',
        type: 'POST',
        dataType: 'JSON',
        data: {
            taikhoan: taiKhoan,
            matkhau: matKhau
        },
        success: function (res) {
            if (res.status == true) {
                location.reload();
            } else {
                $('#errDangNhap').show();
                $('#errDangNhap span').html(res.mess);
            }
        },
        error: function (res) {

        }
    })
}
//Hàm xử lý đăng xuất
function DangXuat() {
    $.ajax({
        url: '/CheckValidAccount/DangXuat',
        type: 'POST',
        dataType: 'JSON',
        success: function (res) {
            if (res.status == true) {
                location.reload();
            } 
        },
        error: function (res) {

        }
    })
}
//Hàm xử lý sự kiện keyup của textbox tài khoản và mật khẩu
function ResetError() {
    $('#errDangNhap').hide();
    $('#errDangNhap span').html('');
}