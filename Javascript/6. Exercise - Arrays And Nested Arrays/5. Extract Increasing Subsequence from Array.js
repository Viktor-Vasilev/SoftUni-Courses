function increasingSequence(arr) {

    let biggest = Number.MIN_SAFE_INTEGER;

    const result = arr.filter((element) => {
        if (element >= biggest) {
            biggest = element;
            return true;
        }
        return false;
    });

return(result);

}

console.log(increasingSequence([1, 3, 8, 4, 10, 12, 3, 2, 24]));
console.log(increasingSequence([1, 2, 3, 4]));
console.log(increasingSequence([20, 3, 2, 15, 6, 1]));


// с обикновен for цикъл
// function increasingSequence(arr) {

//     let result = [];

//     for (let i = 0; i < arr.length; i++) {

//       let element = arr[i];
  
//       if (element >= result[result.length - 1] || result.length === 0) {
//         result.push(element);
//       }
//     }
//     return result;
//   }


// с forEach
// function increasingSequence(arr) {
//     const result = [];
//     let biggest = Number.MIN_SAFE_INTEGER;

//     arr.forEach(element => {
//        if(element >= biggest){
//            result.push(element);
//            biggest = element;
//        } 
//     });
//     return result;
// }

