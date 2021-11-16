import { showHome } from './home.js';
import { showDetails } from './details.js';
import { showCreate } from './create.js';
import { showLogin } from './login.js';
import { showRegister } from './register.js';


// create placeholder modules for every view
// configure and test navigation
// implement modules
// - create async functions for requests
// - implement DOM logic

const views = { // правим си асоциация на линка и функцията
    'homeLink': showHome,
    'loginLink': showLogin,
    'registerLink': showRegister,
    'createLink': showCreate
}

// за nav бара
const nav = document.querySelector('nav'); // взиамме навигацията в променлива

document.getElementById('logoutBtn').addEventListener('click', onLogout); //взимаме бутона за логаут

nav.addEventListener('click', (event) => {
    // проверяваме първо дали сме цъкнали на някой от бутоните / енкърите   
        const view = views[event.target.id]; // търсим вюто в обекта
        if(typeof view == 'function') { // ако сме го намерили е функция и го викаме
            event.preventDefault(); // премахва презареждането
            view(); // вика нужното вю
        }
});




updateNav();

export function updateNav() { // за ъпдейтване на навигацията
    const userData = JSON.parse(sessionStorage.getItem('userData')); // четем сториджа

    if (userData != null){  // имаме потребител
        nav.querySelector('#welcomeMsg').textContent = `Welcome, ${userData.email}`; // за съобщението

        [...nav.querySelectorAll('.user')].forEach(e => e.style.display = 'block'); // понеже са нодове ги обръщаме в масив със спред оператора и ги правим видим всички
        [...nav.querySelectorAll('.guest')].forEach(e => e.style.display = 'none'); // невидими
    } else { //нямаме потребител
        [...nav.querySelectorAll('.user')].forEach(e => e.style.display = 'none'); 
        [...nav.querySelectorAll('.guest')].forEach(e => e.style.display = 'block'); 
    }
}

// за логаут
async function onLogout(event) {
    event.preventDefault();

    event.stopImmediatePropagation(); // защото има закачени два слушателя върху nav

    const {token} = JSON.parse(sessionStorage.getItem('userData')); //нужен ние само токена

    await fetch('http://localhost:3030/users/logout', { //трябва да е оторизирана заявка !!
        headers: {'X-Authorization': token}
    }); // ако не подадем нищо друго заявката автоматично е GET

    sessionStorage.removeItem('userData'); //изчистваме данните за потребителя

    updateNav(); //ъпдейтване нава

    showLogin(); // пренасочваме
}



// Order of views:
// x catalog (home view)
// x login
// - register - не е направено !
// x logout
// - create
// x details
// x likes
// - edit
// - delete
// Start application in Home View (catalog)

showHome();

window.showHome = showHome; // така си викаме отделни секции в конзолата
//window.showDetails = showDetails;
//window.showCreate = showCreate;

