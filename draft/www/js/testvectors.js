let input = inputGenerator(128);

function dec2bin(dec) {
    let pseudoarr = (dec >>> 0).toString(2);
    let result = [];
    for(let item of pseudoarr){
        result.push(item);
    }
    return result;
}

function formatBin(arr) {
    if(arr.length!=7){
        arr.push("0");
        formatBin(arr);
    }
}

function inputGenerator(n){
    let result = [];
    for(let i = 0; i < n; i++){
        let temp = dec2bin(i);
        formatBin(temp);
        temp.push(i%2 == 0 ? "1" : "0");
        temp.push("1");
        temp.push("1");
        temp.unshift("0");
        result.push(temp);
    }
    return result;
}

function DesiredOutputGenerator(input){
    
}
