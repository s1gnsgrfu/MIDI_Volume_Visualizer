/*
bar.js

Copyright (c) 2024 S'(s1gnsgrfu)

This software is released under the MIT License.
see https://github.com/s1gnsgrfu/MIDI_Volume_Visualizer/blob/master/LICENSE
*/

function setProgressBarWidth(width) {
  var progressBar = document.querySelector('.progress_front');
  var innerDiv = document.getElementById("prog2");
  innerDiv.style = "width: "+width;
  progressBar.style.width = width;
}

function setPercent(per) {
    document.getElementById("inper").innerHTML = per + "%";
}

function setTitle(title) {
    document.getElementById("title").innerHTML = title;
}

//setProgressBarWidth('50%');
//setPercent(70);
//setTitle("Chrome");
