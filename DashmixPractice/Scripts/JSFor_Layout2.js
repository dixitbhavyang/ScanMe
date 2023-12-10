$( document ).ready( function ()
{
    /// START PROFILE PICTURE ///

    $( '#profilePicture' ).change( function ( e )
    {
        debugger;
        var file = e.target.files[0]; // Get the selected file
        if ( file )
        {
            var reader = new FileReader();

            reader.onload = function ( e )
            {
                $( '#profilePictureShow' ).attr( 'src', e.target.result ); // Set image source
            };

            reader.readAsDataURL( file ); // Read the file as a data URL
        }
    } );

    $( "#clearPrfofilePicture" ).hover( function ()
    {
        $( "#clearPrfofilePicture i" ).attr( "style", "cursor:pointer" );
    } );

    $( "#clearPrfofilePicture" ).click( function ()
    {
        $( "#profilePictureShow" ).attr( "src", "/assets/media/avatars/avatar10.jpg" );
        $( "#profilePicture" ).val( "" );
    } );

    /// END PROFILE PICTURE ///

    /// START SHOW-HIDE PASSWORD ///

    //$( '#signup-password' ).data( 'original-type-pswd', $( '#signup-password' ).attr( 'type' ) );
    //$( '#login-password' ).data( 'original-type-login-pswd', $( '#login-password' ).attr( 'type' ) );
    //$( '#signup-password-confirm' ).data( 'original-type-cpswd', $( '#signup-password-confirm' ).attr( 'type' ) );

    $( '#Password' ).data( 'original-type-pswd', $( '#Password' ).attr( 'type' ) );
    $( '#signUpForm #Password' ).data( 'original-type-pswd', $( '#signUpForm #Password' ).attr( 'type' ) );
    $( '#ConfirmPassword' ).data( 'original-type-cpswd', $( '#ConfirmPassword' ).attr( 'type' ) );

    $( "#showPassword" ).click( function ()
    {
        debugger;
        $( '#showPassword i' ).toggleClass( 'fa-eye fa-eye-slash' );
        var passwordField = $( '#Password' );
        var originalTypePassword = passwordField.data( 'original-type-pswd' );
        passwordField.attr( 'type', passwordField.attr( 'type' ) === 'text' ? originalTypePassword : 'text' );

    } );

    $( "#showPasswordSignUp" ).click( function ()
    {
        debugger;
        $( '#signUpForm #showPasswordSignUp i' ).toggleClass( 'fa-eye fa-eye-slash' );
        var passwordField = $( '#signUpForm #Password' );
        var originalTypePassword = passwordField.data( 'original-type-pswd' );
        passwordField.attr( 'type', passwordField.attr( 'type' ) === 'text' ? originalTypePassword : 'text' );

    } );

    $( "#showConfirmPassword" ).click( function ()
    {
        debugger;
        $( '#showConfirmPassword i' ).toggleClass( 'fa-eye fa-eye-slash' );
        var confirmPasswordField = $( '#ConfirmPassword' );
        var originalTypeConfirmPassword = confirmPasswordField.data( 'original-type-cpswd' );
        confirmPasswordField.attr( 'type', confirmPasswordField.attr( 'type' ) === 'text' ? originalTypeConfirmPassword : 'text' );

    } );

    /// END SHOW-HIDE PASSWORD ///

    /// START FORM CHANGE ///

    $( ".newAccount" ).click( function ()
    {
        debugger;
        //alert( "Clciked" );
        $( "#title" ).text( "SIGN UP" );
        $( "#signInForm" ).attr( "hidden", true );
        $( "#forgetPasswordForm" ).attr( "hidden", true );
        $( "#signUpForm" ).attr( "hidden", false );
    } );

    $( ".signIn" ).click( function ()
    {
        //alert( "Clciked" );
        $( "#title" ).text( "SIGN IN" );
        $( "#signUpForm" ).attr( "hidden", true );
        $( "#forgetPasswordForm" ).attr( "hidden", true );
        $( "#signInForm" ).attr( "hidden", false );
    } );

    $( "#forgetPassword" ).click( function ()
    {
        $( "#title" ).text( "FORGET PASSWORD" );
        $( "#signUpForm" ).attr( "hidden", true );
        $( "#signInForm" ).attr( "hidden", true );
        $( "#forgetPasswordForm" ).attr( "hidden", false );
    } );

    /// END FORM CHANGE ///
} );