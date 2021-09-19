function sortingNumbers(arr) {
    arr.sort((a, b) => a - b);
    let result = [];
  
    while (arr.length != 0) {
      result.push(arr.shift()); // shift и pop намалят arr.length !!
      result.push(arr.pop());
    }
    return result.filter((num) => num != undefined);
    //return result;
  }

console.log(sortingNumbers([1, 65, 3, 52, 48, 63, 31, -3, 18, 56]));
