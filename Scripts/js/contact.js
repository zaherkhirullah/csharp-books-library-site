/* Contact Form */

/*global $, jQuery*/

$(document).ready(function () {
    "use strict";
    var contactForm = {
        initialized: false,
        initialize: function () {
            if (this.initialized) {
				return;
			}
			this.initialized = true;
			this.build();
			this.events();
        },
        build: function () {
            this.validations();
        },
        events: function () {},
        validations: function () {
            var contactform = $("#contact-form"),
                url = contactform.attr("action");
			contactform.validate({
				submitHandler: function (form) {
					// Loading State
					var submitButton = $(this.submitButton);
                    submitButton.button("loading");
                    // Ajax Submit
                    $.ajax({
                        type: "POST",
                        url: url,
                        data: {
                            "name": $("#contact-form #name").val(),
                            "email": $("#contact-form #email").val(),
                            "message": $("#contact-form #message").val()
                        },
                        dataType: "json",
                        success: function (data) {
							if (data.response === "success") {
								$("#contact-success").removeClass("hidden").fadeOut(7000);
								$("#contact-error").addClass("hidden");
								// Reset Form
								$("#contact-form .form-control")
									.val("")
									.blur()
									.parent()
									.removeClass("has-success")
									.removeClass("has-error")
									.find("label.error")
									.remove();
							} else {
								$("#contact-error").removeClass("hidden").fadeOut(7000);
								$("#contact-success").addClass("hidden");
							}
						},
						complete: function () {
							submitButton.button("reset");
                            $("#")[0].reset();
						}
					});
				},
				rules: {
                    name: {
                        required: true
                    },
                    email: {
                        required: true,
                        email: true
                    },
                    message: {
                        required: true
                    }
                },
                highlight: function (element) {
                    $(element)
                        .parent()
                        .removeClass("has-success")
                        .addClass("has-error");
                },
                success: function (element) {
                    $(element)
                        .parent()
                        .removeClass("has-error")
                        .addClass("has-success")
                        .find("label.error")
                        .remove();
                }
            });
        }
    };
	
	contactForm.initialize();
	
});