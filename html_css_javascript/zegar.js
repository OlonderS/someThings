function WezCzas() {
  var d = new Date();
  document.getElementById("zegar").innerHTML = d.toLocaleTimeString();
}

setInterval(WezCzas, 1000);

window.onload = function() {
  WezCzas();
};

