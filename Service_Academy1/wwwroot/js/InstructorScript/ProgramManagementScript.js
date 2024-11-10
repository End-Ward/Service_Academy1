//PROGRAM MANAGEMENT SCRIPT
function toggleDateInput(programId) {
    const dateInputs = document.getElementById(date - inputs - ${ programId });
    dateInputs.style.display = dateInputs.style.display === 'none' || dateInputs.style.display === '' ? 'block' : 'none';
}

$(document).ready(function () {
    // Optional: If you'd like to keep auto-hiding the alert after a few seconds while still allowing manual close
    setTimeout(function () {
        $(".alert").fadeOut("slow");
    }, 5000);
});
$('#deactivateModal').on('hidden.bs.modal', function () {
    // Optional: trigger any actions after modal is closed
});
function filterPrograms() {
    // Get values from search input and filter dropdowns
    var searchText = document.querySelector(".search-container input").value.toLowerCase();
    var filterAgenda = document.querySelector("#filterAgenda").value.toLowerCase(); // Agenda filter

    // Get all the program cards
    var programCards = document.querySelectorAll(".program-card");

    // Loop through each program card and apply filters
    programCards.forEach(function (card) {
        // Extract program details (e.g., title, instructor name, agenda)
        var programTitle = card.querySelector("h3").textContent.toLowerCase();
        var programAgenda = card.getAttribute("data-agenda").toLowerCase(); // Get the agenda from the data attribute

        // Apply search text and agenda filter
        if (
            (programTitle.includes(searchText)) &&
            (filterAgenda === "all" || programAgenda === filterAgenda)
        ) {
            card.style.display = ""; // Show the card
        } else {
            card.style.display = "none"; // Hide the card
        }
    });
}

// Add event listeners for the search input and filter changes
document.querySelector(".search-container input").addEventListener("input", filterPrograms);
document.querySelector("#filterAgenda").addEventListener("change", filterPrograms);

document.addEventListener('DOMContentLoaded', function () {
    const buttons = document.querySelectorAll('.toggle-button');
    buttons.forEach(button => {
        button.addEventListener('click', function () {
            const programId = this.id.split('-')[1];
            const isActive = this.classList.contains('activated');

            // Toggle the button text and state
            this.classList.toggle('activated');
            this.classList.toggle('deactivated');
            this.textContent = isActive ? 'Deactivate' : 'Activate';

            // Open the corresponding modal
            const modalId = isActive ? '#deactivateModal-' + programId : '#activateModal-' + programId;
            $(modalId).modal('show');
        });
    });
});