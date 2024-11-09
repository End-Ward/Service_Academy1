//PROGRAMSTREAMSCRIPT
function toggleAnnouncementInput() {
    const inputField = document.getElementById('announcement-input');
    inputField.style.display = inputField.style.display === 'none' ? 'block' : 'none';
    if (inputField.style.display === 'block') {
        document.getElementById('announcement-textarea').focus(); // Focus on the textarea
    }
}

// Function to post announcement
function postAnnouncement() {
    const announcementText = document.getElementById('announcement-textarea').innerHTML; // Get HTML content
    if (announcementText) {
        const postsContainer = document.getElementById('posts');
        const newPost = document.createElement('div');
        newPost.className = 'post';
        newPost.innerHTML = `
                    <div class="post-header">
                        <div class="post-user">
                            <img src="/images/profile.png" alt="User Profile Picture" class="post-user-img">
                            <span class="post-user-name">Leigh Smith</span>
                        </div>
                        <span class="post-timestamp">Just now</span>
                    </div>
                    <p class="post-content">${announcementText}</p>
                `;
        postsContainer.prepend(newPost); // Add new post to the top
        document.getElementById('announcement-textarea').innerHTML = ''; // Clear the textarea
        toggleAnnouncementInput(); // Hide the input field
    }
}

// Function to cancel announcement
function cancelPost() {
    document.getElementById('announcement-textarea').innerHTML = ''; // Clear the textarea
    toggleAnnouncementInput(); // Hide the input field
}

// Apply formatting to the selected text only
function applyFormat(formatType) {
    const textarea = document.getElementById('announcement-textarea');
    const selection = window.getSelection();

    if (selection.rangeCount > 0) {
        const range = selection.getRangeAt(0);
        const selectedText = range.toString();

        // Check if there is selected text before applying formatting
        if (selectedText.length > 0) {
            const span = document.createElement('span');
            span.style.fontWeight = formatType === 'bold' ? 'bold' : 'normal';
            span.style.fontStyle = formatType === 'italic' ? 'italic' : 'normal';
            span.style.textDecoration = formatType === 'underline' ? 'underline' : 'none';
            span.textContent = selectedText;

            // Replace the selected text with the formatted span
            range.deleteContents();
            range.insertNode(span);

            // Collapse the selection to the end of the inserted node to continue typing normally
            selection.removeAllRanges();
            selection.addRange(range);
        }
    }

    // Refocus on the textarea after formatting
    textarea.focus();
}

// Function to insert bullet list
function loadModuleContent(filePath) {
    document.getElementById("moduleContentFrame").src = filePath;
}
function openUpdateModuleModal(moduleId, moduleTitle) {
    // Set the current module ID and title in the modal
    $('#moduleIdInput').val(moduleId);  // Assuming you have an input in the modal to capture the module ID
    $('#moduleTitleInput').val(moduleTitle);  // Assuming you have an input for the module title
    // Open the modal
    $('#updateModuleModal').modal('show');
}

function openDeleteModuleModal(moduleId, moduleTitle) {
    // Set the values in the modal before showing it
    $('#deleteModuleModal').find('input[name="moduleId"]').val(moduleId);
    $('#deleteModuleModal').find('.modal-title').text('Delete Module: ' + moduleTitle);
    $('#deleteModuleModal').modal('show');
}

// Close the Update Module Modal (Close Button in the Modal Footer)
$('#updateModuleModal .close, #updateModuleModal .btn-secondary').on('click', function () {
    $('#updateModuleModal').modal('hide');
});

// Close the Delete Module Modal (No Button)
$('#deleteModuleModal .btnNo').on('click', function () {
    $('#deleteModuleModal').modal('hide');
});

// Optional: Close the modal when clicking outside (if needed)
$('#updateModuleModal').on('hidden.bs.modal', function () {
    // Reset the values when the modal is closed
    $('#moduleIdInput').val('');
    $('#moduleTitleInput').val('');
});

$('#deleteModuleModal').on('hidden.bs.modal', function () {
    // Reset the module ID in the delete modal when it's closed
    $('#deleteModuleModal').find('input[name="moduleId"]').val('');
});

function postAnnouncement() {
    alert("This program is archived and read-only.");
}
