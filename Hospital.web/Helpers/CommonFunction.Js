$(document).ready(function () {

    // Department Dropdown Change Event
    $('#DepartmentDD').change(function () {
        var departmentId = $(this).val();
        $('#DoctorDD').empty();
        $('#DoctorDD').append('<option value="0">--Select--</option>');

        // Make an AJAX request to fetch doctors based on the selected department
        $.ajax({
            url: baseURLDoctors,
            data: { departmentId: departmentId },
            type: "POST",
            s     error: function () {
                alert("An error occurred.");
            },
            success: function (result) {
                $.each(result, function (i, data) {
                    $('#DoctorDD').append('<option value="' + data.Value + '">' + data.Text + '</option>');
                });
            }
        });
    });

});
