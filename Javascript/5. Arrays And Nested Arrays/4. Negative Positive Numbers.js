function positiveNegative(numbers) {
    const result = [];

    for (let num of numbers) {
        if (num < 0) {
            result.unshift(num);
        } else {
            result.push(num);
        }
    }

    console.log(result.join('\n'));

    // for (let num of result) {  //друго печатане с обхождане с for of
    //     console.log(num);
    // }
}

positiveNegative([7, -2, 8, 9]);
positiveNegative([3, -2, 0, -1]);