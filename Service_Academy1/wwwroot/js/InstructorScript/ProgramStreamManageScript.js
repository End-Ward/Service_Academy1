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
