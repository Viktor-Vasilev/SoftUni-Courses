function oddPositions(numbers){
    const oddNums = numbers.filter((v, i) => i % 2 == 1); // може и с for цикъл

    const doubled = oddNums.map(x => x * 2);

    doubled.reverse(); //reverse е inPlace - не прави копие !!

console.log(doubled.join(' '));
}

oddPositions([10, 15, 20, 25]);
oddPositions([3, 0, 10, 4, 7, 3]);

// function oddPositionsChained(numbers){
// console.log(numbers
//     .filter((v, i) => i % 2 == 1)
//     .map(x => x * 2)
//     .reverse()
//     .join(' '));
// }

// oddPositionsChained([10, 15, 20, 25]);
// oddPositionsChained([3, 0, 10, 4, 7, 3]);