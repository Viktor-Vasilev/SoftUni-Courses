// function sumFristLast(strings) {
//     const firstElement = Number(strings.shift());
//     const lastElement = Number(strings.pop());

//     return firstElement + lastElement;  //ако е само един елемент дава NaN - модифицираме масива и няма елементи в него
// }

function sumFristLast(strings) {
    const firstElement = Number([...strings].shift());  //правим копие на масива
    const lastElement = Number([...strings].pop());

    return firstElement + lastElement;
}

console.log(sumFristLast(['20', '30', '40']));
console.log(sumFristLast(['5', '10']));
console.log(sumFristLast(['5']));