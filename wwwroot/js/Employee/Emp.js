$(document).ready(function() {
    updateEmployeeRecord();
});



function updateEmployeeRecord(){
    $("#editBtn").on("click",function(){
        alert('hi');
        let rowId = $("empId").val();
        let empName = $("empName").val();
        let empDesignation = $("empDesignation").val();
        let empSalary = $("empSalary").val();
        let empExperience = $("empExperience").val();
        let data ={
            Id:rowId,
            Name : empName,
            Designation : empDesignation,
            Salary : empSalary,
            Experience : empExperience
        }
        $.ajax({
            url: "EmployeeController/UpdateEmployee/",
            data:{data},
            success: function(){
                alert("Success!");
            },
            error: function(){
                alert("Error!");
            }
        });

    })
}

function DeleteEmployeeRecord(id){
        $.ajax({
            url: "/Employee/DeleteEmployee?id=" + id,
            success: function(){
                location.reload();
            },
            error: function(){
                alert("Error!");
            }
        });

}