// Validating Empty Field
function check_empty() {
    if (document.getElementById('name').value == "" || document.getElementById('email').value == "" || document.getElementById('msg').value == "") {
        alert("Wypełnij cały formularz");
       // document.getElementById('abc').style.display = "none";
    } else {
        //document.getElementById('sumbit').submit();
        alert("Wiadomość została wysłana");

    }
}
//Function To Display Popup
function div_show() {
    document.getElementById('abc').style.display = "block";
}
//Function to Hide Popup
function div_hide() {
    document.getElementById('abc').style.display = "none";
}