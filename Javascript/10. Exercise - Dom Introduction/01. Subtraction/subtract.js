function subtract() {

    const result = document.getElementById("result");
    const first = Number(document.getElementById("firstNumber").value);
    const second = Number(document.getElementById("secondNumber").value);
    result.innerHTML = (first - second).toString();
}
    // function subtract() {
    //     let num1 = document.getElementById('firstNumber');
    //     let num2 = document.getElementById('secondNumber');
      
    //     if (num1 === null || num2 === null) {
    //       throw new Error('Something went wrong...');
    //     }
    //     document.getElementById('result').textContent = num1.value - num2.value;
    //   }
   // console.log('TODO:...');
