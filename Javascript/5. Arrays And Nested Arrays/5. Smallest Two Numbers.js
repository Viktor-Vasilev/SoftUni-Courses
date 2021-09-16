function twoSmallestNumbers(numbers){

    numbers = numbers.sort((a, b) => a - b);

    let firstNum = numbers[0];
    let secondNum = numbers[1];

    console.log(`${firstNum} ${secondNum}`);
}

twoSmallestNumbers([30, 15, 50, 5]);
twoSmallestNumbers([3, 0, 10, 4, 7, 3]);

// function solve(input) {
//     let newArray = [];
  
//     input.sort((a, b) => a - b);
//     newArray.push(input[0]);
//     newArray.push(input[1]);
//     return newArray;
//   }