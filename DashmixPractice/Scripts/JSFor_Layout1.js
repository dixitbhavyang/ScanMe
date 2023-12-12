$( document ).ready( function ()
{

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

    $( document ).on( "input","#Username", function ()
    {
        if ( $( "#Username" ).val() != "" )
        {
            $( "#Username" ).removeClass( "is-invalid" );
        }
        else
        {
            $( "#Username" ).attr( "placeholder", "Username is Required" );
            $( "#Username" ).addClass( "is-invalid" );
        }
    } );

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
            var previousProfilePicPath = $( "#ProfilePicturePath" ).attr( "src" );
            postMethodWithFormData( "/User/UpdateProfile", formData,
                    function ( s )
                    {
                        debugger;
                        //alert( s );
                        if ( s == true)
                        {
                            Swal.fire({
                                icon: 'success',
                                title: 'Success!',
                                text: 'Updated Successfully.',
                                confirmButtonColor: '#3085d6',
                                confirmButtonText: 'OK'
                            });
                            $(".imgProfilePic").attr("src",$("#ProfilePicturePath").attr("src"));
                            $(".username").text($("#Username").val());
                        }
                        else
                        {
                            Swal.fire({
                                icon: 'warning',
                                title: 'Oops...',
                                text: 'There is an Error, Please Try again Later!',
                                confirmButtonColor: '#d33',
                                confirmButtonText: 'OK',
                                allowOutsideClick: false
                            });
                            $("ProfilePicturePath").attr("src",previousProfilePicPath);
                            $("#ProfilePicture").val("");
                        }
                    }
                    ,
                    function ( e )
                    {
                        Swal.fire({
                            icon: 'warning',
                            title: 'Oops...',
                            text: 'There is an Error, Please Try again Later!',
                            confirmButtonColor: '#d33',
                            confirmButtonText: 'OK',
                            allowOutsideClick: false
                        });
                        $("ProfilePicturePath").attr("src",previousProfilePicPath);
                        $("#ProfilePicture").val("");
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
                        if ( res == true)
                        {
                            Swal.fire({
                                icon: 'success',
                                title: 'Password Updated Successfully !',
                                text: 'You have to Login again with New Password',
                                confirmButtonColor: '#3085d6',
                                confirmButtonText: 'OK',
                                allowOutsideClick: false
                            }).then((result) => {
                                
                                if (result.isConfirmed) {
                                    location.href = "/User/SignIn";
                                }
                            });
                        }
                        else if ( res == "Incorrect Password" )
                        {
                            Swal.fire({
                                icon: 'error',
                                title: 'Incorrect Password !',
                                text: 'Check your Password!',
                                confirmButtonColor: '#d33',
                                confirmButtonText: 'OK',
                                allowOutsideClick: false
                            });

                        }
                        else
                        {
                            Swal.fire({
                                icon: 'warning',
                                title: 'Oops...',
                                text: 'There is an Error, Please Try again Later!',
                                confirmButtonColor: '#d33',
                                confirmButtonText: 'OK',
                                allowOutsideClick: false
                            });

                        }
                    },
                    function ( e )
                    {
                        Swal.fire({
                            icon: 'warining',
                            title: 'Oops...',
                            text: 'There is an Error, Please Try again Later!',
                            confirmButtonColor: '#d33',
                            confirmButtonText: 'OK',
                            allowOutsideClick: false
                        });
                    }
            );
        }
    } );
    // END - TO SAVE CHANGED USER INFO . . .//

    // START SIGN-OUT //
    $(document).on("click","#btnSignOut",function()
    {
        Swal.fire({
            title: 'Are you sure?',
            text: 'You have to Login again next time!',
            icon: 'warning',
            showCancelButton: true,
            confirmButtonColor: '#3085d6',
            cancelButtonColor: '#d33',
            confirmButtonText: 'Yes, Sign Out!',
            allowOutsideClick: false
        }).then((result) => {
            if (result.isConfirmed) {

                $.post('/User/SignOut', function(response) {
                    location.href="/User/SignIn";
                }).fail(function(xhr, status, error) {
                    // Handle errors if the request fails
                    console.error('Error:', error);
                });

            } else {
                Swal.fire(
                  'Cancelled',
                  'Your action has been cancelled.',
                  'info'
                );
            }
        });

    });
    // END SIGN-OUT //
} );
