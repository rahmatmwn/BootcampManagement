var Accesses = []
var Students = []
$(document).ready(function () {
    hideAlert();
    LoadIndexStudentAccess();
    $('#table').DataTable({
        "ajax": LoadIndexStudentAccess()
    })
})

function LoadAccess(element) {
    if (Accesses.length == 0) {
        $.ajax({
            type: "GET", // get
            url: 'http://localhost:53126/api/Accesses',
            success: function (data) {
                Accesses = data; //StudentAccess
                //and render StudentAccess to element
                renderAccess(element);
            }
        })
    } else {
        //render StudentAccess to element if var AccessStudents above not empty
        renderAccess(element);
    }
}
function renderAccess(element) {
    var $ele = $(element);
    $ele.empty(); //kosongkan element
    $ele.append($('<option/>').val('0').text('Select')); //tambahkan item kedalam dropdown
    $.each(Accesses, function (i, val) { // tambahkan item baru kedalam dropdown untuk setiap nilai yang ada didalam AccessStudents []
        $ele.append($('<option/>').val(val.Id).text(val.Name)); //id sama namanyanya Provincies
    })
}

function LoadStudent(element) {
    if (Students.length == 0) {
        $.ajax({
            type: "GET", // get
            url: 'http://localhost:53126/api/Students',
            success: function (data) {
                Students = data; //StudentAccess
                //and render StudentAccess to element
                renderStudent(element);
            }
        })
    } else {
        //render StudentAccess to element if var AccessStudents above not empty
        renderStudent(element);
    }
}
function renderStudent(element) {
    var $ele = $(element);
    $ele.empty(); //kosongkan element
    $ele.append($('<option/>').val('0').text('Select')); //tambahkan item kedalam dropdown
    $.each(Students, function (i, val) { // tambahkan item baru kedalam dropdown untuk setiap nilai yang ada didalam AccessStudents []
        $ele.append($('<option/>').val(val.Id).text(val.FirstName)); //id sama namanyanya Provincies
    })
}

function LoadIndexStudentAccess() {
    $.ajax({
        type: "GET", //untuk menampilkan data
        url: "http://localhost:53126/api/StudentAccesses",
        async: false, // ini untuk menjalankan fungsi search dan sorting data table
        datatype: "json",
        success: function (studentskill) {
            var html = '';
            $.each(studentskill, function (index, val) {
                html += '<tr>';
                //html += '<td>' + i + '</td>'; ini kalau mau nampilkan nomor 1 sampai sekian
                html += '<td>' + val.Students.FirstName+ '</td>';
                html += '<td>' + val.Accesses.Name + '</td>';
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
    //kalau pop up ngga ketutup berarti ada yang tidak sesuai didalam success: function(result{ (contohnya LoadIndexItem padahal diatas tulisannya LoadIndexAccess
    var item = new Object(); //deklarasikan object baru yang akan disimpan nilai nilai didalamnya // simpan nilai yang ada di #Name di view kedalam object 
    item.Access_Id = $('#Access').val();// masih ragu disini
    item.Student_Id = $('#Student').val();
    $.ajax({
        type: "POST", //insert
        url: "http://localhost:53126/api/StudentAccesses",
        datatype: "json",
        data: item, //data yang akan disimpan adalah object yang di deklarasikan tadi
        success: function (result) { //kalo sukses muat ulang data kedalam tabel
            LoadIndexStudentAccess();
            $('#myModal').modal('hide');
            $('#Access').val(0);
            $('#Student').val(0);
        }
    });
}
function Edit() {
    debugger;
    //kalau pop up ngga ketutup berarti ada yang tidak sesuai didalam success: function(result{
    var item = new Object(); // sama kayak di save
    item.Id = $('#Id').val();// id dari data yang akan diedit// data yang akan diedit
    item.Access_id = $('#Access').val();// masih ragu disini
    item.Student_Id = $('#Student').val();
    $.ajax({
        type: "PUT", //put untuk update
        url: "http://localhost:53126/api/StudentAccesses/" + $('#Id').val(),
        datatype: "json",
        data: item,
        success: function (result) {
            LoadIndexStudentAccess();
            $('#myModal').modal('hide');
            $('#Access').val(0);
            $('#Student').val(0);
        }
    });
};
function GetById(Id) {
    debugger;
    $.ajax({
        url: "http://localhost:53126/api/StudentAccesses/" + Id, // search
        type: "GET",
        datatype: "json",
        success: function (item) {
            $('#Id').val(item.Id);
            $('#Access').val(item.Accesses.Id);//udah benar
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
            url: "http://localhost:53126/api/StudentAccesses/" + Id,
            type: "DELETE",
            success: function (response) {
                swal({
                    title: "Deleted!",
                    text: "That data has been soft deleted.",
                    type: "success"
                },
                function () {
                    window.location.href = '/AccessStudents/Index'; // ini belum tau buat apa
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
    //cek dropdown Access
    if ($('#Access').val() == "0" || $('#Access').val() == 0) {
        isAllValid = false;
        $('#Access').siblings('span.error').css('visibility', 'visible');
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
    //cek dropdown Access
    if ($('#Access').val() == "0" || $('#Access').val() == 0) {
        isAllValid = false;
        $('#Access').siblings('span.error').css('visibility', 'visible');
    }
    // kalau semua field sudah terisi
    if (isAllValid) {
        Edit();
    }
}

function hideAlert() {
    $('#Access').siblings('span.error').css('visibility', 'hidden');
    $('#Student').siblings('span.error').css('visibility', 'hidden');
}

function nuke() {
    $('#Access').val(0);
    $('#Student').val(0);
    hideAlert();
}
LoadAccess($('#Access'));
LoadStudent($('#Student'));