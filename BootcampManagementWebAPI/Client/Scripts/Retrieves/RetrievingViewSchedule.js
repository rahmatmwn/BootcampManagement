$(document).ready(function () {
    LoadIndexSchedule();
    $('#table').DataTable({
        "ajax": LoadIndexSchedule()
    })
})

function LoadIndexSchedule() {
    $.ajax({
        type: "GET", //untuk menampilkan data
        url: "http://localhost:53126/api/Schedules" + Id,
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
                html += '</tr>';
                //i++;
            });
            $('.tbody').html(html);// ini untuk menerapkan koding html diatas

        }
    });
}