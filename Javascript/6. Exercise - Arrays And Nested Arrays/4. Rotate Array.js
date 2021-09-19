function rotateArray(arr, rotations){
for(let i = 0; i < rotations; i++){
    arr.unshift(arr.pop())
}

console.log(arr.join(" "));
}

rotateArray(['1', '2', '3', '4'], 2);
rotateArray(['Banana', 'Orange', 'Coconut', 'Apple'], 15);

// function solve(arr, rotations) {
//     let counter = Number(rotations);
//     while (counter != 0) {
//       let lastElement = arr.pop();
//       arr.unshift(lastElement);
//       counter--;
//     }
  
//     return arr.join(" ");
//   }