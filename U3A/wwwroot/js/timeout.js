//
// page timeout section

let timeoutId;

// Reset the timer when there's a keyboard or mouse event
function resetTimer() {
    clearTimeout(timeoutId);
    timeoutId = setTimeout(redirectToExitPage, 10 * 60 * 1000); // 10 minutes in milliseconds
}

// Redirect to the page
function redirectToExitPage() {
    window.location.href = '/closed.html';
}

// Set up the event listeners
document.addEventListener('touched', resetTimer);
document.addEventListener('keydown', resetTimer);
document.addEventListener('mousemove', resetTimer);

// Start the timer
resetTimer();

