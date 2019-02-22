var Employees = []
var Students = []
var Lessons = []

$(document).ready(function () {
    hideAlert();
    LoadIndexDailyScore();
    $('#table').DataTable({
        "ajax": LoadIndexDailyScore()
    })
})

function LoadIndexDailyScore() {
    $.ajax({
        type: "GET", //untuk menampilkan data
        url: "http://localhost:53126/api/DailyScores",
        async: false, // ini untuk menjalankan fungsi search dan sorting data table
        datatype: "json",
        success: function (dailyscore) {
            var html = '';
            $.each(dailyscore, function (index, val) {
                html += '<tr>';
                //html += '<td>' + i + '</td>'; ini kalau mau nampilkan nomor 1 sampai sekian
                html += '<td>' + val.Date + '</td>';
                html += '<td>' + val.Score1 + '</td>';
                html += '<td>' + val.Score2 + '</td>';
                html += '<td>' + val.Score3 + '</td>';
                html += '<td>' + val.Students.First_Name + '</td>';
                html += '<td>' + val.Lessons.Name + '</td>';
                html += '<td>' + val.Employees.First_Name + '</td>';
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
    var dailyscore = new Object(); //deklarasikan object baru yang akan disimpan nilai nilai didalamnya
    dailyscore.Date = $('#Date').val(); // simpan nilai yang ada di #Name di view kedalam object 
    dailyscore.Score1 = $('#Score1').val();
    dailyscore.Score2 = $('#Score2').val();
    dailyscore.Score3 = $('#Score3').val();
    dailyscore.Students_Id = $('#Student').val();
    dailyscore.Lessons_Id = $('#Lesson').val();
    dailyscore.Employees_Id = $('#Employee').val();
    $.ajax({
        type: "POST", //insert
        url: "http://localhost:53126/api/DailyScores",
        datatype: "json",
        data: dailyscore, //data yang akan disimpan adalah object yang di deklarasikan tadi
        success: function (result) { //kalo sukses muat ulang data kedalam tabel
            LoadIndexDailyScore();
            $('#myModal').modal('hide');
            nuke();
        }
    });
}
function Edit() {
    debugger;
    //kalau pop up ngga ketutup berarti ada yang tidak sesuai didalam success: function(result{ (contohnya LoadIndexvillage padahal diatas tulisannya LoadIndexProvince
    var dailyscore = new Object(); //deklarasikan object baru yang akan disimpan nilai nilai didalamnya
    dailyscore.Date = $('#Date').val(); // simpan nilai yang ada di #Name di view kedalam object 
    dailyscore.Score1 = $('#Score1').val();
    dailyscore.Score2 = $('#Score2').val();
    dailyscore.Score3 = $('#Score3').val();
    dailyscore.Students_Id = $('#Student').val();
    dailyscore.Lessons_Id = $('#Lesson').val();
    dailyscore.Employees_Id = $('#Employee').val();
    $.ajax({
        type: "PUT", //insert
        url: "http://localhost:53126/api/DailyScores/" + $('#Id').val(),
        datatype: "json",
        data: dailyscore, //data yang akan disimpan adalah object yang di deklarasikan tadi
        success: function (result) { //kalo sukses muat ulang data kedalam tabel
            LoadIndexDailyScore();
            $('#myModal').modal('hide');
            nuke();
        }
    });
}
function GetById(Id) {
    debugger;
    $.ajax({
        url: "http://localhost:53126/api/DailyScores/" + Id, // search
        type: "GET",
        datatype: "json",
        success: function (dailyscore) {
            $('#Id').val(dailyscore.Id);
            $('#Date').val(dailyscore.Date);
            $('#Score1').val(dailyscore.Score1);
            $('#Score2').val(dailyscore.Score2);
            $('#Score3').val(dailyscore.Score3);
            $('#Student').val(dailyscore.Students.Id);
            $('#Lesson').val(dailyscore.Lessons.Id);
            $('#Employee').val(dailyscore.Employees.Id);//udah benar
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
            url: "http://localhost:53126/api/DailyScores/" + Id,
            type: "DELETE",
            success: function (response) {
                swal({
                    title: "Deleted!",
                    text: "That data has been soft deleted.",
                    type: "success"
                },
                function () {
                    window.location.href = '/DailyScores/Index';
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
    if ($('#Date').val() == "" || ($('#Date').val() == " ")) {
        isAllValid = false; //kalau textbox nama kosong maka
        $('#Date').siblings('span.error').css('visibility', 'visible'); //ini notifikasi buat ngasi tau field belum diisi pas mencet save 
    }
    //cek dropdown Province
    if ($('#Employee').val() == "0" || $('#Employee').val() == 0) {
        isAllValid = false;
        $('#Employee').siblings('span.error').css('visibility', 'visible');
    }
    //cek dropdown Province
    if ($('#Student').val() == "0" || $('#Student').val() == 0) {
        isAllValid = false;
        $('#Student').siblings('span.error').css('visibility', 'visible');
    }

    if ($('#Lesson').val() == "0" || $('#Lesson').val() == 0) {
        isAllValid = false;
        $('#Lesson').siblings('span.error').css('visibility', 'visible');
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
    if ($('#Date').val() == "" || ($('#Date').val() == " ")) {
        isAllValid = false; //kalau textbox nama kosong maka
        $('#Date').siblings('span.error').css('visibility', 'visible'); //ini notifikasi buat ngasi tau field belum diisi pas mencet save 
    }
    //cek dropdown Province
    if ($('#Employee').val() == "0" || $('#Employee').val() == 0) {
        isAllValid = false;
        $('#Employee').siblings('span.error').css('visibility', 'visible');
    }
    //cek dropdown Province
    if ($('#Student').val() == "0" || $('#Student').val() == 0) {
        isAllValid = false;
        $('#Student').siblings('span.error').css('visibility', 'visible');
    }

    if ($('#Lesson').val() == "0" || $('#Lesson').val() == 0) {
        isAllValid = false;
        $('#Lesson').siblings('span.error').css('visibility', 'visible');
    }
    // kalau semua field sudah terisi
    if (isAllValid) {
        Edit();
    }
}

function LoadEmployee(element) {
    if (Employees.length == 0) {
        $.ajax({
            type: "GET", // get
            url: 'http://localhost:53126/api/Employees',
            success: function (data) {
                Employees = data; //Regency
                //and render Regency to element
                renderEmployee(element);
            }
        })
    } else {
        //render Regency to element if var Regencies above not empty
        renderEmployee(element);
    }
}
function renderEmployee(element) {
    var $ele = $(element);
    $ele.empty(); //kosongkan element
    $ele.append($('<option/>').val('0').text('Select')); //tambahkan village kedalam dropdown
    $.each(Employees, function (i, val) { // tambahkan village baru kedalam dropdown untuk setiap nilai yang ada didalam Regencys []
        $ele.append($('<option/>').val(val.Id).text(val.First_Name)); //id sama namanyanya Provincies
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
        $ele.append($('<option/>').val(val.Id).text(val.First_Name)); //id sama namanyanya Provincies
    })
}

function LoadLesson(element) {
    if (Lessons.length == 0) {
        $.ajax({
            type: "GET", // get
            url: 'http://localhost:53126/api/Lessons',
            success: function (data) {
                Lessons = data; //Regency
                //and render Regency to element
                renderLesson(element);
            }
        })
    } else {
        //render Regency to element if var Regencies above not empty
        renderLesson(element);
    }
}
function renderLesson(element) {
    var $ele = $(element);
    $ele.empty(); //kosongkan element
    $ele.append($('<option/>').val('0').text('Select')); //tambahkan village kedalam dropdown
    $.each(Lessons, function (i, val) { // tambahkan village baru kedalam dropdown untuk setiap nilai yang ada didalam Regencys []
        $ele.append($('<option/>').val(val.Id).text(val.Name)); //id sama namanyanya Provincies
    })
}

function nuke() {
    $('#Date').val('');
    $('#Score1').val('');
    $('#Score2').val('');
    $('#Score3').val('');
    $('#Employee').val(0);
    $('#Student').val(0);
    $('#Lesson').val(0);
    $('#Update').hide();
    $('#Save').show();
    hideAlert();
}
function hideAlert() {
    $('#Date').siblings('span.error').css('visibility', 'hidden');
    $('#Score1').siblings('span.error').css('visibility', 'hidden');
    $('#Score2').siblings('span.error').css('visibility', 'hidden');
    $('#Score3').siblings('span.error').css('visibility', 'hidden');
    $('#Employee').siblings('span.error').css('visibility', 'hidden');
    $('#Student').siblings('span.error').css('visibility', 'hidden');
    $('#Lesson').siblings('span.error').css('visibility', 'hidden');

}

LoadEmployee($('#Employee'));
LoadStudent($('#Student'));
LoadLesson($('#Lesson'));