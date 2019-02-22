var Lockers = []
var Students = []
$(document).ready(function () {
    hideAlert();
    LoadIndexStudentLocker();
    $('#table').DataTable({
        "ajax": LoadIndexStudentLocker()
    })
})

function LoadLocker(element) {
    if (Lockers.length == 0) {
        $.ajax({
            type: "GET", // get
            url: 'http://localhost:53126/api/Lockers',
            success: function (data) {
                Lockers = data; //StudentLocker
                //and render StudentLocker to element
                renderLocker(element);
            }
        })
    } else {
        //render StudentLocker to element if var LockerStudents above not empty
        renderLocker(element);
    }
}
function renderLocker(element) {
    var $ele = $(element);
    $ele.empty(); //kosongkan element
    $ele.append($('<option/>').val('0').text('Select')); //tambahkan item kedalam dropdown
    $.each(Lockers, function (i, val) { // tambahkan item baru kedalam dropdown untuk setiap nilai yang ada didalam LockerStudents []
        $ele.append($('<option/>').val(val.Id).text(val.Name)); //id sama namanyanya Provincies
    })
}

function LoadStudent(element) {
    if (Students.length == 0) {
        $.ajax({
            type: "GET", // get
            url: 'http://localhost:53126/api/Students',
            success: function (data) {
                Students = data; //StudentLocker
                //and render StudentLocker to element
                renderStudent(element);
            }
        })
    } else {
        //render StudentLocker to element if var LockerStudents above not empty
        renderStudent(element);
    }
}
function renderStudent(element) {
    var $ele = $(element);
    $ele.empty(); //kosongkan element
    $ele.append($('<option/>').val('0').text('Select')); //tambahkan item kedalam dropdown
    $.each(Students, function (i, val) { // tambahkan item baru kedalam dropdown untuk setiap nilai yang ada didalam LockerStudents []
        $ele.append($('<option/>').val(val.Id).text(val.FirstName)); //id sama namanyanya Provincies
    })
}

function LoadIndexStudentLocker() {
    $.ajax({
        type: "GET", //untuk menampilkan data
        url: "http://localhost:53126/api/StudentLockers",
        async: false, // ini untuk menjalankan fungsi search dan sorting data table
        datatype: "json",
        success: function (studentskill) {
            var html = '';
            $.each(studentskill, function (index, val) {
                html += '<tr>';
                //html += '<td>' + i + '</td>'; ini kalau mau nampilkan nomor 1 sampai sekian
                html += '<td>' + val.Students.FirstName + '</td>';
                html += '<td>' + val.Lockers.Name + '</td>';
                //ini untuk tampilkan foreign key
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
    //kalau pop up ngga ketutup berarti ada yang tidak sesuai didalam success: function(result{ (contohnya LoadIndexItem padahal diatas tulisannya LoadIndexLocker
    var item = new Object(); //deklarasikan object baru yang akan disimpan nilai nilai didalamnya // simpan nilai yang ada di #Name di view kedalam object 
    item.Locker_Id = $('#Locker').val();// masih ragu disini
    item.Student_Id = $('#Student').val();
    $.ajax({
        type: "POST", //insert
        url: "http://localhost:53126/api/StudentLockers",
        datatype: "json",
        data: item, //data yang akan disimpan adalah object yang di deklarasikan tadi
        success: function (result) { //kalo sukses muat ulang data kedalam tabel
            LoadIndexStudentLocker();
            $('#myModal').modal('hide');
            $('#Locker').val(0);
            $('#Student').val(0);
        }
    });
}
function Edit() {
    debugger;
    //kalau pop up ngga ketutup berarti ada yang tidak sesuai didalam success: function(result{
    var item = new Object(); // sama kayak di save
    item.Id = $('#Id').val();// id dari data yang akan diedit// data yang akan diedit
    item.Locker_id = $('#Locker').val();// masih ragu disini
    item.Student_Id = $('#Student').val();
    $.ajax({
        type: "PUT", //put untuk update
        url: "http://localhost:53126/api/StudentLockers/" + $('#Id').val(),
        datatype: "json",
        data: item,
        success: function (result) {
            LoadIndexStudentLocker();
            $('#myModal').modal('hide');
            $('#Locker').val(0);
            $('#Student').val(0);
        }
    });
};
function GetById(Id) {
    debugger;
    $.ajax({
        url: "http://localhost:53126/api/StudentLockers/" + Id, // search
        type: "GET",
        datatype: "json",
        success: function (item) {
            $('#Id').val(item.Id);
            $('#Locker').val(item.Lockers.Id);//udah benar
            $('#Student').val(item.Students.Id);
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
            url: "http://localhost:53126/api/StudentLockers/" + Id,
            type: "DELETE",
            success: function (response) {
                swal({
                    title: "Deleted!",
                    text: "That data has been soft deleted.",
                    type: "success"
                },
                function () {
                    window.location.href = '/LockerStudents/Index'; // ini belum tau buat apa
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
    if ($('#Student').val() == "0" || ($('#Student').val() == 0)) {
        isAllValid = false; //kalau textbox nama kosong maka
        $('#Student').siblings('span.error').css('visibility', 'visible'); //ini notifikasi buat ngasi tau field belum diisi pas mencet save 
    }
    //cek dropdown Locker
    if ($('#Locker').val() == "0" || $('#Locker').val() == 0) {
        isAllValid = false;
        $('#Locker').siblings('span.error').css('visibility', 'visible');
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
    if ($('#Student').val() == "0" || ($('#Student').val() == 0)) {
        isAllValid = false; //kalau textbox nama kosong maka
        $('#Student').siblings('span.error').css('visibility', 'visible'); //ini notifikasi buat ngasi tau field belum diisi pas mencet save 
    }
    //cek dropdown Locker
    if ($('#Locker').val() == "0" || $('#Locker').val() == 0) {
        isAllValid = false;
        $('#Locker').siblings('span.error').css('visibility', 'visible');
    }
    // kalau semua field sudah terisi
    if (isAllValid) {
        Edit();
    }
}

function hideAlert() {
    $('#Locker').siblings('span.error').css('visibility', 'hidden');
    $('#Student').siblings('span.error').css('visibility', 'hidden');
}

function nuke() {
    $('#Locker').val(0);
    $('#Student').val(0);
    hideAlert();
}
LoadLocker($('#Locker'));
LoadStudent($('#Student'));