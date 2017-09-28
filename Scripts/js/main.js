/*
 * Merope v 1.1
 * Copyright 2016, Filip Greksa
 * www.filipgreksa.com
 * 2016/06/23
 */


/*global $, jQuery*/

$(window).load(function () {
    "use strict";
    // -----------------------------
    // Preloader
    // -----------------------------
    setTimeout(function () {
        $('.preloader').fadeOut(600);
    }, 800);
});

$(window).load(function () {
    "use strict";
    setTimeout(function () {
        $('.ilan').fadeIn(3000);
    }, 1200);
});
$(document).ready(function () {
    "use strict";
    // Init Material scripts for buttons ripples, inputs animations etc, more info on the next link https://github.com/FezVrasta/bootstrap-material-design#materialjs
    $.material.init();

    //  Activate the Tooltips
    $('[data-toggle="tooltip"], [rel="tooltip"]').tooltip();

    // Activate Datepicker
    if ($('.datepicker').length !== 0) {
        $('.datepicker').datepicker({
            weekStart: 1
        });
    }

    // Activate Popovers
    $('[data-toggle="popover"]').popover();
    // ----------------------------
    // Navbar fade
    // ----------------------------
    $(function () {
        var navbar = $('.navbar');
        if (navbar.hasClass("navbar-transparent")) {
            $(window).scroll(function () {
                if (navbar.offset().top > 100) {
                    navbar.removeClass("navbar-transparent");
                } else {
                    navbar.addClass("navbar-transparent");
                }
            });
        } else {
            return;
        }
    });
      // ----------------------------
    // scroll top
    // ----------------------------
    $(function () {
        var Scrolltop = $('.scroll-top');
        if (Scrolltop.style.display="none") {
            $(window).scroll(function () {
                if (Scrolltop.offset().top > 150) {
                    Scrolltop.style.display = "block";
                } else {
                    Scrolltop.style.display = "none";
                }
            });
        } else {
            return;
        }
    });


    // ----------------------------
    // masonry
    // ---------------------------

    // portfolio
    $(function () {
        var $container = $('.masonry');
        // init
        $container.imagesLoaded(function () {
            $container.isotope({
                itemSelector: ".item",
                percentPosition: true,
                masonry: {
                    columnWidth: ".grid-sizer"//,
                },

                // sorting
                getSortData: {
                    category: function (itemElem) {
                        var category = $(itemElem).find('span.meta').attr('data-category');
                        return category;
                    },
                    newest: function (itemElem) {
                        var newest = $(itemElem).find('time').attr('datetime');
                        return newest;
                    }
                },
                sortAscending: {
                    newest: false
                }

            });
        });

        // filter items when filter link is clicked
        $('#filter').on('click', 'a', function () {
            var selector = $(this).attr('data-filter');
            $container.isotope({ filter: selector });
            return false;
        });

        // sort items on button click
        $('#sort').on('click', 'a', function () {
            var sortByValue = $(this).attr('data-sort-by');
            $container.isotope({ sortBy: sortByValue });
        });

    });

    // filter buttons
    var buttonGroup = [];
    // change is-checked class on buttons
    $('.filter').each(function (i, buttonGroup) {
        var $buttonGroup = $(buttonGroup);
        $buttonGroup.on('click', 'a', function () {
            $buttonGroup.find('.is-active').removeClass('is-active').addClass('btn-simple');
            $(this).addClass('is-active').removeClass('btn-simple');
        });
    });


    // -----------------------------
    // Slick
    // -----------------------------
    // Clients Logos
    $('.slick-slider.logos').slick({
        slide: 'ul>li',
        autoplay: true,
        autoplaySpeed: 3000,
        slidesToShow: 6,
        slidesToScroll: 3,
        arrows: true ,
        responsive: [
            {
                breakpoint: 640,
                settings: {
                    slidesToShow: 3,
                    slidesToScroll: 1
                }
            },
            {
                breakpoint: 480,
                settings: {
                    slidesToShow: 2,
                    slidesToScroll: 1
                }
            }
        ]
    });
    // Customers Quotes
    $('.slick-slider.quotes-slider').slick({
        slide: 'ul>li',
        autoplay: true,
        autoplaySpeed: 5000,
        slidesToShow: 1,
        arrows: false,
        dots: true
    });

    // ----------------------------
    // Progressbar
    // ----------------------------
    $('.progress-bar').appear(function () {
        $(this).each(function () {
            var value = $(this).attr('aria-valuenow');
            $(this).animate({
                'width': value + '%'
            }, 2000);
            $(this).find('.bar-value').prop("Counter", 0).animate({
                Counter: value,
                'width': value + '%'
            }, {
                    duration: 2000,
                    step: function (now) {
                        $(this).text(Math.ceil(now));
                    }
                });
        });
    });

    // ----------------------------
    // Statistics - vertical bars
    // ----------------------------
    $('.stat-item').appear(function () {
        var countStat = function () {
            $('.statistic').each(function () {
                var value = $(this).find('.stat-item').attr('data-percent');
                $(this).find('.stat-number').prop("Counter", 0).animate({
                    Counter: value 
                }, {
                        duration: 1600,
                        step: function (now) {
                            $(this).text(Math.ceil(now));
                        }
                    });
            });
        };
        $(this).thermometer({
            percent: 75,
            orientation: 'vertical',
            speed: 'slow'
        }, 2000, countStat());
    });


    $('.navbar-nav li a, a[smooth]').bind('click', function (event) {
        var $anchor = $(this);
        $('html, body').stop().animate({
            scrollTop: $($anchor.attr('href')).offset().top
        }, 1500, 'swing');
        event.preventDefault();
    });


    // -----------------------------
    // Chocolat.js Lightbox
    // ----------------------------

    $('.gallery').Chocolat({
        imageSize: 'contain'
    });

    // -----------------------------
    // Filter / Sort / to Dropdown in xs
    // ----------------------------
    // Create the dropdown base
    $("<label><select />").appendTo(".filter");
    // Populate dropdown with menu items
    $("#filter a, #sort a").each(function () {
        var el = $(this);
        $("<option />", {
            "data-filter": el.attr("data-filter"),
            "data-sort-by": el.attr("data-sort-by"),
            "text": el.text()
        }).appendTo(".filter select");
    });
    // To make dropdown actually work
    $(".filter select").change(function () {
        var selector = $(".filter select option:selected").attr('data-filter'),
            sortByValue = $(".filter select option:selected").attr('data-sort-by');
        $('.masonry').isotope({ filter: selector });
        $('.masonry').isotope({ sortBy: sortByValue });
        return false;
    });

    /* Add Like And Unlick */

        //LIKE
          /*  $("a.like").click(function ()*/
    $('.like').on('click', 'a', function (){
        var id = $(this).attr('data-id');
            var link = "/Home/LikeBook/" + id;
            var a = $(this);
            $.ajax({
                type: "GET",
                url: link,
                success: function (result) {
                    a.html('<i glyphicon glyphicon-heart  text-danger"></i> ' + result).removeClass("like").addClass("unlike");
                }
            });
        });
        //UNLIKE
   // $("a.unlike").click(function ()
    $('.unlike').on('click', 'a',
     function (){
            //var id = $(this).data("id");
         var id = $(this).attr('data-id');
            var link = "/Home/UnlikeBook/" + id;
            var a = $(this);
            $.ajax({
                type: "GET",
                url: link,
                success: function (result) {
                    a.html('  <i class="glyphicon glyphicon-heart text-danger "></i>' + result);
                }
            });
        });



    /* =================================
    ====    Books Details  Page
    ===================================
    */ 
    var comment_id = $("#comment_id").val();
    $("#ShowEditComment").click(function () {
        $("#div_AddComment").toggle(100);
        $("#div_EditComment_" + comment_id).show(100);
    });
    $("#Edit").click(function () {
        $("#div_AddComment").show(100);
        $("#div_EditComment_" + comment_id).toggle(100);
    });
function ShowEditComment(comment_id) {
    $("#div_AddComment").toggle(100);
    $("#div_EditComment_" + comment_id).show(100);
}
function Addcomment() {
    var comment = $("#Addcomment").val();
    var book_Id = $("#book_id").val();
    $.ajax({
        type: "Post",
        url: "/Home/AddComment",
        data: JSON.stringify({ Comment: comment, id: book_Id }),
        contentType: "application/json",
        success: function (result) {
            $("#newCom").append("<div class=" + "comment" + ">" +
                "<div class=" + "comment-user-img" + ">" +
                "<img class=" + "img-circle" + " src=" + "/Content/images/Nophoto.png" + ">" +
                " </div>" +
                "<div class=" + "comment-content" + ">" +
                "<p id=" + "comment_" + ">" + result.comment + "</p>" +
                "</div> </div>"
            );
            $("#Addcomment").val("");
        }, error: function () {
            alert("Failed added");
        }
    })
}
function EditComment(comment_id) {
    $("#div_AddComment").show(100);
    $("#div_EditComment_" + comment_id).toggle(100);

    var comment = $("#edit_Comment_" + comment_id).val();
    $.ajax({
        type: "Post",
        url: "/Home/EditComment",
        data: JSON.stringify({ Comment: comment, id: comment_id }),
        contentType: "application/json",
        success: function (result) {
            alert("Sucsessfully Edit  ");
            $("#comment_Cont_" + comment_id).replaceWith("<p id=" + "comment_Cont_" + comment_id + ">" + comment + "</p>");
            $("#edit_Comment_" + comment_id).val("");
        }
        , error: function (result) {
            $("#comment_Cont_" + comment_id).replaceWith("<p id=" + "comment_Cont_" + comment_id + ">" + comment + "</p>");
            $("#edit_Comment_" + comment_id).val("");
        }
    })
}
function DeleteComment(comment_id) {
    $("#comment_" + comment_id).toggle(100);
    $.ajax({
        type: "Post",
        url: "/Home/DeleteComment",
        data: JSON.stringify({ id: comment_id }),
        contentType: "application/json",
        success: function (result) {
            alert("successfuly Deleted  " + result);
        }, error: function () {
            alert("failed Deleted  " + result);
        }
    })
}