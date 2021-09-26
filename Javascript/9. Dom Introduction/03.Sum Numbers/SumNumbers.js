function calc() {
    // read value of the input fields
    const num1 = Number(document.getElementById('num1').value);
    const num2 = Number(document.getElementById('num2').value);

    // sum values
    const sum = num1 + num2;

    // set result as value of output field
    document.getElementById('sum').value = sum;
}
