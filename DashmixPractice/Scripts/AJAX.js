function postMethodWithFormData( url, data, success, error )
{
    $.ajax( {
        url: url,
        type: 'POST',
        data: data,
        processData: false,
        contentType: false,
        success: success,
        error: error
    } );
}