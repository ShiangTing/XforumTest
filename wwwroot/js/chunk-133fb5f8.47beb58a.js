(window["webpackJsonp"]=window["webpackJsonp"]||[]).push([["chunk-133fb5f8","chunk-2d22a126"],{"1da1":function(t,e,r){"use strict";r.d(e,"a",(function(){return o}));r("d3b7");function n(t,e,r,n,o,a,i){try{var c=t[a](i),s=c.value}catch(u){return void r(u)}c.done?e(s):Promise.resolve(s).then(n,o)}function o(t){return function(){var e=this,r=arguments;return new Promise((function(o,a){var i=t.apply(e,r);function c(t){n(i,o,a,c,s,"next",t)}function s(t){n(i,o,a,c,s,"throw",t)}c(void 0)}))}}},7106:function(t,e,r){"use strict";r.r(e);var n=function(){var t=this,e=t.$createElement,r=t._self._c||e;return r("div",{staticClass:"main-nav"},[r("b-navbar",{staticClass:"d-flex align-items-center",attrs:{toggleable:"lg",type:"dark",variant:"dark"}},[r("router-link",{staticClass:"title mx-5 my-2 text-white",attrs:{to:"/"}},[t._v("Xforum")]),r("b-navbar-toggle",{attrs:{target:"nav-collapse"}}),r("b-collapse",{attrs:{id:"nav-collapse","is-nav":""}},[r("b-navbar-nav",{staticClass:"ml-auto"},[r("b-nav-item",{staticClass:"sidebarGroup"},[r("SideBar")],1),t.isLogin&&"管理者"==t.rolename?r("b-nav-item",{staticClass:"pl-4",attrs:{to:"/VerifyThread"}},[r("font-awesome-icon",{attrs:{icon:"clipboard-check"}})],1):t._e(),t.isLogin?r("b-nav-item",{staticClass:"pl-4",attrs:{to:"/Rank"}},[r("font-awesome-icon",{attrs:{icon:"crown"}})],1):t._e(),t.isLogin&&"版主"==t.rolename||"管理者"==t.rolename?r("b-nav-item",{staticClass:"pl-4",attrs:{to:"/CreateThread"}},[r("font-awesome-icon",{attrs:{icon:"bookmark"}})],1):t._e(),t.isLogin?r("b-nav-item",{staticClass:"pl-4",attrs:{to:"/Post"}},[r("font-awesome-icon",{attrs:{icon:"pen"}})],1):r("b-nav-item",{staticClass:"pl-4",attrs:{to:"/Login"}},[r("font-awesome-icon",{attrs:{icon:"pen"}})],1),t.isLogin?r("b-nav-item",{staticClass:"pl-4",attrs:{to:"/LoveWheal"}},[r("font-awesome-icon",{attrs:{icon:"heart"}})],1):t._e(),r("b-nav-item-dropdown",{staticClass:"pl-4",attrs:{"no-caret":"",right:""},scopedSlots:t._u([{key:"button-content",fn:function(){return[r("font-awesome-icon",{attrs:{icon:"user",size:"lg"}}),r("span",{staticClass:"px-2"},[t._v(t._s(t.name))])]},proxy:!0}])},[t.isLogin?t._e():r("b-dropdown-item",{attrs:{to:"/register"}},[t._v("註冊")]),t.isLogin?t._e():r("b-dropdown-item",{attrs:{to:"/login"}},[t._v("登入")]),t.isLogin?r("b-dropdown-item",{attrs:{href:"javascript:;"},on:{click:function(e){return e.preventDefault(),t.memberCTR(e)}}},[t._v("會員中心")]):t._e(),t.isLogin?r("b-dropdown-item",{on:{click:function(e){return e.preventDefault(),t.logout(e)}}},[t._v("登出")]):t._e()],1)],1)],1)],1)],1)},o=[],a=(r("b0c0"),r("dfc1")),i={components:{SideBar:a["default"]},data:function(){return{name:"訪客",isLogin:!1,rolename:""}},methods:{memberCTR:function(){var t=this;t.$router.push("/MemberCenter")},logout:function(){var t=this;window.localStorage.clear(),t.$store.dispatch("clearAuth"),t.isLogin=!1,t.name="訪客",t.rolename="",t.$router.push("/")}},created:function(){var t=this,e=t.$store.state.tokenModule,r=e.isAuthorize,n="/api/Users/GetSingleMember";r&&(t.isLogin=!0,t.$axios({url:n,method:"GET"}).then((function(e){console.log(e.data),t.name=e.data.data.name,t.rolename=e.data.data.roleName})).catch((function(){window.localStorage.clear(),t.$store.dispatch("clearAuth"),t.isLogin=!1,t.name="訪客"})))}},c=i,s=(r("bd4c"),r("2877")),u=Object(s["a"])(c,n,o,!1,null,"ea12d0a2",null);e["default"]=u.exports},"96cf":function(t,e,r){var n=function(t){"use strict";var e,r=Object.prototype,n=r.hasOwnProperty,o="function"===typeof Symbol?Symbol:{},a=o.iterator||"@@iterator",i=o.asyncIterator||"@@asyncIterator",c=o.toStringTag||"@@toStringTag";function s(t,e,r){return Object.defineProperty(t,e,{value:r,enumerable:!0,configurable:!0,writable:!0}),t[e]}try{s({},"")}catch(N){s=function(t,e,r){return t[e]=r}}function u(t,e,r,n){var o=e&&e.prototype instanceof m?e:m,a=Object.create(o.prototype),i=new S(n||[]);return a._invoke=E(t,r,i),a}function l(t,e,r){try{return{type:"normal",arg:t.call(e,r)}}catch(N){return{type:"throw",arg:N}}}t.wrap=u;var f="suspendedStart",h="suspendedYield",p="executing",d="completed",v={};function m(){}function g(){}function y(){}var w={};w[a]=function(){return this};var b=Object.getPrototypeOf,L=b&&b(b(T([])));L&&L!==r&&n.call(L,a)&&(w=L);var x=y.prototype=m.prototype=Object.create(w);function _(t){["next","throw","return"].forEach((function(e){s(t,e,(function(t){return this._invoke(e,t)}))}))}function k(t,e){function r(o,a,i,c){var s=l(t[o],t,a);if("throw"!==s.type){var u=s.arg,f=u.value;return f&&"object"===typeof f&&n.call(f,"__await")?e.resolve(f.__await).then((function(t){r("next",t,i,c)}),(function(t){r("throw",t,i,c)})):e.resolve(f).then((function(t){u.value=t,i(u)}),(function(t){return r("throw",t,i,c)}))}c(s.arg)}var o;function a(t,n){function a(){return new e((function(e,o){r(t,n,e,o)}))}return o=o?o.then(a,a):a()}this._invoke=a}function E(t,e,r){var n=f;return function(o,a){if(n===p)throw new Error("Generator is already running");if(n===d){if("throw"===o)throw a;return G()}r.method=o,r.arg=a;while(1){var i=r.delegate;if(i){var c=C(i,r);if(c){if(c===v)continue;return c}}if("next"===r.method)r.sent=r._sent=r.arg;else if("throw"===r.method){if(n===f)throw n=d,r.arg;r.dispatchException(r.arg)}else"return"===r.method&&r.abrupt("return",r.arg);n=p;var s=l(t,e,r);if("normal"===s.type){if(n=r.done?d:h,s.arg===v)continue;return{value:s.arg,done:r.done}}"throw"===s.type&&(n=d,r.method="throw",r.arg=s.arg)}}}function C(t,r){var n=t.iterator[r.method];if(n===e){if(r.delegate=null,"throw"===r.method){if(t.iterator["return"]&&(r.method="return",r.arg=e,C(t,r),"throw"===r.method))return v;r.method="throw",r.arg=new TypeError("The iterator does not provide a 'throw' method")}return v}var o=l(n,t.iterator,r.arg);if("throw"===o.type)return r.method="throw",r.arg=o.arg,r.delegate=null,v;var a=o.arg;return a?a.done?(r[t.resultName]=a.value,r.next=t.nextLoc,"return"!==r.method&&(r.method="next",r.arg=e),r.delegate=null,v):a:(r.method="throw",r.arg=new TypeError("iterator result is not an object"),r.delegate=null,v)}function j(t){var e={tryLoc:t[0]};1 in t&&(e.catchLoc=t[1]),2 in t&&(e.finallyLoc=t[2],e.afterLoc=t[3]),this.tryEntries.push(e)}function O(t){var e=t.completion||{};e.type="normal",delete e.arg,t.completion=e}function S(t){this.tryEntries=[{tryLoc:"root"}],t.forEach(j,this),this.reset(!0)}function T(t){if(t){var r=t[a];if(r)return r.call(t);if("function"===typeof t.next)return t;if(!isNaN(t.length)){var o=-1,i=function r(){while(++o<t.length)if(n.call(t,o))return r.value=t[o],r.done=!1,r;return r.value=e,r.done=!0,r};return i.next=i}}return{next:G}}function G(){return{value:e,done:!0}}return g.prototype=x.constructor=y,y.constructor=g,g.displayName=s(y,c,"GeneratorFunction"),t.isGeneratorFunction=function(t){var e="function"===typeof t&&t.constructor;return!!e&&(e===g||"GeneratorFunction"===(e.displayName||e.name))},t.mark=function(t){return Object.setPrototypeOf?Object.setPrototypeOf(t,y):(t.__proto__=y,s(t,c,"GeneratorFunction")),t.prototype=Object.create(x),t},t.awrap=function(t){return{__await:t}},_(k.prototype),k.prototype[i]=function(){return this},t.AsyncIterator=k,t.async=function(e,r,n,o,a){void 0===a&&(a=Promise);var i=new k(u(e,r,n,o),a);return t.isGeneratorFunction(r)?i:i.next().then((function(t){return t.done?t.value:i.next()}))},_(x),s(x,c,"Generator"),x[a]=function(){return this},x.toString=function(){return"[object Generator]"},t.keys=function(t){var e=[];for(var r in t)e.push(r);return e.reverse(),function r(){while(e.length){var n=e.pop();if(n in t)return r.value=n,r.done=!1,r}return r.done=!0,r}},t.values=T,S.prototype={constructor:S,reset:function(t){if(this.prev=0,this.next=0,this.sent=this._sent=e,this.done=!1,this.delegate=null,this.method="next",this.arg=e,this.tryEntries.forEach(O),!t)for(var r in this)"t"===r.charAt(0)&&n.call(this,r)&&!isNaN(+r.slice(1))&&(this[r]=e)},stop:function(){this.done=!0;var t=this.tryEntries[0],e=t.completion;if("throw"===e.type)throw e.arg;return this.rval},dispatchException:function(t){if(this.done)throw t;var r=this;function o(n,o){return c.type="throw",c.arg=t,r.next=n,o&&(r.method="next",r.arg=e),!!o}for(var a=this.tryEntries.length-1;a>=0;--a){var i=this.tryEntries[a],c=i.completion;if("root"===i.tryLoc)return o("end");if(i.tryLoc<=this.prev){var s=n.call(i,"catchLoc"),u=n.call(i,"finallyLoc");if(s&&u){if(this.prev<i.catchLoc)return o(i.catchLoc,!0);if(this.prev<i.finallyLoc)return o(i.finallyLoc)}else if(s){if(this.prev<i.catchLoc)return o(i.catchLoc,!0)}else{if(!u)throw new Error("try statement without catch or finally");if(this.prev<i.finallyLoc)return o(i.finallyLoc)}}}},abrupt:function(t,e){for(var r=this.tryEntries.length-1;r>=0;--r){var o=this.tryEntries[r];if(o.tryLoc<=this.prev&&n.call(o,"finallyLoc")&&this.prev<o.finallyLoc){var a=o;break}}a&&("break"===t||"continue"===t)&&a.tryLoc<=e&&e<=a.finallyLoc&&(a=null);var i=a?a.completion:{};return i.type=t,i.arg=e,a?(this.method="next",this.next=a.finallyLoc,v):this.complete(i)},complete:function(t,e){if("throw"===t.type)throw t.arg;return"break"===t.type||"continue"===t.type?this.next=t.arg:"return"===t.type?(this.rval=this.arg=t.arg,this.method="return",this.next="end"):"normal"===t.type&&e&&(this.next=e),v},finish:function(t){for(var e=this.tryEntries.length-1;e>=0;--e){var r=this.tryEntries[e];if(r.finallyLoc===t)return this.complete(r.completion,r.afterLoc),O(r),v}},catch:function(t){for(var e=this.tryEntries.length-1;e>=0;--e){var r=this.tryEntries[e];if(r.tryLoc===t){var n=r.completion;if("throw"===n.type){var o=n.arg;O(r)}return o}}throw new Error("illegal catch attempt")},delegateYield:function(t,r,n){return this.delegate={iterator:T(t),resultName:r,nextLoc:n},"next"===this.method&&(this.arg=e),v}},t}(t.exports);try{regeneratorRuntime=n}catch(o){Function("r","regeneratorRuntime = r")(n)}},b0c0:function(t,e,r){var n=r("83ab"),o=r("9bf2").f,a=Function.prototype,i=a.toString,c=/^\s*function ([^ (]*)/,s="name";n&&!(s in a)&&o(a,s,{configurable:!0,get:function(){try{return i.call(this).match(c)[1]}catch(t){return""}}})},bbd8:function(t,e,r){},bd4c:function(t,e,r){"use strict";var n=r("bbd8"),o=r.n(n);o.a},dfc1:function(t,e,r){"use strict";r.r(e);var n=function(){var t=this,e=t.$createElement,r=t._self._c||e;return r("b-list-group",t._l(t.threads,(function(e,n){return r("b-list-group-item",{key:n,attrs:{forumId:e.forumId},on:{click:function(r){return t.goToThread(e.routeName)}}},[r("span",{staticStyle:{cursor:"pointer",color:"rgba(150, 155, 5, 0.8)"},attrs:{forumid:e.forumid}},[t._v(" "+t._s(e.forumName))])])})),1)},o=[],a=(r("4160"),r("159b"),r("96cf"),r("1da1")),i={data:function(){return{threads:[]}},beforeRouteUpdate:function(){},methods:{goToThread:function(t){var e=this;e.$router.push("/Thread/".concat(t))},getSideBar:function(){var t=this;return Object(a["a"])(regeneratorRuntime.mark((function e(){var r;return regeneratorRuntime.wrap((function(e){while(1)switch(e.prev=e.next){case 0:return r="/api/Forum/GetAll",e.next=3,t.$axios.get(r).then((function(e){e.data.forEach((function(e){t.threads.push(e)}))})).catch((function(t){console.log(t)}));case 3:case"end":return e.stop()}}),e)})))()}},created:function(){var t=this;return Object(a["a"])(regeneratorRuntime.mark((function e(){return regeneratorRuntime.wrap((function(e){while(1)switch(e.prev=e.next){case 0:return e.next=2,t.getSideBar();case 2:case"end":return e.stop()}}),e)})))()}},c=i,s=r("2877"),u=Object(s["a"])(c,n,o,!1,null,null,null);e["default"]=u.exports}}]);
//# sourceMappingURL=chunk-133fb5f8.47beb58a.js.map