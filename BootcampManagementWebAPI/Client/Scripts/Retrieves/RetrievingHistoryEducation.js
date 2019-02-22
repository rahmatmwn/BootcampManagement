var Universities = []
var Students = []

$(document).ready(function () {
    hideAlert();
    LoadIndexHistoryEducation();
    $('#table').DataTable({
        "ajax": LoadIndexHistoryEducation()
    })
})

function LoadIndexHistoryEducation() {
    $.ajax({
        type: "GET", //untuk menampilkan data
        url: "http://localhost:53126/api/HistoryEducations",
        async: false, // ini untuk menjalankan fungsi search dan sorting data table
        datatype: "json",
        success: function (historyeducation) {
            var html = '';
            $.each(historyeducation, function (index, val) {
                html += '<tr>';
                //html += '<td>' + i + '</td>'; ini kalau mau nampilkan nomor 1 sampai sekian
                html += '<td>' + val.Degree + '</td>';
                html += '<td>' + val.StudyProgram + '</td>';
                html += '<td>' + val.DateStart + '</td>';
                html += '<td>' + val.DateEnd + '</td>';
                html += '<td>' + val.Ipk + '</td>';
                html += '<td>' + val.Universities.Name + '</td>';
                html += '<td>' + val.Students.Name + '</td>';
                html += '<td> <a href="#" onclick="return GetById(' + val.Id + ')"> Edit </a>';
                html += '| <a href="#" onclick="return Delete(' + val.Id + ')"> Delete </a>  </td>';
                html += '</tr>';
                //i++;
            });
            $('.tbody').html(html);// ini untuk menerapkan koding html diatas

        }
    });
}
function Save() {
    //kalau pop up ngga ketutup berarti ada yang tidak sesuai didalam success: function(result{ (contohnya LoadIndexvillage padahal diatas tulisannya LoadIndexProvince
    var historyeducation = new Object(); //deklarasikan object baru yang akan disimpan nilai nilai didalamnya
    historyeducation.Degree = $('#Degree').val(); // simpan nilai yang ada di #Name di view kedalam object 
    historyeducation.StudyProgram = $('#StudyProgram').val();
    historyeducation.DateStart = $('#DateStart').val();
    historyeducation.DateEnd = $('#DateEnd').val();
    historyeducation.Ipk = $('#Ipk').val();
    historyeducation.Universities_Id = $('#University').val();
    historyeducation.Students_Id = $('#Student').val();
    $.ajax({
        type: "POST", //insert
        url: "http://localhost:53126/api/HistoryEducations",
        datatype: "json",
        data: historyeducation, //data yang akan disimpan adalah object yang di deklarasikan tadi
        success: function (result) { //kalo sukses muat ulang data kedalam tabel
            LoadIndexHistoryEducation();
            $('#myModal').modal('hide');
            nuke();
        }
    });
}
function Edit() {
    debugger;
    //kalau pop up ngga ketutup berarti ada yang tidak sesuai didalam success: function(result{ (contohnya LoadIndexvillage padahal diatas tulisannya LoadIndexProvince
    var historyeducation = new Object(); //deklarasikan object baru yang akan disimpan nilai nilai didalamnya
    historyeducation.Degree = $('#Degree').val(); // simpan nilai yang ada di #Name di view kedalam object 
    historyeducation.StudyProgram = $('#StudyProgram').val();
    historyeducation.DateStart = $('#DateStart').val();
    historyeducation.DateEnd = $('#DateEnd').val();
    historyeducation.Ipk = $('#Ipk').val();
    historyeducation.Universities_Id = $('#University').val();
    historyeducation.Students_Id = $('#Student').val();
    $.ajax({
        type: "PUT", //insert
        url: "http://localhost:53126/api/HistoryEducations/" + $('#Id').val(),
        datatype: "json",
        data: historyeducation, //data yang akan disimpan adalah object yang di deklarasikan tadi
        success: function (result) { //kalo sukses muat ulang data kedalam tabel
            LoadIndexHistoryEducation();
            $('#myModal').modal('hide');
            nuke();
        }
    });
}
function GetById(Id) {
    debugger;
    $.ajax({
        url: "http://localhost:53126/api/HistoryEducations/" + Id, // search
        type: "GET",
        datatype: "json",
        success: function (historyeducation) {
            $('#Id').val(historyeducation.Id);
            $('#Degree').val(historyeducation.Degree);
            $('#StudyProgram').val(historyeducation.StudyProgram);
            $('#DateStart').val(historyeducation.DateStart);
            $('#DateEnd').val(historyeducation.DateEnd);
            $('#Ipk').val(historyeducation.Ipk);
            $('#University').val(historyeducation.Universities.Id);//udah benar
            $('#Student').val(historyeducation.Students.Id);
            $('#myModal').modal('show');
            $('#Update').show();
            $('#Save').hide();
        }
    });
}
function Delete(Id) {
    swal({ // popup konfirmasi delete swal 
        title: "Are you sure want to delete this?",
        text: "You will not be able to recover this!",
        type: "warning",
        showCancelButton: true,
        confirmButtonColor: "#DD6B55",
        confirmButtonText: "Yes, Delete it",
        closeOnConfirm: false
    }, function () { // fungsi jika user memilih untuk menghapus
        $.ajax({
            url: "http://localhost:53126/api/HistoryEducations/" + Id,
            type: "DELETE",
            success: function (response) {
                swal({
                    title: "Deleted!",
                    text: "That data has been soft deleted.",
                    type: "success"
                },
                function () {
                    window.location.href = '/HistoryEducations/Index';
                });
            },
            error: function (response) {
                swal("Oops", "We could not connect to the server!", "error");
            }
        });
    });
}
function validationInsert() {
    hideAlert(); // setiap kali ngeklik tombol save ilangkan dulu errornya baru cek lagi satu satu
    var isAllValid = true; //asumsi semua textbox sudah terisi
    //cek textbox nama
    if ($('#Degree').val() == "" || ($('#Degree').val() == " ")) {
        isAllValid = false; //kalau textbox nama kosong maka
        $('#Degree').siblings('span.error').css('visibility', 'visible'); //ini notifikasi buat ngasi tau field belum diisi pas mencet save 
    }
    //cek textbox nama
    if ($('#StudyProgram').val() == "" || ($('#StudyProgram').val() == " ")) {
        isAllValid = false; //kalau textbox nama kosong maka
        $('#StudyProgram').siblings('span.error').css('visibility', 'visible'); //ini notifikasi buat ngasi tau field belum diisi pas mencet save 
    }
    //cek textbox nama
    if ($('#DateStart').val() == "" || ($('#DateStart').val() == " ")) {
        isAllValid = false; //kalau textbox nama kosong maka
        $('#DateStart').siblings('span.error').css('visibility', 'visible'); //ini notifikasi buat ngasi tau field belum diisi pas mencet save 
    }
    //cek textbox nama
    if ($('#DateEnd').val() == "" || ($('#DateEnd').val() == " ")) {
        isAllValid = false; //kalau textbox nama kosong maka
        $('#DateEnd').siblings('span.error').css('visibility', 'visible'); //ini notifikasi buat ngasi tau field belum diisi pas mencet save 
    }
    //cek textbox nama
    if ($('#Ipk').val() == "" || ($('#Ipk').val() == " ")) {
        isAllValid = false; //kalau textbox nama kosong maka
        $('#Ipk').siblings('span.error').css('visibility', 'visible'); //ini notifikasi buat ngasi tau field belum diisi pas mencet save 
    }
    //cek dropdown Province
    if ($('#University').val() == "0" || $('#University').val() == 0) {
        isAllValid = false;
        $('#University').siblings('span.error').css('visibility', 'visible');
    }
    //cek dropdown Province
    if ($('#Student').val() == "0" || $('#Student').val() == 0) {
        isAllValid = false;
        $('#Student').siblings('span.error').css('visibility', 'visible');
    }
    // kalau semua field sudah terisi
    if (isAllValid) {
        Save();
    }
}
function validationUpdate() {
    hideAlert(); // setiap kali ngeklik tombol save ilangkan dulu errornya baru cek lagi satu satu
    var isAllValid = true; //asumsi semua textbox sudah terisi
    //cek textbox nama
    if ($('#Degree').val() == "" || ($('#Degree').val() == " ")) {
        isAllValid = false; //kalau textbox nama kosong maka
        $('#Degree').siblings('span.error').css('visibility', 'visible'); //ini notifikasi buat ngasi tau field belum diisi pas mencet save 
    }
    //cek textbox nama
    if ($('#StudyProgram').val() == "" || ($('#StudyProgram').val() == " ")) {
        isAllValid = false; //kalau textbox nama kosong maka
        $('#StudyProgram').siblings('span.error').css('visibility', 'visible'); //ini notifikasi buat ngasi tau field belum diisi pas mencet save 
    }
    //cek textbox nama
    if ($('#DateStart').val() == "" || ($('#DateStart').val() == " ")) {
        isAllValid = false; //kalau textbox nama kosong maka
        $('#DateStart').siblings('span.error').css('visibility', 'visible'); //ini notifikasi buat ngasi tau field belum diisi pas mencet save 
    }
    //cek textbox nama
    if ($('#DateEnd').val() == "" || ($('#DateEnd').val() == " ")) {
        isAllValid = false; //kalau textbox nama kosong maka
        $('#DateEnd').siblings('span.error').css('visibility', 'visible'); //ini notifikasi buat ngasi tau field belum diisi pas mencet save 
    }
    //cek textbox nama
    if ($('#Ipk').val() == "" || ($('#Ipk').val() == " ")) {
        isAllValid = false; //kalau textbox nama kosong maka
        $('#Ipk').siblings('span.error').css('visibility', 'visible'); //ini notifikasi buat ngasi tau field belum diisi pas mencet save 
    }
    //cek dropdown Province
    if ($('#University').val() == "0" || $('#University').val() == 0) {
        isAllValid = false;
        $('#University').siblings('span.error').css('visibility', 'visible');
    }
    //cek dropdown Province
    if ($('#Student').val() == "0" || $('#Student').val() == 0) {
        isAllValid = false;
        $('#Student').siblings('span.error').css('visibility', 'visible');
    }
    // kalau semua field sudah terisi
    if (isAllValid) {
        Edit();
    }
}

function LoadUniversity(element) {
    if (Universities.length == 0) {
        $.ajax({
            type: "GET", // get
            url: 'http://localhost:53126/api/Universities',
            success: function (data) {
                Universities = data; //Regency
                //and render Regency to element
                renderUniversity(element);
            }
        })
    } else {
        //render Regency to element if var Regencies above not empty
        renderUniversity(element);
    }
}
function renderUniversity(element) {
    var $ele = $(element);
    $ele.empty(); //kosongkan element
    $ele.append($('<option/>').val('0').text('Select')); //tambahkan village kedalam dropdown
    $.each(Universities, function (i, val) { // tambahkan village baru kedalam dropdown untuk setiap nilai yang ada didalam Regencys []
        $ele.append($('<option/>').val(val.Id).text(val.Name)); //id sama namanyanya Provincies
    })
}

function LoadStudent(element) {
    if (Students.length == 0) {
        $.ajax({
            type: "GET", // get
            url: 'http://localhost:53126/api/Students',
            success: function (data) {
                Students = data; //Regency
                //and render Regency to element
                renderStudent(element);
            }
        })
    } else {
        //render Regency to element if var Regencies above not empty
        renderStudent(element);
    }
}
function renderStudent(element) {
    var $ele = $(element);
    $ele.empty(); //kosongkan element
    $ele.append($('<option/>').val('0').text('Select')); //tambahkan village kedalam dropdown
    $.each(Students, function (i, val) { // tambahkan village baru kedalam dropdown untuk setiap nilai yang ada didalam Regencys []
        $ele.append($('<option/>').val(val.Id).text(val.Name)); //id sama namanyanya Provincies
    })
}

function nuke() {
    $('#Degree').val('');
    $('#StudyProgram').val('');
    $('#DateStart').val('');
    $('#DateEnd').val('');
    $('#Ipk').val('');
    $('#University').val(0);
    //$('#Student').val(0);
    $('#Update').hide();
    $('#Save').show();
    hideAlert();
}
function hideAlert() {
    $('#Degree').siblings('span.error').css('visibility', 'hidden');
    $('#StudyProgram').siblings('span.error').css('visibility', 'hidden');
    $('#DateStart').siblings('span.error').css('visibility', 'hidden');
    $('#DateEnd').siblings('span.error').css('visibility', 'hidden');
    $('#Ipk').siblings('span.error').css('visibility', 'hidden');
    $('#University').siblings('span.error').css('visibility', 'hidden');
    //$('#Student').siblings('span.error').css('visibility', 'hidden');
}

LoadUniversity($('#University'));
LoadStudent($('#Student'));