// Write your JavaScript code.
function ChangeDateFormat(value) {
    if (value === null) return "";
    return moment(value).format("DD/MM/YYYY");
}
function CreateDataTable(params) {
    var dom = params["DOM"];
    if (dom === undefined) { dom = "lfrtip"; }

    var lenMenu = [[10, 25, 50, -1], ['10', '25', '50', 'Show All']];
    if (params["LENMENU"] === undefined) {
        lenMenu = [[10, 25, 50, 100, 1000], ['10', '25', '50', '100', '1000']];
    } else {
        lenMenu = params["LENMENU"];
    }

    var allowPaging = params["PAGING"];
    if (allowPaging === undefined) { allowPaging = true; }
    
    var table = params["TABLE"].dataTable({
        "processing": false,
        "serverSide": true,
        "searching": true,
        "paging": allowPaging,
        "oLanguage": { "sInfoFiltered": "" },
        "ajax": {
            "url": params["URL"],
            "type": "POST",
            "data": params["AJAXDATA"]
        },
        "dom": dom,
        "columns": GetColumns(params["COLUMNS"]),
        "order": params["ORDER"],
        "search": {
            "search": params["DSEARCH"]
        },
        "columnDefs": params["COLUMNDEFS"],
        buttons: params["BUTTONS"],
        lengthMenu: lenMenu,
        "responsive": true
    });

    return table;
}

function GetColumns(colPara) {
  
    var array = [];
    for (x = 0; x < colPara.length; x++) {
        var value = colPara[x];

        if (value.constructor === Object) {
            array.push({
                "name": value["NAME"],
                "data": value["DATA"],
                "render": value["RENDER"]
            });
        } else {
            array.push({
                "name": value,
                "data": value
            });
        }
    }
    return array;
}
