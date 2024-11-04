$(document).ready(function () {
    // Counter for question IDs
    let questionCount = 1;

    // Function to add a new question
    function addQuestion() {
        const questionId = `question-${questionCount}`;
        questionCount++;

        // Create the HTML structure for a new question
        const newQuestionHtml = `
            <div class="question-container" id="${questionId}">
                <input type="text" class="question-title" placeholder="Question" />

                <div class="options">
                    <div class="option">
                        <input type="radio" disabled />
                        <input type="text" class="option-input" placeholder="Option 1" />
                    </div>
                    <div class="option">
                        <input type="radio" disabled />
                        <input type="text" class="option-input" placeholder="Option 2" />
                    </div>
                </div>

                <button class="add-option" onclick="addOption('${questionId}')">+ Add option</button>
            </div>
        `;

        // Append the new question to the questions container
        $('#questions-container').append(newQuestionHtml);
    }

    // Function to add a new option to a specific question
    window.addOption = function (questionId) {
        // Find the options container within the specified question
        const optionsContainer = $(`#${questionId} .options`);

        // Create the new option HTML
        const newOptionHtml = `
            <div class="option">
                <input type="radio" disabled />
                <input type="text" class="option-input" placeholder="New option" />
            </div>
        `;

        // Append the new option
        optionsContainer.append(newOptionHtml);
    };

    // Event handler for adding a new question
    $('#add-question').on('click', function (e) {
        e.preventDefault();
        addQuestion();
    });
});
