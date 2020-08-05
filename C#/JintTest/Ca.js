/*
 * @Author: your name
 * @Date: 2020-08-04 15:56:48
 * @LastEditTime: 2020-08-04 15:57:02
 * @LastEditors: your name
 * @Description: In User Settings Edit
 * @FilePath: \Jint\Ca.js
 */

/**
 * concatenate 
 * 将最多21个文本字符串合并为一个字符串。注意：不会自动在输入之间放置空格。参见示例
 */
function concatenate(a0, a1, a2, a3, a4, a5, a6, a7, a8, a9, a10, a11, a12, a13, a14, a15, a16, a17, a18, a19, a20) {
    var data = "";
    for (var index = 0; index <= 20; index++) {
        var temp = eval("a" + index);
        if (!!temp) {
            data += temp;
        }
    }
    console.log(data);
    return data;
}
/**
 * 方法执行的是向上取整计算，它返回的是大于或等于函数参数，并且与之最接近的整数。
 * @param {number} a0 
 */
function CEILING(a0) {
    return Math.ceil(a0);
}
/**
 * 
 * @param {string} splitStr 
 * 将最多11个文本字符串合并为一个由给定值分隔的字符串。
 */
function JOIN(splitStr, a0, a1, a2, a3, a4, a5, a6, a7, a8, a9, a10) {
    var array = [];
    for (var index = 0; index <= 10; index++) {
        var temp = eval("a" + index);
        if (undefined != temp) {
            array.push(temp);
        }
    }
    return array.join(splitStr);
}
/**
 * 
 * @param {string} splitStr 
 * 将最多11个文本字符串合并为一个由给定值分隔的字符串。如果任何输入文本字符串为空，它们将被忽略，并且输出中将不包括额外的分隔符。
 */
function JOINNB(splitStr, a0, a1, a2, a3, a4, a5, a6, a7, a8, a9, a10) {
    var array = [];
    for (var index = 0; index <= 10; index++) {
        var temp = eval("a" + index);
        if (!!temp) {
            array.push(temp);
        }
    }
    return array.join(splitStr);
}


/**
 * 
 * 接受2到10个输入，并返回第一个非空的输入。
 */
function IFBLANK(a0, a1, a2, a3, a4, a5, a6, a7, a8, a9, a10) {
    for (var index = 0; index <= 10; index++) {
        var temp = eval("a" + index);
        if (!!temp) {
            return temp;
        }
    }
}