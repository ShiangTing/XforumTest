(window["webpackJsonp"]=window["webpackJsonp"]||[]).push([["chunk-44693789"],{"855e":function(t,a,e){},"9dab":function(t,a,e){"use strict";var s=e("855e"),r=e.n(s);r.a},a55b:function(t,a,e){"use strict";e.r(a);var s=function(){var t=this,a=t.$createElement,e=t._self._c||a;return e("div",[e("Navbar"),e("div",{staticClass:"container px-4 py-5 p-lg-5"},[e("div",{staticClass:"row justify-content-center"},[e("div",{staticClass:"card p-lg-5 p-3 w-100",staticStyle:{"max-width":"35rem"}},[e("div",{staticClass:"card-body"},[e("h1",{staticClass:"login-title"},[t._v("登入")]),t.error.isError?e("div",{staticClass:"alert alert-danger",attrs:{role:"alert"}},[t._v(" "+t._s(t.error.message)+" ")]):t._e(),e("form",[e("div",{staticClass:"form-group"},[e("label",{attrs:{for:"account"}},[t._v("帳號")]),e("input",{directives:[{name:"model",rawName:"v-model",value:t.loginData.email,expression:"loginData.email"}],staticClass:"form-control",attrs:{type:"text",id:"account","aria-describedby":"emailHelp",placeholder:"輸入帳號"},domProps:{value:t.loginData.email},on:{input:function(a){a.target.composing||t.$set(t.loginData,"email",a.target.value)}}})]),e("div",{staticClass:"form-group"},[e("label",{attrs:{for:"password"}},[t._v("密碼")]),e("input",{directives:[{name:"model",rawName:"v-model",value:t.loginData.password,expression:"loginData.password"}],staticClass:"form-control",attrs:{type:"password",id:"password",placeholder:"輸入密碼"},domProps:{value:t.loginData.password},on:{input:function(a){a.target.composing||t.$set(t.loginData,"password",a.target.value)}}})]),t._m(0),e("input",{staticClass:"w-100 btn btn-primary",attrs:{type:"button",value:"登入"},on:{click:t.login}})]),e("p",{staticClass:"mt-3 text-center"},[e("a",{attrs:{href:"javascript:;"}},[t._v("忘記密碼")]),t._v(" | "),e("router-link",{attrs:{to:{name:"register"}}},[t._v(" 註冊")])],1)])])])])],1)},r=[function(){var t=this,a=t.$createElement,e=t._self._c||a;return e("div",{staticClass:"custom-control custom-switch text-center my-3"},[e("input",{staticClass:"custom-control-input",attrs:{type:"checkbox",id:"remember"}}),e("label",{staticClass:"custom-control-label",attrs:{for:"remember"}},[t._v("記住我")])])}],o=e("7106"),i={components:{Navbar:o["default"]},data:function(){return{loginData:{email:"",password:""},error:{isError:!1,message:""}}},methods:{login:function(){var t=this,a="/api/JwtHelper/signin";t.$axios.post(a,t.loginData).then((function(a){if(200==a.status&&a.data.issuccessful){var e={refreshToken:a.data.refreshToken,token:a.data.token,expireTime:a.data.expireTime,isAuthorize:!0};t.$store.dispatch("setAuth",e),t.$router.push("/")}else 200!=a.status||a.data.issuccessful||(t.error.isError=!0,t.error.message=a.data.errorMsg);console.log(a)})).catch((function(a){t.error.isError=!0,t.error.message=a.response.data.message}))}}},n=i,l=(e("9dab"),e("2877")),c=Object(l["a"])(n,s,r,!1,null,"12609e2a",null);a["default"]=c.exports}}]);
//# sourceMappingURL=chunk-44693789.b9f845f8.js.map