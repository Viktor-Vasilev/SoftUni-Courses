function listOfNames(arr) {

    arr.sort((a, b) => a.localeCompare(b));

    let orderNumber = 1;

    arr.forEach((element) => {
        console.log(`${orderNumber}.${element}`)
        orderNumber++;
    })
}

listOfNames(["John", "Bob", "Christina", "Ema"]);

// function listOfNames(arr) {
//     let result = arr
//       .sort((a, b) => a.localeCompare(b))
//       .map((el, index) => {
//         return `${index + 1}.${el}`;
//       });
  
//     return result.join("\r\n");
//   }