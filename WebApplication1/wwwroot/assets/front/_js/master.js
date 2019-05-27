$(document).ready(function() {
	//Global Variables
	$froot=$('#froot').val();
	$curpage=$('#curpage').val();
	//$('a').attr('href','#');

    ////////////////////////////////////////////////////////////////////////////
    //disable # anchors
    $('body').on('click',"a[href='#']",function(e){e.preventDefault();});
    $("a[href='#']").click(function(e){e.preventDefault();});
    
    
    ////////////////////////////////////////////////////////////////////////////
    //back to prev page
    $('[data-backurl]').click(function(e){
        e.preventDefault();
        parent.history.back();
        return false;
    });
    
    
    ////////////////////////////////////////////////////////////////////////////
	/*remain chars*/
	$("[data-remain-chars]").each(function() {
        var no = $(this).attr("data-remain-chars");
        $(this).remaining_char(no);
    });


    ////////////////////////////////////////////////////////////////////////////
    //text direction
    $('input[type=text]').keypress(function(){
        $this = $(this);
        if($this.val().length == 1){
            var x =  new RegExp("[\x00-\x80]+"); // is ascii
            var isAscii = x.test($this.val());

            if(isAscii){$this.css("direction", "ltr");}
            else{$this.css("direction", "rtl");}
        }
    });
    
    
	//////////////////////////////////////////////////////////////////////////////	
	//go_to_top
	$('.gotop').click(function(){
		$('html,body').animate({scrollTop:0},1000);
	});
    
    
    ////////////////////////////////////////////////////////////////////////////
    //number_format inputs
    $("input.number_format").keyup(function(){
        var num = this.value.replace(/[^\d]/g, '');
        if(num.length>3)
            num = num.replace(/\B(?=(?:\d{3})+(?!\d))/g, ',');
        this.value = num;
    });		


    //////////////////////////////////////////////////////////////////////
    // refresh captcha
    // $('[data-refresh-captcha]').click(function(){
    //     var $this = $(this);
    //     var src_captcha = "_includes/captcha.php?"+Date.now();
    //     $this.closest('.captcha_wrapper').find('img.captcha_pic').attr('src',src_captcha);
    // });


    ///////////////////////////////////////////////////////////////////
	//cropper
	$('[data-run-cropper]').change(function(){
		var x = $(this).attr('data-x');
		var y = $(this).attr('data-y');	
        var element = $(this).attr('data-element');	

        $(element).find('.cropper_preview').css('background-image','none');
        $(element).find('.rmv_file').show();
        $(element).find('.rmv_file').attr('data-filename','1');
        
		setTimeout(function(){run_cropper(element,x,y);},500);
	});
    
    ////////////////////////////////////////////////////////////////////////////
    //ellipsis
    ellipsis();
    
    
    ////////////////////////////////////////////////////////////////////////////1
    //textarea autosize
	if($('.autosize').length != 0){
        autosize($('.autosize'));
	}
    
    
    ////////////////////////////////////////////////////////////////////////////1
    //lazy img
	if($('[data-lazy-img]').length != 0){
    	$('[data-lazy-img]').lazy();
	}


    ////////////////////////////////////////////////////////////////////////////
    // get image info
    $('[data-image-info]').change(function(){
        var $this = $(this);
        var $form = $this.closest('form');
        var files = !!this.files ? this.files : [];
        var image = new Image();
        var reader = new FileReader();
        reader.readAsDataURL(files[0]);
        
        reader.onloadend = function() {
          image.src = this.result;
          image.onload = function() {
            $this.attr('data-width',image.width);
            $this.attr('data-height',image.height);
            $form.valid();
          };
        };
    });


    ////////////////////////////////////////////////////////////////////////////
    //tooltip
    $('.tooltip').parent().hover(function(){
        $(this).find('.tooltip').stop(true,true).fadeIn(200);
    },function(){
        $(this).find('.tooltip').stop(true,true).fadeOut(200);
    });
    
    
    ////////////////////////////////////////////////////////////////////////////
    //Select With Select Style
    $('select[data-select-style]').each(function(){
        var label = $(this).find('option:selected').text();
        $(this).siblings('.select_label').text(label);
    });

    $('select[data-select-style]').change(function(){
        var label = $(this).find('option:selected').text();
        $(this).siblings('.select_label').text(label);
    });//change


    ////////////////////////////////////////////////////////////////////////////
    //Change State
    // $("select[name=state_id]").change(function(){
    //     var $this = $(this);
    //     var state_id = $(this).val();
    //     $this.closest("form").find("select[name=city_id]").closest(".select_style").addClass("loading_ajax");
    //
    //     $.post("_includes/ajax-process.php",{
    //         state_id:state_id,
    //         go_change_state:""
    //     },function(response){
    //         $this.closest("form").find("select[name=city_id]").html(response);
    //         $this.closest("form").find("select[name=city_id]").closest(".select_style").find(".select_label").text("--انتخاب شهر--");
    //         $this.closest("form").find("select[name=area_id]").html("<option value=''>--انتخاب منطقه--</option>");
    //         $this.closest("form").find("select[name=area_id]").closest(".select_style").find(".select_label").text("--انتخاب منطقه--");
    //         $this.closest("form").find("select[name=region_id]").html("<option value=''>--انتخاب محدوده--</option>");
    //         $this.closest("form").find("select[name=region_id]").closest(".select_style").find(".select_label").text("--انتخاب محدوده--");
    //         $this.closest("form").find("select[name=city_id]").closest(".select_style").removeClass("loading_ajax");
    //     });
    // });//Change State & City

    //Change City
    // $("select[name=city_id]").change(function(){
    //     var $this = $(this);
    //     var city_id = $(this).val();
    //     $this.closest("form").find("select[name=area_id]").closest(".select_style").addClass("loading_ajax");
    //
    //     $.post("_includes/ajax-process.php",{
    //         city_id:city_id,
    //         go_change_city:""
    //     },function(response){
    //         var data = $.parseJSON(response);
    //         $this.closest("form").find("select[name=area_id]").html(data.area);
    //         $this.closest("form").find("select[name=area_id]").closest(".select_style").find(".select_label").text("--انتخاب منطقه--");
    //         $this.closest("form").find("select[name=region_id]").html("<option value=''>--انتخاب محدوده--</option>");
    //         $this.closest("form").find("select[name=region_id]").closest(".select_style").find(".select_label").text("--انتخاب محدوده--");
    //         $this.closest("form").find("select[name=area_id]").closest(".select_style").removeClass("loading_ajax");
    //     });
    // });//Change State & City

    //Change Area
    // $("select[name=area_id]").change(function(){
    //     var $this = $(this);
    //     var area_id = $(this).val();
    //     $this.closest("form").find("select[name=region_id]").closest(".select_style").addClass("loading_ajax");
    //
    //     $.post("_includes/ajax-process.php",{
    //         area_id:area_id,
    //         go_change_area:""
    //     },function(response){
    //         var data = $.parseJSON(response);
    //         $this.closest("form").find("select[name=region_id]").html(data.region);
    //         $this.closest("form").find("select[name=region_id]").closest(".select_style").find(".select_label").text("--انتخاب محدوده--");
    //         $this.closest("form").find("select[name=region_id]").closest(".select_style").removeClass("loading_ajax");
    //     });
    // });//Change State & City



    ////////////////////////////////////////////////////////////////////////////    
    //Scrolls Y
    $(".have_scroll_y").mCustomScrollbar({
		snapAmount:40,
		scrollButtons:{enable:true},
		keyboard:{scrollAmount:40},
		mouseWheel:{deltaFactor:40},
		scrollInertia:400,
		theme:"dark-thin"
		/*autoHideScrollbar:true*/
    });
        
	//Scrolls X
	$(".have_scroll_x").mCustomScrollbar({
		axis:"x",
		theme:"dark-thin",
		advanced:{autoExpandHorizontalScroll:true},
		//scrollbarPosition:"outside",
		snapAmount:40,
		scrollButtons:{enable:true},
		keyboard:{scrollAmount:40},
		mouseWheel:{deltaFactor:40},
		scrollInertia:400,
		autoHideScrollbar:true
	});

	//////////////////////////////////////////////////////////////////////////////	
	//NewsLetter   
	$('[data-go-newsletter]').click(function(e){
		e.preventDefault();
        var $form = $(this).closest("form");	
		var $this = $(this);
		var email = $form.find('input[name=email]').val();
		
		if(email.trim() != ''){
			if($form.valid()){
				show_modal();
				$.post("_includes/ajax-process.php",{
					go_newsletter:'',
					email:email,
				},function(response){
					hide_modal();
					var data = $.parseJSON(response);
					if(data.error == ""){
						show_notif("","شما با موفقیت به خبرنامه سایت پیوستید.",'s',5000);
						$form.find('input[name=email]').val("");
					}else{
						show_notif("خطا",data.error,'e',5000);
					}
				});
			}//email ok
			else{
				show_notif("خطا","ایمیل وارد شده معتبر نمی باشد",'e',5000);
			}
		}//required ok
		else{
			show_notif("خطا","ابتدا ایمیل خود را وارد نمایید...",'e',5000);
		}
	});//NewsLetter	
	//////////////////////////////////////////////////////////////////////////////	
	//go to top 
	$(window).scroll(function(){
		var body_sc=$(this).scrollTop();
		if( body_sc > 500){
			$('.goto_top').stop(true,false).addClass('active');
		}
		else{
			$('.goto_top').stop(true,false).removeClass('active');
		}
	});
	////////////////////////////////////////////////////////////////////////////
	//tooltip_style1
	$('.have_tooltip').hover(function(){
		$(this).find('.tooltip_style1').stop(true,false).fadeIn(200);
	},function(){
		$(this).find('.tooltip_style1').stop(true,false).fadeOut(200);
	});
	/////////////////////////////////////////////////////////////////////////////////////
	// open .sub_menu
	$('.have_menu').hover(function(){
		$(this).find('.sub_style1').fadeIn(0,function(){
			$(this).addClass('active');
		});
	},function(){
		$(this).find('.sub_style1').slideUp(200,function(){
			$(this).removeClass('active');
		});
	});
	//////////////////////////////////////////////////////////
	//search part
	$('.page_title .search_part .search_btn').click(function(){
		var search_part = $('.page_title .search_part');
		if($(search_part).hasClass('active')){
			$(search_part).removeClass('active');
		}
		else{
			$(search_part).addClass('active');
		}
	});
	$("body").click(function(e){
		if(!$(e.target).is(".page_title .search_part") && !$(e.target).is(".page_title .search_part *")){
			$('.page_title .search_part').removeClass('active');
		}
	});
	///////////////////////////////////////////////////////////
	// responsive menu
	$('.responsive_menu_btn').click(function(){
		$('.header_style1 .responsive_menu').fadeIn(300).addClass('active');
		$('body').css('overflow','hidden');
	});
	$('.header_style1 .responsive_menu .close_btn , .header_style1 .responsive_menu .close_bg').click(function(){
		$('.header_style1 .responsive_menu').fadeOut(300).removeClass('active');
		$('body').css('overflow','auto');
	});
	//responsive sub menu
	$('.responsive_menu .bottom_part .have_menu').click(function(){
		$(this).find('.sub_style2').slideToggle(200);
	});

	////////////////////////////////////////////////////////////
    // alarm_part2
    $('.alarm_style2 .close_icon').click(function(){
        $('.alarm_style2').fadeOut(300);
    });
    $('body').click(function(e){
        if(!$(e.target).is('.alarm_style2') && !$(e.target).is('.alarm_style2 *')){
            $('.alarm_style2').fadeOut(300);
        }
    });// body click
	
    

});//document ready
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	