var apponclick = null;
var apppageurl = null;
function send_form(e, t){
    var n = $(e).attr("action"), r = {};
    $.each($(e).serializeArray(), function(e, t){
        r[t.name] = t.value;
    });
	$.post(n, r, t);
}
function send_form_pop(e){
    return send_form(e, function(e) {
        show_pop_box(e);
    });
}
function send_form_in(e){
    return send_form(e, function(t) {
        set_form_notice(e, t);
    });
}
function set_click(t){
	apponclick = t;
}
function set_form_notice(e, t){
    var n = $(n).attr("name");
    t = '<span class="label label-important">' + t + "</span>";
    if ($("#form_" + n + "_notice").length != 0)
        $("#form_" + n + "_notice").html(t);
    else {
        var r = $("<div class='form_notice'></div>");
        r.attr("id", "form_" + n + "_notice"); r.html(t); $(e).prepend(r);
    }
}
function show_pop_box(e, t){
    t == undefined && (t = "lp_pop_box");
    if ($("#" + t).length == 0) {
        var n = $('<div><div id="lp_pop_container"></div></div>');
        n.attr("id", t);n.css("display", "none");$("body").prepend(n);
    }
    e != "" && $("#lp_pop_container").html(e);
    var r = ($(window).width() - $("#" + t).width()) / 2;
    $("#" + t).css("left", r);$("#" + t).css("display", "block");
}
function hide_pop_box(e){
    e == undefined && (e = "lp_pop_box");$("#" + e).css("display", "none");
}
function show_float_box(e, t) {
	apponclick = t;
    t == null && (t = "设置");
    
	if(typeof t == 'object' ){
		t = t.innerText;
	}
	
	$("#float_box").off("show"), $("#float_box").on("show", function() {
        $("#float_box_title").text(t);$("#float_box .modal-body").load(e);
    });
	$("#float_box .modal-body").html('<div class="muted"><center>Loading</center>'); $("#float_box").modal({show: !0});
}

function show_d(e,t,width){
	var title = '设置';
	var w = 660;
	if(t){
		title = t.innerText;
	}
	if(width){
		w = width;
	}
	artDialog.defaults['zIndex'] = 44;
	art.dialog.load(e,
	{
		id:'float_s',
		lock:true,
		title:title,
		width:w
	},
	true);
}

function show_s(e,t){
	var title = '删除';
	if(t){
		title = t.innerText;
	}
	if(width){
		w = width;
	}
	artDialog.defaults['zIndex'] = 45;
	art.dialog.load(e,{id:'float_del',lock:true,title:title},true);
}
function close_float_box() {
    $("#float_box").modal("hide")
}
function ajax_page(e,t,callback) {
	if(e){
		apppageurl = $(e).attr('data-url');
	}
	if(t){
		apponclick = t;
	}
    e == null && (e = apppageurl);
    t == null && (t = apponclick);
	var obj = null;
	if(t){
		obj = $(t).parentsUntil('#ajaxpage').parent();
	}
	if(!obj)obj= $('#ajaxpage');
	//alert(obj);
	//alert(e);
	if(callback!=null)
	obj.load(apppageurl,null,callback);
	else obj.load(apppageurl);
}
function outcheck(e) {
    return e != "" ? (alert(e), !1) : !0
}
function checkvalue(e, t, n, r, i) {
    if (!e){
		alert("“" + i + "”" + "不能为空！");
        return false;
		}
    var s, o, u, a, f, l;
    l = getformvalue(e), l == null ? (lenght = 0, l = "") : u = l.length, s = "", r % 2 >= 1 && l == "" && (s = s + "“" + i + "”" + "不能为空！" + "\n");
    if (r % 4 >= 2) {
        f = "0123456789.";
        for (a = 0; a <= u - 1; a++)
            if (f.indexOf(l.substring(a, a + 1)) == -1) {
                s = s + "“" + i + "”" + "必需是数字！" + "\n";
                break
            }
    }
    if (r % 8 >= 4) {
        f = "0123456789";
        for (a = 0; a <= u - 1; a++)
            if (f.indexOf(l.substring(a, a + 1)) == -1) {
                s = s + "“" + i + "”" + "必需是整数！" + "\n";
                break
            }
    }
    if (r % 16 >= 8) {
        f = "abcdefghijklmnopqrstuvwxyzabcdefghijklmnopqrstuvwxyz0123456789_-.";
        for (a = 0; a <= u - 1; a++)
            if (f.indexOf(l.substring(a, a + 1)) == -1) {
                s = s + "“" + i + "”" + "包含非法字符！它只能是字母、数字和“- _ .”。" + "\n";
                break
            }
    }
    if (r % 32 >= 16) {
        f = t.replace("[a-z]", "abcdefghijklmnopqrstuvwxyz"), f = f.replace("[a-z]", "abcdefghijklmnopqrstuvwxyz"), f = f.replace("[0-9]", "0123456789");
        for (a = 0; a <= u - 1; a++)
            if (f.indexOf(l.substring(a, a + 1)) == -1) {
                s = s + "“" + i + "”" + "包含非法字符！它只能是" + n + "。" + "\n";
                break
            }
    }
    return r % 64 >= 32 && (u >= t && u <= n || (s = s + "“" + i + "”" + "的长度必需在" + t + "到" + n + "之间！" + "\n")), r % 128 >= 64 && (parseInt(l) >= parseInt(t) && parseInt(l) <= parseInt(n) || (s = s + "“" + i + "”" + "必需在" + t + "到" + n + "之间！" + "\n")), s != "" ? (alert(s), o = getformtype(e), o != "radio" && o != "checkbox" && e.focus(), !1) : !0
}
function getformtype(e) {
    if (!e)
        return false;
    var t;
    return t = e.type, typeof t == "undefined" && (t = e[0].type), t
}
function getformvalue(e) {
    if (!e)
        return false;
    var t, r;
    r = "", t = getformtype(e);
    switch (t) {
        case "radio":
            n = e.length - 1;
            if (isNaN(n) != 1) {
                for (i = 0; i <= n; i++)
                    if (e[i].checked == 1)
                        return e[i].value;
                break
            }
            e.checked == 1 ? r = e.value : r = "";
        case "checkbox":
            n = e.length - 1;
            if (isNaN(n) == 1)
                e.checked == 1 ? r = e.value : r = "";
            else
                for (i = 0; i <= n; i++)
                    e[i].checked == 1 && (r != "" && (r += ","), r += e[i].value);
            return Trim(r);
        case "select-one":
            n = e.length - 1;
            for (i = 0; i <= n; i++)
                if (e.options[i].selected == 1) {
                    r = e.options[i].value;
                    break
                }
            return Trim(r);
        case "select-multiple":
            n = e.length - 1;
            for (i = 0; i <= n; i++)
                e.options[i].selected == 1 && (r != "" && (r += ","), r += e.options[i].value);
            return r;
        default:
            return e.value == '' ?'':Trim(e.value);
    }
    return e.value == '' ? Trim(e.value) : '';
}
function ischecked(e, t) {
    if (!e)
        return false;
    var n, r;
    r = e.length - 1;
    for (n = 0; n <= r; n++)
        if (t == e[n])
            return !0;
    return !1
}
function SetSelectedAndChecked(e, t) {
    if (!e)
        return false;
    var n, r, i, s, o = new Array;
    r = "", n = e.type, typeof n == "undefined" && (n = e[0].type);
    switch (n) {
        case "radio":
            s = e.length - 1;
            if (isNaN(s) == 1)
                (e.value = t) ? e.checked = !0 : e.checked = !1;
            else
                for (i = 0; i <= s; i++)
                    e[i].value == t ? e[i].checked = !0 : e[i].checked = !1;
            break;
        case "checkbox":
            s = e.length - 1, o = t.split(",");
            if (isNaN(s) == 1)
                ischecked(o, e.value) ? e.checked = !0 : e.checked = !1;
            else
                for (i = 0; i <= s; i++)
                    ischecked(o, e[i].value) ? e[i].checked = !0 : e[i].checked = !1;
            break;
        case "select-one":
            s = e.options.length - 1;
            for (i = 0; i <= s; i++)
                e.options[i].value == t ? e.options[i].selected = !0 : e.options[i].selected = !1;
            break;
        case "select-multiple":
            s = e.options.length - 1, o = t.split(",");
            for (i = 0; i <= s; i++)
                ischecked(o, e.options[i].value) ? e.options[i].selected = !0 : e.options[i].selected = !1;
            break;
        default:
            return !1
    }
    return !0
}

String.prototype.Trim = function(){ return Trim(this);}
String.prototype.LTrim = function(){return LTrim(this);}
String.prototype.RTrim = function(){return RTrim(this);}

//此处为独立函数
function LTrim(str)
{
    var i;
    for(i=0;i<str.length;i++)
    {
        if(str.charAt(i)!=" "&&str.charAt(i)!=" ")break;
    }
    str=str.substring(i,str.length);
    return str;
}
function RTrim(str)
{
    var i;
    for(i=str.length-1;i>=0;i--)
    {
        if(str.charAt(i)!=" "&&str.charAt(i)!=" ")break;
    }
    str=str.substring(0,i+1);
    return str;
}
function Trim(str)
{
    return LTrim(RTrim(str));
}

function setCookie(NameOfCookie, value, expiredays)
{
 var ExpireDate = new Date ();
 ExpireDate.setTime(ExpireDate.getTime() + (expiredays * 24 * 3600 * 1000));
 document.cookie = NameOfCookie + "=" + escape(value) + ((expiredays == null) ? "" : "; expires=" + ExpireDate.toGMTString());
}
function getCookie(NameOfCookie)
{
 if (document.cookie.length > 0)
 {
  begin = document.cookie.indexOf(NameOfCookie+"=");
  if (begin != -1)   
  {
   begin += NameOfCookie.length+1;
   end = document.cookie.indexOf(";", begin);
   if (end == -1) end = document.cookie.length;
  return unescape(document.cookie.substring(begin, end));
  }
 }
 return null;
}
function delCookie (NameOfCookie)
{
 if (getCookie(NameOfCookie))
 {
  document.cookie = NameOfCookie + "=" + "; expires=Thu, 01-Jan-70 00:00:01 GMT";
 }
}