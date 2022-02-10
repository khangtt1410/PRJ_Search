//Hàm tra cứu
function TraCuu() {
    var keyWord = $('#txtKeyWord').val();
    var tuNgonNgu = $('#ddlTuNgonNgu').val();
    var denNgonNgu = $('#ddlDenNgonNgu').val();
    //Kiểm tra xem phần chi tiết đang ẩn hay hiện
    var checkDisplay = $('#bodyResult').is(':hidden');
    if (keyWord != '' && checkDisplay == true) {
        $('#bodyResult').attr('hidden', false);
    }
    $("html, body").animate({ scrollTop: 650 }, 1000);
    //Xử lý sự kiện để hiện thông tin

    $.ajax({
        url: '/TrangChu/KetQuaTraCuu',
        data: {
            keyWord: keyWord,
            tuNgonNgu: tuNgonNgu,
            denNgonNgu: denNgonNgu
        },
        type: 'GET',
        success: function (res) {
            $('#bodyResult').html(res);
        },
        error: function (res) {

            $('#noidung').text('Đã xảy ra sự cố trong quá trình tra cứu');
            $('#modalThongBao').modal('show');
        }
    })
}
//Hàm đọc từ ngữ
function SpeakWord(id) {
    $('#audio_' + id)[0].load();
    $('#audio_' + id)[0].play();
    var time = $('#audio_' + id)[0].duration;
    $('#iconplay_' + id).removeClass('ti-control-play');
    $('#iconplay_' + id).addClass('ti-control-pause');

    var f_duration = 0; 
    document.getElementById('audio_' + id).addEventListener('canplaythrough', function (e) {
        f_duration = Math.round(e.currentTarget.duration);
        setTimeout(() => {
            $('#iconplay_' + id).removeClass('ti-control-pause');
            $('#iconplay_' + id).addClass('ti-control-play');
        }, f_duration + 600)
    });
}
//Hàm xử lý nhấn nút enter
function OnKeyPress_Enter_Search(e) {
    if (e.keyCode == '13') {
        var keyWord = $('#txtKeyWord').val();
        if (keyWord != "") {
            TraCuu();
        }
    }
}

