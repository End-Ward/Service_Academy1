const quizForm = document.querySelector('form');

quizForm.addEventListener('submit', function (e) {
    const answerFields = document.querySelectorAll('.answer-field');
    let isValid = true;

    // Check each answer field
    answerFields.forEach(function (field) {
        if (field.value.trim() === '') {
            isValid = false;
            field.style.borderColor = 'red';  // Highlight empty fields
        } else {
            field.style.borderColor = '';  // Reset border color if field is not empty
        }
    });

    if (!isValid) {
        e.preventDefault();  // Prevent form submission
        alert('Please fill out all answer fields.');
    }
});