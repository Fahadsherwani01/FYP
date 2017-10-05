function clear_text(e){$("#"+e).val("").css("fontStyle","normal").css("color","black")}function openChild(e,t,n){
var o=window.open(e,t,n);null===o.opener&&(o.opener=t.self)}function hideDiv(e){$("#"+e).css("display","none"),
0===$("div[id^=floatBox]").filter(":visible").length&&overlayHide()}function showDiv(e){$("#"+e).css("display","block")}
function removeElement(e){$("#"+e).remove()}function overlayHide(){$("#overlay").css("display","none"),
$("div[id^=floatBox]").css("display","none")}function overlayShow(){
0===$("#overlay").length&&$('<div id="overlay" onclick="overlayHide();" />').appendTo("body"),
$("#overlay").css("height",$(document).height()+"px").show()}function checkFloatBox(e){
0===$("#"+e).length&&$("<div />").attr("id",e).appendTo("body")}function dgid(e){return document.getElementById(e)}
function changeSortOrder(){var e=$("#sort_order").val()
;self.location=-1!=location.href.search(/sort=/i)?location.href.replace(/sort=[a-zA-Z]*/i,"sort="+e):location.href+"&sort="+e}
function changeResultsPerPage(){var e=$("#results_per_page").val()
;self.location=-1!=location.href.search(/maxrows=/i)?location.href.replace(/maxrows=[0-9]*/i,"maxrows="+e):location.href+"&maxrows="+e
}function compareWithOtherDrugsSeeAll(e,t,n){$.ajax({url:"/js/compare-with-other-drugs.php?ddc_id="+t+"&brand_name_id="+n,
success:function(e){$("#compareWithOtherDrugs").html(e)}})}function brandFamilyDrugDocsSeeAll(e,t){$.ajax({
url:"/js/brand-family-drug-docs.php?url="+t,success:function(e){$("#brandFamilyDrugDocs").html(e)}})}
function otherBrandNamesSeeAll(e,t,n){$.ajax({url:"/js/other-brand-names.php?url="+t+"&type="+n,success:function(e){
$("#other_brand_names_"+n).html(e)}})}function moreResourcesSeeAll(e,t,n){$.ajax({
url:"/js/more-resources.php?url="+t+"&type="+n,success:function(e){$("#more_resources_"+n).html(e)}})}
function getQueryParameter(e){e=e.replace(/[\[]/,"\\[").replace(/[\]]/,"\\]")
;var t=new RegExp("[\\?&]"+e+"=([^&#]*)").exec(window.location.search)
;return null!==t?decodeURIComponent(t[1].replace(/\+/g," ")):""}function dosageDisambiguation(e,t,n){return e.preventDefault(),
e.stopPropagation(),$.ajax({type:"GET",complete:dosageDisambiguationCB,data:"",
url:"/dosage-disambiguation.php?ddc_id="+t+"&brand_name_id="+n}),!1}function dosageDisambiguationCB(e){
DDC.Popup.create(e.responseText,{width:350})}function checkDisclaimerCookies(){
DDC.Cookie.get("terms_interactions")&&(document.getElementById("nav").innerHTML=document.getElementById("nav").innerHTML.replace("drug_interactions.html","drug_interactions.php")),
DDC.Cookie.get("terms_pillid")&&(document.getElementById("nav").innerHTML=document.getElementById("nav").innerHTML.replace("pill_identification.html","imprints.php"))
}function mayoImageToggle(e,t,n){window.location="#Image_"+n,document.getElementById("Image_"+n).innerHTML=e.innerHTML
;var o=document.getElementsByClassName("mayoImageThumb");for(i=0;i<o.length;i++)o[i].className="mayoImageThumb"
;e.className="mayoImageThumb mayoImageThumbSelected"}function surveyGet(){$.ajax({type:"POST",data:{a:window.location.href},
url:"/survey/get.php",success:function(e){$("#survey").html(e)}})}function surveyClose(e){$.ajax({type:"POST",data:{a:e},
async:!1,url:"/survey/close.php",success:function(e){$("#surveyContent").html(e)}})}function topRelatedOtherConditions(e,t,n,o){
$("#topRelatedOtherConditions").html('<img src="/img/loading.gif" />'),$("#topRelatedOtherConditions").html($.ajax({type:"GET",
url:"/top-related-other-conditions.php?ddc_id="+e+"&brand_name_id="+t+"&max_conditions="+n+"&title="+o,async:!1}).responseText)}
function conditionDrugLog(e,t,n){var o="/js/condition-drug-log.php?condition_id="+e+"&ddc_id="+t+"&brand_name_id="+n;$.ajax({
url:o,async:!1})}function drugConditionLog(e,t,n){
var o="/js/drug-condition-log.php?ddc_id="+e+"&brand_name_id="+t+"&condition_id="+n;$.ajax({url:o,async:!1})}
var DDC=window.DDC||{};jQuery.fn.center=function(){
var e=Math.round(($(document).width()-this.width())/2),t=Math.max(20,Math.round($(window).height()/2-this.height()/2+$(window).scrollTop())-20)
;return this.css({left:e,top:t}),this},DDC.Page=function(){function e(){var e=$("#content");if(e.length){
var n=e.find("h1").text();!n||n.length<25||n.indexOf("/")<0||["h1","h2","h3","p","b"].forEach(function(n){t(e,n)})}}
function t(e,t){var n=e.find(t);n.length&&n.each(function(){var e=$(this);if(e.html()===e.text()){
var t=$(this).html().replace(/\//g,"/<wbr>");e.html(t)}})}function n(e){e.preventDefault(),e.stopPropagation()
;var t=$(e.target).closest("[data-more-id]"),n=t.data("more-id")
;window.moreResourceStorage&&window.moreResourceStorage[n]&&t.replaceWith(window.moreResourceStorage[n])}function o(){var e=i()
;$("#content ul").each(function(){var t=$(this),n=t.find("li");if(!(n.length<10)){var o={numItems:0,numItemsLongLength:0,
maxLength:0,hasChildList:!1};n.each(function(){var t=$(this),n=t.text().length
;e.countHtmlItems||t.html()===t.text()?o.numItems++:t.html().indexOf("<li")>=0&&(o.hasChildList=!0),
n>e.charLimit.paragraph&&o.numItemsLongLength++,o.maxLength=Math.max(n,o.maxLength)}),a(t,o,e)}})}function i(){var e={
countHtmlItems:!1,charLimit:{paragraph:30,content:350}}
;return $("body").hasClass("page-section-international")&&(e.countHtmlItems=!0,e.charLimit.content=0),e}function a(e,t,n){
if(!t.hasChildList){if(t.numItems>50)e.addClass("list-length-long");else if(t.numItems>25)e.addClass("list-length-medium");else{
if(!(t.numItems>10))return;e.addClass("list-length-short")}
n.charLimit.content&&t.maxLength>n.charLimit.content?e.addClass("list-type-content"):t.numItemsLongLength/t.numItems*100>5?e.addClass("list-type-paragraph"):e.addClass("list-type-word")
}}return{init:function(){e(),o(),$(".more-resources-more-toggle").on("click",n)}}}(),DDC.Form=function(){function e(e){
if(!t())return!1;$(e.target).find("input[type=submit]").each(function(){
$(this).attr("data-submit")&&$(this).val($(this).attr("data-submit")).addClass("input-button-disabled")})}function t(){
var e=$("[data-terms-required=1]");return!(e.length&&!e.is(":checked"))||(alert("You must accept the terms to continue."),!1)}
function n(e,t){""===t?$("#user-"+e).removeClass("input-warning"):($("#user-"+e).addClass("input-warning"),
t=" <span class='msg-warning'>"+t+"</span>");var n="rego-"+e;$("#"+n).length&&$("#"+n).remove();var o=$("<span />").attr({id:n
}).html(t);$("#user-"+e).after(o)}return{init:function(){$("form").on("submit",e)},validate:t,regoCheck:function(e,t,o){
$.get("/register-check.php",{key:e,val:t,val2:o},function(t){n(e,t)})}}}(),DDC.Pill=function(){function e(){
$("#shape-content").hide(),$("#shape-select").css({visibility:"visible"}),$(document).off("click")}return{showShapes:function(){
var t=$("#shape-content");t.length||((t=$("<div />").attr("id","shape-content").css({position:"absolute",top:"0",zIndex:150
})).html("<p style='padding: 12px;'>Loading shapes...</p>").load("/js/pill-shapes.html"),$("#shape-select").closest("div").css({
position:"relative"}),$("#shape-select").after(t)),t.show(),$("#shape-select").css({visibility:"hidden"}).blur(),
window.setTimeout(function(){$(document).on("click",e)},10)},selectShape:function(t){$("#shape-select").val(t),e()}}}(),
DDC.Sidebar=function(){function e(e){$(".sideBoxDrugInfoExtra .sideBoxContent").html(e.responseText)}function t(e){
$(".sideBoxUnapproved .sideBoxContent").html(e.responseText)}return{showDrugInfoExtra:function(t,n,o,i,a){
$(".sideBoxDrugInfoExtra").slideDown(),$(".sideBoxDrugInfoExtra .sideBoxTitle").html(o),
$(".sideBoxDrugInfoExtra .sideBoxContent").html("<img alt='Loading...' src='/img/misc/ajax-loader-large.gif' width='32' height='32' />"),
$.ajax({type:"GET",complete:e,data:{type:t,id:n,ddc_id:i,brand_name_id:a},url:"/drug-info-extra.php"})},
showConditionInfoExtra:function(t,n,o,i){$(".sideBoxDrugInfoExtra").slideDown(),
$(".sideBoxDrugInfoExtra .sideBoxTitle").html(o),
$(".sideBoxDrugInfoExtra .sideBoxContent").html("<img alt='Loading...' src='/img/misc/ajax-loader-large.gif' width='32' height='32' />"),
$.ajax({type:"GET",complete:e,data:{type:t,id:n,condition_id:i},url:"/condition-info-extra.php"})},
showConditionDocInfoExtra:function(t,n,o,i,a){$(".sideBoxDrugInfoExtra").slideDown(),
$(".sideBoxDrugInfoExtra .sideBoxTitle").html(n),
$(".sideBoxDrugInfoExtra .sideBoxContent").html("<img alt='Loading...' src='/img/misc/ajax-loader-large.gif' width='32' height='32' />"),
$.ajax({type:"GET",complete:e,data:{type:t,url:o,doc_title:i,doc_filename:a},url:"/condition-doc-info-extra.php"})},
showUnapproved:function(e,n){
$(".sideBoxUnapproved").slideDown(),$(".sideBoxUnapproved .sideBoxContent").html("<img alt='Loading...' src='/img/misc/ajax-loader-large.gif' width='32' height='32' />"),
$.ajax({type:"GET",complete:t,data:{ddc_id:e,brand_name_id:n},url:"/fda-unapproved-extra.php"})}}}(),DDC.Pro=function(){
function e(){DDC.Cookie.set("proclick",1,90),ga("send","event","Pro","MenuClick")}return{init:function(){$("#nav-pro").click(e)}
}}(),DDC.GoogleMap=function(){var e="google-map";return{init:function(){
var t=$("#gmap-zoom").length?parseInt($("#gmap-zoom").val()):12,n=new google.maps.LatLng($("#gmap-latitude").val(),$("#gmap-longitude").val()),o={
zoom:t,center:n,scaleControl:!1,mapTypeControl:!1,disableDefaultUI:!1,mapTypeId:google.maps.MapTypeId.ROADMAP
},i=new google.maps.Map(document.getElementById(e),o);new google.maps.Marker({map:i,position:n})}}}(),
DDC.TextHighlight=function(){function e(){var e=window.location.href;if(e.match(/^https:\/\/www\.drugs\.com\//)){
var t=window.getSelection().toString().trim(),n=new RegExp(t,"i")
;if(t&&t.length<=50&&t.length>=3&&t.match(/^[a-zA-Z0-9\s]+$/)&&!e.match(n)){var o=new XMLHttpRequest
;o.open("POST","/text-highlight-log.php",!0),o.setRequestHeader("Content-type","application/x-www-form-urlencoded"),
o.send("url="+e+"&selected_text="+t)}}}return{init:function(){document.addEventListener("click",e)}}}();