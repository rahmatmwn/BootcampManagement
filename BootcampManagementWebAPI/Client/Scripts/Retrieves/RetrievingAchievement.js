var Students = []
$(document).ready(function () {
    hideAlert();
    LoadIndexAchievement();
    $('#table').DataTable({
        "ajax": LoadIndexAchievement()
    })
})

function LoadStudent(element) {
    if (Students.length == 0) {
        $.ajax({
            type: "GET", // get
            url: 'http://localhost:53126/api/Students',
            success: function (data) {
                Students = data; //Achievement
                //and render Achievement to element
                renderStudent(element);
            }
        })
    } else {
        //render Achievement to element if var Achievements above not empty
        renderStudent(element);
    }
}
function renderStudent(element) {
    var $ele = $(element);
    $ele.empty(); //kosongkan element
    $ele.append($('<option/>').val('0').text('Select')); //tambahkan item kedalam dropdown
    $.each(Students, function (i, val) { // tambahkan item baru kedalam dropdown untuk setiap nilai yang ada didalam Achievements []
        $ele.append($('<option/>').val(val.Id).text(val.Name)); //id sama namanyanya Provincies
    })
}

function LoadIndexAchievement() {
    $.ajax({
        type: "GET", //untuk menampilkan data
        url: "http://localhost:53126/api/Achievements",
        async: false, // ini untuk menjalankan fungsi search dan sorting data table
        datatype: "json",
        success: function (kelas) {
            var html = '';
            $.each(kelas, function (index, val) {
                html += '<tr>';
                //html += '<td>' + i + '</td>'; ini kalau mau nampilkan nomor 1 sampai sekian
                html += '<td>' + val.Students.FirstName + '</td>';
                html += '<td>' + val.Name + '</td>';
                html += '<td>' + val.Date + '</td>';
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
    //kalau pop up ngga ketutup berarti ada yang tidak sesuai didalam success: function(result{ (contohnya LoadIndexItem padahal diatas tulisannya LoadIndexDepartment
    var item = new Object(); //deklarasikan object baru yang akan disimpan nilai nilai didalamnya
    item.Name = $('#Name').val(); // simpan nilai yang ada di #Name di view kedalam object
    // masih ragu disini
    item.Student_Id = $('#Student').val();
    $.ajax({
        type: "POST", //insert
        url: "http://localhost:53126/api/Achievements",
        datatype: "json",
        data: item, //data yang akan disimpan adalah object yang di deklarasikan tadi
        success: function (result) { //kalo sukses muat ulang data kedalam tabel
            LoadIndexAchievement();
            $('#myModal').modal('hide');
            $('#Name').val('');
            $('#Student').val(0);
        }
    });
}
function Edit() {
    debugger;
    //kalau pop up ngga ketutup berarti ada yang tidak sesuai didalam success: function(result{
    var item = new Object(); // sama kayak di save
    item.Name = $('#Name').val(); // simpan nilai yang ada di #Name di view kedalam object
    // masih ragu disini
    item.Student_Id = $('#Student').val();
    $.ajax({
        type: "PUT", //put untuk update
        url: "http://localhost:53126/api/Achievements/" + $('#Id').val(),
        datatype: "json",
        data: item,
        success: function (result) {
            LoadIndexAchievement();
            $('#myModal').modal('hide');
            $('#Name').val('');
            $('#Student').val(0);
        }
    });
};
function GetById(Id) {
    debugger;
    $.ajax({
        url: "http://localhost:53126/api/Achievements/" + Id, // search
        type: "GET",
        datatype: "json",
        success: function (item) {
            $('#Id').val(item.Id);
            $('#Name').val(item.Name);
            //udah benar
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
            url: "http://localhost:53126/api/Achievements/" + Id,
            type: "DELETE",
            success: function (response) {
                swal({
                    title: "Deleted!",
                    text: "That data has been soft deleted.",
                    type: "success"
                },
                function () {
                    window.location.href = '/Achievements/Index'; // ini belum tau buat apa
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

    // kalau semua field sudah terisi
    if (isAllValid) {
        Edit();
    }
}

function hideAlert() {
    $('#Name').siblings('span.error').css('visibility', 'hidden');
    $('#Student').siblings('span.error').css('visibility', 'hidden');
}

function nuke() {
    $('#Name').val('');
    $('#Student').val(0);
    hideAlert();
}

LoadStudent($('#Student'));