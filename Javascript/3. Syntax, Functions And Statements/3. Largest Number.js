function findLargestNumber(a, b, c) {
    let result = 0;
    
    if (a > b && a > c) { 
        result = a; }
    else if (b > a && b > c) { 
        result = b; }
    else if (c > a && c > b) { 
        result = c; }
    console.log(`The largest number is ${result}.`);
}

findLargestNumber(5, -3, 16);
findLargestNumber(-3, -5, -22.5);

//with params
// function secondSolution(...params) { 
//     console.log(`The largest number is ${Math.max(...params)}.`);
// }

// secondSolution(5, -3, 16);
// secondSolution(-3, -5, -22.5);

