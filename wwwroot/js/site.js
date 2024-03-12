// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

// check website if there are any query strings for filtration of the booking. 
const queryString = window.location.search;
const urlParams = new URLSearchParams(queryString);
if (urlParams.get('filter') != null) {
    const filter = urlParams.get('filter');
    // for booked filtering
    if (filter == "booked") {
        // remove all information regarding the unbooked 
        document.querySelectorAll(".table-success").forEach(x => x.style.display = "None");
        document.getElementById("unbooked").style.display = "None";
        // set selection option to booked
        document.getElementById("filtration").value = "booked"
    } 
    // for unbooked 
    else if (filter == "unbooked") {
        // remove all information regarding the booked 
        document.querySelectorAll(".table-danger").forEach(x => x.style.display = "None")
        document.getElementById("booked").style.display = "None";
        // set selection option to unbooked
        document.getElementById("filtration").value = "unbooked"


    }
    // no need for else, if user enters the "all" selection if will per default show all 

}


if(document.getElementById("action") != null){
    let btn = document.getElementById("action");
    btn.addEventListener("click", SubmitForm)
}

console.log(queryString);
console.log(window.location.pathname)
function SubmitForm(){
    let text = "hej";
    let resp = confirm(text);
    if(!resp){
        window.location.href = "www.google.se"
    } else {
        window.location.href = "www.google.se"

    }

}