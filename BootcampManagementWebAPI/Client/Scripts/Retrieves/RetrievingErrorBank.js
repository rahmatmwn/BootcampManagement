var Departments = []
var Students = []
$(document).ready(function () {
    hideAlert();
    LoadIndexErrorBank();
    $('#table').DataTable({
        "ajax": LoadIndexErrorBank()
    })
})

function LoadDepartment(element) {
    if (Departments.length == 0) {
        $.ajax({
            type: "GET", // get
            url: 'http://localhost:53126/api/Departments',
            success: function (data) {
                Departments = data; //ErrorBank
                //and render ErrorBank to element
                renderDepartment(element); 
            }
        })
    } else {
        //render ErrorBank to element if var ErrorBanks above not empty
        renderDepartment(element);
    }
}
function renderDepartment(element) {
    var $ele = $(element);
    $ele.empty(); //kosongkan element
    $ele.append($('<option/>').val('0').text('Select')); //tambahkan item kedalam dropdown
    $.each(Departments, function (i, val) { // tambahkan item baru kedalam dropdown untuk setiap nilai yang ada didalam ErrorBanks []
        $ele.append($('<option/>').val(val.Id).text(val.Name)); //id sama namanyanya Provincies
    })
}


function LoadIndexErrorBank() {
    $.ajax({
        type: "GET", //untuk menampilkan data
        url: "http://localhost:53126/api/ErrorBanks",
        async: false, // ini untuk menjalankan fungsi search dan sorting data table
        datatype: "json",
        success: function (kelas) {
            var html = '';
            $.each(kelas, function (index, val) {
                html += '<tr>';
                //html += '<td>' + i + '</td>'; ini kalau mau nampilkan nomor 1 sampai sekian
                html += '<td>' + val.Students.FirstName + '</td>';
                html += '<td>' + val.Message + '</td>';
                html += '<td>' + val.Description + '</td>';
                html += '<td>' + val.Solution + '</td>';
                html += '<td>' + val.Departments.Name + '</td>';
                html += '<td>' + val.Date + '</td>';
//ini untuk tampilkan foreign key
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
    item.Message = $('#Message').val(); // simpan nilai yang ada di #Name di view kedalam object
    item.Description = $('#Description').val();
    item.Solution = $('#Solution').val();
    item.Department_Id = $('#Department').val();// masih ragu disini
    item.Student_Id = $('#Student').val();
    $.ajax({
        type: "POST", //insert
        url: "http://localhost:53126/api/ErrorBanks",
        datatype: "json",
        data: item, //data yang akan disimpan adalah object yang di deklarasikan tadi
        success: function (result) { //kalo sukses muat ulang data kedalam tabel
            LoadIndexErrorBank();
            $('#myModal').modal('hide');
            $('#Message').val('');
            $('#Description').val('');
            $('#Solution').val('');
            $('#Department').val(0);
            $('#Student').val(0);
        }
    });
}
function Edit() {
    debugger;
    //kalau pop up ngga ketutup berarti ada yang tidak sesuai didalam success: function(result{
    var item = new Object(); // sama kayak di save
    item.Message = $('#Message').val(); // simpan nilai yang ada di #Name di view kedalam object
    item.Description = $('#Description').val();
    item.Solution = $('#Solution').val();
    item.Department_Id = $('#Department').val();// masih ragu disini
    item.Student_Id = $('#Student').val();
    $.ajax({
        type: "PUT", //put untuk update
        url: "http://localhost:53126/api/ErrorBanks/" + $('#Id').val(),
        datatype: "json",
        data: item,
        success: function (result) {
            LoadIndexErrorBank();
            $('#myModal').modal('hide');
            $('#Message').val('');
            $('#Description').val('');
            $('#Solution').val('');
            $('#Department').val(0);
            $('#Student').val(0);
        }
    });
};
function GetById(Id) {
    debugger;
    $.ajax({
        url: "http://localhost:53126/api/ErrorBanks/" + Id, // search
        type: "GET",
        datatype: "json",
        success: function (item) {
            $('#Id').val(item.Id);
            $('#Message').val(item.Message);
            $('#Description').val(item.Description);
            $('#Solution').val(item.Solution);
            $('#Department').val(item.Departments.Id);//udah benar
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
            url: "http://localhost:53126/api/ErrorBanks/" + Id,
            type: "DELETE",
            success: function (response) {
                swal({
                    title: "Deleted!",
                    text: "That data has been soft deleted.",
                    type: "success"
                },
                function () {
                    window.location.href = '/ErrorBanks/Index'; // ini belum tau buat apa
                });
            },
            error: function (response) {
                swal("Oops", "We could not connect to the server!", "error");
            }
        });
    });
}

//item.Message = $('#Message').val(); // simpan nilai yang ada di #Name di view kedalam object
//item.Description = $('#Description').val();
//item.Solution = $('#Solution').val();
//item.Department_Id = $('#Department').val();// masih ragu disini
//item.Student_Id = $('#Student').val();

function validationInsert() {
    hideAlert(); // setiap kali ngeklik tombol save ilangkan dulu errornya baru cek lagi satu satu
    var isAllValid = true; //asumsi semua textbox sudah terisi
    //cek textbox nama
    if ($('#Message').val() == "" || ($('#Message').val() == " ")) {
        isAllValid = false; //kalau textbox nama kosong maka
        $('#Message').siblings('span.error').css('visibility', 'visible'); //ini notifikasi buat ngasi tau field belum diisi pas mencet save 
    }
    if ($('#Description').val() == "" || ($('#Description').val() == " ")) {
        isAllValid = false; //kalau textbox nama kosong maka
        $('#Description').siblings('span.error').css('visibility', 'visible'); //ini notifikasi buat ngasi tau field belum diisi pas mencet save 
    }
    //cek dropdown Department
    if ($('#Solution').val() == "" || $('#Solution').val() == " ") {
        isAllValid = false;
        $('#Solution').siblings('span.error').css('visibility', 'visible');
    }
    if ($('#Department').val() == "0" || $('#Department').val() == 0) {
        isAllValid = false;
        $('#Department').siblings('span.error').css('visibility', 'visible');
    }
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
    debugger;
    hideAlert();
    var isAllValid = true; //asumsi semua textbox sudah terisi
    //cek textbox nama
    if ($('#Message').val() == "" || ($('#Message').val() == " ")) {
        isAllValid = false; //kalau textbox nama kosong maka
        $('#Message').siblings('span.error').css('visibility', 'visible'); //ini notifikasi buat ngasi tau field belum diisi pas mencet save 
    }
    if ($('#Description').val() == "" || ($('#Description').val() == " ")) {
        isAllValid = false; //kalau textbox nama kosong maka
        $('#Description').siblings('span.error').css('visibility', 'visible'); //ini notifikasi buat ngasi tau field belum diisi pas mencet save 
    }
    //cek dropdown Department
    if ($('#Solution').val() == "" || $('#Solution').val() == " ") {
        isAllValid = false;
        $('#Solution').siblings('span.error').css('visibility', 'visible');
    }
    if ($('#Department').val() == "0" || $('#Department').val() == 0) {
        isAllValid = false;
        $('#Department').siblings('span.error').css('visibility', 'visible');
    }
    if ($('#Student').val() == "" || $('#Student').val() == " ") {
        isAllValid = false;
        $('#Student').siblings('span.error').css('visibility', 'visible');
    }
    // kalau semua field sudah terisi
    if (isAllValid) {
        Edit();
    }
}

function hideAlert() {
    $('#Message').siblings('span.error').css('visibility', 'hidden');
    $('#Description').siblings('span.error').css('visibility', 'hidden');
    $('#Solution').siblings('span.error').css('visibility', 'hidden');
    $('#Department').siblings('span.error').css('visibility', 'hidden');
    $('#Student').siblings('span.error').css('visibility', 'hidden');
}

function nuke() {
    $('#Message').val('');
    $('#Description').val('');
    $('#Solution').val('');
    $('#Department').val(0);
    $('#Student').val(0);
    hideAlert();
}
LoadDepartment($('#Department'));
//LoadStudent($('#Student'));