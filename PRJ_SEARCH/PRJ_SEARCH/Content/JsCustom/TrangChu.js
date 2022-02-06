//Hàm tra cứu
function TraCuu() {
    var keyWord = $('#txtKeyWord').val();
    //Kiểm tra xem phần chi tiết đang ẩn hay hiện
    var checkDisplay = $('#lstDetail').is(':hidden');
    $('#lstDetail').attr('hidden', !checkDisplay);

    $("html, body").animate({ scrollTop: 650 }, 1000);
    //Xử lý sự kiện để hiện thông tin

    $.ajax({
        url: '/TrangChu/TraCuu',
        data: { keyWord: keyWord },
        type: 'GET',
        success: function (res) {
            $('#lstDetail').html(res);
        },
        error: function (res) {

            $('#noidung').text('Đã xảy ra sự cố trong quá trình tra cứu');
            $('#modalThongBao').modal('show');
        }
    })
}