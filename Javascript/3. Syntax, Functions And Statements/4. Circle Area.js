function solve(radius) {
    let inputType = typeof(radius);
    if (inputType === 'number') {
      let area = Math.pow(radius, 2) * Math.PI;
      console.log(area.toFixed(2));
    } else {
  console.log(`We can not calculate the circle area, because we receive a ${inputType}.`);
    }
  }

solve(5);
solve("name");

/////////

function CircleArea(x) {
    let type = typeof(x);
    
    if (type === "number") {
      let circleArea = Math.pow(x, 2) * Math.PI;
      console.log(circleArea.toFixed(2));
    }
    else {
      console.log(`We can not calculate the circle area, because we receive a ${type}.`)
    }
  }
  

  CircleArea(5);
  CircleArea("name");