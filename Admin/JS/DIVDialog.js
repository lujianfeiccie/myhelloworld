function show(ele)
{
  eval(ele + ".style.display = ''");
}
function hidden(ele)
{
  eval(ele + ".style.display = 'none'");
}
function closeDIV()
{
    hidden("loginDIV");
    hidden("mbDIV");
}
function openDIV()
{
     show("loginDIV");
     show("mbDIV");
}
 