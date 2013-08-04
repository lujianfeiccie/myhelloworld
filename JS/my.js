function CheckAll(checkbox)
{
	var elements = checkbox.form.elements;
	for(var i = 0; i < elements.length; i++) {
		if(elements[i].type == "checkbox"  &&  elements[i].id != checkbox.id) {
			elements[i].checked = checkbox.checked;
			hilightRow(elements[i]);
		}
	}
}

function hilightRow(checkbox)
{    
    var row = checkbox.parentNode.parentNode;
    if (checkbox.type == "checkbox") {
        if (checkbox.checked) {
            row.style.backgroundColor = '#FFFFCC';            
        }
        else {
            if (row.rowIndex % 2 == 0) {
                row.style.backgroundColor = 'white';
            } else {
                row.style.backgroundColor = '#F7F6F3';
            }
        }
    }    
}

function mybooklist(button)
{
 	var elements = button.form.elements;
	var num = 0;
	for(var i = 0; i < elements.length; i++) {
		if(elements[i].type == "checkbox"  &&  elements[i].id != button.id) {
		    if (elements[i].checked) {
			    num++;
			}
		}
	}
    var mybooklist = document.getElementById("mybooklist");
    mybooklist.innerHtml += num;	
}

function deleteRow(rowIndex)
{
	//alert(rowIndex);
	var table = document.getElementById('ctl00_ContentPlaceHolder1_GridView1');
	table.deleteRow(rowIndex);
}

function getIt(obj)
{
	var r,c
	o = obj

	    while(o.tagName != "TD" && o.tagName != "TH")
		    o = o.parentNode
		        if(o.tagName != "TD" && o.tagName != "TH")
			        return
			            c = o.cellIndex
			                while(o.tagName != "TR")
				                o = o.parentNode
				                    if(o.tagName != "TR")
					                    return
					                        r = o.rowIndex

					                            //alert("o=" + o.value + " r=" + r + " c=" + c);
					                            deleteRow(r);

	//下面的代码是取gridview模板列中控件的内容
	//document.getElementById("grid1").rows[r].cells[0].innerText可以求网格单元的内容
	//    document.getElementById("ctl00_ContentPlaceHolder1_GridView1").rows[r].cells[0].firstChild.value="";
	//    document.getElementById("ctl00_ContentPlaceHolder1_GridView1").rows[r].cells[1].firstChild.value="";
	//    document.getElementById("ctl00_ContentPlaceHolder1_GridView1").rows[r].cells[2].firstChild.value="";
}

function checkReaderCoderbar()
{
	var textbox = document.getElementById("TextBox1");

	if(isNaN(textbox.value))
		alert('输入有误，请重新输入');

}

function showInfo()
{
    //dojo.widget.byId("dialog0").show();
    dojo.byId('info').innerHTML = "正在";
    dlg0.show();
    //dojo.html.setOpacity(dojo.byId('main'), 0.3)
	//dojo.lfx.html.fadeOut('gridview', 400).play();
}		


