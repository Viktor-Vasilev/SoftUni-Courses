function addAndRemove(arr) {

    let startNumber = 1;

    let result = [];

    arr.forEach((element) => {
        if (element == "add") {
            result.push(startNumber);
        } else {
            result.pop();
        }

        startNumber++;
    })

    if (result.length == 0) {
        console.log("Empty")
    }
    else {
        console.log(result.join("\n"))
    }
};

addAndRemove(['add', 'add', 'add', 'add']);
addAndRemove(['add', 'add', 'remove', 'add', 'add']);
addAndRemove(['remove', 'remove', 'remove']);

// function addRemoveElements(commands){

//     let result = [];
//     let counter = 1;

//     commands.forEach(command => {
//         switch (command) {
//             case 'add':
//                 result.push(counter);
//                 break;
//             case 'remove':
//                 result.pop();
//                 break;
//         }
//         counter++;
//     });