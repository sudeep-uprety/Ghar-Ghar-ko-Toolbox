function userValid() {
    var Name, gender, con, EmailId, emailExp;
    Name = document.getElementById("txtUserId").value;
    gender = document.getElementById("ddlType").value= document.getElementById("txt1").value;
    con = document.getElementById("txt2").value;
    EmailId = document.getElementById("txtmail").value;
    emailExp = /^([a-zA-Z0-9_\.\-])+\@(([a-zA-Z0-9\-])+\.)+([com\co\.\in])+$/; // to validate email id  
} 