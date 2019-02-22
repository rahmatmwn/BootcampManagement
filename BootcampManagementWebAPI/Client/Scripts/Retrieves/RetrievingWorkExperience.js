var Students = []
$(document).ready(function () {
    hideAlert();
    LoadIndexWorkExperience();
    $('#table').DataTable({
        "ajax": LoadIndexWorkExperience()
    })
})

function LoadIndexWorkExperience() {
    $.ajax({
        type: "GET", //untuk menampilkan data
        url: "http://localhost:53126/api/WorkExperiences",
        async: false, // ini untuk menjalankan fungsi search dan sorting data table
        datatype: "json",
        success: function (workExperience) {
            var html = '';
            $.each(workExperience, function (index, val) {
                html += '<tr>';
                //html += '<td>' + i + '</td>'; ini kalau mau nampilkan nomor 1 sampai sekian
                html += '<td>' + val.Name + '</td>';
                html += '<td>' + val.Position + '</td>';
                html += '<td>' + val.Description + '</td>';
                html += '<td>' + val.DateStart + '</td>';
                html += '<td>' + val.DateEnd + '</td>';
                html += '<td>' + val.Students.FirstName + '</td>';
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
    var workExperience = new Object(); //deklarasikan object baru yang akan disimpan nilai nilai didalamnya
    workExperience.Position = $('#Name').val();
    workExperience.Position = $('#Position').val(); // simpan nilai yang ada di #Name di view kedalam object 
    workExperience.Description = $('#Description').val();
    workExperience.DateStart = $('#DateStart').val();
    workExperience.DateEnd = $('#DateEnd').val();
    workExperience.Students_Id = $('#Student').val();
    $.ajax({
        type: "POST", //insert
        url: "http://localhost:53126/api/WorkExperiences",
        datatype: "json",
        data: workExperience, //data yang akan disimpan adalah object yang di deklarasikan tadi
        success: function (result) { //kalo sukses muat ulang data kedalam tabel
            LoadIndexWorkExperience();
            $('#myModal').modal('hide');
            nuke();
        }
    });
}
function Edit() {
    debugger;
    //kalau pop up ngga ketutup berarti ada yang tidak sesuai didalam success: function(result{ (contohnya LoadIndexvillage padahal diatas tulisannya LoadIndexProvince
    var workExperience = new Object(); //deklarasikan object baru yang akan disimpan nilai nilai didalamnya
    workExperience.Position = $('#Name').val();
    workExperience.Position = $('#Position').val(); // simpan nilai yang ada di #Name di view kedalam object 
    workExperience.Description = $('#Description').val();
    workExperience.DateStart = $('#DateStart').val();
    workExperience.DateEnd = $('#DateEnd').val();
    workExperience.Students_Id = $('#Student').val();
    $.ajax({
        type: "PUT", //insert
        url: "http://localhost:53126/api/WorkExperiences/" + $('#Id').val(),
        datatype: "json",
        data: workExperience, //data yang akan disimpan adalah object yang di deklarasikan tadi
        success: function (result) { //kalo sukses muat ulang data kedalam tabel
            LoadIndexWorkExperience();
            $('#myModal').modal('hide');
            nuke();
        }
    });
}
function GetById(Id) {
    debugger;
    $.ajax({
        url: "http://localhost:53126/api/WorkExperiences/" + Id, // search
        type: "GET",
        datatype: "json",
        success: function (workExperience) {
            $('#Id').val(workExperience.Id);
            $('#Name').val(workExperience.Name);
            $('#Position').val(workExperience.Position);
            $('#Description').val(workExperience.Description);
            $('#DateStart').val(workExperience.DateStart);
            $('#DateEnd').val(workExperience.DateEnd);//udah benar
            $('#Student').val(workExperience.Students.Id);
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
            url: "http://localhost:53126/api/WorkExperiences/" + Id,
            type: "DELETE",
            success: function (response) {
                swal({
                    title: "Deleted!",
                    text: "That data has been soft deleted.",
                    type: "success"
                },
                function () {
                    window.location.href = '/WorkExperiences/Index';
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
    if ($('#Name').val() == "" || ($('#Name').val() == " ")) {
        isAllValid = false; //kalau textbox nama kosong maka
        $('#Name').siblings('span.error').css('visibility', 'visible'); //ini notifikasi buat ngasi tau field belum diisi pas mencet save 
    }
    if ($('#Position').val() == "" || ($('#Position').val() == " ")) {
        isAllValid = false; //kalau textbox nama kosong maka
        $('#Position').siblings('span.error').css('visibility', 'visible'); //ini notifikasi buat ngasi tau field belum diisi pas mencet save 
    }
    //cek textbox nama
    if ($('#Description').val() == "" || ($('#Description').val() == " ")) {
        isAllValid = false; //kalau textbox nama kosong maka
        $('#Description').siblings('span.error').css('visibility', 'visible'); //ini notifikasi buat ngasi tau field belum diisi pas mencet save 
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
    if ($('#Name').val() == "" || ($('#Name').val() == " ")) {
        isAllValid = false; //kalau textbox nama kosong maka
        $('#Name').siblings('span.error').css('visibility', 'visible'); //ini notifikasi buat ngasi tau field belum diisi pas mencet save 
    }
    //cek textbox nama
    if ($('#Position').val() == "" || ($('#Position').val() == " ")) {
        isAllValid = false; //kalau textbox nama kosong maka
        $('#Position').siblings('span.error').css('visibility', 'visible'); //ini notifikasi buat ngasi tau field belum diisi pas mencet save 
    }
    //cek textbox nama
    if ($('#Description').val() == "" || ($('#Description').val() == " ")) {
        isAllValid = false; //kalau textbox nama kosong maka
        $('#Description').siblings('span.error').css('visibility', 'visible'); //ini notifikasi buat ngasi tau field belum diisi pas mencet save 
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
        $ele.append($('<option/>').val(val.Id).text(val.FirstName)); //id sama namanyanya Provincies
    })
}

function nuke() {
    $('#Name').val('');
    $('#Position').val('');
    $('#Description').val('');
    $('#DateStart').val('');
    $('#DateEnd').val('');
    $('#Student').val(0);
    $('#Update').hide();
    $('#Save').show();
    hideAlert();
}
function hideAlert() {
    $('#Name').siblings('span.error').css('visibility', 'hidden');
    $('#Position').siblings('span.error').css('visibility', 'hidden');
    $('#Description').siblings('span.error').css('visibility', 'hidden');
    $('#DateStart').siblings('span.error').css('visibility', 'hidden');
    $('#DateEnd').siblings('span.error').css('visibility', 'hidden');
    $('#Student').siblings('span.error').css('visibility', 'hidden');
}

LoadStudent($('#Student'));