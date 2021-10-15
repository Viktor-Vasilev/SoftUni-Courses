// function validate() {
//     const userNameRegex = /^[A-Za-z0-9]{3,20}$/;
//     const passwordRegex = /^\w{5,15}$/;
//     const emailRegex =  /(^[\w]+@[\w]+\.[\w]+$)/;

//     let isValidInput = true;
//     let isChecked = false;


//     const submitButton = document.getElementById("submit");


//     submitButton.addEventListener("click", (e) => {
//         e.preventDefault();
//         const userNameField = document.getElementById("username");
//         if (!userNameRegex.test(userNameField.value)){
//             isValidInput = false;
//             userNameField.style.borderColor = "red";
//         } else {
//             userNameField.style.borderColor = "none";
//         }

//         const passwordField = getElementById("password");
//         const confirmPasswordField = getElementById("confirm-password");
//         if(!passwordRegex.test(passwordRegex.value)) {
//             isValidInput = false;
//             passwordField.style.borderColor = "red";
//         } else {
//             passwordField.style.borderColor = "none";
//         }

//         if(passwordField.value != confirmPasswordField.value) {
//             isValidInput = false;
//             passwordField.style.borderColor = "red";
//             //confirmPasswordField.style.borderColor = "red";
//         }else {
//             passwordField.style.borderColor = "none";
//             //confirmPasswordField.style.borderColor = "none";
//         }

//         const emailField = document.getElementById("email");
//         if(!emailRegex.test(emailField.value)) {
//             isValidInput = false;
//             emailField.style.borderColor = "red";
//         }else {
//             emailField.style.borderColor = "none";
//         }

//         const validDiv = document.getElementById("valid");
//         if(isValidInput) {
//             validDiv.style.display = "block";
//         } else {
//             validDiv.style.display = "none";
//         }

//         if(isChecked) {
//             const companyNumber = document.getElementById("companyNumber");
//             if(companyNumber.value < 1000 || companyNumber.value > 9999) {
//                 companyNumber.style.borderColor = "red";
//             }else {
//                 companyNumber.style.borderColor = "none";
//             }

//         }
//     });

//     document.getElementById("company").addEventListener("change", (e) => {
//         if (e.target.checked) {
//             isChecked = true;

//             document.getElementById("companyInfo").style.display = "block";
           
//         }else {
//             isChecked = false;
//             document.getElementById("companyInfo").style.display = "none";
//         }
//     })
// }

function validate() {
    const username = document.getElementById('username');
    const password = document.getElementById('password');
    const confirmPassword = document.getElementById('confirm-password');
    const email = document.getElementById('email');
    const company = document.getElementById('company');
    const companyInfo = document.getElementById('companyInfo');
    const companyNumber = document.getElementById('companyNumber');
    const validField = document.getElementById('valid');

    company.addEventListener('change', () => {
        companyInfo.style.display = company.checked ? 'block' : 'none';
    });

    document.getElementById('submit').addEventListener('click', onClick);

    let valid;

    function onClick(ev) {
        valid = true;

        ev.preventDefault();

        checkValidity(username, /^[A-Za-z0-9]{3,20}$/);
        checkValidity(password, /^\w{5,15}$/);
        checkValidity(confirmPassword, /^\w{5,15}$/);
        checkValidity(email, /@(\w)*\./);

        if (confirmPassword.value !== password.value) {
            confirmPassword.style.borderColor = 'red';
            password.style.borderColor = 'red';
            valid = false;
        }

        if (company.checked) {
            if (1000 > Number(companyNumber.value) || Number(companyNumber.value) > 9999) {
                companyNumber.style.borderColor = 'red';
                valid = false;
            } else {
                companyNumber.style.borderColor = ''
            }
        }

        if (valid) {
            validField.style.display = 'block';
        } else {
            validField.style.display = 'none';
        }
    }

    function checkValidity(element, regExp) {
        if (!regExp.test(element.value)) {
            element.style.borderColor = 'red';
            valid = false;
        } else {
            element.style.borderColor = '';
        }
    }
}
