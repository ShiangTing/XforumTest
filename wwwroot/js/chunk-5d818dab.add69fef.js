(window["webpackJsonp"]=window["webpackJsonp"]||[]).push([["chunk-5d818dab"],{"3d4f":function(t,e,n){},"789b":function(t,e,n){"use strict";n.r(e);var a=function(){var t=this,e=t.$createElement,n=t._self._c||e;return n("div",[n("Navbar"),n("div",{staticClass:"container"},[n("h2",{staticClass:"pt-3 text-center"},[t._v("購買稱號")]),n("div",{staticClass:"d-flex justify-content-between title-context"},[n("div",[n("span",[t._v("會員名稱:")]),n("span",[t._v(t._s(t.user.userName))])]),n("div",[n("span",[t._v("您目前的點數:")]),n("span",[t._v("$"+t._s(t.user.points))])]),n("div",[n("span",[t._v("想要購買的稱號:")]),n("span",[t._v(t._s(t.wantedRankName))])])]),t._m(0),t._l(t.hasRank,(function(e,a){return n("div",{key:a,staticClass:"d-inline-block"},[n("span",{staticClass:"badge badge-info m-3 p-2"},[t._v(t._s(e.titleName))])])})),t._m(1),n("table",{staticClass:"table table-dark"},[t._m(2),n("tbody",t._l(t.allRank,(function(e,a){return n("tr",{key:a,staticClass:"rankData",on:{click:function(n){return t.selectRank(e.titleName,e.price)}}},[n("th",{attrs:{scope:"row"}},[t._v(t._s(a+1))]),n("td",[t._v(t._s(e.titleName))]),n("td",[t._v("$"+t._s(e.price))]),n("td",[n("button",{staticClass:"btn btn-primary",attrs:{type:"button"},on:{click:function(n){return t.buyRank(e.titleName)}}},[t._v(" 購買 ")])])])})),0)])],2)],1)},s=[function(){var t=this,e=t.$createElement,n=t._self._c||e;return n("h4",[n("b",[t._v("已經擁有的稱號")])])},function(){var t=this,e=t.$createElement,n=t._self._c||e;return n("h4",[n("b",[t._v("可以購買的稱號")])])},function(){var t=this,e=t.$createElement,n=t._self._c||e;return n("thead",[n("tr",[n("th",{attrs:{scope:"col"}},[t._v("#")]),n("th",{attrs:{scope:"col"}},[t._v("稱號名稱")]),n("th",{attrs:{scope:"col"}},[t._v("稱號點數")]),n("th",{attrs:{scope:"col"}})])])}],r=(n("4160"),n("a434"),n("159b"),n("96cf"),n("1da1")),o=n("7106"),i=n("bc3a"),c=n.n(i),l={components:{Navbar:o["default"]},data:function(){return{user:{userId:"",userName:"",points:""},allRank:[],hasRank:[],wantedRankName:"",wantedRankPrice:"",inputCheck:[],buyRankData:{UserId:"",TitleId:""}}},methods:{buyRank:function(t){var e=this;""==this.wantedRankName?e.$swal("請先選擇想要買的稱號哦!"):this.$swal({title:"".concat(t),text:"你確定要購買嗎",type:"question",showCancelButton:!0,confirmButtonText:"確定",cancelButtonText:"取消"}).then((function(t){if(t.value){var n="/api/Title/BuyTitle";e.buyRankData.UserId=e.user.userId,e.buyRankData.TitleId=e.wantedRankName,c()({url:"".concat(n),method:"POST",data:e.buyRankData}).then((function(){console.log("成功購買"),e.$router.go(0)})).catch((function(t){return console.log(t.response)}))}else console.log("購買失敗")}))},selectRank:function(t,e){console.log(t),this.wantedRankName=t,this.wantedRankPrice=e},getPoints:function(){var t=this,e="/api/Title/GetPoints";c.a.get(e+"/"+t.user.userId).then((function(e){t.user.points=e.data})).catch((function(t){return console.log(t.response)}))},getHasRank:function(){var t=this,e="/api/Title/GetHasTitles";c()({url:e+"/"+t.user.userId,method:"GET"}).then((function(e){e.data.forEach((function(e){t.hasRank.push(e)}))})).catch((function(t){return console.log(t.response)}))},getAllRank:function(){var t=this,e="/api/Title/GetAllTitles";c.a.get(e).then((function(e){e.data.forEach((function(e){t.allRank.push(e)}))})).catch((function(t){return console.log(t.response)}))},getAllAxios:function(){var t=this,e=t.$store.state.tokenModule,n=e.isAuthorize,a=e.token;t.isLogin=!0;var s="/api/Users/GetUserId",r="/api/Users/GetUserName";n&&c.a.all([c()({url:s,method:"GET",headers:{Authorization:"Bearer ".concat(a)}}),c()({url:r,method:"GET",headers:{Authorization:"Bearer ".concat(a)}})]).then(c.a.spread((function(e,n){t.user.userId=e.data,t.user.userName=n.data,t.getPoints(),t.getHasRank()}))).catch((function(t){return console.log(t.response)}))}},computed:{selectCheck:function(){return this.inputCheck.length>0}},updated:function(){var t=this;t.hasRank.forEach((function(e){t.allRank.forEach((function(t,n,a){e.titleName==t.titleName&&(a.splice(n,1),console.log(a))}))}))},created:function(){var t=this;return Object(r["a"])(regeneratorRuntime.mark((function e(){return regeneratorRuntime.wrap((function(e){while(1)switch(e.prev=e.next){case 0:return e.next=2,t.getAllAxios();case 2:return e.next=4,t.getAllRank();case 4:case"end":return e.stop()}}),e)})))()}},u=l,h=(n("f093"),n("2877")),d=Object(h["a"])(u,a,s,!1,null,"81074b8e",null);e["default"]=d.exports},a434:function(t,e,n){"use strict";var a=n("23e7"),s=n("23cb"),r=n("a691"),o=n("50c4"),i=n("7b0b"),c=n("65f0"),l=n("8418"),u=n("1dde"),h=n("ae40"),d=u("splice"),f=h("splice",{ACCESSORS:!0,0:0,1:2}),p=Math.max,v=Math.min,k=9007199254740991,m="Maximum allowed length exceeded";a({target:"Array",proto:!0,forced:!d||!f},{splice:function(t,e){var n,a,u,h,d,f,_=i(this),b=o(_.length),g=s(t,b),R=arguments.length;if(0===R?n=a=0:1===R?(n=0,a=b-g):(n=R-2,a=v(p(r(e),0),b-g)),b+n-a>k)throw TypeError(m);for(u=c(_,a),h=0;h<a;h++)d=g+h,d in _&&l(u,h,_[d]);if(u.length=a,n<a){for(h=g;h<b-a;h++)d=h+a,f=h+n,d in _?_[f]=_[d]:delete _[f];for(h=b;h>b-a+n;h--)delete _[h-1]}else if(n>a)for(h=b-a;h>g;h--)d=h+a-1,f=h+n-1,d in _?_[f]=_[d]:delete _[f];for(h=0;h<n;h++)_[h+g]=arguments[h+2];return _.length=b-a+n,u}})},f093:function(t,e,n){"use strict";var a=n("3d4f"),s=n.n(a);s.a}}]);
//# sourceMappingURL=chunk-5d818dab.add69fef.js.map