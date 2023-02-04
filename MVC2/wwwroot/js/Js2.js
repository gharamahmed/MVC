var empSSN = document.getElementById("ESSN")
var proNum = document.getElementById("Pnum")
var PartialNum = document.getElementById("EmpSSN")
empSSN.addEventListener("change", async () => {
    var project = await fetch("http://localhost:5158/ValidateProject/partialpro/" + empSSN.value)
    projectList = await project.text();
    PartialNum.innerHTML = projectList;

})