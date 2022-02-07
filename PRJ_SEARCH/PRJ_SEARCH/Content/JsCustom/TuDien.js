//Khai báo mảng tạm chứa danh sách từ ngữ
var lstTuNgu = [];
//Hàm xử lý tìm kiếm, load trang theo tiêu chí tìm kiếm
function Search() {
    //Lấy thông tin tại các ô tìm kiếm
    var keyWord = $('#txtSearch').val();
    //Gọi hàm ajax
    $.ajax({
        url: '/TuDien/GetListData',
        data:
        {
            keyword: keyWord,
        },
        success: function (res) {
            $('#tblTuDien').html(res);
            //Lấy thông tin tại các ô tìm kiếm
            $('#txtSearch').val(keyWord);
        }
    })
}
//Hàm xử lý khi nhấn chuyển trang 
$(document).on('click', '#tblTuDien .paginationNavigator li a', function (e) {
    e.preventDefault();
    if ($(this).attr('href') == undefined || $.trim($(this).attr('href')) == "") return;
    //Lấy thông tin tại các ô tìm kiếm
    var keyWord = $('#txtSearch').val();
    $.ajax({
        url: $(this).attr('href'),
        data:
        {
            keyword: keyWord
        },
        type: 'GET',
        success: function (res) {
            $('#tblTuDien').html(res);

            $('#DataTables_Table_0_paginate ul li.currentPage').addClass('currentpage');
            //Lấy thông tin tại các ô tìm kiếm
            $('#txtSearch').val(keyWord);
        }
    });
});
//Hiển thị modal xác nhận
function ShowModal_XacNhan(id) {
    $('#IDTuDien_Modal').val(id);
    $('#Delete_TuDien').modal('show');
}
//Hàm xử lý xóa từ điển
function Delete() {
    var id = $('#IDTuDien_Modal').val();
    $.ajax({
        url: '/TuDien/Delete',
        dataType: 'JSON',
        type: 'GET',
        data: { id: id },
        success: function (rs) {
            if (rs.status == true) {
                $("#Delete_TuDien").modal("hide");
                $('#noidung').text('Xóa từ điển thành công.')
                $('#modalThongBao').modal('show');
                Search();
            }
        }
    })
}

//Hàm reset form thêm mới/sửa đổi
function ResetForm() {
    //reset thông tin từ điển
    $('#id').val(0);
    $('#txtMaTuDien').val('');
    $('#txtTenTuDien').val('');
    $('#txtTacGia').val('');
    $('#dllTuNgonNgu option[value="0"]').prop('selected', true);
    $('#dllDenNgonNgu option[value="0"]').prop('selected', true);

    $('#errMaTuDien').html('');
    $('#errMaTuDien').hide();
    $('#errTenTuDien').html('');
    $('#errTenTuDien').hide();
    $('#errNgonNguNguon').html('');
    $('#errNgonNguNguon').hide();
    $('#errNgonNguDich').html('');
    $('#errNgonNguDich').hide();
    ResetForm_TuNgu();
    lstTuNgu = [];
    $('#bodyTuNgu').html('');
}
//Hàm reset form từ ngữ trong từ điển
function ResetForm_TuNgu() {
    //reset thông tin từ ngữ
    $('#txtIDTuNgu').val(0);
    $('#txtNoiDungTu').val('');
    $('textarea').each(function () {
        var name = $(this).attr('name');
        CKEDITOR.replace(name);
    });
    CKEDITOR.instances["txtNghiaCuaTu"].setData('');
    CKEDITOR.instances["txtTuDongNghia"].setData('');
    CKEDITOR.instances["txtTuTraiNghia"].setData('');
    CKEDITOR.instances["txtViDu"].setData('');
    CKEDITOR.instances["txtThanhNgu"].setData('');
    CKEDITOR.instances["txtCacCumDongTu"].setData('');
    CKEDITOR.instances["txtTuLienQuan"].setData('');

}
//Hàm xử lý gọi form thêm mới/ sửa đổi
function ShowModalAddEdit(id) {
    ResetForm();
    if (id == null || id == 0) {
        $('#TieuDe').html("Thêm mới từ điển");
    }
    else {
        $('#TieuDe').html("Cập nhật thông tin từ điển");
    }
    $.ajax({
        url: "/TuDien/GetData",
        data: {
            id: id
        },
        type: 'GET',
        dataType: 'JSON',
        success: function (result) {
            if (result.status == true) {
                //Load danh sách ngôn ngữ
                var htmlNgonNgu = '';
                $.each(result.lstNgonNgu, function (i, item) {
                    htmlNgonNgu += '<option value="' + item.ID + '">' + item.TenNgonNgu + '</option>'
                });
                $('#dllTuNgonNgu').append(htmlNgonNgu);
                $('#dllDenNgonNgu').append(htmlNgonNgu);
                //Load chi tiết thông tin từ điển
                $('#id').val(id);
                $('#txtMaTuDien').val(result.data.MaTuDien);
                $('#txtTenTuDien').val(result.data.TenTuDien);
                $('#txtTacGia').val(result.data.TacGia);
                $('#dllTuNgonNgu option[value="' + result.data.IDNgonNguNguon + '"]').prop('selected', true);
                $('#dllDenNgonNgu option[value="' + result.data.IDNgonNguDich + '"]').prop('selected', true);
                //Load danh sách từ ngữ vào bảng tạm
                $.each(result.lstTuNgu, function (i, item) {
                    var objTuNgu = {};
                    objTuNgu.ID = item.ID;
                    objTuNgu.NoiDungTu = item.NoiDungTu;
                    objTuNgu.NghiaCuaTu = item.NghiaCuaTu;
                    objTuNgu.TuDongNghia = item.TuDongNghia;
                    objTuNgu.TuTraiNghia = item.TuTraiNghia;
                    objTuNgu.ViDu = item.ViDu;
                    objTuNgu.ThanhNgu = item.ThanhNgu;
                    objTuNgu.CumDongTu = item.CumDongTu;
                    objTuNgu.TuLienQuan = item.TuLienQuan;
                    lstTuNgu.push(objTuNgu);
                })
                ResetTableTuNgu();
            }
        }
    });
    $("#mdlTuDien_AddEdit").modal("show");
}
//Hàm lưu từ điển
function Save() {
    //Kiểm tra ràng buộc của các trường thông tin từ điển
    var isSave = true;
    var maTuDien = $('#txtMaTuDien').val().trim();
    var tenTuDien = $('#txtTenTuDien').val().trim();
    var tacGia = $('#txtTacGia').val().trim();
    var ngonNguNguon = $('#dllTuNgonNgu').val();
    var ngonNguDich = $('#dllDenNgonNgu').val();
    var id = $('#id').val();

    if (maTuDien == "") {
        isSave = false;
        $('#errMaTuDien').html("Không được để trống");
        $('#errMaTuDien').show();
    }
    if (tenTuDien == "") {
        isSave = false;
        $('#errTenTuDien').html("Không được để trống");
        $('#errTenTuDien').show();
    }
    if (ngonNguNguon == 0) {
        isSave = false;
        $('#errNgonNguNguon').html("Không được để trống");
        $('#errNgonNguNguon').show();
    }
    if (ngonNguDich == 0) {
        isSave = false;
        $('#errNgonNguDich').html("Không được để trống");
        $('#errNgonNguDich').show();
    }
    if (isSave == true) {
        var formData = new FormData();
        //Thông tin từ điển
        formData.append("MaTuDien", maTuDien);
        formData.append("TenTuDien", tenTuDien);
        formData.append("TacGia", tacGia);
        formData.append("IDNgonNguNguon", ngonNguNguon);
        formData.append("IDNgonNguDich", ngonNguDich);
        formData.append("ID", id);
        //Danh sách từ ngữ trong từ điển
        formData.append("lstTuNgu", JSON.stringify(lstTuNgu));

        $.ajax({
            async: false,
            type: 'POST',
            url: "/TuDien/Save",
            data: formData,
            cache: false,
            contentType: false,
            processData: false,
            success: function (response) {
                if (response.status == true) {
                    //Hiển thị thông báo
                    $('#mdlTuDien_AddEdit').modal('hide');
                    $('#noidung').text(response.mess);
                    $('#modalThongBao').modal('show');
                    //Load lại trang
                    Search();

                }
            },
            error: function (err) {
                $('#noidung').text('Đã xảy ra sự cố trong quá trình lưu trữ thông tin từ điển');
                $('#modalThongBao').modal('show');
            }
        });
    }
}

//Hàm thêm mới từ ngữ vào mảng tạm
function ThemTuNgu_MangTam() {
    var idTuNgu = $('#txtIDTuNgu').val();
    var noiDungTu = $('#txtNoiDungTu').val();
    var nghiaCuaTu = CKEDITOR.instances["txtNghiaCuaTu"].getData();
    var tuDongNghia = CKEDITOR.instances["txtTuDongNghia"].getData();
    var tuTraiNghia = CKEDITOR.instances["txtTuTraiNghia"].getData();
    var viDu = CKEDITOR.instances["txtViDu"].getData();
    var thanhNgu = CKEDITOR.instances["txtThanhNgu"].getData();
    var cumDongTu = CKEDITOR.instances["txtCacCumDongTu"].getData();
    var tuLienQuan = CKEDITOR.instances["txtTuLienQuan"].getData();
    //Khởi tạo bản ghi 
    var objTuNgu = {};
    objTuNgu.ID = idTuNgu;
    objTuNgu.NoiDungTu = noiDungTu;
    objTuNgu.NghiaCuaTu = nghiaCuaTu;
    objTuNgu.TuDongNghia = tuDongNghia;
    objTuNgu.TuTraiNghia = tuTraiNghia;
    objTuNgu.ViDu = viDu;
    objTuNgu.ThanhNgu = thanhNgu;
    objTuNgu.CumDongTu = cumDongTu;
    objTuNgu.TuLienQuan = tuLienQuan;

    var valid = true;
    if (noiDungTu.trim() == "") {
        valid = false;
        $('#errNoiDungTu').html("Không được để trống");
        $('#errNoiDungTu').show();
    }
    if (nghiaCuaTu.trim() == "") {
        valid = false;
        $('#errNghiaCuaTu').html("Không được để trống");
        $('#errNghiaCuaTu').show();
    }
    if (valid) {
        //Kiểm tra xem từ ngữ đó đã xuất hiện trong từ điển hay chưa. Nếu có rồi thì cập nhật, chưa có sẽ thêm vào mảng
        var existCheck = lstTuNgu.filter(k => k.NoiDungTu.toLowerCase() == noiDungTu.toLowerCase())[0];
        if (existCheck != undefined) {
            existCheck.NghiaCuaTu = nghiaCuaTu;
            existCheck.TuDongNghia = tuDongNghia;
            existCheck.TuTraiNghia = tuTraiNghia;
            existCheck.ViDu = viDu;
            existCheck.ThanhNgu = thanhNgu;
            existCheck.CumDongTu = cumDongTu;
            existCheck.TuLienQuan = tuLienQuan;
        } else {

            //Thêm bản ghi vào mảng
            lstTuNgu.push(objTuNgu);
        }
        //reset lại danh sách từ ngữ 
        ResetTableTuNgu();
        ResetForm_TuNgu();
    } else {
        return false;
    }
}
//Hàm reset lại danh sách từ điển theo mảng tạm
function ResetTableTuNgu() {
    var html = '';
    $.each(lstTuNgu, function (i, item) {
        html += '<tr>' +
            '<td class="left">' + item.NoiDungTu + '</td>' +
            '<td class="left">' + item.NghiaCuaTu + '</td>' +
            '<td class="center"><i class="fa fa-edit" onclick="SuaDoiTuNgu(\'' + item.NoiDungTu + '\')" style="margin-right:5px"></i><i class="fa fa-trash" onclick="XoaBoTuNgu(\'' + item.NoiDungTu + '\')"></i></td>' +
            '</tr>';
    })
    $('#bodyTuNgu').html(html);
}
//Hàm sửa đổi từ ngữ
function SuaDoiTuNgu(noiDungTu) {
    var existObj = lstTuNgu.filter(k => k.NoiDungTu.toLowerCase() == noiDungTu.toLowerCase())[0];
    $('#txtIDTuNgu').val(existObj.ID);
    $('#txtNoiDungTu').val(existObj.NoiDungTu);
    CKEDITOR.instances["txtNghiaCuaTu"].setData(existObj.NghiaCuaTu);
    CKEDITOR.instances["txtTuDongNghia"].setData(existObj.TuDongNghia);
    CKEDITOR.instances["txtTuTraiNghia"].setData(existObj.TuTraiNghia);
    CKEDITOR.instances["txtViDu"].setData(existObj.ViDu);
    CKEDITOR.instances["txtThanhNgu"].setData(existObj.ThanhNgu);
    CKEDITOR.instances["txtCacCumDongTu"].setData(existObj.CumDongTu);
    CKEDITOR.instances["txtTuLienQuan"].setData(existObj.TuLienQuan);
}
//Hàm xóa từ ngữ
function XoaBoTuNgu(noiDungTu) {
    var existCheck = lstTuNgu.filter(k => k.NoiDungTu.toLowerCase() == noiDungTu.toLowerCase())[0];
    var index = lstTuNgu.indexOf(existCheck);
    lstTuNgu.splice(index, 1);
    ResetTableTuNgu();
}