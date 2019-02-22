var Religions = []
var Villages = []

$(document).ready(function () {
    hideAlert();
    LoadIndexEmployee();
    $('#table').DataTable({
        "ajax": LoadIndexEmployee()
    })
})

function LoadIndexEmployee() {
    $.ajax({
        type: "GET", //untuk menampilkan data
        url: "http://localhost:53126/api/Employees",
        async: false, // ini untuk menjalankan fungsi search dan sorting data table
        datatype: "json",
        success: function (employee) {
            var html = '';
            $.each(employee, function (index, val) {
                html += '<tr>';
                //html += '<td>' + i + '</td>'; ini kalau mau nampilkan nomor 1 sampai sekian
                html += '<td>' + val.First_Name + '</td>';
                html += '<td>' + val.Last_Name + '</td>';
                html += '<td>' + val.Date_Of_Birth + '</td>';
                html += '<td>' + val.Place_Of_Birth + '</td>';
                html += '<td>' + val.Gender + '</td>';
                html += '<td>' + val.Address + '</td>';
                html += '<td>' + val.Phone + '</td>';
                html += '<td>' + val.Email + '</td>';
                html += '<td>' + val.Role + '</td>';
                html += '<td>' + val.Religions.Name + '</td>';
                html += '<td>' + val.Villages.Name + '</td>';
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
    var employee = new Object(); //deklarasikan object baru yang akan disimpan nilai nilai didalamnya
    employee.First_Name = $('#First_Name').val(); // simpan nilai yang ada di #Name di view kedalam object 
    employee.Last_Name = $('#Last_Name').val();
    employee.Date_Of_Birth = $('#Date_Of_Birth').val();
    employee.Place_Of_Birth = $('#Place_Of_Birth').val();
    var radios = document.getElementsByName("radButton");
    if (radios[0].checked) {
        employee.Gender = "Male";
    } else { //asumsinya karna sudah ada validasi jadi ngga perlu buat else if untuk female radio button
        employee.Gender = "Female";
    }
    employee.Address = $('#Address').val();
    employee.Phone = $('#Phone').val();
    employee.Email = $('#Role').val();
    employee.Role = $('#Role').val();
    employee.Religions_Id = $('#Religion').val();
    employee.Villages_Id = $('#Village').val();// masih ragu disini
    $.ajax({
        type: "POST", //insert
        url: "http://localhost:53126/api/Employees",
        datatype: "json",
        data: employee, //data yang akan disimpan adalah object yang di deklarasikan tadi
        success: function (result) { //kalo sukses muat ulang data kedalam tabel
            LoadIndexEmployee();
            $('#myModal').modal('hide');
            nuke();
        }
    });
}
function Edit() {
    debugger;
    //kalau pop up ngga ketutup berarti ada yang tidak sesuai didalam success: function(result{ (contohnya LoadIndexvillage padahal diatas tulisannya LoadIndexProvince
    var employee = new Object(); //deklarasikan object baru yang akan disimpan nilai nilai didalamnya
    employee.First_Name = $('#First_Name').val(); // simpan nilai yang ada di #Name di view kedalam object 
    employee.Last_Name = $('#Last_Name').val();
    employee.Date_Of_Birth = $('#Date_Of_Birth').val();
    employee.Place_Of_Birth = $('#Place_Of_Birth').val();
    var radios = document.getElementsByName("radButton");
    if (radios[0].checked) {
        employee.Gender = "Male";
    } else { //asumsinya karna sudah ada validasi jadi ngga perlu buat else if untuk female radio button
        employee.Gender = "Female";
    }
    employee.Address = $('#Address').val();
    employee.Phone = $('#Phone').val();
    employee.Email = $('#Role').val();
    employee.Role = $('#Role').val();
    employee.Religions_Id = $('#Religion').val();
    employee.Villages_Id = $('#Village').val();// masih ragu disini
    $.ajax({
        type: "PUT", //insert
        url: "http://localhost:53126/api/Employees/" + $('#Id').val(),
        datatype: "json",
        data: employee, //data yang akan disimpan adalah object yang di deklarasikan tadi
        success: function (result) { //kalo sukses muat ulang data kedalam tabel
            LoadIndexEmployee();
            $('#myModal').modal('hide');
            nuke();
        }
    });
}
function GetById(Id) {
    debugger;
    $.ajax({
        url: "http://localhost:53126/api/Employees/" + Id, // search
        type: "GET",
        datatype: "json",
        success: function (employee) {
            $('#Id').val(employee.Id);
            $('#First_Name').val(employee.First_Name);
            $('#Last_Name').val(employee.Last_Name);
            $('#Date_Of_Birth').val(employee.Date_Of_Birth);
            $('#Place_Of_Birth').val(employee.Place_Of_Birth);
            if (employee.Gender == "Male") {
                $('#Male').checked;
            } else {
                $('#Female').checked;
            }
            $('#Address').val(employee.Address);
            $('#Phone').val(employee.Phone);
            $('#Email').val(employee.Email);
            $('#Role').val(employee.Role);
            $('#Religion').val(employee.Religions.Id);//udah benar
            $('#Village').val(employee.Villages.Id);
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
            url: "http://localhost:53126/api/Employees/" + Id,
            type: "DELETE",
            success: function (response) {
                swal({
                    title: "Deleted!",
                    text: "That data has been soft deleted.",
                    type: "success"
                },
                function () {
                    window.location.href = '/Employees/Index'; 
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
    if ($('#First_Name').val() == "" || ($('#First_Name').val() == " ")) {
        isAllValid = false; //kalau textbox nama kosong maka
        $('#First_Name').siblings('span.error').css('visibility', 'visible'); //ini notifikasi buat ngasi tau field belum diisi pas mencet save 
    }
    //cek textbox nama
    if ($('#Last_Name').val() == "" || ($('#Last_Name').val() == " ")) {
        isAllValid = false; //kalau textbox nama kosong maka
        $('#Last_Name').siblings('span.error').css('visibility', 'visible'); //ini notifikasi buat ngasi tau field belum diisi pas mencet save 
    }
    //cek textbox nama
    if ($('#Date_Of_Birth').val() == "" || ($('#Date_Of_Birth').val() == " ")) {
        isAllValid = false; //kalau textbox nama kosong maka
        $('#Date_Of_Birth').siblings('span.error').css('visibility', 'visible'); //ini notifikasi buat ngasi tau field belum diisi pas mencet save 
    }
    //cek textbox nama
    if ($('#Place_Of_Birth').val() == "" || ($('#Place_Of_Birth').val() == " ")) {
        isAllValid = false; //kalau textbox nama kosong maka
        $('#Place_Of_Birth').siblings('span.error').css('visibility', 'visible'); //ini notifikasi buat ngasi tau field belum diisi pas mencet save 
    }
    //CHECKPOINT
    var radios = document.getElementsByName("radButton");
    var buttonChecked = false;
    var i = 0;
    while (!buttonChecked && i < radios.length) {
        if (radios[i].checked) buttonChecked = true;
        i++;
    }
    if (!buttonChecked) {
        isAllValid = false;
        $('#Gender').children('span.error').css("visibility", "visible");
    }
    //cek textbox nama
    if ($('#Address').val() == "" || ($('#Address').val() == " ")) {
        isAllValid = false; //kalau textbox nama kosong maka
        $('#Address').siblings('span.error').css('visibility', 'visible'); //ini notifikasi buat ngasi tau field belum diisi pas mencet save 
    }
    //cek textbox nama
    if ($('#Phone').val() == "" || ($('#Phone').val() == " ")) {
        isAllValid = false; //kalau textbox nama kosong maka
        $('#Phone').siblings('span.error').css('visibility', 'visible'); //ini notifikasi buat ngasi tau field belum diisi pas mencet save 
    }
    if ($('#Email').val() == "" || ($('#Email').val() == " ")) {
        isAllValid = false; //kalau textbox nama kosong maka
        $('#Email').siblings('span.error').css('visibility', 'visible'); //ini notifikasi buat ngasi tau field belum diisi pas mencet save 
    }
    if ($('#Role').val() == "" || ($('#Role').val() == " ")) {
        isAllValid = false; //kalau textbox nama kosong maka
        $('#Role').siblings('span.error').css('visibility', 'visible'); //ini notifikasi buat ngasi tau field belum diisi pas mencet save 
    }
    //cek dropdown Province
    if ($('#Religion').val() == "0" || $('#Religion').val() == 0) {
        isAllValid = false;
        $('#Religion').siblings('span.error').css('visibility', 'visible');
    }
    //cek dropdown Province
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
    hideAlert(); // setiap kali ngeklik tombol save ilangkan dulu errornya baru cek lagi satu satu
    var isAllValid = true; //asumsi semua textbox sudah terisi
    //cek textbox nama
    if ($('#First_Name').val() == "" || ($('#First_Name').val() == " ")) {
        isAllValid = false; //kalau textbox nama kosong maka
        $('#First_Name').siblings('span.error').css('visibility', 'visible'); //ini notifikasi buat ngasi tau field belum diisi pas mencet save 
    }
    //cek textbox nama
    if ($('#Last_Name').val() == "" || ($('#Last_Name').val() == " ")) {
        isAllValid = false; //kalau textbox nama kosong maka
        $('#Last_Name').siblings('span.error').css('visibility', 'visible'); //ini notifikasi buat ngasi tau field belum diisi pas mencet save 
    }
    //cek textbox nama
    if ($('#Date_Of_Birth').val() == "" || ($('#Date_Of_Birth').val() == " ")) {
        isAllValid = false; //kalau textbox nama kosong maka
        $('#Date_Of_Birth').siblings('span.error').css('visibility', 'visible'); //ini notifikasi buat ngasi tau field belum diisi pas mencet save 
    }
    //cek textbox nama
    if ($('#Place_Of_Birth').val() == "" || ($('#Place_Of_Birth').val() == " ")) {
        isAllValid = false; //kalau textbox nama kosong maka
        $('#Place_Of_Birth').siblings('span.error').css('visibility', 'visible'); //ini notifikasi buat ngasi tau field belum diisi pas mencet save 
    }
    //CHECKPOINT
    var radios = document.getElementsByName("radButton");
    var buttonChecked = false;
    var i = 0;
    while (!buttonChecked && i < radios.length) {
        if (radios[i].checked) buttonChecked = true;
        i++;
    }
    if (!buttonChecked) {
        isAllValid = false;
        $('#Gender').children('span.error').css("visibility", "visible");
    }
    //cek textbox nama
    if ($('#Address').val() == "" || ($('#Address').val() == " ")) {
        isAllValid = false; //kalau textbox nama kosong maka
        $('#Address').siblings('span.error').css('visibility', 'visible'); //ini notifikasi buat ngasi tau field belum diisi pas mencet save 
    }
    //cek textbox nama
    if ($('#Phone').val() == "" || ($('#Phone').val() == " ")) {
        isAllValid = false; //kalau textbox nama kosong maka
        $('#Phone').siblings('span.error').css('visibility', 'visible'); //ini notifikasi buat ngasi tau field belum diisi pas mencet save 
    }
    if ($('#Email').val() == "" || ($('#Email').val() == " ")) {
        isAllValid = false; //kalau textbox nama kosong maka
        $('#Email').siblings('span.error').css('visibility', 'visible'); //ini notifikasi buat ngasi tau field belum diisi pas mencet save 
    }
    if ($('#Role').val() == "" || ($('#Role').val() == " ")) {
        isAllValid = false; //kalau textbox nama kosong maka
        $('#Role').siblings('span.error').css('visibility', 'visible'); //ini notifikasi buat ngasi tau field belum diisi pas mencet save 
    }
    //cek dropdown Province
    if ($('#Religion').val() == "0" || $('#Religion').val() == 0) {
        isAllValid = false;
        $('#Religion').siblings('span.error').css('visibility', 'visible');
    }
    //cek dropdown Province
    if ($('#Village').val() == "0" || $('#Village').val() == 0) {
        isAllValid = false;
        $('#Village').siblings('span.error').css('visibility', 'visible');
    }
    // kalau semua field sudah terisi
    if (isAllValid) {
        Edit();
    }
}

function LoadReligion(element) {
    if (Religions.length == 0) {
        $.ajax({
            type: "GET", // get
            url: 'http://localhost:53126/api/Religions',
            success: function (data) {
                Religions = data; //Regency
                //and render Regency to element
                renderReligion(element);
            }
        })
    } else {
        //render Regency to element if var Regencies above not empty
        renderReligion(element);
    }
}
function renderReligion(element) {
    var $ele = $(element);
    $ele.empty(); //kosongkan element
    $ele.append($('<option/>').val('0').text('Select')); //tambahkan village kedalam dropdown
    $.each(Religions, function (i, val) { // tambahkan village baru kedalam dropdown untuk setiap nilai yang ada didalam Regencys []
        $ele.append($('<option/>').val(val.Id).text(val.Name)); //id sama namanyanya Provincies
    })
}

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

function nuke() {
    $('#First_Name').val('');
    $('#Last_Name').val('');
    $('#Date_Of_Birth').val('');
    $('#Place_Of_Birth').val('');
    $('#Address').val('');
    $('#Phone').val('');
    $('#Email').val('');
    $('#Role').val('');
    $('#Religion').val(0);
    $('#Village').val(0);
    $('#Update').hide();
    $('#Save').show();
    hideAlert();
}
function hideAlert() {
    $('#First_Name').siblings('span.error').css('visibility', 'hidden');
    $('#Last_Name').siblings('span.error').css('visibility', 'hidden');
    $('#Date_Of_Birth').siblings('span.error').css('visibility', 'hidden');
    $('#Place_Of_Birth').siblings('span.error').css('visibility', 'hidden');
    $('#Address').siblings('span.error').css('visibility', 'hidden');
    $('#Phone').siblings('span.error').css('visibility', 'hidden');
    $('#Gender').children('span.error').css('visibility', 'hidden');
    $('#Email').siblings('span.error').css('visibility', 'hidden');
    $('#Role').siblings('span.error').css('visibility', 'hidden');
    $('#Village').siblings('span.error').css('visibility', 'hidden');
    $('#Religion').siblings('span.error').css('visibility', 'hidden');
}

LoadReligion($('#Religion'));
LoadVillage($('#Village'));