let isAscendingTrainees = true;
let isAscendingRequests = true;

function toggleSortTrainees() {
    isAscendingTrainees = !isAscendingTrainees;
    const sortIcon = document.getElementById('sortIconTrainees');
    sortIcon.className = isAscendingTrainees ? 'fa-solid fa-arrow-up-a-z' : 'fa-solid fa-arrow-down-a-z';

    // Sorting logic for trainees goes here
    if (isAscendingTrainees) {
        sortTrainees(); // Sort ascending
    } else {
        sortTraineesDescending(); // Sort descending
    }
}

function toggleSortRequests() {
    isAscendingRequests = !isAscendingRequests;
    const sortIcon = document.getElementById('sortIconRequests');
    sortIcon.className = isAscendingRequests ? 'fa-solid fa-arrow-up-a-z' : 'fa-solid fa-arrow-down-a-z';

    // Sorting logic for requests goes here
    if (isAscendingRequests) {
        sortRequests(); // Sort ascending
    } else {
        sortRequestsDescending(); // Sort descending
    }
}
function openDenyModal(enrollmentId) {
    $('#enrollmentId').val(enrollmentId);  // Set enrollment ID in the hidden input
    $('#denyModal').modal('show');         // Show the modal
}

// Implement your sorting logic for trainees and requests here
function sortTrainees() {
    // Sort logic for ascending order
    console.log('Sorting trainees in ascending order');
}

function sortTraineesDescending() {
    // Sort logic for descending order
    console.log('Sorting trainees in descending order');
}

function sortRequests() {
    // Sort logic for ascending order
    console.log('Sorting requests in ascending order');
}

function sortRequestsDescending() {
    // Sort logic for descending order
    console.log('Sorting requests in descending order');
}
$(document).ready(function () {
    $('#viewGradeModal').on('show.bs.modal', function (event) {
        var button = $(event.relatedTarget); // Button that triggered the modal
        var enrolleeId = button.data('enrollee-id'); // Extract enrollment ID
        var programId = button.data('program-id'); // Extract program ID
        var traineeName = button.data('trainee-name'); // Extract trainee name
        var modal = $(this);

        // Set the trainee name dynamically
        modal.find('.modal-title #traineeName').text(traineeName);

        // Fetch the grades data using AJAX
        $.ajax({
            url: '/Instructor/GetGrades', // Action URL where you'll fetch the grades
            type: 'GET',
            data: { enrollmentId: enrolleeId, programId: programId },
            success: function (data) {
                console.log('Program ID:', programId);
                console.log('Enrollment ID:', enrolleeId);
                console.log('Received Data:', data);
                console.log(data);  // Log the raw data to the console

                // Check if data is undefined or null
                if (!data || data === undefined || data === null) {
                    console.error('No data received or data is undefined.');
                    return;
                }

                var gradesTableBody = modal.find('#gradesTableBody');
                gradesTableBody.empty(); // Clear any existing rows

                // Check if data is an array and process accordingly
                if (Array.isArray(data)) {
                    data.forEach(function (grade) {
                        var row = '<tr>' +
                            '<td>' + grade.quizTitle + '</td>' +
                            '<td>' + grade.rawScore + '</td>' +
                            '<td>' + grade.totalScore + '</td>' +
                            '<td>' + grade.computedScore + '</td>' +
                            '<td>' + grade.remarks + '</td>' +
                            '</tr>';
                        gradesTableBody.append(row);
                    });
                } else {
                    console.error('Data is not in the expected format.');
                }
            },
            error: function () {
                alert('Error fetching grade data.');
            }
        });

    });
});
