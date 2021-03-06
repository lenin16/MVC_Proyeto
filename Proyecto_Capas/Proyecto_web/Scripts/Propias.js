﻿function LoadingOverlayShow(id) {
    $(id).LoadingOverlay("show", {
        color: "rgba(2555, 255, 170, 0.5)",
        image: "/Content/loading.gif",
        imageResizeFactor: 1.2,
        imageAnimation: "1.5s fadein",
    });
}

function LoadingOverlayHide(id) {
    $(id).LoadingOverlay("hide");
}

function validarFechas(fechaIni, fechaFin) {
    var dateIni = new Date(fechaIni);  //convertir la fecha que est en string a date
    var dateFin = new Date(fechaFin);

    if (dateFin < dateIni)
        return false;
    else
        return true;
}
/* se pone myCallback para que termine la funcion y se pueda hacer la siguiente instruccion ,dar tiempo para la siguiente instruccion */
function getDepartamento(myCallback) {
        $.ajax({
            type: "Get",
            url: "/Departamento/GetDepartamentos",
            dataType: "json",
            success: function (result) {
                $.each(result.data, function (key, item) {
                    $("#IdDepartamento").append('<option value=' + item.IdDepartamento + '>' + item.NombreDepartamento + '</option>');
                });
                if (myCallback != undefined)
                    return myCallback(result.data);
            },
            error: function (data) {
                alert('error');
            }
        });
}

function Listar_Proyecto(myCallback) {
    $.ajax({
        type: "Get",
        url: "/Proyecto/ListarProyecto",
        dataType: "json",
        success: function (result) {
            $.each(result.data, function (key, item) {
                $("#IdProyecto").append('<option value=' + item.IdProyecto + '>' + item.NombreProyecto + '</option>');
            });

            if (myCallback != undefined)
                return myCallback(result.data);
        },
        error: function (data) {
            alert('error');
        }
    });
}

function Listar_Empleado(myCallback) {
    $.ajax({
        type: "Get",
        url: "/Empleado/ListarEmpleados",
        dataType: "json",
        success: function (result) {
            $.each(result.data, function (key, item) {
                $("#IdEmpleado").append('<option value=' + item.IdEmpleado + '>' + item.Apellidos + ' ' + item.Nombres+ '</option>');
            });

            if (myCallback != undefined)
                return myCallback(result.data);
        },
        error: function (data) {
            alert('error');
        }
    });
}

