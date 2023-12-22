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

function postMethod( url, data, success, error )
{
    $.ajax( {
        type: 'POST',
        url: url, // Replace with your server-side endpoint
        data: data, // Send integer value as data
        success: success,
        error: error
    } );
}