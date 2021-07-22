// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
// @ts-check


;

function autofillDate() {

	var now = new Date();

	var day = ("0" + now.getDate()).slice(-2);
	var month = ("0" + (now.getMonth() + 1)).slice(-2);

	var today = now.getFullYear() + "-" + (month) + "-" + (day);

	$('#currentdate').val(today);

}

function autofillTime() {
	//var date = new Date();
	//var currentTime = date.toISOString().substring(11, 16);
	
	


	//$('#currenttime').val(today);

}