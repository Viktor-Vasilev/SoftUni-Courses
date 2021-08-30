function solve(num, com1, com2, com3, com4, com5) {
    let number = Number(num);  // let number = +num;

    const arr = [com1, com2, com3, com4, com5];

    for (let i = 0; i < arr.length; i++) {
        switch (arr[i]) {
            case 'chop':
                number /= 2;
                console.log(number);
                break;
            case 'dice':
                number = Math.sqrt(number);
                console.log(number);
                break;
            case 'spice':
                number++;
                console.log(number);
                break;
            case 'bake':
                number *= 3;
                console.log(number);
                break;
            case 'fillet':
                number -= number * 0.2;
                console.log(number);
                break;
        }
    }


}

console.log(solve('32', 'chop', 'chop', 'chop', 'chop', 'chop'));
console.log(solve('9', 'dice', 'spice', 'chop', 'bake', 'fillet'));

// function cookingByNumbers(...input) {
// let startNumber = Number(input.shift());

// let operations = {
//     chop: (x) => x /= 2,
//     dice: (x) => x = Math.sqrt(x),
//     spice: (x) => x += 1,
//     bake: (x) => x *= 3,
//     fillet: (x) => x -= x * 0.2,
// }

// for (let i = 0; i < input.length; i++) {
//     let currentOperation = input[i];

//     startNumber = operations[currentOperation](startNumber);

//     console.log(startNumber);
// }
// }


// cookingByNumbers('32', 'chop', 'chop', 'chop', 'chop', 'chop');
// cookingByNumbers('9', 'dice', 'spice', 'chop', 'bake', 'fillet');