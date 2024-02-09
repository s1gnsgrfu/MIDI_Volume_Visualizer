var progressBar = document.getElementById("progressBar");
  
var progress = 0;

function updateProgressBar(percentage) {
  progressBar.style.width = percentage + "%";
}

var increaseButton = document.getElementById("increaseButton");

increaseButton.addEventListener("click", function() {
  progress += 10;
  if (progress > 100) {
    progress = 100;
  }
  updateProgressBar(progress);
});