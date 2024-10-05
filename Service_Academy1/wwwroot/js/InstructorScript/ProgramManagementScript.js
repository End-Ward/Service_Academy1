function toggleDateInput(programId) {
    const dateInputs = document.getElementById(`date-inputs-${programId}`);
    dateInputs.style.display = dateInputs.style.display === 'none' || dateInputs.style.display === '' ? 'block' : 'none';
}