function solve(num) {
    const string = num.toString();
    let isSame = true;
    let sum = 0;

    for (let i = 0; i < string.length; i++) {
        if (string[i] !== string[i + 1] && string[i + 1] !== undefined) {
            isSame = false;
        }

        sum += Number(string[i]);
    }

    return `${isSame}\n${sum}`

}

console.log(solve(2222222));
console.log(solve(1234));

// function solve(input){

//     let digits = input.toString().split('');
//     let realDigits = digits.map(Number);
  
//     let isAllNumberTheSame = true;
//     let number = parseFloat(realDigits[0]);
  
//     var sum = 0 ;
//      for (let index = 0; index < realDigits.length; index++) {
//        var parseInt = parseFloat(realDigits[index]);
  
//      if (parseInt != number) {
//        isAllNumberTheSame=false;
//      }
//      sum += parseInt;
//      }
  
//    console.log(isAllNumberTheSame)
//    console.log(sum);
//   }
  
//   solve(1234);



// function solve(num) {
//     let nums = String(num).split("");
//     let isSame = true;
//     let firstNum = nums[0];
  
//     nums.forEach(function(num) {
//       if (num != firstNum) {
//         isSame = false;
//       }
//     });
  
//     let sum = nums.map(Number).reduce((acc, cur) => acc + cur);
  
//     console.log(isSame);
//     console.log(sum);
//   }
  
//   solve(2222222);
//   solve(1234);