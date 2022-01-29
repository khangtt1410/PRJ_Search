//Hàm tra cứu
function TraCuu() {
    var keyWord = $('#txtKeyWord').val();
    //Kiểm tra xem phần chi tiết đang ẩn hay hiện
    var checkDisplay = $('#lstDetail').is(':hidden');
    $('#lstDetail').attr('hidden', !checkDisplay);

    $("html, body").animate({ scrollTop: 650 }, 1000);
    //Xử lý sự kiện để hiện thông tin
    //...
}