function addCount(user_id,page_id)
{
    var xmlhttp;
    if (window.XMLHttpRequest)
      {// code for IE7+, Firefox, Chrome, Opera, Safari
      xmlhttp=new XMLHttpRequest();
      }
    else
      {// code for IE6, IE5
      xmlhttp=new ActiveXObject("Microsoft.XMLHTTP");
      }
 
      if(user_id==null){
         return;
      }
      if(user_id == ""){
         return;
      }
    xmlhttp.open("GET","statistic.ashx?user_id='"+user_id+"'&page_id='"+page_id+"'&t=" + Math.random(),false);
    xmlhttp.send();
}

function getfunc(){
  var numargs   =   arguments.length; 
  alert(numargs);
}
