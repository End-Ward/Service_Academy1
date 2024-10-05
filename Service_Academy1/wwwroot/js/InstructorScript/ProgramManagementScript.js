function toggleDateInput(programId) {
    const dateInputs = document.getElementById(`date-inputs-${programId}`);
    dateInputs.style.display = dateInputs.style.display === 'none' || dateInputs.style.display === '' ? 'block' : 'none';
}

function confirmArchive() {
    return confirm("Do you want to archive this Program? Once Archived you cannot modify its content.");
}

$(document).ready(function () {
    // Optional: If you'd like to keep auto-hiding the alert after a few seconds while still allowing manual close
    setTimeout(function () {
        $(".alert").fadeOut("slow");
    }, 5000);
});