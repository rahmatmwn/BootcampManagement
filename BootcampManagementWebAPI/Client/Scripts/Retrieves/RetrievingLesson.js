var Departments = []
var Employees = []
$(document).ready(function () {
    hideAlert();
    LoadIndexLesson();
    $('#table').DataTable({
        "ajax": LoadIndexLesson()
    })
})

function LoadEmployee(element) {
    if (Employees.length == 0) {
        $.ajax({
            type: "GET", // get
            url: 'http://localhost:53126/api/Employees',
            success: function (data) {
                Employees = data; //Class
                //and render Class to element
                renderEmployee(element);
            }
        })
    } else {
        //render Class to element if var Classes above not empty
        renderEmployee(element);
    }
}
function renderEmployee(element) {
    var $ele = $(element);
    $ele.empty(); //kosongkan element
    $ele.append($('<option/>').val('0').text('Select')); //tambahkan item kedalam dropdown
    $.each(Employees, function (i, val) { // tambahkan item baru kedalam dropdown untuk setiap nilai yang ada didalam Classs []
        $ele.append($('<option/>').val(val.Id).text(val.First_Name)); //id sama namanyanya Provincies
    })
}

function LoadDepartment(element) {
    if (Departments.length == 0) {
        $.ajax({
            type: "GET", // get
            url: 'http://localhost:53126/api/Departments',
            success: function (data) {
                Departments = data; //Lesson
                //and render Lesson to element
                renderDepartment(element); 
            }
        })
    } else {
        //render Lesson to element if var Lessons above not empty
        renderDepartment(element);
    }
}
function renderDepartment(element) {
    var $ele = $(element);
    $ele.empty(); //kosongkan element
    $ele.append($('<option/>').val('0').text('Select')); //tambahkan item kedalam dropdown
    $.each(Departments, function (i, val) { // tambahkan item baru kedalam dropdown untuk setiap nilai yang ada didalam Lessons []
        $ele.append($('<option/>').val(val.Id).text(val.Name)); //id sama namanyanya Provincies
    })
}


function LoadIndexLesson() {
    $.ajax({
        type: "GET", //untuk menampilkan data
        url: "http://localhost:53126/api/Lessons",
        async: false, // ini untuk menjalankan fungsi search dan sorting data table
        datatype: "json",
        success: function (lesson) {
            var html = '';
            $.each(lesson, function (index, val) {
                html += '<tr>';
                //html += '<td>' + i + '</td>'; ini kalau mau nampilkan nomor 1 sampai sekian
                html += '<td>' + val.Name + '</td>';
                html += '<td>' + val.Level + '</td>';
                html += '<td>' + val.LinkFile + '</td>';
                html += '<td>' + val.Departments.Name + '</td>';
                html += '<td>' + val.Employees.First_Name + '</td>'
                html += '<td>' + val.Date + '</td>';
                html += '<td> <a href="#" onclick="return GetById('+val.Id+')"> Edit </a>';
                html += '| <a href="#" onclick="return Delete('+val.Id+')"> Delete </a>  </td>';
                html += '</tr>';
                //i++;
            });
            $('.tbody').html(html);// ini untuk menerapkan koding html diatas

        }
    });
}
function Save() {
    //kalau pop up ngga ketutup berarti ada yang tidak sesuai didalam success: function(result{ (contohnya LoadIndexItem padahal diatas tulisannya LoadIndexDepartment
    var item = new Object(); //deklarasikan object baru yang akan disimpan nilai nilai didalamnya
    item.Name = $('#Name').val(); 
    item.Level = $('#Level').val();
    item.Date = $('#Date').val();
    item.LinkFile = $('#LinkFile').val();
    item.Department_Id = $('#Department').val();
    item.Employee_Id = $('#Employee').val();
    $.ajax({
        type: "POST", //insert
        url: "http://localhost:53126/api/Lessons",
        datatype: "json",
        data: item, //data yang akan disimpan adalah object yang di deklarasikan tadi
        success: function (result) { //kalo sukses muat ulang data kedalam tabel
            LoadIndexLesson();
            $('#myModal').modal('hide');
            $('#Name').val('');
            $('#Level').val('');
            $('#Date').val('');
            $('#Department').val(0);
            $('#Employee').val(0);
            $('#LinkFile').val('');
        }
    });
}
function Edit() {
    debugger;
    //kalau pop up ngga ketutup berarti ada yang tidak sesuai didalam success: function(result{
    var item = new Object(); // sama kayak di save
    item.Name = $('#Name').val();
    item.Level = $('#Level').val();
    item.Date = $('#Date').val();
    item.LinkFile = $('#LinkFile').val();
    item.Department_Id = $('#Department').val();
    item.Employee_Id = $('#Employee').val();
    $.ajax({
        type: "PUT", //put untuk update
        url: "http://localhost:53126/api/Lessons/" + $('#Id').val(),
        datatype: "json",
        data: item,
        success: function (result) {
            LoadIndexLesson();
            $('#myModal').modal('hide');
            $('#Name').val('');
            $('#Level').val('');
            $('#Date').val('');
            $('#Department').val(0);
            $('#Employee').val(0);
            $('#LinkFile').val('');
        }
    });
};
function GetById(Id) {
    debugger;
    $.ajax({
        url: "http://localhost:53126/api/Lessons/" + Id, // search
        type: "GET",
        datatype: "json",
        success: function (item) {
            $('#Id').val(item.Id);
            $('#Name').val(item.Name);
            $('#Level').val(item.Level);
            $('#Date').val(item.Date);
            $('#LinkFile').val(item.LinkFile);
            $('#Department').val(item.Departments.Id);
            $('#Employee').val(item.Employees.Id);
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
            url: "http://localhost:53126/api/Lessons/" + Id,
            type: "DELETE",
            success: function (response) {
                swal({
                    title: "Deleted!",
                    text: "That data has been soft deleted.",
                    type: "success"
                },
                function () {
                    window.location.href = '/Lessons/Index'; // ini belum tau buat apa
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
    if ($('#Level').val() == "" || ($('#Level').val() == " ")) {
        isAllValid = false; //kalau textbox nama kosong maka
        $('#Level').siblings('span.error').css('visibility', 'visible'); //ini notifikasi buat ngasi tau field belum diisi pas mencet save 
    }
    if ($('#Date').val() == "" || ($('#Date').val() == " ")) {
        isAllValid = false; //kalau textbox nama kosong maka
        $('#Date').siblings('span.error').css('visibility', 'visible'); //ini notifikasi buat ngasi tau field belum diisi pas mencet save 
    }
    if ($('#LinkFile').val() == "" || ($('#LinkFile').val() == " ")) {
        isAllValid = false; //kalau textbox nama kosong maka
        $('#Linkfile').siblings('span.error').css('visibility', 'visible'); //ini notifikasi buat ngasi tau field belum diisi pas mencet save 
    }
    //cek dropdown Department
    if ($('#Department').val() == "0" || $('#Department').val() == 0) {
        isAllValid = false;
        $('#Department').siblings('span.error').css('visibility', 'visible');
    }
    if ($('#Employee').val() == "0" || $('#Employee').val() == 0) {
        isAllValid = false;
        $('#Employee').siblings('span.error').css('visibility', 'visible');
    }
    // kalau semua field sudah terisi
    if (isAllValid) { 
        Save();
    }
}

function validationUpdate() {
    debugger;
    hideAlert();
    var isAllValid = true; //asumsi semua textbox sudah terisi
    //cek textbox nama
    if ($('#Name').val() == "" || ($('#Name').val() == " ")) {
        isAllValid = false; //kalau textbox nama kosong maka
        $('#Name').siblings('span.error').css('visibility', 'visible'); //ini notifikasi buat ngasi tau field belum diisi pas mencet save 
    }
    if ($('#Level').val() == "" || ($('#Level').val() == " ")) {
        isAllValid = false; //kalau textbox nama kosong maka
        $('#Level').siblings('span.error').css('visibility', 'visible'); //ini notifikasi buat ngasi tau field belum diisi pas mencet save 
    }
    if ($('#Date').val() == "" || ($('#Date').val() == " ")) {
        isAllValid = false; //kalau textbox nama kosong maka
        $('#Date').siblings('span.error').css('visibility', 'visible'); //ini notifikasi buat ngasi tau field belum diisi pas mencet save 
    }
    if ($('#LinkFile').val() == "" || ($('#LinkFile').val() == " ")) {
        isAllValid = false; //kalau textbox nama kosong maka
        $('#Linkfile').siblings('span.error').css('visibility', 'visible'); //ini notifikasi buat ngasi tau field belum diisi pas mencet save 
    }
    //cek dropdown Department
    if ($('#Department').val() == "0" || $('#Department').val() == 0) {
        isAllValid = false;
        $('#Department').siblings('span.error').css('visibility', 'visible');
    }
    if ($('#Employee').val() == "0" || $('#Employee').val() == 0) {
        isAllValid = false;
        $('#Employee').siblings('span.error').css('visibility', 'visible');
    }
    // kalau semua field sudah terisi
    if (isAllValid) {
        Edit();
    }
}

function hideAlert() {
    $('#Name').siblings('span.error').css('visibility', 'hidden');
    $('#Level').siblings('span.error').css('visibility', 'hidden');
    $('#Date').siblings('span.error').css('visibility', 'hidden');
    $('#Department').siblings('span.error').css('visibility', 'hidden');
    $('#Employee').siblings('span.error').css('visibility', 'hidden');
    $('#LinkFile').siblings('span.error').css('visibility', 'hidden');
}

function nuke() {
    $('#Name').val('');
    $('#Level').val('');
    $('#Date').val('');
    $('#Department').val(0);
    $('#Employee').val(0);
    $('#LinkFile').val('');
    $('#Update').hide();
    $('#Save').show();
    hideAlert();
}
LoadDepartment($('#Department'));
LoadEmployee($('#Employee'));