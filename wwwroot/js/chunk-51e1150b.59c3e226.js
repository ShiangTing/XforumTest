(window["webpackJsonp"]=window["webpackJsonp"]||[]).push([["chunk-51e1150b"],{"0eca":function(e,t,a){"use strict";var n=a("c4ca"),s=a.n(n);s.a},"857a":function(e,t,a){var n=a("1d80"),s=/"/g;e.exports=function(e,t,a,r){var i=String(n(e)),o="<"+t;return""!==a&&(o+=" "+a+'="'+String(r).replace(s,"&quot;")+'"'),o+">"+i+"</"+t+">"}},9911:function(e,t,a){"use strict";var n=a("23e7"),s=a("857a"),r=a("af03");n({target:"String",proto:!0,forced:r("link")},{link:function(e){return s(this,"a","href",e)}})},af03:function(e,t,a){var n=a("d039");e.exports=function(e){return n((function(){var t=""[e]('"');return t!==t.toLowerCase()||t.split('"').length>3}))}},c4ca:function(e,t,a){},c8e8:function(e,t,a){"use strict";a.r(t);var n=function(){var e=this,t=e.$createElement,a=e._self._c||t;return a("div",[a("Navbar"),a("div",{staticClass:"container"},[a("div",{staticClass:"d-flex"},[a("div",{staticClass:"d-flex flex-column mt-5"},[e._m(0),a("div",{staticClass:"mt-3"},[e.hasImg?a("img",{staticStyle:{border:"1px dashed wheat"},attrs:{id:"blah",alt:"上傳您的頭像",width:"100",height:"100",src:e.user.imgLink}}):a("img",{staticStyle:{border:"1px dashed wheat"},attrs:{id:"blah",src:e.user.imgLink,alt:"上傳您的頭像",width:"100",height:"100"}})]),a("input",{ref:"file",staticClass:"mt-3",attrs:{type:"file",name:"file"},on:{change:e.handleFileUpload}})]),a("div",{staticClass:"d-flex flex-column mt-5 ml-5"},[e._m(1),a("h3",[a("b",[e._v("$"+e._s(e.user.points))])])])]),a("b-form",[a("div",{staticClass:"row mt-5"},[a("div",{staticClass:"col"},[a("b-form-group",[a("h4",[a("b",[e._v("帳號名稱")])]),a("b-form-input",{attrs:{type:"email",required:"",readonly:""},model:{value:e.user.email,callback:function(t){e.$set(e.user,"email",t)},expression:"user.email"}})],1)],1),a("div",{staticClass:"col"},[a("h4",[a("b",[e._v("暱稱")])]),a("b-form-group",[a("div",{staticClass:"d-flex"},[a("b-form-input",{attrs:{id:"input-2",required:"",placeholder:"Enter name",disabled:e.inputCanChange},model:{value:e.user.name,callback:function(t){e.$set(e.user,"name",t)},expression:"user.name"}})],1)])],1),a("div",{staticClass:"col"},[a("h4",[a("b",[e._v("年齡")])]),a("b-form-group",[a("div",{staticClass:"d-flex"},[a("b-form-input",{attrs:{type:"number",min:"1",required:"",disabled:e.inputCanChange},model:{value:e.user.age,callback:function(t){e.$set(e.user,"age",t)},expression:"user.age"}})],1)])],1)]),a("div",{staticClass:"row mt-5"},[a("div",{staticClass:"col"},[a("h4",[a("b",[e._v("性別")])]),a("b-form-group",[a("select",{staticStyle:{width:"51%",height:"38px","border-radius":"5px","background-color":"#ddd"},attrs:{disabled:e.inputCanChange},on:{change:function(t){return e.getOptionIdx(t,t.target.selectedIndex)}}},[a("option",{attrs:{disabled:"",selected:""}},[e._v(e._s(e.user.gender))]),e._l(e.genderList,(function(t,n){return a("option",{key:n,attrs:{id:e.genderList[n]}},[e._v(" "+e._s(t)+" ")])}))],2)])],1),a("div",{staticClass:"col"},[a("h4",[a("b",[e._v("電話")])]),a("b-form-group",[a("div",{staticClass:"d-flex"},[a("b-form-input",{attrs:{type:"text",required:"",disabled:e.inputCanChange},model:{value:e.user.phone,callback:function(t){e.$set(e.user,"phone",t)},expression:"user.phone"}})],1)])],1),a("div",{staticClass:"col"},[a("h4",[a("b",[e._v("權限")])]),a("b-form-group",[a("div",{staticClass:"d-flex"},[a("b-form-input",{attrs:{type:"text",readonly:""},model:{value:e.user.roleName,callback:function(t){e.$set(e.user,"roleName",t)},expression:"user.roleName"}})],1)])],1)]),a("h4",{staticClass:"text-center my-5"},[a("b",[e._v("已經擁有的稱號")])]),a("div",{staticClass:"d-flex justify-content-center mb-5"},e._l(e.hasRank,(function(t,n){return a("div",{key:n,staticClass:"d-inline-block"},[t.titleName==e.user.ownerRank?a("div",[a("font-awesome-icon",{attrs:{icon:"crown"}}),a("span",{staticClass:"badge badge-primary m-3 p-2"},[e._v(e._s(e.user.ownerRank))])],1):e._e(),a("span",{staticClass:"badge badge-info m-3 p-2 ownerRank",domProps:{textContent:e._s(e.otherRank(t.titleName))},on:{click:function(a){return e.changeRank(t.titleName)}}})])})),0),a("div",{staticClass:"d-flex justify-content-center"},[a("b-button",{attrs:{pill:"",variant:"primary"},on:{click:e.updateMember}},[e._v("提交修改")]),e.inputCanChange?a("b-button",{staticClass:"ml-2",attrs:{pill:"",variant:"outline-secondary"},on:{click:e.inputChange}},[e._v("修改會員資料")]):a("b-button",{staticClass:"ml-2",attrs:{pill:"",variant:"info"},on:{click:e.inputChange}},[e._v("完成修改")])],1)])],1)],1)},s=[function(){var e=this,t=e.$createElement,a=e._self._c||t;return a("h4",[a("b",[e._v("會員頭像")])])},function(){var e=this,t=e.$createElement,a=e._self._c||t;return a("h4",[a("b",[e._v("X幣")])])}],r=(a("4160"),a("b0c0"),a("9911"),a("159b"),a("96cf"),a("1da1")),i=a("7106"),o=a("bc3a"),u=a.n(o),l={components:{Navbar:i["default"]},data:function(){return{file:"",inputCanChange:!0,user:{userId:"",email:"",password:"",name:"",age:"",phone:"",points:"",roleName:"",gender:"",ownerRank:"",imgLink:""},updateData:{name:"",password:"",age:"",phone:"",gender:"",titleName:"",imgLink:""},hasRank:[],show:!0,selectGender:"",genderList:["female","male"],hasImg:!1}},methods:{handleFileUpload:function(){var e=this;this.file=this.$refs.file.files[0];var t="3d78cf6e67ed6af",a=new FormData;a.append("image",this.file),u()({url:"https://api.imgur.com/3/image",method:"POST",headers:{Authorization:"Client-ID "+t},data:a}).then((function(t){var a=t.data.data.link;e.user.imgLink=a,e.hasImg=!0})).catch((function(e){console.log(e)}))},updateMember:function(){var e=this;e.updateData.name=e.user.name,e.updateData.password=e.user.password,e.updateData.age=e.user.age,e.updateData.phone=e.user.phone,e.updateData.gender=e.user.gender,e.updateData.titleName=e.user.ownerRank,e.updateData.imgLink=e.user.imgLink,this.$axios.patch("/api/Users/UpdateMember",e.updateData).then((function(){console.log("成功"),e.$router.go(0)})).catch((function(e){console.log(e)}))},getOptionIdx:function(e,t){this.user.gender=e.target.querySelectorAll("option")[t].id},inputChange:function(){return this.inputCanChange?this.inputCanChange=!1:this.inputCanChange=!0},changeRank:function(e){var t=this;t.user.ownerRank=e},otherRank:function(e){if(e!==this.user.ownerRank)return e},getSingleMember:function(){var e=this,t=this,a=t.$store.state.tokenModule,n=a.isAuthorize,s=a.token,r="/api/Users/GetSingleMember";n&&t.$axios({url:r,method:"GET",headers:{Authorization:"Bearer ".concat(s)}}).then((function(a){t.user.email=a.data.data.email,t.user.name=a.data.data.name,t.user.userId=a.data.data.userId,t.user.ownerRank=a.data.data.titleName,t.user.age=a.data.data.age,t.user.gender=a.data.data.gender,t.user.phone=a.data.data.phone,t.user.points=a.data.data.points,t.user.roleName=a.data.data.roleName,t.user.imgLink=a.data.data.imgLink,t.user.password=a.data.data.password,e.getHasRank()})).catch((function(e){console.log(e)}))},getHasRank:function(){var e=this,t="/api/Title/GetHasTitles";e.$axios({url:t+"/"+e.user.userId,method:"GET"}).then((function(t){t.data.forEach((function(t){e.hasRank.push(t)}))})).catch((function(e){return console.log(e.response)}))}},created:function(){var e=this;return Object(r["a"])(regeneratorRuntime.mark((function t(){return regeneratorRuntime.wrap((function(t){while(1)switch(t.prev=t.next){case 0:return t.next=2,e.getSingleMember();case 2:case"end":return t.stop()}}),t)})))()}},c=l,d=(a("0eca"),a("2877")),p=Object(d["a"])(c,n,s,!1,null,"69c47261",null);t["default"]=p.exports}}]);
//# sourceMappingURL=chunk-51e1150b.59c3e226.js.map