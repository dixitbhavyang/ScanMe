$( document ).ready( function ()
{
    $( document ).on("click","#btnDashboard",function ()
    {
        $.ajax( {
            url: "/Home/Index", success: function ( result )
            {
                $( "#main-container" ).html( result );
            }
        } );

    } );

    $( document ).on("click","#btnSocialMediaLinks",function ()
    {
        $.ajax( {
            url: "/Home/SocialmediaLinks", success: function ( result )
            {
                $("#btnSocialMediaLinks").addClass("active");
                $("#btnSettings").removeClass("active");
                $( "#main-container" ).html( result );
            }
        } );

    } );

    $( document ).on("click","#btnSettings",function ()
    {
        $.ajax( {
            url: "/Home/Settings", success: function ( result )
            {
                $("#btnSettings").addClass("active");
                $("#btnSocialMediaLinks").removeClass("active");
                $( "#main-container" ).html( result );
            }
        } );

    } );


    /// START PROFILE PICTURE ///
    $( document ).on("change", "#ProfilePicture", function ( e )
    {
        var file = e?.target?.files[0]; // Get the selected file
        if ( file )
        {
            var reader = new FileReader();

            reader.onload = function ( e )
            {
                $( '#ProfilePicturePath' ).attr( 'src', e.target.result ); // Set image source
            };

            reader.readAsDataURL( file ); // Read the file as a data URL
        }
    } );

    $( document ).on("hover", "#clearPrfofilePicture" , function ()
    {
        $( "#clearPrfofilePicture i" ).attr( "style", "cursor:pointer" );
    } );

    $( document ).on("click", "#clearPrfofilePicture", function ()
    {
        $( "#ProfilePicturePath" ).attr( "src", "/assets/media/avatars/avatar10.jpg" );
        $( "#ProfilePicture" ).val( "" );
    } );
    /// END PROFILE PICTURE ///


    //  HIDE AND SHOW PASSWORD //
    $( '#Password' ).data( 'original-type-pswd', $( '#Password' ).attr( 'type' ) );
    $( '#NewPassword' ).data( 'original-type-new-pswd', $( '#NewPassword' ).attr( 'type' ) );
    $( '#ConfirmPassword' ).data( 'original-type-cpswd', $( '#ConfirmPassword' ).attr( 'type' ) );

    $( document ).on("click", "#showCurrentPassword" , function ()
    {
        $( '#showCurrentPassword i' ).toggleClass( 'fa-eye fa-eye-slash' );
        var passwordField = $( '#Password' );
        var originalTypePassword = passwordField.data( 'original-type-pswd' );
        passwordField.attr( 'type', passwordField.attr( 'type' ) === 'text' ? originalTypePassword : 'text' );

    } );

    $( document ).on("click","#showNewPassword", function ()
    {
        $( '#showNewPassword i' ).toggleClass( 'fa-eye fa-eye-slash' );
        var passwordField = $( '#NewPassword' );
        var originalTypePassword = passwordField.data( 'original-type-new-pswd' );
        passwordField.attr( 'type', passwordField.attr( 'type' ) === 'text' ? originalTypePassword : 'text' );

    } );

    $( document ).on("click","#showNewPasswordConfirm", function ()
    {
        $( '#showNewPasswordConfirm i' ).toggleClass( 'fa-eye fa-eye-slash' );
        var passwordField = $( '#ConfirmPassword' );
        var originalTypePassword = passwordField.data( 'original-type-cpswd' );
        passwordField.attr( 'type', passwordField.attr( 'type' ) === 'text' ? originalTypePassword : 'text' );

    } );
    // END HIDE AND SHOW PASSWORD //


    $( document ).on( "input","#Name", function ()
    {
        if ( $( "#Name" ).val() != "" )
        {
            $( "#Name" ).removeClass( "is-invalid" );
        }
        else
        {
            $( "#Name" ).attr( "placeholder", "Name is Required" );
            $( "#Name" ).addClass( "is-invalid" );
        }
    } );

    $( document ).on( "input","#Email", function ()
    {
        if ( $( "#Email" ).val() != "" )
        {
            $( "#Email" ).removeClass( "is-invalid" );
        }
        else
        {
            $( "#Email" ).attr( "placeholder", "Email is Required" );
            $( "#Email" ).addClass( "is-invalid" );
        }
    } );

    $( document ).on( "input","#NewPassword", function ()
    {
        if ( $( "#Password" ).val() != "" )
        {
            if ( $( "#NewPassword" ).val() == "" )
            {
                $( "#NewPassword" ).addClass( "is-invalid" );
            }
            else if ( parseInt( $( "#NewPassword" ).val().length ) < 5 )
            {
                $( "#NewPassword" ).addClass( "is-invalid" );
                var div = document.querySelector( "#newPasswordLength" );
                div.style.display = "block";
            }
            else
            {
                var div = document.querySelector( "#newPasswordLength" );
                div.style.display = "none";
                $( "#NewPassword" ).removeClass( "is-invalid" );
            }
        }
    } );

    $( document ).on( "input","#ConfirmPassword", function ()
    {
        if ( $( "#Password" ).val() != "" )
        {
            if ( $( "#ConfirmPassword" ).val() !== $( "#NewPassword" ).val() )
            {
                $( "#ConfirmPassword" ).addClass( "is-invalid" );
                var div = document.querySelector( "#confirmPasswordError" );
                div.style.display = "block";
            }
            else
            {
                $( "#ConfirmPassword" ).removeClass( "is-invalid" );
                var div = document.querySelector( "#confirmPasswordError" );
                div.style.display = "none";
            }
        }
    } );


    // TO SAVE CHANGED USER INFO . . .//
    function validateUserProfileControls()
    {
        var Name = $( "#Name" ).val();
        var Username = $( "#Username" ).val();
        var Email = $( "#Email" ).val();

        if ( Name == "" )
        {
            $( "#Name" ).focus();
            $( "#Name" ).attr( "placeholder", "Name is Required" );
            $( "#Name" ).addClass( "is-invalid" );
            return false;
        }
        else if ( Email == "" )
        {
            $( "#Email" ).focus();
            $( "#Email" ).attr( "placeholder", "Email is Required" );
            $( "#Email" ).addClass( "is-invalid" );
            return false;
        }
        return true;
    }


    $(document).on( "click", '#btnUpdateProfile', function ()
    {
        debugger;
        if ( validateUserProfileControls() )
        {
            var formData = new FormData($( "#updateProfileForm" )[0] );
            formData.append( "ProfilePicturePath", $( "#ProfilePicturePath" ).attr( "src" ) );

            postMethodWithFormData( "/User/UpdateProfile", formData,
                    function ( s )
                    {
                        debugger;
                        //alert( s );
                        if ( s == "Updated Successfully" )
                        {
                            $(".imgProfilePic").attr("src",$("#ProfilePicturePath").attr("src"));
                        }
                        else if ( s == "No Changes" )
                        {
                            var div = document.querySelector( "#updateProfileError" );
                            div.style.display = "none";
                        }
                        else
                        {
                            var div = document.querySelector( "#updateProfileError" );
                            div.style.display = "block";
                        }
                    }
                    ,
                    function ( e )
                    {
                        alert( e );
                    }
            );
        }
    } );

    function validateUpdatePasswordControls()
    {
        var Password = $( "#Password" ).val();
        var New_Password = $( "#NewPassword" ).val();
        var Confirm_Password = $( "#ConfirmPassword" ).val();

        if ( Password != "" )
        {
            if ( New_Password == "" )
            {
                $( "#NewPassword" ).focus();
                $( "#NewPassword" ).addClass( "is-invalid" );
                return false;
            }
            else if ( Confirm_Password == "" )
            {
                $( "#ConfirmPassword" ).focus();
                $( "#ConfirmPassword" ).addClass( "is-invalid" );
                return false;
            }
            else if ( New_Password != Confirm_Password )
            {
                $( "#ConfirmPassword" ).focus();
                $( "#ConfirmPassword" ).addClass( "is-invalid" );
                return false;
            }
            else
            {
                $( "#NewPassword" ).removeClass( "is-invalid" );
                $( "#ConfirmPassword" ).removeClass( "is-invalid" );
                return true;
            }
        }
        return false;
    }

    $( document).on("click","#btnUpdatePassword" , function ()
    {
        if ( validateUpdatePasswordControls() )
        {
            var formData = new FormData( $( "#updatePasswordForm" )[0] );
            postMethodWithFormData( "/User/UpdatePassword", formData,
                    function (res)
                    {
                        debugger;
                        //alert( res );
                        if ( res == "Updated Successfully" )
                        {
                            location.href = "/User/SignIn";
                        }
                        else if ( res == "Incorrect Password" )
                        {
                            var div = document.querySelector( "#incorrectPassword" );
                            div.style.display = "block";
                        }
                        else
                        {
                            var div = document.querySelector( "#incorrectPassword" );
                            div.style.display = "none";

                            var div = document.querySelector( "#updatePasswordError" );
                            div.style.display = "block";
                        }
                    },
                    function ( e )
                    {
                        alert( e );
                    }
            );
        }
    } );
    // END - TO SAVE CHANGED USER INFO . . .//

} );
