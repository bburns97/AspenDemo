var potionlistAPI = '/api/PotionsAPI/';
var potionrecipieAPI = 'api/PotionRecipieAPI/';

$(document).ready(function () {

    var mooddl = $('#slcMood');
    mooddl.append("<option>Happy</option>");
    mooddl.append("<option>Sad</option>");


    $.ajax({
        url: potionlistAPI,
        type: "GET",
        success: function (data, status, xhr) {
            var potionlist = $('#potionList');
            for (var i = 0; i < data.rows.length; i++) {
                if (data.rows[i].Allergy == false) {
                    potionlist.append('<li class="ui-state-highlight" id=' + data.rows[i].PotionID + '>' + data.rows[i].Name + '</li>');
                } else {
                    potionlist.append('<li class="ui-state-highlight myAltRowClass" id=' + data.rows[i].PotionID + '>' + data.rows[i].Name + '</li>');
                }
            }
        },
        error: function (msg) {
            alert(msg);
        }
    });

    function sortNumber(a, b) {
        return a - b;
    }

    function GetResult() {
        var order1 = $('#potionList').sortable('toArray').toString();
        var order2 = $('#sortable2').sortable('toArray');
        order2.sort(sortNumber);
        var ingredientList = order2.toString();

        var mood = $("#slcMood option:selected").text();
        var MoodID;
        if (mood == "Happy") {
            MoodID = "1";
        } else if (mood == "Sad") {
            MoodID = "2";
        } else {
            MoodID = "0";
        }

        var requestmessage = { "MoodID": MoodID, "PotionRecipieIngredientList": ingredientList };

        $.ajax({
            url: '/api/PotionRecipieAPI/',
            data: requestmessage,
            type: "POST",
            success: function (data, status, xhr) {
                var resultspan = $('#spnresult');
                if (data != null) {
                    resultspan.empty();
                    resultspan.append('We got a result!! the Result is <b>' + data.Effect + '</b>');
                } else {
                    resultspan.empty();
                    var potioncheck = $('#sortable2').sortable('toArray');
                    if (potioncheck.length > 0) {
                        resultspan.append('BOOM!!');
                    }
                }
            }
        });
    }

    $('#slcMood').change(function () {
        GetResult();
    });

    $(function () {
        $("#potionList, #sortable2").sortable({
            connectWith: ".connectedSortable",
            update: function () {
                GetResult();
            }
        }).disableSelection();
    });

});