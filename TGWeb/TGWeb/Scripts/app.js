$('#trigger').click(function () {
    $('#output').removeClass('alert-success').removeClass('alert-danger');
    $('#output').html('<img src="/Content/loading.gif" />');
    $.post(
        'api2/values/',
        { '': $('#url').val() },
        function (payload) {
            var cls = payload.indexOf('failure') >= 0 ? 'alert-danger' : 'alert-success';
            $('#output').text(payload);
            $('#output').addClass('alert '+cls);
    });
})