function solve(num1, num2) {
    while (num2 != 0) {
        let temp = num2;
        num2 = num1 % num2;
        num1 = temp;
    }
    return num1
}

console.log(solve(15, 5));
console.log(solve(2154, 458));


// with recursion
// function gcd_rec(a, b) {
//     if (b) {
//         return gcd_rec(b, a % b);
//     } else {
//         return Math.abs(a);
//     }
//   }
//   console.log(gcd_rec(15, 5));
//   console.log(gcd_rec(2154, 458));