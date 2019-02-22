var Districts = []
$(document).ready(function () {
    hideAlert();
    LoadIndexVillage();
    $('#table').DataTable({
        "ajax": LoadIndexVillage()
    })
})

function LoadDistrict(element) {
    if (Districts.length == 0) {
        $.ajax({
            type: "GET", // get
            url: 'http://localhost:53126/api/Districts',
            success: function (data) {
                Districts = data; //Regency
                //and render Regency to element
                renderDistrict(element);
            }
        })
    } else {
        //render Regency to element if var Regencies above not empty
        renderDistrict(element);
    }
}
function renderDistrict(element) {
    var $ele = $(element);
    $ele.empty(); //kosongkan element
    $ele.append($('<option/>').val('0').text('Select')); //tambahkan village kedalam dropdown
    $.each(Districts, function (i, val) { // tambahkan village baru kedalam dropdown untuk setiap nilai yang ada didalam Regencys []
        $ele.append($('<option/>').val(val.Id).text(val.Name)); //id sama namanyanya Provincies
    })
}

function LoadIndexVillage() {
    $.ajax({
        type: "GET", //untuk menampilkan data
        url: "http://localhost:53126/api/Villages",
        async: false, // ini untuk menjalankan fungsi search dan sorting data table
        datatype: "json",
        success: function (village) {
            var html = '';
            $.each(village, function (index, val) {
                html += '<tr>';
                //html += '<td>' + i + '</td>'; ini kalau mau nampilkan nomor 1 sampai sekian
                html += '<td>' + val.Name + '</td>';
                html += '<td>' + val.Districts.Name + '</td>'; //ini untuk tampilkan foreign key
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
    var village = new Object(); //deklarasikan object baru yang akan disimpan nilai nilai didalamnya
    village.Name = $('#Name').val(); // simpan nilai yang ada di #Name di view kedalam object 
    village.Districts_Id = $('#District').val();// masih ragu disini
    $.ajax({
        type: "POST", //insert
        url: "http://localhost:53126/api/Villages",
        datatype: "json",
        data: village, //data yang akan disimpan adalah object yang di deklarasikan tadi
        success: function (result) { //kalo sukses muat ulang data kedalam tabel
            LoadIndexVillage();
            $('#myModal').modal('hide');
            $('#Name').val('');
            $('#District').val(0);
        }
    });
}
function Edit() {
    debugger;
    //kalau pop up ngga ketutup berarti ada yang tidak sesuai didalam success: function(result{
    var village = new Object(); // sama kayak di save
    village.Id = $('#Id').val();// id dari data yang akan diedit
    village.Name = $('#Name').val();// data yang akan diedit
    village.Districts_Id = $('#District').val();// masih ragu disini
    $.ajax({
        type: "PUT", //put untuk update
        url: "http://localhost:53126/api/Villages/" + $('#Id').val(),
        datatype: "json",
        data: village,
        success: function (result) {
            LoadIndexVillage();
            $('#myModal').modal('hide');
            $('#Name').val('');
            $('#District').val(0);
        }
    });
};
function GetById(Id) {
    debugger;
    $.ajax({
        url: "http://localhost:53126/api/Villages/Get/" + Id, // search
        type: "GET",
        datatype: "json",
        success: function (village) {
            $('#Id').val(village.Id);
            $('#Name').val(village.Name);
            $('#District').val(village.Districts.Id);//udah benar
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
            url: "http://localhost:53126/api/Villages/" + Id,
            type: "DELETE",
            success: function (response) {
                swal({
                    title: "Deleted!",
                    text: "That data has been soft deleted.",
                    type: "success"
                },
                function () {
                    window.location.href = '/Villages/Index'; // ini belum tau buat apa
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
    //cek dropdown Province
    if ($('#District').val() == "0" || $('#District').val() == 0) {
        isAllValid = false;
        $('#District').siblings('span.error').css('visibility', 'visible');
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
    //cek dropdown Province
    if ($('#District').val() == "0" || $('#District').val() == 0) {
        isAllValid = false;
        $('#District').siblings('span.error').css('visibility', 'visible');
    }
    // kalau semua field sudah terisi
    if (isAllValid) {
        Edit();
    }
}

function hideAlert() {
    debugger;
    $('#Name').siblings('span.error').css('visibility', 'hidden');
    $('#District').siblings('span.error').css('visibility', 'hidden');
}

function nuke() {
    $('#Name').val('');
    $('#District').val(0);
    $('#Update').hide();
    $('#Save').show();
    hideAlert();
}
LoadDistrict($('#District'));