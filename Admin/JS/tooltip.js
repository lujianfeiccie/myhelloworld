var xPos;
var yPos;

function showToolTip(id,evt){
    if (evt) {
        var url = evt.target;
    }
    else {
        evt = window.event;
        var url = evt.srcElement;
    }
    xPos = evt.clientX;
    yPos = evt.clientY;
   
   var toolTip = document.getElementById("toolTip");
   toolTip.innerHTML = "<h1>提示信息</h1><p>"+document.getElementById("info"+id).innerHTML+"</p>";
   toolTip.style.top = parseInt(yPos)+2 + "px";
   toolTip.style.left = parseInt(xPos)+2 + "px";
   toolTip.style.visibility = "visible";
   
}

function hideToolTip(){
   var toolTip = document.getElementById("toolTip");
   toolTip.style.visibility = "hidden";
}