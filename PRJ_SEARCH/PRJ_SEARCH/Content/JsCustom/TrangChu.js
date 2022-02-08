//Hàm tra cứu
function TraCuu() {
    var keyWord = $('#txtKeyWord').val();
    var tuNgonNgu = $('#ddlTuNgonNgu').val();
    var denNgonNgu = $('#ddlDenNgonNgu').val();
    //Kiểm tra xem phần chi tiết đang ẩn hay hiện
    var checkDisplay = $('#lstDetail').is(':hidden');
    if (keyWord != '' && checkDisplay == true) {
        $('#lstDetail').attr('hidden', false);
    }
    $("html, body").animate({ scrollTop: 650 }, 1000);
    //Xử lý sự kiện để hiện thông tin

    $.ajax({
        url: '/TrangChu/TraCuu',
        data: {
            keyWord: keyWord,
            tuNgonNgu: tuNgonNgu,
            denNgonNgu: denNgonNgu
        },
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
//Hàm đọc từ ngữ
function SpeakWord(id) {
    var word = $('#txtNoiDungTu_' + id).html();
    $.ajax({
        url: '/TrangChu/SpeakWord',
        dataType: 'JSON',
        type: 'POST',
        data: { word: word },
        success: function (res)
        {
            $('audio_' + id).attr('src', res.pathSave);
            $('audio_' + id).click();
        }
    })
}