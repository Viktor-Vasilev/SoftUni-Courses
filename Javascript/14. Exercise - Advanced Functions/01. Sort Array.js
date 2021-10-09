function solve(arr, command) {
    if (command == "desc") {
        return arr.sort((a, b) => {
            return b - a;
        })
    } else {
        return arr.sort((a, b) => a - b);
    }
}

console.log(solve([14, 7, 17, 6, 8], 'asc'));
console.log(solve([14, 7, 17, 6, 8], 'desc'));