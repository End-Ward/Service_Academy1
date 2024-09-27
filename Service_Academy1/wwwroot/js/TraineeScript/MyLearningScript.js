function redirectToLesson(lessonUrl) {
    // Redirect to the provided lesson URL
    window.location.href = lessonUrl;
}

function redirectToCatalog(url) {
    window.location.href = url;
}



let userEnrolledPrograms = [
    {
        title: "Introduction to Web Development",
        description: "Learn the basics of HTML, CSS, and JavaScript.",
        image: "../Images/web-dev-course.png",
        link: "CourseDetails.html"
    }
];

// Function to dynamically add enrolled programs
function displayEnrolledPrograms() {
    const programsEnrolledDiv = document.querySelector('.programs-enrolled');

    // Check if the user has enrolled programs
    if (userEnrolledPrograms.length > 0) {
        userEnrolledPrograms.forEach(program => {
            // Create the course card dynamically
            const courseCard = document.createElement('div');
            courseCard.classList.add('course-card');

            courseCard.innerHTML = `
                <img src="${program.image}" alt="${program.title}" class="course-image">
                <div class="course-details">
                    <h4>${program.title}</h4>
                    <p>${program.description}</p>
                    <a href="${program.link}" class="cta-button">View Course</a>
                </div>
            `;

            // Append the course card to the programs-enrolled div
            programsEnrolledDiv.appendChild(courseCard);
        });
    } else {
        // If no enrolled programs, display a message
        programsEnrolledDiv.innerHTML = '<p>You are not enrolled in any programs yet. Browse our catalog to get started!</p>';
    }
}
