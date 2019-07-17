﻿var documentElement = document.documentElement;
function callback() {
    var clientWidth = documentElement.clientWidth;
    // 屏幕宽度大于780，不在放大
    clientWidth = clientWidth < 780 ? clientWidth : 780;
    documentElement.style.fontSize = clientWidth / 10 + 'px';
}
document.addEventListener('DOMContentLoaded', callback);
window.addEventListener('orientationchange' in window ? 'orientationchange' : 'resize', callback);

function dateFtt(date, fmt) { //author: meizz   
    fmt = fmt || "yyyy-MM-dd";
    if (typeof (date) == "string") {
        if (date.indexOf('/Date(') > -1 || date.indexOf('/date(') > -1) {
            date = parseDate(date);
        } else {
            date = new Date(date);
        }        
    }
    var o = {
        "M+": date.getMonth() + 1, //月份   
        "d+": date.getDate(), //日   
        "h+": date.getHours(), //小时   
        "m+": date.getMinutes(), //分   
        "s+": date.getSeconds(), //秒   
        "q+": Math.floor((date.getMonth() + 3) / 3), //季度   
        "S": date.getMilliseconds() //毫秒   
    };
    if (/(y+)/.test(fmt))
        fmt = fmt.replace(RegExp.$1, (date.getFullYear() + "").substr(4 - RegExp.$1.length));
    for (var k in o)
        if (new RegExp("(" + k + ")").test(fmt))
            fmt = fmt.replace(RegExp.$1, (RegExp.$1.length == 1) ? (o[k]) : (("00" + o[k]).substr(("" + o[k]).length)));
    return fmt;
}