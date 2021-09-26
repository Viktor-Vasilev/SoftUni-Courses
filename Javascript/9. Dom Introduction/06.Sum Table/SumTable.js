function sumTable() {
    // select first table
    const rows = document.querySelectorAll('table tr');
    let sum = 0;

    // select only rows containing values
    // repeat for every row
    // find last cell
    // add cell value to sum
    for (let i = 1; i < rows.length - 1; i++) { // от втория до предпоследния ред!
        const cell = rows[i].lastElementChild;
        sum += Number(cell.textContent);
    }

    // select element with id "sum" and set its value
    document.getElementById('sum').textContent = sum;

}
// Make Table Interactive (change <td> to input) - uncomment in tamplate!
//     function sumTable() {
//         // select first table
//         const rows = document.querySelectorAll('table tr');
//         let sum = 0;
    
//         // select only rows containing values
//         // repeat for every row
//         // find last cell
//         // add cell value to sum
//         for (let i = 1; i < rows.length - 1; i++) {
//             const cell = rows[i].lastElementChild;
//             const input = cell.firstElementChild;
//             sum += Number(input.value);
//         }
    
//         // select element with id "sum" and set its value
//         document.getElementById('sum').children[0].value = sum;

// 