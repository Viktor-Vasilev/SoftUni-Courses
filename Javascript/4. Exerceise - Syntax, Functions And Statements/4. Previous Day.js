function previousDate(year, month, day) {

   //месеца започва от нула !!!

   let resultDate = new Date(year, month - 1, day);

   resultDate.setDate(day - 1);

   return `${resultDate.getFullYear()}-${resultDate.getMonth() + 1}-${resultDate.getDate()}` // добавяме си месеца!
};

console.log(previousDate(2016, 9, 30));
console.log(previousDate(2016, 10, 1));
console.log(previousDate(2016, 1, 1));


// един грешен тест:
// function solve(year, month, day) {

//    let today = new Date(year, month, day);

//    let yesterday = new Date(today.valueOf() - 1000*60*60*24);



//    return `${yesterday.getFullYear()}-${yesterday.getMonth()}-${yesterday.getDate()}`
// };

// console.log(solve(2016, 9, 30));
// console.log(solve(2016, 10, 1));
// console.log(solve(2016, 1, 1));