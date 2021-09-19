function printNElement(arr, step) {

    let resultArr = [];

    for (let i = 0; i < arr.length; i += step) {
        resultArr.push(arr[i]);
    }
    return resultArr;
}

console.log(printNElement(["1", "2", "3", "4", "5"], 6));
console.log(printNElement(["5", "20", "31", "4", "20"], 2));
console.log(printNElement(["dsa", "asd", "test", "tset"], 2));

