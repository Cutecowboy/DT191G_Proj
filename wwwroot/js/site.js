// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

// check website if there are any query strings for filtration of the booking. 
let queryString = window.location.search;
let urlParams = new URLSearchParams(queryString);
if (urlParams.get('filter') != null) {
    let filter = urlParams.get('filter');
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
let msg = document.getElementById("message");
msg.style.display = "none";

if(urlParams.get('message') != null){
    let msgno = urlParams.get("message");
    msg.style.display = "block";

    setTimeout(() => {
        msg.style.display = "none";
    }, 5000);
    let msgarr = ["You have successfully booked a time!", "You have successfully unbooked your time!", "You have successfully edited the timeslot!", "You have successfully removed the timeslot!", "You have successfully created a new timeslot!", "You have successfully logged out!"]

    msg.innerHTML = msgarr[msgno - 1];
}

