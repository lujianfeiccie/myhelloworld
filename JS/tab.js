/*Swich EasyTabs Functions - no need to edit something here*/
function easytabs(menunr, active) 
{
	for (i=1; i <= 3; i++)
	{
		document.getElementById("tablink"+i).className='tab'+i;
    	document.getElementById("tabcontent"+i).style.display = 'none';
	}
	document.getElementById("tablink"+active).className='tab'+active+' tabactive';
	document.getElementById("tabcontent"+active).style.display = 'block';
}

function easytabs2(menunr, active) 
{
	for (i=1; i <= 7; i++)
	{
		document.getElementById("anotherlink"+i).className='tab'+i;
    	document.getElementById("anothercontent"+i).style.display = 'none';
	}
	document.getElementById("anotherlink"+active).className='tab'+active+' tabactive';
	document.getElementById("anothercontent"+active).style.display = 'block';
}
window.onload=function(){
 easytabs('1','1');
 easytabs2('1','1');
}