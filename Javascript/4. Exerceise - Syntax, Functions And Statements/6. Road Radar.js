function solve(speed, area) {
    let limit = 0;

    switch (area) {
        case 'motorway':
            limit = 130;
            break;
        case 'interstate':
            limit = 90;
            break;
        case 'city':
            limit = 50;
            break;
        case 'residential':
            limit = 20;
            break;
    }

    const speeding = speed - limit;

    if (speeding <= 0) {
        return `Driving ${speed} km/h in a ${limit} zone`;
    }

    let status = '';

    if (speeding <= 20) {
        status = 'speeding';
    }
    else if (speeding > 20 && speeding <= 40) {
        status = 'excessive speeding';
    }
    else {
        status = 'reckless driving';
    }

    return `The speed is ${speeding} km/h faster than the allowed speed of ${limit} - ${status}`

}

console.log(solve(40, 'city'));
console.log(solve(21, 'residential'));
console.log(solve(120, 'interstate'));
console.log(solve(200, 'motorway'));

// function Solve([speed, area]) {

//     const residentialMax = 20;
//     const interstateMax = 90;
//     const motorwayMax = 130;
//     const cityMax = 50;
//     let output = '';

//     switch (area) {
//         case 'residential':
//             output = CheckForSpeeding(speed, residentialMax);
//             break;
//         case 'city':
//             output = CheckForSpeeding(speed, cityMax);
//             break;
//         case 'interstate':
//             output = CheckForSpeeding(speed, interstateMax);
//             break;
//         case 'motorway':
//             output = CheckForSpeeding(speed, motorwayMax);
//             break;
//     }

//     console.log(output);
// }


// function CheckForSpeeding(speed, maxSpeed) {

//     let result = '';
//     if (speed <= maxSpeed) {
//         result = ''
//     } else if (speed - maxSpeed <= 20) {
//         result = 'speeding';
//     } else if (speed - maxSpeed <= 40) {
//         result = 'excessive speeding';
//     } else {
//         result = 'reckless driving';
//     }
//     return result;
// }