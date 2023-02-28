
//PRCE CHANGING
$("#_change_price").click(function () {


    $("#enter_new_price").hide();
    $("#confirm_price_div").hide();
    $("#selecting_fuel_price").show();
    $("#change_price").modal('show');
});

$("#confirm_price").click(function ( ) {

    var entered = $("#enter_price").val();
    if (entered.length== 0) {
        swal("Error!", "Please enter price to proceed", "warning"); old_p
    }
    else {

        $("#new_price").text(entered);
        $("#enter_new_price").hide();
        $("#confirm_price_div").show("slow");
        $("#selecting_fuel_price").hide();
    }
});
function confirm_price(id, price,f_names) {
    $("#fuel_id").text(id);
    $("#old_p").text(price);
    $("#_fuel_name").text(f_names);

    $("#enter_new_price").show("slow");
    $("#confirm_price_div").hide();
    $("#selecting_fuel_price").hide("slow");

}
$("#back_to_choose_fuel_price").click(function () {
    $("#enter_new_price").hide("slow");
    $("#confirm_price_div").hide("slow");
    $("#selecting_fuel_price").show("slow");

});


$("#edit_price").click(function () {
    $("#enter_new_price").show("slow");
    $("#confirm_price_div").hide("slow");
    $("#selecting_fuel_price").hide("slow");
});


$("#f_price").click(function () {


    var id = $("#fuel_id").text();
    var n_price = $("#new_price").text();
    $.ajax({
        type: "POST",
        url: "/Calculations/change_pricsene",
        data: {
            "id": id, "new_price": n_price
        },
        success: function (response) {
            //$("#selecting_fuel").hide("slow");

            if (response.response_msg != 'Ok') {
                //  swal("Error!", "Failed to change price.Please contact system admin ", "error");
                swal("Error!", response.response_msg, "error");

            }
            else {
                swal("Sucess!", "Successfully changed price!", "success", {
                    buttons: {

                        catch: {
                            text: "Ok",
                            value: "Submit",
                        },
                        /* defeat: true,*/
                    },
                })
                    .then((value) => {
                        switch (value) {


                            case "catch":
                                window.location.reload();
                                break;

                            default:
                                window.location.reload();
                        }
                    });
                //swal("Success", "Meter submitted successfully!", "success");

            }
            $("#submit_sales_modal").modal('hide');
        }


        ,
        failure: function (response) {
            swal("error", "Failed to upload", "warning");



        },
        error: function (response) {
            swal("error", response.error, "warning");


        }
    });

});



//REFILLING TANK
$("#refill_button").click(function () {


    $("#enter_quantity_refilled").hide();
    $("#confirm_refill_div").hide();
    $("#selecting_fule_refill").show();
    $("#refill_modal").modal('show');
});

$("#confirm_refill").click(function ( ) {

    var entered = $("#enter_volume").val();
    if (entered.length== 0) {
        swal("Warning!", "Please enter volume refilled in litres", "warning"); old_p
    }
    else {
        var p_v = $("#c_quantity").text();
        var r_a = entered
        var n_v = parseFloat(p_v) + parseFloat(r_a);
        var t_c = $("#t_capacity").text();

        if (parseInt(n_v) > parseInt(t_c)) {

            swal("Invalid ammount entered!", "Volume refilled does not seems to be correct.Please check and try again!", "warning"); old_p

           
        }
        else {
            $("#new_price").text(entered);
            $("#p_volume").text(p_v);
            $("#v_refilled").text(r_a);



            $("#n_volume").text(n_v);
            $("#enter_quantity_refilled").hide();
            $("#confirm_refill_div").show("slow");
            $("#selecting_fuel_price").hide();

        }


    }
});
function select_fuel_refill(id,c_quantity,t_capacity,f_name) {
    $("#f_id_r").text(id);
    $("#_f_name").text(f_name);
    $("#c_quantity").text(c_quantity);
    $("#t_capacity").text(t_capacity);
    $("#_fuel_name").text(f_name);

    $("#enter_quantity_refilled").show("slow");
    $("#confirm_refill_div").hide();
    $("#selecting_fule_refill").hide();
   

}
$("#back_to_choose_fuel_refill").click(function () {

    $("#enter_quantity_refilled").hide("slow");
    $("#confirm_refill_div").hide("slow");
    $("#selecting_fule_refill").show("slow");

});


$("#edit_refill").click(function () {
    $("#enter_quantity_refilled").show("slow");
    $("#confirm_refill_div").hide("slow");
    $("#selecting_fuel_price").hide("slow");
});


$("#f_refill").click(function () {

    var f_id = $("#f_id_r").text();
    var p_v = $("#c_quantity").text();
    var r_a = $("#enter_volume").val();
    var n_v = parseFloat(p_v) + parseFloat(r_a);
    var t_c = $("#t_capacity").text();
    $.ajax({
        type: "POST",
        url: "/Calculations/refill_fuel",
        data: {
            "id": f_id, "Ammount_refilled": r_a, "initial_readings": p_v, "final_readings": n_v,"agent_id":1
        },
        success: function (response) {
            //$("#selecting_fuel").hide("slow");

            if (response.response_msg != 'Ok') {
                //  swal("Error!", "Failed to change price.Please contact system admin ", "error");
                swal("Error!", response.response_msg, "error");

            }
            else {
                swal("Sucess!", "Refill successfully!", "success", {
                    buttons: {

                        catch: {
                            text: "Ok",
                            value: "Submit",
                        },
                        /* defeat: true,*/
                    },
                })
                    .then((value) => {
                        switch (value) {


                            case "catch":
                                window.location.reload();
                                break;

                            default:
                                window.location.reload();
                        }
                    });
                //swal("Success", "Meter submitted successfully!", "success");

            }
            $("#submit_sales_modal").modal('hide');
        }


        ,
        failure: function (response) {
            swal("error", "Failed", "warning");



        },
        error: function (response) {
            swal("error", response.error, "warning");


        }
    });

});