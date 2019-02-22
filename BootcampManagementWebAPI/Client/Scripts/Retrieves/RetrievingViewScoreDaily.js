
$(document).ready(function () {
    LoadIndexDailyScore();
    $('#table').DataTable({
        "ajax": LoadIndexDailyScore()
    })
})

function LoadIndexDailyScore() {
    $.ajax({
        type: "GET", //untuk menampilkan data
        url: "http://localhost:53126/api/DailyScores/",
        async: false, // ini untuk menjalankan fungsi search dan sorting data table
        datatype: "json",
        success: function (dailyscore) {
            var html = '';
            $.each(dailyscore, function (index, val) {
                html += '<tr>';
                //html += '<td>' + i + '</td>'; ini kalau mau nampilkan nomor 1 sampai sekian
                html += '<td>' + val.Date + '</td>';
                html += '<td>' + val.Score1 + '</td>';
                html += '<td>' + val.Score2 + '</td>';
                html += '<td>' + val.Score3 + '</td>';
                //html += '<td>' + val.Students.First_Name + '</td>';
                //html += '<td>' + val.Lessons.Name + '</td>';
                html += '</tr>';
                //i++;
            });
            $('.tbody').html(html);// ini untuk menerapkan koding html diatas

        }
    });
}