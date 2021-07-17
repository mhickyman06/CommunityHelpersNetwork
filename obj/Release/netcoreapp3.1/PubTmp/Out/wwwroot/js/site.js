// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

(function ($) {
});

$(".navbar-toggler").on("click", function () {

    $(".navbar-nav").css("padding-left", "20px");
});

$(".help-icon").on("onmouseover", function () {
    $(".sub-menu-1").css("display", "none");
});

$('.aHandler').click(function (event) {
    event.preventDefault();
    
});

//$(document).ready(function () {
  
//});
//$(document).ready(function () {
//    $("#ListBranchesTable").DataTable({
//        "scrollY": "450px",
//        "scrollCollapse": true,
//        "paging": true,
//    })
//});


//$(document).ready(function () {
//    $("#userstable").DataTable({
//        "scrollY": "450px",
//        "scrollCollapse": true,
//        "paging": true,
//    })
//});

//$(document).ready(function () {
//    $("#newsList").DataTable({
//        "scrollY": "450px",
//        "scrollCollapse": true,
//        "paging": true,
//    })
//});

$(document).ready(function () {
    
    //$("#BranchesTable").DataTable({
    //    "scrollY": "450px",
    //    "scrollCollapse": true,
    //    "paging": true,
    //});
    $("#ListBranchesTable").DataTable({
        //"scrollY": "450px",
        "scrollCollapse": false,
        "paging": true,
        "scrollX": true,
        "scroller": true,
    });
    $("#branchesTable").DataTable({
        //"scrollY": "450px",
        "scrollCollapse": false,
        "paging": true,
        "scrollX": true,
        "scroller":true
        
    });

    //$("#ListBranchesTable").DataTable({
    //    "scrollY": "450px",
    //    "scrollCollapse": true,
    //    "paging": true,
    //});

    $("#userstable").DataTable({
        //"scrollY": "450px",
        "scrollCollapse": false,
        "paging": true,
        "scrollX": "600px",
        //"scroller": true
    });


    $("#newsList").DataTable({
        //"scrollY": "450px",
        "scrollCollapse": true,
        "paging": true,
         "scrollX": true,
        "scroller":true
    });
    var imageFile = ["carousel-img1.jpg","carousel-img2.jpg", "carousel-img3.jpg", "carousel-img4.jpg"];
    var currentIndex = 0;
    setInterval(function () {
        if (currentIndex == imageFile.length) {
            currentIndex = 0;
        }
        $(".header-top1").fadeIn(10).css('background-image', 'url(../../Images/' + imageFile[currentIndex++] + ')');
        $(".donate-top1").fadeIn(10).css('background-image', 'url(../../Images/' + imageFile[currentIndex++] + ')');

    }, 3000);
  
});

