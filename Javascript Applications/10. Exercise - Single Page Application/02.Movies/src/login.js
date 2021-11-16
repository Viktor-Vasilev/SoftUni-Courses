// initialization
// - find relevant section

import { updateNav } from './app.js';
import { showView } from './dom.js';
import { showHome } from './home.js';

// - detach section from DOM
const section = document.getElementById('form-login');
const form = section.querySelector('form'); // взимаме формуляра
form.addEventListener('submit', onLogin);
section.remove();

// display logic - трябва да изпразни съдържанието на страницата и да добави своето
export function showLogin() {
    showView(section);
}

async function onLogin(event) { // взимаме данните от формата
    event.preventDefault();
    
    const formData = new FormData(form);

    const email = formData.get('email').trim();
    const password = formData.get('password').trim();

    try {
        const res = await fetch('http://localhost:3030/users/login', {
            method: 'post',
            headers: {'Content-Type': 'application/json'},
            body: JSON.stringify({email, password})
        });

        if(res.ok != true) {  // ако не проработи хвърляме грешка
            const error = await res.json();
            throw new Error(error.message);
        }

        const data = await res.json(); //ако всичко е минало успешно имаме обект с информацията
        sessionStorage.setItem('userData', JSON.stringify ({  // запазваме информацията в сешън или локал сториджа
            email: data.email,
            id: data._id,
            token: data.accessToken
        }));

        form.reset(); // при успешен логин изчистваме формата

        updateNav(); // ъпдейтване навигацията да показва правилните бутони

        showHome(); // визуализираме каталога
    } catch (err) {
        alert(err.message);
    }

}