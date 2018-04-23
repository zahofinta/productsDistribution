

$(document).ready(function () {

    //$('#AnnouncementToPost').validate({
    //    errorClass: 'help-block animation-slideDown', // You can change the animation class for a different entrance animation - check animations page  
    //    errorElement: 'div',
    //    errorPlacement: function (error, e) {
    //        e.parents('.form-group > div').append(error);
    //    },
    //    highlight: function (e) {

    //        $(e).closest('.form-group').removeClass('has-success has-error').addClass('has-error');
    //        $(e).closest('.help-block').remove();
    //    },
    //    success: function (e) {
    //        e.closest('.form-group').removeClass('has-success has-error');
    //        e.closest('.help-block').remove();
    //    },
    //    rules: {
    //        'title': {
    //            required: true
               
    //        },

    //        'arrive_date': {
    //            required: true
               
    //        }
          

         

    //    },
    //    messages: {
            

    //        'title': {
    //            required: 'Заглавие на обява е задължително поле !!!!'
                
    //        },

    //        'arrive_date': {
    //            required: 'Дата за доставка е задължително поле !!!!'
                
    //        }

        
            
    //    }



    //});
    $('#AnnouncementToPost').validate({ // initialize the plugin
        submitHandler: function (form) { // for demo
            alert('valid form submitted'); // for demo
            return false; // for demo
        }
    });


    $('.announcementForm').each(function () {

      //  $(this).closest('.announcementForm').find('.validatePrice').
            $(this).closest('.announcementForm').find('.validatePrice').each(function () {
            $(this).rules("add", {
                required: true,
                messages: {
                    required: "Цена е задължително поле !!!!"
                }
            });
        });

        $('.validateQuantity').each(function () {
            $(this).rules("add", {
                required: true,
                messages: {
                    required: "Максимално количество е задължително поле !!!!"
                }
            });
        });
        $('.ddlProducer').each(function () {
            $(this).rules("add", {
                required: true,
                messages: {
                    required: "Трябва да бъде избран производител !!!!"
                }
            });
        });
        $('.ddlProduct').each(function () {
            $(this).rules("add", {
                required: true,
                messages: {
                    required: "Трябва да буде избран продукт !!!!"
                }
            });
        });

       
    });
 
    //$('.validatePrice').each(function () {
    //    $(this).rules("add", {
    //        required: true,
    //        messages: {
    //            required : "Цена е задължително поле !!!!"
    //        }
    //    });
    //});

    //$('.validateQuantity').each(function () {
    //        $(this).rules("add", {
    //            required: true,
    //            messages: {
    //                required: "Максимално количество е задължително поле !!!!"
    //            }
    //        });
    //    });
    //        $('.ddlProducer').each(function () {
    //            $(this).rules("add", {
    //                required: true,
    //                messages: {
    //                    required: "Трябва да бъде избран производител !!!!"
    //                }
    //            });
    //        });
    //            $('.ddlProduct').each(function () {
    //                $(this).rules("add", {
    //                    required: true,
    //                    messages: {
    //                        required: "Трябва да буде избран продукт !!!!"
    //                    }
    //                });
    //            });

                });
            
        
