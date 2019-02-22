var Lessons = []
var Classes = []
var Rooms = []
$(document).ready(function () {
    hideAlert();
    LoadIndexSchedule();
    $('#table').DataTable({
        "ajax": LoadIndexSchedule()
    })
})

function LoadRoom(element) {
    if (Rooms.length == 0) {
        $.ajax({
            type: "GET", // get
            url: 'http://localhost:53126/api/Rooms',
            success: function (data) {
                Rooms = data; //Schedule
                //and render Schedule to element
                renderRoom(element);
            }
        })
    } else {
        //render Schedule to element if var Schedules above not empty
        renderRoom(element);
    }
}
function renderRoom(element) {
    var $ele = $(element);
    $ele.empty(); //kosongkan element
    $ele.append($('<option/>').val('0').text('Select')); //tambahkan item kedalam dropdown
    $.each(Rooms, function (i, val) { // tambahkan item baru kedalam dropdown untuk setiap nilai yang ada didalam Schedules []
        $ele.append($('<option/>').val(val.Id).text(val.Name)); //id sama namanyanya Provincies
    })
}

function LoadLesson(element) {
    if (Lessons.length == 0) {
        $.ajax({
            type: "GET", // get
            url: 'http://localhost:53126/api/Lessons',
            success: function (data) {
                Lessons = data; //Schedule
                //and render Schedule to element
                renderLesson(element); 
            }
        })
    } else {
        //render Schedule to element if var Schedules above not empty
        renderLesson(element);
    }
}
function renderLesson(element) {
    var $ele = $(element);
    $ele.empty(); //kosongkan element
    $ele.append($('<option/>').val('0').text('Select')); //tambahkan item kedalam dropdown
    $.each(Lessons, function (i, val) { // tambahkan item baru kedalam dropdown untuk setiap nilai yang ada didalam Schedules []
        $ele.append($('<option/>').val(val.Id).text(val.Name)); //id sama namanyanya Provincies
    })
}

function LoadClass(element) {
    if (Classes.length == 0) {
        $.ajax({
            type: "GET", // get
            url: 'http://localhost:53126/api/Classes',
            success: function (data) {
                Classes= data; //Schedule
                //and render Schedule to element
                renderClass(element);
            }
        })
    } else {
        //render Schedule to element if var Schedules above not empty
        renderClass(element);
    }
}
function renderClass(element) {
    var $ele = $(element);
    $ele.empty(); //kosongkan element
    $ele.append($('<option/>').val('0').text('Select')); //tambahkan item kedalam dropdown
    $.each(Classes, function (i, val) { // tambahkan item baru kedalam dropdown untuk setiap nilai yang ada didalam Schedules []
        $ele.append($('<option/>').val(val.Id).text(val.Name)); //id sama namanyanya Provincies
    })
}

function LoadIndexSchedule() {
    $.ajax({
        type: "GET", //untuk menampilkan data
        url: "http://localhost:53126/api/Schedules",
        async: false, // ini untuk menjalankan fungsi search dan sorting data table
        datatype: "json",
        success: function (schedule) {
            var html = '';
            $.each(schedule, function (index, val) {
                html += '<tr>';
                //html += '<td>' + i + '</td>'; ini kalau mau nampilkan nomor 1 sampai sekian
                
                html += '<td>' + val.Lessons.Name + '</td>';
                html += '<td>' + val.Classes.Name + '</td>';
                html += '<td>' + val.Rooms.Name + '</td>';
                html += '<td>' + val.DateStart + '</td>';
                html += '<td>' + val.DateEnd + '</td>';
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
    //kalau pop up ngga ketutup berarti ada yang tidak sesuai didalam success: function(result{ (contohnya LoadIndexItem padahal diatas tulisannya LoadIndexLesson
    var item = new Object(); //deklarasikan object baru yang akan disimpan nilai nilai didalamnya
    item.DateStart = $('#DateStart').val();
    item.DateEnd = $('#DateEnd').val();// simpan nilai yang ada di #Name di view kedalam object 
    item.Lesson_Id = $('#Lesson').val();// masih ragu disini
    item.Class_Id = $('#Class').val();
    item.Room_Id = $('#Room').val();
    $.ajax({
        type: "POST", //insert
        url: "http://localhost:53126/api/Schedules",
        datatype: "json",
        data: item, //data yang akan disimpan adalah object yang di deklarasikan tadi
        success: function (result) { //kalo sukses muat ulang data kedalam tabel
            LoadIndexSchedule();
            $('#myModal').modal('hide');
            $('#Name').val('');
            $('#Lesson').val(0);
            $('#Class').val(0);
            $('#Room').val(0);

        }
    });
}
function Edit() {
    debugger;
    //kalau pop up ngga ketutup berarti ada yang tidak sesuai didalam success: function(result{
    var item = new Object(); // sama kayak di save
    item.Id = $('#Id').val();// id dari data yang akan diedit
    item.DateStart = $('#DateStart').val();
    item.DateEnd = $('#DateEnd').val();
    item.Lesson_id = $('#Lesson').val();// masih ragu disini
    item.Class_Id = $('#Class').val();
    item.Room_Id = $('#Room').val();
    $.ajax({
        type: "PUT", //put untuk update
        url: "http://localhost:53126/api/Schedules/" + $('#Id').val(),
        datatype: "json",
        data: item,
        success: function (result) {
            LoadIndexSchedule();
            $('#myModal').modal('hide');
            $('#DateStart').val('');
            $('#DateEnd').val('');
            $('#Lesson').val(0);
            $('#Class').val(0);
            $('#Room').val(0);
        }
    });
};
function GetById(Id) {
    debugger;
    $.ajax({
        url: "http://localhost:53126/api/Schedules/" + Id, // search
        type: "GET",
        datatype: "json",
        success: function (item) {
            $('#Id').val(item.Id);
            $('#DateStart').val(item.DateStart);
            $('#DateEnd').val(item.DateEnd);
            $('#Lesson').val(item.Lessons.Id);//udah benar
            $('#Class').val(item.Classes.Id);
            $('#Room').val(item.Rooms.Id);
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
            url: "http://localhost:53126/api/Schedules/" + Id,
            type: "DELETE",
            success: function (response) {
                swal({
                    title: "Deleted!",
                    text: "That data has been soft deleted.",
                    type: "success"
                },
                function () {
                    window.location.href = '/Schedules/Index'; // ini belum tau buat apa
                });
            },
            error: function (response) {
                swal("Oops", "We could not connect to the server!", "error");
            }
        });
    });
}

//item.DateStart = $('#DateStart').val();
//item.DateEnd = $('#DateEnd').val();// simpan nilai yang ada di #Name di view kedalam object 
//item.Lesson_Id = $('#Lesson').val();// masih ragu disini
//item.Class_Id = $('#Class').val();
//item.Room_Id = $('#Room').val();

function validationInsert() {
    hideAlert(); // setiap kali ngeklik tombol save ilangkan dulu errornya baru cek lagi satu satu
    var isAllValid = true; //asumsi semua textbox sudah terisi
    //cek textbox nama
    if ($('#DateStart').val() == "" || ($('#DateStart').val() == " ")) {
        isAllValid = false; //kalau textbox nama kosong maka
        $('#DateStart').siblings('span.error').css('visibility', 'visible'); //ini notifikasi buat ngasi tau field belum diisi pas mencet save 
    }
    if ($('#DateEnd').val() == "" || ($('#DateEnd').val() == " ")) {
        isAllValid = false; //kalau textbox nama kosong maka
        $('#DateEnd').siblings('span.error').css('visibility', 'visible'); //ini notifikasi buat ngasi tau field belum diisi pas mencet save 
    }
    //cek dropdown Lesson
    if ($('#Lesson').val() == "0" || $('#Lesson').val() == 0) {
        isAllValid = false;
        $('#Lesson').siblings('span.error').css('visibility', 'visible');
    }
    if ($('#Class').val() == "0" || $('#Class').val() == 0) {
        isAllValid = false;
        $('#Class').siblings('span.error').css('visibility', 'visible');
    }
    if ($('#Room').val() == "0" || $('#Room').val() == 0) {
        isAllValid = false;
        $('#Room').siblings('span.error').css('visibility', 'visible');
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
    //cek dropdown Lesson
    if ($('#Lesson').val() == "0" || $('#Lesson').val() == 0) {
        isAllValid = false;
        $('#Lesson').siblings('span.error').css('visibility', 'visible');
    }
    // kalau semua field sudah terisi
    if (isAllValid) {
        Edit();
    }
}

function hideAlert() {
    $('#DateStart').siblings('span.error').css('visibility', 'hidden');
    $('#DateEnd').siblings('span.error').css('visibility', 'hidden');
    $('#Lesson').siblings('span.error').css('visibility', 'hidden');
    $('#Class').siblings('span.error').css('visibility', 'hidden');
    $('#Room').siblings('span.error').css('visibility', 'hidden');
}

function nuke() {
    $('#Name').val('');
    $('#Lesson').val(0);
    $('#Class').val(0);
    $('#Room').val(0);
    $('#DateStart').val('');
    $('#DateEnd').val('');
    hideAlert();
}
LoadLesson($('#Lesson'));
LoadClass($('#Class'));
LoadRoom($('#Room'));