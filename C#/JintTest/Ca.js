/*
 * @Author: your name
 * @Date: 2020-08-04 14:17:52
 * @LastEditTime: 2020-08-17 10:22:25
 * @LastEditors: Please set LastEditors
 * @Description: In User Settings Edit
 * @FilePath: \undefinedc:\Users\lwq20\Desktop\a.js
 */
/**
 * concatenate 
 * 将最多21个文本字符串合并为一个字符串。注意：不会自动在输入之间放置空格。参见示例
 */
function CONCATENATE(a0, a1, a2, a3, a4, a5, a6, a7, a8, a9, a10, a11, a12, a13, a14, a15, a16, a17, a18, a19, a20) {
    var data = "";
    for (var index = 0; index <= 20; index++) {
        var temp = eval("a" + index);
        if (!!temp) {
            data += temp;
        }
    }
    return data;
}

/**
 * ISBLANK
 * 如果传递的字符串为空，则返回true，否则返回false。
 */
function ISBLANK(a0) {
    return a0 === "";
}
/*
 *
 * 如果指定的true/false条件为true，则返回一个值；如果为false，则返回另一个值。
 */
function IF(exp, a0, a1) {
    return (!!exp) ? a0 : a1;

}
/**
 * 方法执行的是向上取整计算，它返回的是大于或等于函数参数，并且与之最接近的整数。
 * @param {any} a0
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

/**
 * 给定一个输入文本，一个最大长度和一个分隔符，将返回输入文本的最长部分，该部分不超过最大长度，并在分隔符的实例处被截断。
 * @param {any} str
 * @param {any} length
 * @param {any} sp
 */
function LEFTWORD(str, length, sp) {
    return substring(str, length) + sp;
}

/**
 * 如果指定的true/false条件为true，则返回一个值；如果为false，则返回另一个值。
 * @param {any} condition
 * @param {any} a0
 * @param {any} a1
 */
function IF(condition, a0, a1) {
    return condition ? a0 : a1;
}
/**
 * 把str字符串的所有的rp0字段替换成rp1字段
 * @param {any} str
 * @param {any} rp0
 * @param {any} rp1
 */
function REPLACE(str, rp0, rp1) {
    return str.replace(rp0, rp1);
}

function isExitsFunction(funcName) {
    try {
        if (typeof (eval(funcName)) == "function") {
            return true;
            // funcName();
        }
    } catch (e) {
        console.log(eval(funcName) + "+++++++++++++++++我异常了!!!!!!!!");
    }
    return false;
}
