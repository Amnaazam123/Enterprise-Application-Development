$(document).ready(function () {
     $("#b1").click(function () {
        //qk partial view shared hai, isi liye sath url me ye btaen k kis controller is is partial view me aa ray. 
        $.get("/Home/NewsPartialView", function (NewsPartialViewCode) {
            $("#PartialPlaceHolder").html(NewsPartialViewCode);
        });
    });
 });


$(document).ready(function () {
    $("#b2").click(function () {
            $("#PartialPlaceHolder").html("");
    });
});


