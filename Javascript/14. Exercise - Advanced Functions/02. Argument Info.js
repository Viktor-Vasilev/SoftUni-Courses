function solve(...arr) {

    let result = {};

    for (let i = 0; i < arr.length; i++) {

        let typeOfObject = typeof arr[i];

        if (result[typeOfObject]) {
            result[typeOfObject] += 1;
        } else {
            result[typeOfObject] = 1;
        }

        console.log(`${typeOfObject}: ${arr[i]}`);
    }
    // for (const [key, value] of Object.entries(result).sort(
    //     (a, b) => b[1] - a[1]
    // )) {
    //     console.log(`${key} = ${value}`);
    // }
    Object.entries(result)
        .sort((a, b) => b[1] - a[1])
        .forEach((el) => {
            console.log(`${el[0]} = ${el[1]}`);
        });
}
console.log(solve('cat', 42, function () { console.log('Hello world!'); }));