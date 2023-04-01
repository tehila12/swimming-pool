var path = 'https://localhost:44371/api/'
var name;

//הצגת כל המנויים
function GetAllSubscribers() {
    getNameByID();
    getSubTypeName();
    setTimeout(function () {
        axios.get(path + 'Subscribers/GetAllSubscribers').then(
            (response) => {
                console.log(response)
                var result = response.data;


                var allNames = JSON.parse(sessionStorage.subName);
                var subTypaNames = JSON.parse(sessionStorage.subTypeName);
                console.log(allNames)
                console.log(subTypaNames)

                var body = document.getElementsByClassName("bodyb")[0];
                var table = document.createElement("table");
                table.className = "table table-hover";


                var thead = document.createElement("thead");
                var tr = document.createElement("tr");
                var th = document.createElement("th");;


                th.innerHTML = 'בחירה';
                tr.appendChild(th);

                th = document.createElement("th");
                th.innerHTML = 'שם מנוי';
                tr.appendChild(th);
               

                th = document.createElement("th");
                th.innerHTML = 'סוג מנוי';
                tr.appendChild(th);

                th = document.createElement("th");
                th.innerHTML = 'תאריך התחלת מנוי';

                tr.appendChild(th);
                th = document.createElement("th");
                th.innerHTML = 'מספר כניסות';
                tr.appendChild(th);

                th = document.createElement("th");
                th.innerHTML = 'סטטוס';
                tr.appendChild(th);

                thead.appendChild(tr);
                table.appendChild(thead);

                var tbody = document.createElement("tbody");
                for (var i = 0; i < result.length; i++) {
                    var tr = document.createElement("tr");


                    var td = document.createElement("INPUT");
                    td.setAttribute("type", "radio");
                    td.setAttribute("name", "choose");
                    td.setAttribute("value", result[i].Subscription_id);
                    td.className = "choose";
                    tr.appendChild(td);

                   


                    
                    var subName = allNames[i];
               
                    var td = document.createElement("td");
                    td.innerHTML = subName;
                    tr.appendChild(td);

                  

                    var TypeName = subTypaNames[i];
                    var td = document.createElement("td");
                    td.innerHTML = TypeName;
                    tr.appendChild(td);

                    var td = document.createElement("td");
                    td.innerHTML = getdate(result[i].start_date);
                    tr.appendChild(td);
                    var td = document.createElement("td");
                    td.innerHTML = result[i].sum_of_entries;
                    tr.appendChild(td);
                    var td = document.createElement("td");
                    td.innerHTML = result[i].status;
                    tr.appendChild(td);


                    tbody.appendChild(tr);

                }

                table.appendChild(tbody);
                body.appendChild(table);
                tbody.className = "MyTable";


            },
            (error) => {
                console.log(error);
            }
        ); },1000)
   
}


function getdate(date) {
    var dt = new Date(date)
    return dt.getDate() + "." + (dt.getMonth() + 1) + "." + dt.getFullYear();
}



//מספר הכניסות לסוג מנוי 
function GetNumOfEnter() {
    var subType = document.querySelector('#sub-type').value;

    axios.get(path + 'SubsType/GetNumEnter/' + subType).then(
        (response) => {
            console.log(response)
            var result = response.data;
            return result;

        },
        (error) => {
            console.log(error);
        }
    );
}


//עדכון מנוי ---סטטוס ותאריך התחלה
function UpdateSub() {


}

//מחיקת מנוי
function DelteSub(id) {

}

//id הצגת שם המנוי לפי  
function getNameByID() {

   
    axios.get(path + 'Customers/getAllNames').then(
        (response) => {
            var result = response.data;

            sessionStorage.subName = JSON.stringify(result);


        },
        (error) => {
            console.log(error);
        }
    );



}


//הצגת שם סוג מנוי 
function getSubTypeName() {
    axios.get(path + 'SubsType/GetAllTypeNames').then(
        (response) => {
            var result = response.data;
            sessionStorage.subTypeName = JSON.stringify(result);

        },
        (error) => {
            console.log(error);
        }
    );
}


function indexChoose() {
    var d = document.getElementsByName('choose');
    for (var i = 0; i < d.length; i++) {
        if (d[i].checked) {
            return d[i].value;
        }
    }

}

