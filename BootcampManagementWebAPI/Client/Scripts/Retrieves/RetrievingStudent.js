var Classes = []
var Villages = []
var Religions = []
var Provincies = []
$(document).ready(function () {
    hideAlert();
    LoadIndexStudent();
    $('#table').DataTable({
        "ajax": LoadIndexStudent()
    })
})

function LoadReligion(element) {
    if (Religions.length == 0) {
        $.ajax({
            type: "GET", // get
            url: 'http://localhost:53126/api/Religions',
            success: function (data) {
                Religions = data; //Student
                //and render Student to element
                renderReligion(element); 
            }
        })
    } else {
        //render Student to element if var Students above not empty
        renderReligion(element);
    }
}
function renderReligion(element) {
    var $ele = $(element);
    $ele.empty(); //kosongkan element
    $ele.append($('<option/>').val('0').text('Select')); //tambahkan item kedalam dropdown
    $.each(Religions, function (i, val) { // tambahkan item baru kedalam dropdown untuk setiap nilai yang ada didalam Students []
        $ele.append($('<option/>').val(val.Id).text(val.Name)); //id sama namanyanya Provincies
    })
}

function LoadClass(element) {
    if (Classes.length == 0) {
        $.ajax({
            type: "GET", // get
            url: 'http://localhost:53126/api/Classes',
            success: function (data) {
                Classes = data; //Student
                //and render Student to element
                renderClass(element);
            }
        })
    } else {
        //render Student to element if var Students above not empty
        renderClass(element);
    }
}
function renderClass(element) {
    var $ele = $(element);
    $ele.empty(); //kosongkan element
    $ele.append($('<option/>').val('0').text('Select')); //tambahkan item kedalam dropdown
    $.each(Classes, function (i, val) { // tambahkan item baru kedalam dropdown untuk setiap nilai yang ada didalam Students []
        $ele.append($('<option/>').val(val.Id).text(val.Name)); //id sama namanyanya Provincies
    })
}

function LoadProvince() {
    $.ajax({
        url: 'http://localhost:53126/api/Province',
        type: 'GET',
        datatype: 'json',
        success: function (result) {
            var province = $('#Province');
            province.empty();
            province.append($('<option/>').val('0').text('Select Province'));
            $.each(result, function (i, Provinces) {
                $("<option></option>").val(Provinces.Id).text(Provinces.Name).appendTo(province);
            });
            $('#Regency').val('0');
            $('#District').val('0');
            $('#Village').val('0');
        }
    });
}

function LoadRegency() {
    debugger;
    $.ajax({
        url: 'http://localhost:53126/api/Regency/GetRegency/' + $('#Province').val(),
        type: 'GET',
        datatype: 'json',
        success: function (result) {
            var regency = $('#Regency');
            regency.empty();
            regency.append($('<option/>').val('0').text('Select Regency'));
            $.each(result, function (i, Regencies) {
                $("<option></option>").val(Regencies.Id).text(Regencies.Name).appendTo(regency);
            });
            $('#Regency').prop("disabled", false);
            $('#District').prop("disabled", false);
            $('#Village').prop("disabled", false);
            $('#District').val('0');
            $('#Village').val('0');
        }
    });
}

function LoadDistrict() {
    debugger;
    $.ajax({
        url: 'http://localhost:53126/api/Districts/GetDistrict/' + $('#Regency').val(),
        type: 'GET',
        datatype: 'json',
        success: function (result) {
            var district = $('#District');
            district.empty();
            district.append($('<option/>').val('0').text('Select District'));
            $.each(result, function (i, Districts) {
                $("<option></option>").val(Districts.Id).text(Districts.Name).appendTo(district);
            });
            $('#Village').val('0');
        }
    });
}

function LoadVillage(element) {
    debugger;
    $.ajax({
        url: 'http://localhost:53126/api/Villages/GetVillage/' + $('#District').val(),
        type: 'GET',
        datatype: 'json',
        success: function (result) {
            var village = $('#Village');
            village.empty();
            village.append($('<option/>').val('0').text('Select Village'));
            $.each(result, function (i, Villages) {
                $("<option></option>").val(Villages.Id).text(Villages.Name).appendTo(village);
            });
        }
    });
}

function LoadRegencyAll() {
    debugger;
    $.ajax({
        url: 'http://localhost:53126/api/Regency/',
        type: 'GET',
        datatype: 'json',
        success: function (result) {
            var regency = $('#Regency');
            regency.empty();
            regency.append($('<option/>').val('0').text('Select Regency'));
            $.each(result, function (i, Regencies) {
                $("<option></option>").val(Regencies.Id).text(Regencies.Name).appendTo(regency);
            });
        }
    });
}

function LoadDistrictAll() {
    debugger;
    $.ajax({
        url: 'http://localhost:53126/api/Districts/',
        type: 'GET',
        datatype: 'json',
        success: function (result) {
            var district = $('#District');
            district.empty();
            district.append($('<option/>').val('0').text('Select District'));
            $.each(result, function (i, Districts) {
                $("<option></option>").val(Districts.Id).text(Districts.Name).appendTo(district);
            });
        }
    });
}

function LoadVillageAll(element) {
    debugger;
    $.ajax({
        url: 'http://localhost:53126/api/Villages/',
        type: 'GET',
        datatype: 'json',
        success: function (result) {
            var village = $('#Village');
            village.empty();
            village.append($('<option/>').val('0').text('Select Village'));
            $.each(result, function (i, Villages) {
                $("<option></option>").val(Villages.Id).text(Villages.Name).appendTo(village);
            });
        }
    });
}



function LoadIndexStudent() {
    $.ajax({
        type: "GET", //untuk menampilkan data
        url: "http://localhost:53126/api/Students",
        async: false, // ini untuk menjalankan fungsi search dan sorting data table
        datatype: "json",
        success: function (student) {
            var html = '';
            $.each(student, function (index, val) {
                html += '<tr>';
                //html += '<td>' + i + '</td>'; ini kalau mau nampilkan nomor 1 sampai sekian
                html += '<td>' + val.FirstName + '</td>';
                html += '<td>' + val.LastName + '</td>';
                html += '<td>' + val.PlaceOfBirth + '</td>';
                html += '<td>' + val.DateOfBirth + '</td>';

                html += '<td>' + val.Gender + '</td>';
                html += '<td>' + val.Address + '</td>';
                html += '<td>' + val.Phone + '</td>';
                html += '<td>' + val.Email + '</td>';
                html += '<td>' + val.Status + '</td>';
                html += '<td>' + val.HiringLocation + '</td>';
                html += '<td>' + val.Classes.Name + '</td>';
                html += '<td>' + val.Religions.Name + '</td>';
                html += '<td>' + val.Villages.Name + '</td>';
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
    //kalau pop up ngga ketutup berarti ada yang tidak sesuai didalam success: function(result{ (contohnya LoadIndexItem padahal diatas tulisannya LoadIndexClass
    var item = new Object(); //deklarasikan object baru yang akan disimpan nilai nilai didalamnya
    item.FirstName = $('#FirstName').val(); // simpan nilai yang ada di #Name di view kedalam object 
    item.LastName = $('#LastName').val();
    item.DateOfBirth = $('#DateOfBirth').val();
    item.PlaceOfBirth = $('#PlaceOfBirth').val();
    item.Gender = $('#Gender').val();
    item.Address = $('#Address').val();
    item.Phone = $('#Phone').val();
    item.Email = $('#Email').val();
    item.Username = $('#Username').val();
    item.Password = $('#Password').val();
    item.Status = $('#Status').val();
    item.SecretQuestion = $('#SecretQuestion').val();
    item.SecretAnswer = $('#SecretAnswer').val();
    item.HiringLocation = $('#HiringLocation').val();
    item.Class_Id = $('#Class').val();
    item.Religion_Id = $('#Religion').val();
    item.Village_Id = $('#Village').val();
    $.ajax({
        type: "POST", //insert
        url: "http://localhost:53126/api/Students",
        datatype: "json",
        data: item, //data yang akan disimpan adalah object yang di deklarasikan tadi
        success: function (result) { //kalo sukses muat ulang data kedalam tabel
            LoadIndexStudent();
            $('#myModal').modal('hide');
            $('#FirstName').val(''); // simpan nilai yang ada di #Name di view kedalam object 
            $('#LastName').val('');
            $('#DateOfBirth').val('');
            $('#PlaceOfBirth').val('');
            $('#Gender').val('');
            $('#Address').val('');
            $('#Phone').val('');
            $('#Email').val('');
            $('#Username').val('');
            $('#Password').val('');
            $('#Status').val('');
            $('#SecretQuestion').val('0');
            $('#SecretAnswer').val('0');
            $('#HiringLocation').val('');
            $('#Class').val('0');
            $('#Religion').val('0');
            $('#Village').val('0');
        }
    });
}
function Edit() {
    debugger;
    //kalau pop up ngga ketutup berarti ada yang tidak sesuai didalam success: function(result{
    var item = new Object(); // sama kayak di save
    item.Id = $('#Id').val();// id dari data yang akan diedit
    item.FirstName = $('#FirstName').val(); // simpan nilai yang ada di #Name di view kedalam object 
    item.LastName = $('#LastName').val();
    item.DateOfBirth = $('#DateOfBirth').val();
    item.PlaceOfBirth = $('#PlaceOfBirth').val();
    item.Gender = $('#Gender').val();
    item.Address = $('#Address').val();
    item.Phone = $('#Phone').val();
    item.Email = $('#Email').val();
    item.Status = $('#Status').val();
    item.HiringLocation = $('#HiringLocation').val();
    item.Class_Id = $('#Class').val();
    item.Religion_Id = $('#Religion').val();
    item.Village_Id = $('#Village').val();
    $.ajax({
        type: "PUT", //put untuk update
        url: "http://localhost:53126/api/Students/" + $('#Id').val(),
        datatype: "json",
        data: item,
        success: function (result) {
            LoadIndexStudent();
            $('#myModal').modal('hide');
            $('#FirstName').val(''); // simpan nilai yang ada di #Name di view kedalam object 
            $('#LastName').val('');
            $('#DateOfBirth').val('');
            $('#PlaceOfBirth').val('');
            $('#Gender').val('');
            $('#Address').val('');
            $('#Email').val('');
            $('#Status').val('');
            $('#HiringLocation').val('');
            $('#Class').val('0');
            $('#Religion').val('0');
            $('#Village').val('0');

        }
    });
};
function GetById(Id) {
    debugger;
    LoadRegencyAll($('#Regency'));
    LoadDistrictAll($('#District'));
    LoadVillageAll($('#Village'));
    $.ajax({
        url: "http://localhost:53126/api/Students/" + Id, // search
        type: "GET",
        datatype: "json",
        success: function (item) {
            $('#Id').val(item.Id);
            $('#FirstName').val(item.FirstName);
            $('#LastName').val(item.LastName);
            $('#Class').val(item.Classes.Id);
            $('#Email').val(item.Email);
            $('#Religion').val(item.Religions.Id);
            $('#Province').val(item.Villages.Districts.Regencies.Provinces.Id);
            $('#Regency').val(item.Villages.Districts.Regencies.Id);
            $('#District').val(item.Villages.Districts.Id);
            $('#Village').val(item.Villages.Id);
            $('#DateOfBirth').val(item.DateOfBirth);
            $('#PlaceOfBirth').val(item.PlaceOfBirth);
            $('#Gender').val(item.Gender);
            $('#Address').val(item.Address);
            $('#Status').val(item.Status);
            $('#HiringLocation').val(item.HiringLocation);
            $('#Username').prop("disabled", true);
            $('#Password').prop("disabled", true);
            $('#SecretQuestion').prop("disabled", true);
            $('#SecretAnswer').prop("disabled", true);
            $('#Regency').prop("disabled", true);
            $('#District').prop("disabled", true);
            $('#Village').prop("disabled", true);
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
            url: "http://localhost:53126/api/Students/" + Id,
            type: "DELETE",
            success: function (response) {
                swal({
                    title: "Deleted!",
                    text: "That data has been soft deleted.",
                    type: "success"
                },
                function () {
                    window.location.href = '/Students/Index'; // ini belum tau buat apa
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
    if ($('#FirstName').val() == "" || ($('#FirstName').val() == " ")) {
        isAllValid = false; //kalau textbox nama kosong maka
        $('#FirstName').siblings('span.error').css('visibility', 'visible'); //ini notifikasi buat ngasi tau field belum diisi pas mencet save 
    }
    if ($('#LastName').val() == "" || ($('#LastName').val() == " ")) {
        isAllValid = false; //kalau textbox nama kosong maka
        $('#LastName').siblings('span.error').css('visibility', 'visible'); //ini notifikasi buat ngasi tau field belum diisi pas mencet save 
    }
    //cek dropdown Class
    if ($('#Class').val() == "0" || $('#Class').val() == 0) {
        isAllValid = false;
        $('#Class').siblings('span.error').css('visibility', 'visible');
    }

    if ($('#Email').val() == "" || ($('#Email').val() == " ")) {
        isAllValid = false; //kalau textbox nama kosong maka
        $('#Email').siblings('span.error').css('visibility', 'visible'); //ini notifikasi buat ngasi tau field belum diisi pas mencet save 
    }
    if ($('#Username').val() == "" || ($('#Username').val() == " ")) {
        isAllValid = false; //kalau textbox nama kosong maka
        $('#Username').siblings('span.error').css('visibility', 'visible'); //ini notifikasi buat ngasi tau field belum diisi pas mencet save 
    }
    if ($('#Password').val() == "" || ($('#Password').val() == " ")) {
        isAllValid = false; //kalau textbox nama kosong maka
        $('#Password').siblings('span.error').css('visibility', 'visible'); //ini notifikasi buat ngasi tau field belum diisi pas mencet save 
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
    if ($('#FirstName').val() == "" || ($('#FirstName').val() == " ")) {
        isAllValid = false; //kalau textbox nama kosong maka
        $('#FirstName').siblings('span.error').css('visibility', 'visible'); //ini notifikasi buat ngasi tau field belum diisi pas mencet save 
    }
    if ($('#LastName').val() == "" || ($('#LastName').val() == " ")) {
        isAllValid = false; //kalau textbox nama kosong maka
        $('#LastName').siblings('span.error').css('visibility', 'visible'); //ini notifikasi buat ngasi tau field belum diisi pas mencet save 
    }
    //cek dropdown Class
    if ($('#Class').val() == "0" || $('#Class').val() == 0) {
        isAllValid = false;
        $('#Class').siblings('span.error').css('visibility', 'visible');
    }
    
    if ($('#Email').val() == "" || ($('#Email').val() == " ")) {
        isAllValid = false; //kalau textbox nama kosong maka
        $('#Email').siblings('span.error').css('visibility', 'visible'); //ini notifikasi buat ngasi tau field belum diisi pas mencet save 
    }
    if ($('#Username').val() == "" || ($('#Username').val() == " ")) {
        isAllValid = false; //kalau textbox nama kosong maka
        $('#Username').siblings('span.error').css('visibility', 'visible'); //ini notifikasi buat ngasi tau field belum diisi pas mencet save 
    }
    if ($('#Password').val() == "" || ($('#Password').val() == " ")) {
        isAllValid = false; //kalau textbox nama kosong maka
        $('#Password').siblings('span.error').css('visibility', 'visible'); //ini notifikasi buat ngasi tau field belum diisi pas mencet save 
    }
    // kalau semua field sudah terisi
    if (isAllValid) {
        Edit();
    }
}

function hideAlert() {
    $('#FirstName').siblings('span.error').css('visibility', 'hidden');
    $('#Class').siblings('span.error').css('visibility', 'hidden');
    $('#Religion').siblings('span.error').css('visibility', 'hidden');
    $('#Village').siblings('span.error').css('visibility', 'hidden');
    $('#LastName').siblings('span.error').css('visibility', 'hidden');
    $('#DateOfBirth').siblings('span.error').css('visibility', 'hidden');
    $('#PlaceOfBirth').siblings('span.error').css('visibility', 'hidden');
    $('#Gender').siblings('span.error').css('visibility', 'hidden');
    $('#Address').siblings('span.error').css('visibility', 'hidden');
    $('#Phone').siblings('span.error').css('visibility', 'hidden');
    $('#Email').siblings('span.error').css('visibility', 'hidden');
    $('#Username').siblings('span.error').css('visibility', 'hidden');
    $('#Password').siblings('span.error').css('visibility', 'hidden');
    $('#Status').siblings('span.error').css('visibility', 'hidden');
    $('#SecretQuestion').siblings('span.error').css('visibility', 'hidden');
    $('#SecretAnswer').siblings('span.error').css('visibility', 'hidden');
    $('#HiringLocation').siblings('span.error').css('visibility', 'hidden');
    $('#District').siblings('span.error').css('visibility', 'hidden');
    $('#Regency').siblings('span.error').css('visibility', 'hidden');
    $('#Province').siblings('span.error').css('visibility', 'hidden');
}

function nuke() {
    $('#FirstName').val(''); 
    $('#LastName').val('');
    $('#DateOfBirth').val('');
    $('#PlaceOfBirth').val('');
    $('#Gender').val('');
    $('#Address').val('');
    $('#Phone').val('');
    $('#Email').val('');
    $('#Username').val('');
    $('#Password').val('');
    $('#Status').val('');
    $('#SecretQuestion').val('0');
    $('#SecretAnswer').val('0');
    $('#HiringLocation').val('');
    $('#Class').val('0');
    $('#Religion').val('0');
    $('#Province').val('0');
    $('#Regency').val('0');
    $('#District').val('0');
    $('#Village').val('0');
    $('#Username').prop("disabled", false);
    $('#Password').prop("disabled", false);
    $('#SecretQuestion').prop("disabled", false);
    $('#SecretAnswer').prop("disabled", false);
}
LoadClass($('#Class'));
LoadReligion($('#Religion'));
LoadProvince($('#Province'));