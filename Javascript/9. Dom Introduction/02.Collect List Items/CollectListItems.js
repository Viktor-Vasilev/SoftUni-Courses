// function extractText() {
//     const items = document.getElementById('items').children;

//     const result = [];

//     for (const item of items) {   // => не работи в джъдж - няма итератор !!
//         result.push(item.textContent);
//     }

//     document.getElementById('result').textContent = result.join('\n');
// }

function extractText() {
    const items = document.getElementById('items').children;

    const result = [];

    for (const item of Array.from(items)) {
        result.push(item.textContent);
    }

    // const result = [...items].map(e => e.textContent).join('\n');

    document.getElementById('result').textContent = result.join('\n');

}
    // with selector
//     function extractText() {
//         const items = document.querySelectorAll('#items li');
    
//         const result = [];
    
//         for (const item of Array.from(items)) {
//             result.push(item.textContent);
//         }
    
//         document.getElementById('result').textContent = result.join('\n');
//     }
