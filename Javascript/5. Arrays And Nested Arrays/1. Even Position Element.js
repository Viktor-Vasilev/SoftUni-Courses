function evenPosition(strings) {

    let result = '';

    for (let i = 0; i < strings.length; i+=2) {   
            result += strings[i];
            result += ' ';
    }

    console.log(result);
}



evenPosition(["20", "30", "40", "50", "60"]);
evenPosition(["5", "10"]);

// function sumEvenPositionNumbers(params){
//     let result = [];
//     for (let i = 0; i < params.length; i+= 2) {
        
//         result.push(params[i]);
//     }

//     console.log(result.join(' '));