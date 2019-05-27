$(document).ready(function(e) {

/////////////////////////////////////////////////////////////////////////
// regex
$.validator.addMethod("regex", function(value, element, regexpr) {          
    return regexpr.test(value);
}, "Provide a valid regex");


/////////////////////////////////////////////////////////////////////////
// image min_width
$.validator.addMethod("min_width", function(value, element, min_width) {
    
    var width = $(element).attr('data-width');
    if(width == 0){
        return true;
    }
    else if(width >= min_width){
        return true;
    }
    else if(width < min_width){
        return false;
    }
}, "error");


/////////////////////////////////////////////////////////////////////////
// image min_height
$.validator.addMethod("min_height", function(value, element, min_height) {
    
    var height = $(element).attr('data-height');
    if(height == 0){
        return true;
    }
    else if(height >= min_height){
        return true;
    }
    else if(height < min_height){
        return false;
    }
}, "error");


/////////////////////////////////////////////////////////////////////////
// image max_size
$.validator.addMethod("max_size", function(value, element, max_size) {
    var size = Math.round(element.files[0].size / 1024);
    return (size <= max_size)?true:false;
}, "error");



//////////////////////////////////////////////////////////////
//frm_edit_product
$("#frm_edit_product").validate({
	errorClass: "error",
	ignore:'',
	rules: {
		cat1_id: {
			required:true,
		},
		name: {
			required:true,
		},
		file:{	
			extension: "rar|zip",
            require_from_group: [1, ".valid_group1"]
		},
		file_old:{	
            require_from_group: [1, ".valid_group1"]
		},
		image:{
			extension: "gif|png|jpg|jpeg"
		},
		price: {
			required:true,	
			regex:/^[0-9,]+$/
		}
	},
	
	messages: {
		cat1_id: {
			required:"",
		},
		name: {
			required:"",
		},
		file:{
			require_from_group:"فایل خود را انتخاب نمایید",
			extension: "فرمت های مجاز zip | rar می باشد"
		},
		file_old:{	
            require_from_group: "فایل خود را انتخاب نمایید",
		},
		image:{
			extension: "فرمت های مجاز gif | png | jpg | jpeg می باشد"
		},
		price: {
			required:"",	
			regex:"کاراکترهای وارد شده مجاز نمی باشد"
		}	
	},
    groups: {
        names: "file file_old"
    }	
});//frm_edit_product

/////////////////////////////////////////////////////////////////////////////
//frm_newsletter
$("#frm_newsletter").validate({
	errorClass: "error",
	rules: {
		email: {
			required:true,
			email:true,
		},
	},
	
	messages: {
		email: {
			required:"",
			email:"",
		},	
	}	
});//frm_newsletter



//////////////////////////////////////////////////////////////
// frm_login
$("#frm_login").validate({
	errorClass: "error",

	rules: {
		email:{
			required:true,
			email: true			
		},
		password: {
			required: true
		},
		captcha:{
			required:true
		}
	},//rules	
	messages: {
		email:{
			required:"آدرس ایمیل خود را وارد کنید",
			email: "آدرس ایمیل معتبر نیست."
		},
        password: {
			required: "کلمه عبور خود را وارد کنید."
		},
		captcha:{
			required:"کد امنیتی را وارد کنید"
		}	
	}//messages	
});//frm_login



//////////////////////////////////////////////////////////////
// frm_register
$("#frm_register").validate({
	errorClass: "error",

	rules: {
		name:{
			required:true,
		},
		email:{
			required:true,
			email: true			
		},
		tel: {
			required: true ,
			regex:/^[0-9]+$/
		},
        password: {
			required: true
		},
        password_confirmation: {
			required: true
		},
		captcha:{
			required:true
		}
	},//rules	
	messages: {
		name:{
			required:"نام و نام خانوادگی خود را وارد کنید",
		},
		email:{
			required:"آدرس ایمیل خود را وارد کنید",
			email: "آدرس ایمیل معتبر نیست."			
		},
		tel: {
			required: "شماره تماس خود را وارد کنید",
			regex:"شماره تماس معتبر نیست."
		},
        password: {
			required: "کلمه عبور خود را وارد کنید",
		},
        password_confirmation: {
			required: "تکرار کلمه عبور خود را وارد کنید",
			equalTo: "کلمه عبور وارد شده و تکرار آن مغایرت دارند"
		},
		captcha:{
			required:"کد امنیتی را وارد کنید"
		}
	}//messages	
});// frm_register1


///////////////////////////////////////////////////////
$('#frm_change_pass').validate({
	errorClass: "error",	
	rules: {
		current_password:{
			required:true,
			
		},
		password:{
			required:true,
			
		},
        password_confirmation:{
			required:true,
			equalTo: "#pass",
		}

	},//rules	
	messages: {
        current_password:{
			required:"کلمه عبور فعلی خود را وارد نمائید.",
			
		},
        password:{
			required:"کلمه عبور جدید خود را وارد نمائید.",
			
		},
        password_confirmation:{
			required:"تکرار کلمه عبور خود را وراد نمائید",
			equalTo: "کلمه عبور وارد شده و تکرار آن مغایرت دارند",
		},
		
	}//messages
});



//////////////////////////////////////////////////////////////
// frm_forgotpass
$("#frm_forgotpass").validate({
	errorClass: "error",

	rules: {
		email:{
			required:true,
			email: true			
		},
	},//rules	
	messages: {
		email:{
			required:"",
			email: ""		
		},
	}//messages	
});//frm_forgotpass



//////////////////////////////////////////////////////////////
// frm_resetpass
$("#frm_resetpass").validate({
	errorClass: "error",

	rules: {
        password: {
			required: true
		},
        password_confirmation: {
			required: true,
			equalTo: "#pass"
		}	
	},//rules	
	messages: {
        password: {
			required: "",
		},
        password_confirmation: {
			required: "",
			equalTo: ""
		}		
	}//messages	
});// frm_resetpass

//////////////////////////////////////////////////////////////
$("#frm_register").validate({
	ignore:"",
	errorContainer: $("div.error_container"),
	errorLabelContainer: $("div.error_container ul"),
	wrapper: 'li',

	errorClass: "error",
	rules: {
		firstname:{
			required:true,
			regex:/^[a-zA-Z\s]+$/
		},
		lastname:{ 
			required:true,
			regex:/^[a-zA-Z\s]+$/		
		},
		email:{
			required:true,
			email: true			
		},
		mobile:{
			required:true,
			regex:/^[0-9]+$/
		},
		phone:{
			required:true,
			regex:/^[0-9]+$/
		},
		captcha:{
			required:true
		},
		password: {
			required: true
		},
        password_confirmation: {
			required: true,
			equalTo: "#password"
		}	
	},//rules	
	messages: {
		firstname:{
			required:"نام خود را وارد نمائید",
			regex:"نام معتبر نیست - تنها از حروف لاتین استفاده کنید"
		},
		lastname:{ 
			required:"نام  خانوادگی خود را وارد نمائید",
			regex:"نام خانوادگی معتبر نیست - تنها از حروف لاتین استفاده کنید"	
		},
		email:{
			required:"پست الکترونیک خود را وارد نمائید",
			email: "ایمیل وارد شده معتبر نیست"			
		},
		mobile:{
			required:"تلفن همراه خود را وارد کنید",
			regex:"تلفن وارد شده معتبر نیست"
		},
		phone:{
			required:"تلفن ثابت خود را وارد کنید",
			regex:"تلفن وارد شده معتبر نیست"
		},
		captcha:{
			required:"کد امنیتی را وارد کنید"
		},
		password: {
			required: "کلمه عبور خود را وارد نمائید",
		},
        password_confirmation: {
			required: "تکرار کلمه عبور خود را وارد نمائید",
			equalTo: "کلمه عبور و تکرار آن مغایرت دارند"
		}		
	}//messages	
});
/////////////////////////////////////////////////////////////////////////////
//page register-domain   
$("#frm_check_domains").validate({
	ignore:"",
	errorClass: "error",
	rules: {
		domain: {
			required:true,
			regex:/^[a-zA-Z0-9\-]+$/
		},
		"domain_exts[]":"required"
	},
	
	messages: {
		domain:  {
			required: "نام دامنه خود را وارد نمائید",
			regex: "دامنه معتبر نیست"
		},
		"domain_exts[]":{
			required:""
		}	
	}	
});
//////////////////////////////
///////////////////////////////////////////////////////
$('#share_frm').validate({
	errorClass: "error",	
	rules: {
		email:{
			required:true,	
			email: true	
		},
		captcha:{
			required:true,
		}
	},//rules	
	messages: {
		email:{
			required:"",
			email: ""	
		},
		captcha:{
			required:"",
		}
		
	}//messages
});// #share_frm
//////////////////////////////
///////////////////////////////////////////////////////
$('#comment_frm').validate({
	errorClass: "error",	
	rules: {
		comment:{
			required:true,	
		}
	},//rules	
	messages: {
        comment:{
			required:"لطفاً نظر خود را وارد کنید",
		}
	}//messages
});// #comment_frm
///////////////////////////////////////////////////////
//contact frm
$('#contact_frm').validate({
	errorClass: "error",	
	rules: {
		name:{
			required:true,	
		},
		email:{
			required:true,	
			email:true
		},
        message:{
			required:true,	
		}
	},//rules	
	messages: {
		name:{
			required:"نام و نام خانوادگی خود را وارد کنید." ,
		},
		email:{
			required:"ایمیل خود را وارد کنید." ,
			email:"ایمیل معتبر نیست."
		},
        message:{
			required:"متن مورد نظر خود را وارد کنید." ,
		}
	}//messages
});// #comment_frm
///////////////////////////////////////////////////////
//#new addres
$('#new_addres').validate({
	errorClass: "error",	
	rules: {
		name:{
			required:true,	
		},
		email:{
			required:true,	
			email:true
		},
		phone:{
			required:true,	
			regex:/^[0-9]+$/
		},
		tel:{
			required:true,
			regex:/^[0-9]+$/	
		},
		city:{
			required:true,
		},
		local:{
			required:true,	
		},
		addres:{
			required:true,	
		}
	},//rules	
	messages: {
		name:{
			required:"نام و نام خانوادگی خود را وارد کنید." ,
		},
		email:{
			required:"ایمیل خود را وارد کنید." ,
			email:"ایمیل معتبر نیست."
		},
		phone:{
			required:"شماره موبایل خود را وارد کنید." ,
			regex:"شماره موبایل معتبر نیست."
		},
		tel:{
			required:"تلفن ثابت خود را وارد کنید." ,
			regex:"شماره تلفن ثابت معتبر نیست."
		},
		city:{
			required:"شهر خود را انتخاب کنید." ,
		},
		local:{
			required:"استان خود را انتخاب کنید." ,
		},
		addres:{
			required:"آدرس جدید را وارد کنید." ,
		}
	}//messages
});// #new_addres
///////////////////////////////////////////////////////
//#new addres
$('#new_massage').validate({
	errorClass: "error",	
	rules: {
		subject:{
			required:true,	
		},
		content:{
			required:true,	
		}
	},//rules	
	messages: {
		subject:{
			required:"موضوع خود را وارد کنید." ,
		},
		content:{
			required:"متن پیام خود را وارد کنید." ,
		}
	}//messages
});// #new_massage
//////////////////////////////
});//DOM READY