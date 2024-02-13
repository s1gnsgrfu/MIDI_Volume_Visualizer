function setProgressBarWidth(width) {
  var progressBar = document.querySelector('.progress_front');
  var innerDiv = document.getElementById("prog2");
  innerDiv.style = "width: "+width;
  progressBar.style.width = width;
}

//setProgressBarWidth('50%');
