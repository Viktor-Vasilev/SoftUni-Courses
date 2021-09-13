function solve(year, month, day) {

   let yesterday = new Date(year, month, day - 1);

   return `${yesterday.getFullYear()}-${yesterday.getMonth()}-${yesterday.getDate()}`
};

console.log(solve(2016, 9, 30));
console.log(solve(2016, 10, 1));
console.log(solve(2016, 1, 1));