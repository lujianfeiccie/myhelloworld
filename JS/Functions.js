// JScript 文件
function addCookie(title,url) {　 // 加入收藏夹
　　　　　if (document.all) {
　　　　　　　　window.external.addFavorite(url, title);
　　　　　}
　　　　　else if (window.sidebar) {
　　　　　　　　 window.sidebar.addPanel(title, url,"");
　　　　　}
　　}

　　function setHomepage(title,url) {　 // 设置首页
　　　　if (document.all) {
　　　　　　　document.body.style.behavior = 'url(#default#homepage)';
　　　　　　　document.body.setHomePage(url);

　　　　}
　　　　 else if (window.sidebar) {
　　　　　　　if (window.netscape) {
　　　　　　　　　 try {
　　　　　　　　　　　　　　netscape.security.PrivilegeManager.enablePrivilege("UniversalXPConnect");
　　　　　　　　　　　　}
　　　　　　　　　catch (e) {
　　　　　　　　　　　　alert("该操作被浏览器拒绝，如果想启用该功能，请在地址栏内输入 about:config,然后将项 signed.applets.codebase_principal_support 值该为true");
						addCookie(title,url);
　　　　　　　　　　　　}
　　　　　　　　　}
　　　　　　　var prefs = Components.classes['@mozilla.org/preferences-service;1'].getService(Components.interfaces.nsIPrefBranch);
　　　　　　　prefs.setCharPref('browser.startup.homepage', url);
　　　　　　　}

　　　　} 
//验证码判断
    var code ; //在全局 定义验证码  
    
     function createCode()  
     {   
       code = "";  
       var codeLength = 5;//验证码的长度  
       var checkCode = document.getElementById("checkCode");  
       var selectChar = new Array(0,1,2,3,4,5,6,7,8,9,'A','B','C','D','E','F','G','H','I','J','K','L','M','N','O','P','Q','R','S','T','U','V','W','X','Y');// 所有候选组成验证码的字符，当然也可以用中文的     
       for(var i=0;i<codeLength;i++)  
       {  
        var charIndex = Math.floor(Math.random()*36);  
        code +=selectChar[charIndex];  
       }   
       if(checkCode)  
       {  
         checkCode.className="code";  
         checkCode.value = code;
         checkCode.blur();  
       }       
     }    
     function validate ()   {  
       var inputCode = document.getElementById("validCode").value;  
       if(inputCode.length <=0)  
       {  
           alert("请输入验证码！");  
       }  
       else if(inputCode.toUpperCase() != code )  
       {  
          alert("验证码输入错误！");  
          createCode();//刷新验证码  
       }
         
       else  
       {  
         var username=$("#username").val();
         var psw=$("#password").val();
         if(username!=""&&psw!="")
         {
            $("#login").submit();
         }
         else
         {alert("请正确输入用户名和密码！");}
       }  
 }  
  
//投票的
function vote()
{
    var optionid=$("[name='web_vote_value'][checked]").val();
    var originhtml=$("#myvote").html();
    
    if(optionid==null)
    {
        alert("请选择！");
        return;
    }
    else
    {
         $.ajax({ type:"Get",
           url: "DoVote.aspx",
           cache: false,
           data:"id="+optionid+"&act=vote",
           success: function(data){
                    if(data=="0")
                    {
                        $("#myvote").html(originhtml);
                    }
                    else
                    {
                         $("#myvote").html(data);
                     }
           }
        }); 
    }
}
function viewvote()
{
     $.ajax({ type:"Get",
           url: "DoVote.aspx",
           cache: false,
           data:"",
           success: function(data){
                    if(data=="0")
                    {
                        $("#myvote").html(originhtml);
                    }
                    else
                    {
                         $("#myvote").html(data);
                     }
           }
        }); 
}

function showoptions()
{
     $("#myvote").html(indexoriginhtml);
}
///用户注册

// JScript 文件
var checked=false; //用于提交判断
/***************************************
//中文检查
*/
function IsHanZi(strHanZi)
{
    if(!strHanZi) return; if(strHanZi=='') return false;
    var PatSWord=/^[\x00-\xff]+$/; //匹配所有单字节长度的字符组成的字符串
    var PatDWord=/[^\x00-\xff]+/g; //匹配双字节长度的字符组成的字符串
    if(!PatSWord.test(strHanZi)) return true;
    return false;
} 

/*****************************************************  
 *  函数名：DateCheck()
 *  作  用：检查字符中是否在指定的大小范围内和是否含有非法字符
 *	参  数：date: 要检查的字符；
 *          minum:  字符最小的长度
 *  		maxnum: 字符最大的长度
 *  返回值：True:   数据不在指定范围内或含有非法字符
 *			False:  数据在指定范围内且不含有非法字符
 ******************************************************
*/
function DateCheck(date,minnum,maxnum)
{
	if (date.length < minnum || date.length > maxnum ){
		//window.alert("输入数据的长度不能少于 " + minnum + " 位并且不能大于 " + maxnum + " 位!");
		return false;
	}
/*
	 a = date.indexOf("'");
	 b = date.indexOf("|");
	 c = date.indexOf("\"");
	 
	 if (a != -1||b != -1 ||c != -1){
	   window.alert("您的输入含有特殊字符，请重新输入！");
	   return true;
	  	}
*/
	return true;
}


/*****************************************************  
 *  函数名：	IsNum()
 *  作  用：检查字符是否是纯数字
 *	参  数：str: 要检查的字符；  
 *  返回值：True:   是数字
 *			False:  不是纯数字
 ******************************************************
*/
function IsNum(str)
{
	return !/\D/.test(str)
}


/*****************************************************  
 *  函数名：	IsStr()
 *  作  用：检查字符是否是字符
 *	参  数：str: 要检查的字符  
 *  返回值：True:   是字符
 *			False:  不是纯字符
 ******************************************************
*/
function IsStr(str)
{      
　　if (/[^\x00-\xff]/g.test(str))
	{
		return false;
	}
　　else 
	{
		return true;
	}
}


/*****************************************************  
 *  函数名：IsEmail()
 *  作  用：检查Email地址是否合法
 *	参  数：date: 要检查的Email地址  
 *  返回值：True: Email 地址合法
 *          False:Email 地址不合法
 *****************************************************
*/
function IsEmail(vEMail)
{
	var regInvalid=/(@.*@)|(\.\.)|(@\.)|(\.@)|(^\.)/;
	var regValid=/^.+\@(\[?)[a-zA-Z0-9\-\.]+\.([a-zA-Z]{2,3}|[0-9]{1,3})(\]?)$/;
	return (!regInvalid.test(vEMail)&&regValid.test(vEMail));
}

/*****************************************************  
 *  作  用：检查用户表单信息
 *	参  数：无 
 *  返回值：True: 验证通过
 *          False: 验证没有通过
 ******************************************************
*/
function CheckUsername(){
    var theback=false;
    var userN=document.getElementById("username");
    var username = userN.value;
	var usernamemsg=document.getElementById("usernamemsg");
	if (username=="")
	{
	   usernamemsg.innerHTML="<span class='alert'>用户名不能为空！</span>";
	   userN.focus();
	   checked=false;
	   return false;
	 }
	 else if(!DateCheck(username,4,16))
	 {
	    usernamemsg.innerHTML="<span class='alert'>用户名应为4-16个字符！</span>";
	    userN.focus();
	    checked=false;
	    return false;
	  }
	  else{
	        $.ajax({ type:"Get",
           url: "Register.aspx",
           cache: false,
           data:"act=checkname&UserName="+$("input[id='username']").get(0).value,
           beforeSend:function(){ $("#usernamemsg").html("<img src='Images/progress.gif' width='18' height='18' />正在链接服务器..."); },
           success: function(data){
                if(data=="ok")
                    {
                     $("#usernamemsg").html("<img src='Images/check_right.gif' width='18' height='18' /><span class='checked'>恭喜你！该用户名可以使用。</span>");
                     theback=true;
                    }
                else
                 {
                     $("#usernamemsg").html("<img src='Images/check_err.gif' width='18' height='18' /><span class='alert'>该用户名已经被占用</span>");
                     checked=false;
                     $("#username").focus();
                     theback= false;
                }
               
           }
        }); 
        return theback;
 
    }
  
 
}

function CheckCardNO(){
    var theback=false;
    var userN=document.getElementById("card");
    var username = userN.value;
	var usernamemsg=document.getElementById("cardmsg");
	if (username=="")
	{
	   usernamemsg.innerHTML="<span class='alert'>一卡通不能为空！</span>";
	   userN.focus();
	   checked=false;
	   return false;
	 }
	 else if(!DateCheck(username,12,12)||!IsNum(username))
	 {
	    usernamemsg.innerHTML="<span class='alert'>请正确输入一卡通卡号！</span>";
	    userN.focus();
	    checked=false;
	    return false;
	  }
	  else{
	        $.ajax({ type:"Get",
           url: "Register.aspx",
           cache: false,
           data:"act=checkcard&card="+$("input[id='card']").get(0).value,
           beforeSend:function(){ $("#cardmsg").html("<img src='Images/progress.gif' width='18' height='18' />正在链接服务器..."); },
           success: function(data){
                if(data=="可用的卡号！")
                   {
                     $("#cardmsg").html("<img src='Images/check_right.gif' width='18' height='18' /><span class='checked'>卡号输入正确</span>");
                     theback= true;
                    }
                else
                 {
                     $("#cardmsg").html("<img src='Images/check_err.gif' width='18' height='18' /><span class='alert'>"+data+"</span>");
                     checked=false;
                     $("#card").focus();
                     theback= false;
                }
               
           }
        }); 
      
 
    }
  
   return theback;
}



function checkpsw(){
    var psw=document.getElementById("password");
	var password = psw.value;
	var passwordmsg=document.getElementById("passwordmsg");	
	if (password=="")
	{
	   passwordmsg.innerHTML="<span class='alert'>请输入密码!</span>";
	   return false;
	 }

	if(!DateCheck(password,6,16))
	{
		passwordmsg.innerHTML="<span class='alert'>密码必须为6-16个字符!</span>";
		psw.value = "";
		
		return false;
	}
	passwordmsg.innerHTML="<span class='checked'>密码正确输入!</span>";
	
	return true;
}
function checkpsw2(){	
    var password=document.getElementById("password").value;
	var password2 = document.getElementById("password2");
	var password2msg=document.getElementById("password2msg");	
	if (password2.value=="")
	{
	   password2msg.innerHTML="<span class='alert'>请再输入一次新密码!</span>";
	   
	   return false;
	 }
	
	if(!DateCheck(password2.value,6,16))
	{
		password2.value = "";
		password2msg.innerHTML="<span class='alert'>密码必须为6-16位的字符!</span>";
		
		return false;
	}
	
	if (password != password2.value) 
	{
		password2msg.innerHTML="<span class='alert'>两次密码输入不一致!</span>";
		document.getElementById("password").value = "";
		password2.value = "";
		
		return false;
	}
	if (password == password2.value) 
	{
		password2msg.innerHTML="<span class='checked'>两次密码输入一致!</span>";
		
		return true;
	}
}

function CheckTiShi()
{
    if($("#tishi").val()=="")
       { $("#tishimsg").html("<span class='alert'>请输入密码提示!</span>");
       checked=false;
       }
    else{$("#tishimsg").html("<span class='checked'>正确输入!</span>"); return true;}
}
function CheckAnswer()
{
     if($("#answer").val()=="")
       { $("#answermsg").html("<span class='alert'>请输入密码提示答案!</span>");
       checked=false;
       }
       else{$("#answermsg").html("<span class='checked'>正确输入!</span>"); return true;}
}

function checkpost(){
    var agree = document.getElementById("agree").checked;
   
    if(checkpsw()&&checkpsw2()&&CheckTiShi()&&CheckAnswer()&&agree)
            checked=true;
    else
        checked=false;
  
     
    if(checked)
    {
        document.getElementById("checkall").innerHTML="<span class='checked'>信息填写完成！</span>";
         $('#waiting').fadeIn('slow');
        $('#User').hide();
        document.getElementById("User").submit();
    }
    else
    {
        document.getElementById("checkall").innerHTML="<span class='alert'>请完善相关信息，并同意该协议！</span>";
    }
}

///其他通用的
function changeblockhead(id,tt,classname){
    var divid="#"+id+" span";
  for(i=0;i<$(divid).size();i++)
  {
    $(divid).eq(i).removeClass(classname);
  }
  $(divid).eq(tt-1).addClass(classname); 


}
function changeblock(id,tt,classname){
    var divid="#"+id+" ."+classname;
  for(i=0;i<$(divid).size();i++)
  {
    $(divid).eq(i).hide();
  }
  $(divid).eq(tt-1).fadeIn("fast"); 
}
//tooltips
var xPos;
var yPos;

function showToolTip(title,msg,evt){
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
   toolTip.innerHTML = "<h1>"+title+"</h1><p>"+msg+"</p>";
  toolTip.style.top = parseInt(yPos)+2 + "px";
 //  toolTip.style.left = parseInt(xPos)+2 + "px";
   toolTip.style.visibility = "visible";
   
}

function hideToolTip(){
   var toolTip = document.getElementById("toolTip");
   toolTip.style.visibility = "hidden";
}