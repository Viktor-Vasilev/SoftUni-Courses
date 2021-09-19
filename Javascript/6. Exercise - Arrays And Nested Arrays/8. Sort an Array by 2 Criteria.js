function sortBy2Criteria(arr) {

    arr.sort((a, b) => a.length - b.length || a.localeCompare(b));

    return arr.join("\r\n");
}

console.log(sortBy2Criteria(['alpha', 'beta', 'gamma']));
console.log(sortBy2Criteria(['Isacc', 'Theodor', 'Jack', 'Harrison', 'George']));
console.log(sortBy2Criteria(['test', 'Deny', 'omen', 'Default']));

// function sortBy2Criteria(arr) {
//     const result = arr.sort((a, b) => {
//         if(a.length > b.length) {
//             return 1;
//         } else if (a.length == b.length) {
//             return a.localeCompare(b);
//         } else {
//             return -1;
//         }
//     })
//     console.log(result.join("\n"));
// }

// (sortBy2Criteria(['alpha', 'beta', 'gamma']));
// (sortBy2Criteria(['Isacc', 'Theodor', 'Jack', 'Harrison', 'George']));
// (sortBy2Criteria(['test', 'Deny', 'omen', 'Default']));
