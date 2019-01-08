"use strict";
$(document).ready(function () {
    //toastr.success("Without any options","Simple notification!");
    //	var parentdiv=$('#fileList');
    ////	var childdiv=$('<div class="file-box"><div class="file"><a href="#"><span class="corner"></span><div class="icon"><i class="fa fa-file"></i></div><div class="file-name">Document_2014.doc<br/><small>添加时间：2014-10-13</small></div></a></div></div>');
    //	var boarddiv1 = '<div class="file-box"><div class="file"><a href="#"><span class="corner"></span><div class="icon"><i class="fa fa-file"></i></div><div class="file-name">Document_2014.doc<br/><small>添加时间：2014-10-13</small></div></a></div></div>';
    //	//childdiv.appendto(parentdiv);、
    //	var boarddiv2='<div class="file"><a href="#"><span class="corner"></span><div class="icon"><i class="fa fa-file"></i></div><div class="file-name">Document_2014.doc<br/><small>添加时间：2014-10-13</small></div></a></div>';
    //	$('#fileList').append(boarddiv1); 
    //document.getElementById("TextBox6").style.display = "none";
    //document.getElementById("TextBox7").style.display = "none";
    
});
$(".lables").click(function(){
	$("#lable").val($(this).text());
});

$("#avatar_input").change(function () {
    $("#avator").attr("src", URL.createObjectURL($(this)[0].files[0]));
});
$(".lables1").click(function () {
    $("#level").val($(this).text());
});


function fun() {
    
    $("#hind_class").hide();
    $("#hind_teacher").hide();
}
function fun1() {
    
    $("#hind_class").show();
    $("#hind_teacher").show();
}
$("#upload").click(function () {
    if ($("#Image").val() == "" || $("#resource").val() == "") {

        alert("文件不齐！");
        return false;
    }
});
$("#upload2").click(function () {
    if ($("#avatar_input").val() == "") {

        alert("请选择图片！");
        return false;
    }
});
$("#upload4").click(function () {
    if ($("#avator_input").val() == "") {

        alert("请上传头像！");
        return false;
    }
});


