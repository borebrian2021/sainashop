

function openNav() {
    var x = document.getElementById("mySidenav");
    if (x.style.width == "0px") {
        document.getElementById("mySidenav").style.width = "180px";
        //document.getElementById("close").style.display = "block";
        //document.getElementById("main").style.marginLeft = "0px";
        document.getElementById("mySidenav").style.marginLeft = "8px";
    }
    else {
        document.getElementById("mySidenav").style.width = "0px";
        //document.getElementById("open").style.display = "block";
        //document.getElementById("close").style.display = "none";
        document.getElementById("main").style.marginLeft = "0";
    }
    //$("hide").show();
   

   

}

function closeNav() {
    $("show").show();
    $("hide").hide();
}
//}
//document.addEventListener("click", () => {
//    document.getElementById("mySidenav").style.width = "0px";
//    $("#submit_sales_modal").click(function () {

//        alert("shasasf");

//    });
//}, true);

