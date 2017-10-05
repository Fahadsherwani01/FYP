RegExp.escape||(RegExp.escape=function(s){return s.replace(/[-\/\\^$*+?.()|[\]{}]/g,"\\$&")}),Date.now||(Date.now=function(){
return(new Date).getTime()}),Number.isInteger=Number.isInteger||function(value){
return"number"==typeof value&&isFinite(value)&&Math.floor(value)===value
},String.prototype.includes||(String.prototype.includes=function(search,start){"use strict"
;return"number"!=typeof start&&(start=0),!(start+search.length>this.length)&&-1!==this.indexOf(search,start)}),
String.prototype.startsWith||(String.prototype.startsWith=function(searchString,position){return position=position||0,
this.substr(position,searchString.length)===searchString
}),String.prototype.endsWith||(String.prototype.endsWith=function(searchString,position){var subjectString=this.toString()
;("number"!=typeof position||!isFinite(position)||Math.floor(position)!==position||position>subjectString.length)&&(position=subjectString.length),
position-=searchString.length;var lastIndex=subjectString.lastIndexOf(searchString,position)
;return-1!==lastIndex&&lastIndex===position}),String.prototype.trim||(String.prototype.trim=function(){
return this.replace(/^[\s\uFEFF\xA0]+|[\s\uFEFF\xA0]+$/g,"")}),Array.isArray||(Array.isArray=function(arg){
return"[object Array]"===Object.prototype.toString.call(arg)}),Array.prototype.filter||(Array.prototype.filter=function(fun){
"use strict";if(void 0===this||null===this)throw new TypeError;var t=Object(this),len=t.length>>>0
;if("function"!=typeof fun)throw new TypeError
;for(var res=[],thisArg=arguments.length>=2?arguments[1]:void 0,i=0;i<len;i++)if(i in t){var val=t[i]
;fun.call(thisArg,val,i,t)&&res.push(val)}return res}),Array.prototype.forEach||(Array.prototype.forEach=function(callback){
var T,k;if(null==this)throw new TypeError("this is null or not defined");var O=Object(this),len=O.length>>>0
;if("function"!=typeof callback)throw new TypeError(callback+" is not a function");for(arguments.length>1&&(T=arguments[1]),
k=0;k<len;){var kValue;k in O&&(kValue=O[k],callback.call(T,kValue,k,O)),k++}}),
Array.prototype.includes||(Array.prototype.includes=function(searchElement,fromIndex){"use strict"
;if(null==this)throw new TypeError('"this" is null or not defined');var o=Object(this),len=o.length>>>0;if(0===len)return!1
;for(var n=0|fromIndex,k=Math.max(n>=0?n:len-Math.abs(n),0);k<len;){if(function(x,y){
return x===y||"number"==typeof x&&"number"==typeof y&&isNaN(x)&&isNaN(y)}(o[k],searchElement))return!0;k++}return!1}),
Array.prototype.some||(Array.prototype.some=function(fun){"use strict"
;if(null==this)throw new TypeError("Array.prototype.some called on null or undefined")
;if("function"!=typeof fun)throw new TypeError
;for(var t=Object(this),len=t.length>>>0,thisArg=arguments.length>=2?arguments[1]:void 0,i=0;i<len;i++)if(i in t&&fun.call(thisArg,t[i],i,t))return!0
;return!1}),Array.prototype.find||(Array.prototype.find=function(predicate){
if(null==this)throw new TypeError('"this" is null or not defined');var o=Object(this),len=o.length>>>0
;if("function"!=typeof predicate)throw new TypeError("predicate must be a function");for(var thisArg=arguments[1],k=0;k<len;){
var kValue=o[k];if(predicate.call(thisArg,kValue,k,o))return kValue;k++}}),window.JSON||(window.JSON={parse:function(sJSON){
return eval("("+sJSON+")")},stringify:function(){var toString=Object.prototype.toString,isArray=Array.isArray||function(a){
return"[object Array]"===toString.call(a)},escMap={'"':'\\"',"\\":"\\\\","\b":"\\b","\f":"\\f","\n":"\\n","\r":"\\r","\t":"\\t"
},escFunc=function(m){return escMap[m]||"\\u"+(m.charCodeAt(0)+65536).toString(16).substr(1)
},escRE=/[\\"\u0000-\u001F\u2028\u2029]/g;return function stringify(value){if(null==value)return"null"
;if("number"==typeof value)return isFinite(value)?value.toString():"null";if("boolean"==typeof value)return value.toString()
;if("object"==typeof value){if("function"==typeof value.toJSON)return stringify(value.toJSON());if(isArray(value)){
for(var res="[",i=0;i<value.length;i++)res+=(i?", ":"")+stringify(value[i]);return res+"]"}
if("[object Object]"===toString.call(value)){var tmp=[]
;for(var k in value)value.hasOwnProperty(k)&&tmp.push(stringify(k)+": "+stringify(value[k]));return"{"+tmp.join(", ")+"}"}}
return'"'+value.toString().replace(escRE,escFunc)+'"'}}()});