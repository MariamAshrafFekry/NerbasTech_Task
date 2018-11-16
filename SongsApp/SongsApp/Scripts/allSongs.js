// Start Display all Songs
$("#ibtn-close-songs").click(function () {
    $("#idiv-result-result .row").remove();
    $("#idiv-result hr").remove();
});
function displayAllSongs(song, name) {
    html = $("<div class='row'>").append("<center><div class='cdiv-song'><span class='cspan-song-name'>" + name + "</span>")
        .append("<audio controls class='col-md-8 audio'><source src ='" + song + "' type = 'audio/mp3' /></audio >")
        .append("<button class='col-md-offset-1 btn btn-primary cbtn-audio-download'><a class='ca-audio' href='" + song + "' download='file.mp3'>Download</a></button>")
        .append("</div></div></center>");
    $("#idiv-result").append(html);
    $("#idiv-result").append("<hr>");
    $("<div class='row'>").append("</div>");
}
$("#ibtn-songs-all").click(function () {
    $("#imodal-songs-result button.close").prop('disabled', true);
    $("#imodal-songs-result .cdiv-custom-alert").addClass('hidden');
    $("#imodal-songs-result #idiv-result").append('<span class="cspn-proxy"><span class="cspn-loader"></span><br />Loading...</span>');
    $.ajax({
        type: 'POST',
        url: '/Song/GetAllSongs',
        dataType: 'json',
        success: function (data) {
            var songs = data.songs;
            var songsCount = data.count;
            for (var i = 0; i < songsCount; i++) {
                displayAllSongs(songs[i].song, songs[i].Name);
            }
            $("#imodal-songs-result #idiv-result .cspn-proxy").remove();
            $("#imodal-songs-result button.close").prop('disabled', false);
        },
        error: function (data) {
            alert("Sorry an error happened please try again");
        }
    });
});
// End Display all Songs