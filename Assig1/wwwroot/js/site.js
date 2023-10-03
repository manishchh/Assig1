// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.


 
document.getElementById("yearSelect").addEventListener("change", function (e) {
    const selectedYear = e.target.value;
    document.querySelectorAll("tr[data-year]").forEach(row => {
        if (row.getAttribute("data-year") === selectedYear) {
            row.style.display = "table-row";
        } else {
            row.style.display = "none";
        }
    });
});
function goBack() {
    window.history.back();
}

