﻿$(function () {

    var vProveedor = $('#proveedor').val();
    var vServicio = $('#servicio').val();
    //var vTarifa = $('#periodo').val();
    
    $('#dtp_start').datetimepicker({
        defaultDate: new Date(),
    });
    $('#dtp_beginning').datetimepicker();
    $('#dtp_ending').datetimepicker();

        function renderTextColor(data, type, row, meta) {
        var text = data.toLowerCase();
        var template = $('<span>');
        if (text.indexOf('no aplicable') >= 0) {
            template.css('color', 'green').html(data);
        } else if (text.indexOf('conforme') >= 0) {
            template.css('color', 'green').html(data);
        } else if (text.indexOf('pendiente') >= 0) {
            template.css('color', 'red').html(data);
        } else {
            template.css('color', 'red').html(data);
        }
        return $('<div>').append(template).html();
    }

        

    // Listar Fechas POr Temporada

        $('#temporada').on('change', function () {
            var Temporada = $(this).val();
            var Fecha_Inicio = "";
            var Fecha_Final = "";
            var fecha = '1001-01-01 00:00';
            var max_fields = 1;
            var x = 0;
            debugger;
            $.ajax({
                type: 'POST',
                url: '/Tarifa/ListadoFechasXTemporada',
                contentType: 'application/json; charset=utf-8',
                data: JSON.stringify({ Temporada: Temporada }),
                success: function (data) {                    
                    Fecha_Inicio = data.FECHA_INICIO;
                    Fecha_Final = data.FECHA_FIN;
                    debugger;

                    if (fecha == Fecha_Inicio && fecha == Fecha_Final) {
                        $("#dtp_beginning").remove();
                        $("#dtp_ending").remove();
                        $(".dtp_beginning").append('<div class="input-group date" id="dtp_beginning"><input type="text" class="form-control input-sm" data-date-format="YYYY-MM-DD"/><span class="input-group-addon input-sm"><i class="fa fa-calendar"></i></span></div>');
                        $(".dtp_ending").append('<div class="input-group date" id="dtp_ending"><input type="text" class="form-control input-sm" data-date-format="YYYY-MM-DD"/><span class="input-group-addon input-sm"><i class="fa fa-calendar"></i></span></div>');
                        $('#dtp_beginning').datetimepicker();
                        $('#dtp_ending').datetimepicker();

                    }

                    

                    if (data.length != 0) {
                        if (fecha != Fecha_Inicio) {
                            if (x < max_fields) {
                                $("#dtp_beginning").remove();
                                $("#dtp_ending").remove();
                                $(".dtp_beginning").append('<div class="input-group date" id="dtp_beginning"><input type="text" class="form-control input-sm" value ="' + Fecha_Inicio + '"" data-date-format="YYYY-MM-DD"/><span class="input-group-addon input-sm"><i class="fa fa-calendar"></i></span></div>');
                                $(".dtp_ending").append('<div class="input-group date" id="dtp_ending"><input type="text" class="form-control input-sm" value ="' + Fecha_Final + '"" data-date-format="YYYY-MM-DD"/><span class="input-group-addon input-sm"><i class="fa fa-calendar"></i></span></div>');
                                $('#dtp_beginning').datetimepicker();
                                $('#dtp_ending').datetimepicker();
                            }
                        }
            
                   }
                   
                },
            })

        });


    //*Guardar Tarifa*//

    //function onClickGuardarTarifa() {
    //    debugger;
    //    var valor = 0;
    //    var vProveedor = $('#proveedor').val();

    //    if ($('input#inlineCheckbox1').is(':checked')) {
    //        valor = 1
    //    }
    //    else {
    //        valor = 0        }
      
    //    var data = {            
    //        eTarifa: {
    //            Proveedor: vProveedor,
    //            Estado: valor,
    //            Nombre: $('#tarifa').val(),
    //            Fecha_Comenzar: $('#dtp_start').data('DateTimePicker').date(),
    //            Temporada: $('#temporada').val(),                
    //            Notas: $('#notas').val(),
    //        }
    //    }


    //    $.ajax({
    //        type: 'POST',
    //        url: '/Tarifa/GuardarTarifa',
    //        contentType: 'application/json; charset=utf-8',
    //        data: JSON.stringify(data)
    //    })
    //    .done(function (data) {
    //        debugger;
    //        showSuccessMessage('Se ha guardado la tarifa');
    //        setTimeout(function () {
    //            window.location = '/Tarifa/TarifaProveedor?proveedor=' + vProveedor;
    //        }, 2000);
    //    })
    //    .fail(function () {
    //        showErrorMessage('No se pudo guardar el tarifario. Inténtelo de nuevo.');
    //        enableAllComponents(true);
    //    });
    //}

    function onClickRegistrarTarifa(e) {
        e.preventDefault();

        var lstTarifas = new Array();

        

        desde = $("#npersona").val(),
        hasta = $("#hasta").val();

        //var data = {
        //    eTarifa: {
        //        Periodo_Fechas: $("#periodo").val(),
        //        Tipo_Acomodacion: $("#tipoacomodacion").val(),
        //        Tipo_Acomodacion: $("#tipoacomodacion").val(),
        //        Tipo_Pasajero: $("#tipopasajero").val(),
        //        N_Persona: $("#npersona").val(),
        //        N_hasta: $("#hasta").val(),
        //        Precio: $("#neto").val(),
        //    }
        //}
        debugger;
        while (desde <= hasta) {
            var Tarifa = {};
            Tarifa.TARIFA = $("#periodo").val();
            Tarifa.RANGO = + desde ;
            Tarifa.PROVEEDOR = vProveedor;
            Tarifa.SERVICIO = vServicio;
            Tarifa.Tipo_Acomodacion = $("#tipoacomodacion").val();
            Tarifa.Tipo_Pasajero = $("#tipopasajero").val();
            Tarifa.Precio = $("#neto").val();
            desde++
            lstTarifas.push(Tarifa);
            };

        $.ajax({
            type: 'POST',
            url: '/Tarifa/GuardarTarifa',
            contentType: 'application/json; charset=utf-8',
            data: JSON.stringify(lstTarifas)
        })
        .done(function (data) {
            showSuccessMessage('Se ha guardado el tarifario');
            setTimeout(function () {
                window.location = '/Tarifa/TarifaProveedor?Servicio=' + vServicio + '&Proveedor=' + vProveedor;
            }, 2000);
        })
        .fail(function () {
            showErrorMessage('No se pudo guardar el tarifario. Inténtelo de nuevo.');
            enableAllComponents(true);
        });        
    }

    function onClickRegistrarPeriodo(e) {
        e.preventDefault();

        var Proveedor = $("#proveedor").val();
        var Servicio = $("#servicio").val();

        window.location = '/Periodo/Index?Servicio=' + Servicio + '&Proveedor=' + Proveedor;
        //window.location = '/Tarifa/TarifaProveedor?Servicio=' + item["SERVICIO"] + '&Proveedor=' + item["PROVEEDOR"];
    }


    function onClickRegistrarTarifaDetalle(e) {
        e.preventDefault();
        var item = grid.row($(this).parents('tr')).data();
        if (!item) {
            item = grid.row($(e.target).parents('tr').prev()).data();
        }
        debugger;

        //var Tarifa = item.TARIFA;
        //var Proveedor = item.PROVEEDOR;

        window.location = '/TarifaDetalle/NuevaTarifaDetalle?Proveedor=' + item.PROVEEDOR + '&Tarifa=' + item.TARIFA;

    }

    function onClickListarServiciotarifa(e) {
        e.preventDefault();
        var item = grid.row($(this).parents('tr')).data();
        if (!item) {
            item = grid.row($(e.target).parents('tr').prev()).data();
        }
        debugger;

        var Tarifa = item.TARIFA;
        var Proveedor = item.PROVEEDOR;

        window.location = '/TarifaDetalleServicio/Index?Proveedor=' + item.PROVEEDOR + '&Tarifa=' + item.TARIFA;
    }





    //*LISTA TARIFA*//
    var grid = $('#resultados').DataTable({
        scrollX: true,
        paging: true,
        processing: true,
        ordering: false,
        deferLoading: 0,
        responsive: {
            details: {
                type: 'column',
                display: $.fn.dataTable.Responsive.display.childRowImmediate,
                renderer: function (api, index, columns) {
                    $('div#resultados_wrapper .dataTables_scrollHead').hide();

                    var row = $(api.row(index).node());
                    row.hide();

                    var html = $('#responsive-template').html();
                    var a = document.getElementById('yourlinkId'); //or grab it by tagname etc


                    var template = $(html);
                    template.find('#tarifa').html(columns[0].data);
                    template.find('#nombre').html(columns[1].data);
                    template.find('#fechavalidez').html(columns[2].data);
                    template.find('#fechainivigencia').html(columns[3].data);

                    //setTextColor(template, '#descripcion', columns[1].data);

                    return template;
                }
            }
        },

        ajax: {
            method: 'GET',
            //url: '/Tarifa/ListadoTarifa?Proveedor=' + vProveedor + '&Servicio=' + vServicio + '&Tarifa=' + vTarifa,
            url: '/Tarifa/ListadoTarifa',
            dataType: 'json',
            dataSrc: '',
            data: function (items) {
                var filtro = {                    
                    Proveedor: vProveedor,
                    Servicio: vServicio,
                    Tarifa: $.trim($('#periodo').val())
                };
                return filtro;
            }
        },

        columns: [
    {
        title: 'TARIFA',
        data: 'TARIFA',
        width: 70,
        className: 'not-mobile',
        visible: true,

    },

    {
        title: 'PROVEEDOR',
        data: 'PROVEEDOR',
        width: 50,
        className: 'not-mobile',
        visible: false,
    },

    {
        title: 'SERVICIO',
        data: 'SERVICIO',
        width: 100,
        className: 'not-mobile',
        visible: false,
    },
    {
        title: 'TIPO_ACOMODACION',
        data: 'TIPO_ACOMODACION',
        width: 40,
        className: 'not-mobile'
    },


    {
        title: 'TIPO_PASAJERO',
        data: 'TIPO_PASAJERO',
        width: 40,
        className: 'not-mobile',
        visible: true,
    },
    {
        title: 'RANGO',
        data: 'RANGO',
        width: 50,
        className: 'not-mobile',
        visible: true,
    },

    {
        title: 'PRECIO',
        data: 'PRECIO',
        width: 40,
        className: 'not-mobile',
        visible: true,
    },
        ]
    });   


    $('#resultados tbody').on('click', 'button.RegistrarTarifDetalle', onClickRegistrarTarifaDetalle);
    window.onClickRegistrarTarifaDetalle = onClickRegistrarTarifaDetalle;


    $('#resultados tbody').on('click', 'button.ListarServiciotarifa', onClickListarServiciotarifa);
    window.onClickListarServiciotarifa = onClickListarServiciotarifa;

    $('.form-horizontal').on('click', 'button.RegistrarTarifa', onClickRegistrarTarifa);
    window.onClickRegistrarTarifa = onClickRegistrarTarifa;

    $('.form-horizontal').on('click', 'button.RegistrarPeriodo', onClickRegistrarPeriodo);
    window.onClickRegistrarPeriodo = onClickRegistrarPeriodo;
    

    $('#periodo').change(function () {
        grid.ajax.reload();
    })

});