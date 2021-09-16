function lastKNumberSequence(length, count) {

    let result = [1];

    for (let i = 1; i < length; i++) {
        let lastElements = result.slice(-count);
        let sum = lastElements.reduce((x, y) => x + y);
        result.push(sum);

    }

    console.log(result.join(' '))
}

// function solve(n, k) {
//     let array = [];
//     let countSlice = 1;
//     for (let index = 0; index < n; index++) {
//       if (index == 0) {
//         array[index] = 1;
//       } else {
//         let newArray = array.slice();
//         if (index > k) {
//           for (let index = 0; index < countSlice; index++) {
//             newArray.shift();
//           }
//           countSlice++;
//         }
//         array[index] = sumKElements(newArray.slice(0, newArray.length));
//       }
//     }
  
//     return array;
  
//     function sumKElements(params) {
//       let sum = 0;
//       for (let index = 0; index < params.length; index++) {
//         sum += Number(params[index]);
//       }
//       return sum;
//     }
//   }

lastKNumberSequence(6, 3);
lastKNumberSequence(8, 2);