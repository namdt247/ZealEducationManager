$('a#btnDeleteCourse').click(function (event) {
    event.preventDefault();
    if (confirm("Are you sure delete?")) {
        let url = $(this).attr('href');
        window.location = url;
    }
})

$('a#btnDeleteUser').click(function (event) {
    event.preventDefault();
    if (confirm("Are you sure delete?")) {
        let url = $(this).attr('href');
        window.location = url;
    }
})

$('a#btnDeleteBatch').click(function (event) {
    event.preventDefault();
    if (confirm("Are you sure delete?")) {
        let url = $(this).attr('href');
        window.location = url;
    }
})

$('a#btnDeleteExam').click(function (event) {
    event.preventDefault();
    if (confirm("Are you sure delete?")) {
        let url = $(this).attr('href');
        window.location = url;
    }
})

$('a#btnDeleteFeedback').click(function (event) {
    event.preventDefault();
    if (confirm("Are you sure delete?")) {
        let url = $(this).attr('href');
        window.location = url;
    }
})