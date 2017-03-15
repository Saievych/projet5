$(document).ready (function () {

    document.getElementById("anne").onchange = function ShowEtud() {       
        var data = getData();
        var select_etud = document.getElementById("etudiants");
        var selectedAnne = document.getElementById("anne").options[document.getElementById("anne").selectedIndex].value;
        select_etud.innerHTML = '';
        var opt_tmp = document.createElement("option");
        opt_tmp.value = 'default';
        opt_tmp.innerHTML = '-------------';
        select_etud.appendChild(opt_tmp);
        var tmp = data.annes[find_anne(data.annes, selectedAnne)];
                for (var j = 0; j < tmp._etudiants.length; j++) {
                    var opt = document.createElement("option");
                    opt.value = tmp._etudiants[j]._id;
                    opt.innerHTML = tmp._etudiants[j]._nom + " " + tmp._etudiants[j]._prenom;
                    select_etud.appendChild(opt);
                }
                return;
    };
        
    
   
    
    document.getElementById("etudiants").onchange = function () {
        ShowCompetence();
            };
    var competences = getData();
    competences = competences.competences;
    for (var i = 0; i < competences.length; i++)
    {
        
        var x = document.getElementById(String(competences[i]._id));
        var col = x.getAttribute("background");
        x.val = competences[i];
        x.onmouseenter = function (event) {
            //giveLayout(event);
            col = event.target.getAttribute("background");
            event.target.setAttribute("style", "background: yellow");
            myVar = setTimeout(function () {
                showRelations(event.target.val);
            }, 100);
        }
        x.onmouseleave = function (event) {
            event.target.setAttribute("style", "background:" + col);
            clearTimeout(myVar);
            hideRelations(event.target.val);
            if (document.getElementById("etudiants").selectedIndex != -1)
                ShowCompetence();
        }

        x.onclick = function (event) {
            giveDetails(event.target.val);
        }

    }
    //ShowEtud();
    alert('ok');

});
//function giveLayout(e) {
//    var div = this.getElementsByTagName('div')[0],
//    em = '-20', // 20 = max-width подсказки
//    tR = div.getBoundingClientRect(),
//    tS = getComputedStyle(t, '').fontSize.slice(0, -2),
//    d = document.documentElement.getBoundingClientRect().right - tR.right;
//    if (tR.left < 0) div.style.left = parseInt(tS * em - tR.left * 2) + 'px';
//    if (d < 0) div.style.right = parseInt(tS * em - d * 2) + 'px';
//}
//var tooltip = document.querySelectorAll('.tooltip');
//for (var i = 0; i < tooltip.length; i++) {
//    tooltip[i].addEventListener('click', raz, false);
//    tooltip[i].addEventListener('mouseover', raz, false);
//}
function ShowCompetence() {
    var tmp2 = document.getElementById("etudiants").val;
    if (tmp2 != undefined) {
        for (var i = 0; i < tmp2._competuds.length; i++) {
            document.getElementById(String(tmp2._competuds[i]._CompetenceId)).setAttribute("style", "background: darkgray");
            //switch (tmp2._competuds[i]._Etat) {
            //    case 2:
            //        document.getElementById(String(tmp2._competuds[i]._CompetenceId)).setAttribute("style", "background: Brown");
            //        break;
            //    case 3:
            //        document.getElementById(String(tmp2._competuds[i]._CompetenceId)).setAttribute("style", "background: Brown");
            //        break;
            //    default:
            //        break;
            //}
        }
    }
    var data = getData();
    var index = document.getElementById("etudiants").options[document.getElementById("etudiants").selectedIndex].value;
    var selectedAnne = document.getElementById("anne").options[document.getElementById("anne").selectedIndex].value;
    var tmp = data.annes[find_anne(data.annes, selectedAnne)];
    tmp2 = tmp._etudiants[find_etudiant(tmp._etudiants, parseInt(index))];
    document.getElementById("etudiants").val = tmp2;
    //alert("test2");
    for (var i = 0; i < tmp2._competuds.length; i++) {
        switch (tmp2._competuds[i]._Etat) {
            case 1:
                document.getElementById(String(tmp2._competuds[i]._CompetenceId)).setAttribute("style", "background: red");
                break;
            case 2:
                document.getElementById(String(tmp2._competuds[i]._CompetenceId)).setAttribute("style", "background: darkorange");
                break;
            case 3:
                document.getElementById(String(tmp2._competuds[i]._CompetenceId)).setAttribute("style", "background: lime ");
                break;
            default:
                break;
        }
    }
    return;
}
function showRelations(value) {
    for( var i=0; i< value._competences_Par.length; i++)
        document.getElementById(value._competences_Par[i]._id).setAttribute("style", " background: magenta ");

    for (var i = 0; i < value._competences_Son.length; i++) 
        document.getElementById(value._competences_Son[i]._id).setAttribute("style", " background: blue ");
}
function hideRelations(value)
{
    for (var i = 0; i < value._competences_Par.length; i++)
        //document.getElementById(value._competences_Par[i]._id).setAttribute("style", "background: " + window.getComputedStyle(document.getElementById(value._competences_Par[i]._id)).backgroundColor);
        document.getElementById(value._competences_Par[i]._id).setAttribute("style", "background: darkgray");

    for (var i = 0; i < value._competences_Son.length; i++)
        //document.getElementById(value._competences_Son[i]._id).setAttribute("style", "background: " + window.getComputedStyle(document.getElementById(value._competences_Par[i]._id)).backgroundColor);
        document.getElementById(value._competences_Son[i]._id).setAttribute("style", "background: darkgray");
}

function getData()
{
    try {
        //data = JSON.parse(d);
        var str = '@HTML.Raw(document.getElementById("data").innerHTML)';
        var data = JSON.parse(document.getElementById("data").innerHTML.replace(/(&quot\;)/g, "\""));
    } catch (e) {

        var data = document.getElementById("data").innerHTML;
    }
    return data;
}

var find_anne = function (array, value) {
    for (var i = 0; i < array.length; i++)
        if (array[i]._anne === value) return i;

}
var find_etudiant = function (array, value) {
    for (var i = 0; i < array.length; i++)
        if (array[i]._id === value) return i;

}

var find_semestre = function (array, value) {
    for (var i = 0; i < array.length; i++)
        if (array[i]._semestre === value) return i;

}


function giveDetails(value) {
    var d = document.createElement("DIV");
    d.setAttribute("id", "divcenter");
    var dd = document.createElement("DIV");
    dd.setAttribute("id", "Mymodal");
    dd.setAttribute("class", "modal-fade")
    var d1 = document.createElement("DIV");
    d1.setAttribute("class", "modal-dialog modal-sm");
    var d2 = document.createElement("DIV");
    d2.setAttribute("class", "modal-content");
    var d3 = document.createElement("DIV");
    d3.setAttribute("class", "modal-header");
    var h = document.createElement("h4");
    h.setAttribute("class", "modal-title");
    var header = document.createTextNode("Les détails de competence: " + value._code);
    h.appendChild(header);
    d3.appendChild(h);
    var d4 = document.createElement("DIV");
    d4.setAttribute("class", "modal-body");
    var Sem = document.createTextNode("Semestre " + value._semestre);
    var d4_1 = document.createElement("DIV");
    d4_1.appendChild(Sem);
    d4.appendChild(d4_1);
    var Cours = document.createTextNode("Cours: " + value._cours);
    var d4_2 = document.createElement("DIV");
    d4_2.appendChild(Cours);
    d4.appendChild(d4_2);
    var Description = document.createTextNode("Description: " + String(value._description));
    var d4_3 = document.createElement("DIV");
    d4_3.appendChild(Description);
    d4.appendChild(d4_3);
    var Link = document.createTextNode("Link: " + value._link);
    var d4_4 = document.createElement("A");
    d4_4.setAttribute("href",String(value._link));
    d4_4.appendChild(Link);
    d4.appendChild(d4_4);
    var Professeur = document.createTextNode("Responsable: ");
    for (var i = 0; i < value._prof.length ; i++)
    {
        Professeur.textContent += value._prof[i].Professeur_prenom + " " + value._prof[i].Professeur_nom + " ";
        if (value._prof.length >= 2)
            Professeur.textContent += "/ ";
    }
    var d4_5 = document.createElement("DIV");
    d4_5.appendChild(Professeur);
    d4.appendChild(d4_5);
    //d4.appendChild(d4_4);
    //var text = document.createTextNode("IssueSummary: " + value.IssueSummary + "\n\t" + "IssueCreator: " + value.IssueCreator + "\n\t" + "IssueDescription: " + value.IssueDescription + "\n\t" + "IssueUpdateDate: " + value.IssueUpdateDate);
    //d4.appendChild(text);
    var d5 = document.createElement("DIV");
    d5.setAttribute("class","modal-footer");
        var button = document.createElement("BUTTON");
            button.setAttribute("class", "btn btn-default");
            button.setAttribute("type", "button");
            button.setAttribute("data-dismiss", "Mymodal");
            var buttontext = document.createTextNode("Ferme");
            button.appendChild(buttontext);
            button.onclick = function () {
                //document.getElementById("divcenter").setAttribute("z-index", "1");
                //$(dd).remove();
                $(d).remove();
                                 };
    d5.appendChild(button);
    d2.appendChild(d3);
    d2.appendChild(d4);
    d2.appendChild(d5);
    d1.appendChild(d2);
    dd.appendChild(d1);
    d.appendChild(dd);
    //d.onclick = function () {
    //    //$(dd).remove();
    //    $(d).remove();
    //};

    //var main = document.getElementById("header");
    //main.insertBefore(d,document.getElementById("main"));
    document.getElementById("header").appendChild(d);
    return;
}








