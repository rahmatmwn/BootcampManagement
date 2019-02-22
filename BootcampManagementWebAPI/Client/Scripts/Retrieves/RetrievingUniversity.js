var Villages = []
$(document).ready(function () {
    hideAlert();
    LoadIndexUniversity();
    $('#table').DataTable({
        "ajax": LoadIndexUniversity()
    })
})

function LoadVillage(element) {
    if (Villages.length == 0) {
        $.ajax({
            type: "GET", // get
            url: 'http://localhost:53126/api/Villages',
            success: function (data) {
                Villages = data; //Regency
                //and render Regency to element
                renderVillage(element);
            }
        })
    } else {
        //render Regency to element if var Regencies above not empty
        renderVillage(element);
    }
}
function renderVillage(element) {
    var $ele = $(element);
    $ele.empty(); //kosongkan element
    $ele.append($('<option/>').val('0').text('Select')); //tambahkan village kedalam dropdown
    $.each(Villages, function (i, val) { // tambahkan village baru kedalam dropdown untuk setiap nilai yang ada didalam Regencys []
        $ele.append($('<option/>').val(val.Id).text(val.Name)); //id sama namanyanya Provincies
    })
}

function LoadIndexUniversity() {
    $.ajax({
        type: "GET", //untuk menampilkan data
        url: "http://localhost:53126/api/Universities",
        async: false, // ini untuk menjalankan fungsi search dan sorting data table
        datatype: "json",
        success: function (university) {
            var html = '';
            $.each(university, function (index, val) {
                html += '<tr>';
                //html += '<td>' + i + '</td>'; ini kalau mau nampilkan nomor 1 sampai sekian
                html += '<td>' + val.Name + '</td>';
                html += '<td>' + val.Address + '</td>';
                html += '<td>' + val.Phone + '</td>';
                html += '<td>' + val.Villages.Name + '</td>'; //ini untuk tampilkan foreign key
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
    var university = new Object(); //deklarasikan object baru yang akan disimpan nilai nilai didalamnya
    university.Name = $('#Name').val(); // simpan nilai yang ada di #Name di view kedalam object 
    university.Address = $('#Address').val();
    university.Phone = $('#Phone').val();
    university.Villages_Id = $('#Village').val();// masih ragu disini
    $.ajax({
        type: "POST", //insert
        url: "http://localhost:53126/api/Universities",
        datatype: "json",
        data: university, //data yang akan disimpan adalah object yang di deklarasikan tadi
        success: function (result) { //kalo sukses muat ulang data kedalam tabel
            LoadIndexUniversity();
            $('#myModal').modal('hide');
            $('#Name').val('');
            $('#Address').val('');
            $('#Phone').val('');
            $('#Village').val(0);
        }
    });
}
function Edit() {
    debugger;
    //kalau pop up ngga ketutup berarti ada yang tidak sesuai didalam success: function(result{
    var university = new Object(); // sama kayak di save
    university.Id = $('#Id').val();// id dari data yang akan diedit
    university.Name = $('#Name').val();// data yang akan diedit
    university.Address = $('#Address').val();
    university.Phone = $('#Phone').val();
    university.Villages_Id = $('#Village').val();// masih ragu disini
    $.ajax({
        type: "PUT", //put untuk update
        url: "http://localhost:53126/api/Universities/" + $('#Id').val(),
        datatype: "json",
        data: university,
        success: function (result) {
            LoadIndexUniversity();
            $('#myModal').modal('hide');
            $('#Name').val('');
            $('#Address').val('');
            $('#Phone').val('');
            $('#Village').val(0);
        }
    });
};
function GetById(Id) {
    debugger;
    $.ajax({
        url: "http://localhost:53126/api/Universities/" + Id, // search
        type: "GET",
        datatype: "json",
        success: function (university) {
            $('#Id').val(university.Id);
            $('#Name').val(university.Name);
            $('#Address').val(university.Address);
            $('#Phone').val(university.Phone);
            $('#Village').val(university.Villages.Id);//udah benar
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
            url: "http://localhost:53126/api/Universities/" + Id,
            type: "DELETE",
            success: function (response) {
                swal({
                    title: "Deleted!",
                    text: "That data has been soft deleted.",
                    type: "success"
                },
                function () {
                    window.location.href = '/Universities/Index'; // ini buat kembali ke halaman index setelah delete
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
    //cek textbox Address
    if ($('#Address').val() == "" || ($('#Address').val() == " ")) {
        isAllValid = false; //kalau textbox nama kosong maka
        $('#Address').siblings('span.error').css('visibility', 'visible'); //ini notifikasi buat ngasi tau field belum diisi pas mencet save 
    }
    //cek textbox Phone
    if ($('#Phone').val() == "" || ($('#Phone').val() == " ") || ($('#Phone').val() == "0")) {
        isAllValid = false; //kalau textbox nama kosong maka
        $('#Phone').siblings('span.error').css('visibility', 'visible'); //ini notifikasi buat ngasi tau field belum diisi pas mencet save 
    }
    //cek dropdown Village
    if ($('#Village').val() == "0" || $('#Village').val() == 0) {
        isAllValid = false;
        $('#Village').siblings('span.error').css('visibility', 'visible');
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
    //cek textbox Address
    if ($('#Address').val() == "" || ($('#Address').val() == " ")) {
        isAllValid = false; //kalau textbox nama kosong maka
        $('#Address').siblings('span.error').css('visibility', 'visible'); //ini notifikasi buat ngasi tau field belum diisi pas mencet save 
    }
    //cek textbox Phone
    if ($('#Phone').val() == "" || ($('#Phone').val() == " ") || ($('#Phone').val() == "0")) {
        isAllValid = false; //kalau textbox nama kosong maka
        $('#Phone').siblings('span.error').css('visibility', 'visible'); //ini notifikasi buat ngasi tau field belum diisi pas mencet save 
    }
    //cek dropdown Village
    if ($('#Village').val() == "0" || $('#Village').val() == 0) {
        isAllValid = false;
        $('#Village').siblings('span.error').css('visibility', 'visible');
    }
    // kalau semua field sudah terisi
    if (isAllValid) {
        Edit();
    }
}

function hideAlert() {
    debugger;
    $('#Name').siblings('span.error').css('visibility', 'hidden');
    $('#Address').siblings('span.error').css('visibility', 'hidden');
    $('#Phone').siblings('span.error').css('visibility', 'hidden');
    $('#Village').siblings('span.error').css('visibility', 'hidden');
}

function nuke() {
    $('#Name').val('');
    $('#Address').val('');
    $('#Phone').val('');
    $('#Village').val(0);
    $('#Update').hide();
    $('#Save').show();
    hideAlert();
}
LoadVillage($('#Village'));