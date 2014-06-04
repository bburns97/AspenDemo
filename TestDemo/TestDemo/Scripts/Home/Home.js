$(document).ready(function () {

    var potionlistAPI = '/api/PotionsAPI/';

    jQuery("#gridMain").jqGrid({
        url: potionlistAPI,
        datatype: 'json',
        mtype: 'GET',
        colNames: ['PotionID', 'Name', 'Description', 'Allergy', 'Color', 'Effect'],
        colModel: [
            { name: 'PotionID', index: 'PotionID', width: 75 },
            { name: 'Name', index: 'Name', width: 100, editable: true },
            { name: 'Description', index: 'Description', width: 650, editable: true, edittype:'textarea', editoptions:{rows:7, cols: 30} },
            { name: 'Allergy', index: 'Allergy', width: 75, hidden: true, editable: true },
            {
                name: 'Color', index: 'Color', width: 75, editable: true, formatter: 'select',
                edittype: 'select', editoptions: {
                    value: 'Orange:Orange;Red:Red;Blue:Blue;Green:Green;Purple:Purple;White:White;Black:Black;Yellow:Yellow',
                    defaultValue: 'White',
                    dataInit: function (elem) { $(elem).css("margin-top", "8px"); }
                },
                stype: 'select', searchoptions: { sopt: ['eq', 'ne'], value: ':Any;Orange:Orange;Red:Red;Blue:Blue;Green:Green;Purple:Purple;White:White;Black:Black;Yellow:Yellow' },
                formoptions: { rowpos: 5, colpos: 1 }
            },
            {
                name: 'Effect', index: 'Effect', width: 150, editable: true, formatter: 'select',
                edittype: 'select', editoptions: {
                    value: 'Laughing:Laughing;Crying:Crying;Sneezing:Sneezing;Dancing:Dancing;Flying:Flying;Sleeping:Sleeping;Death:Death;Calmed Appetite:Calmed Appetite',
                    defaultValue: 'Laughing',
                    dataInit: function (elem) { $(elem).css("margin-top", "8px"); }
                },
                stype: 'select', searchoptions: { sopt: ['eq', 'ne'], value: 'Laughing:Laughing;Crying:Crying;Sneezing:Sneezing;Dancing:Dancing;Flying:Flying;Sleeping:Sleeping;Death:Death;Calmed Appetite:Calmed Appetite' },
                formoptions: { rowpos: 6, colpos: 1 }
            }
        ],
        pager: '#pagernav',
        height: 200,
        autowidthwidth: true,
        viewrecords: true,
        jsonReader: { repeatitems: false },
        rowNum: 10,
        gridview: true,
        rowattr: function (rd) {
            if (rd.Allergy == true) { // verify that the testing is correct in your case
                return { "class": "myAltRowClass" };
            }
        }
    });

    function updateDialog(action) {
        return {
            url: potionlistAPI
            , closeAfterAdd: true
            , closeAfterEdit: true
            , afterShowForm: function (formId) { }
            , modal: true
            , onclickSubmit: function (params) {
                var list = $("#gridMain");
                var selectedRow = list.getGridParam("selrow");
                rowData = list.getRowData(selectedRow);
                params.url += rowData.PotionID;
                params.mtype = action;
            }
            , width: "400"
            , height: "300"
        };
    }

    jQuery("#gridMain").jqGrid('navGrid', '#pagernav', { add: true, edit: true, del: true },
        updateDialog('PUT'),
        updateDialog('POST'),
        updateDialog('DELETE')
    );
});