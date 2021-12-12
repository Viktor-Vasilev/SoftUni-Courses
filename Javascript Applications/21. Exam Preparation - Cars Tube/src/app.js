import { logout } from './api/data.js';
import { page, render } from './lib.js';
import { getUserData } from './util.js';
import { createPage } from './views/create.js';
import { detailsPage } from './views/details.js';
import { editPage } from './views/edit.js';
import { homePage } from './views/home.js';
import { loginPage } from './views/login.js';
import { catalogPage } from './views/catalog.js';
import { registerPage } from './views/register.js';
import { myCarsPage } from './views/mycars.js';


const root = document.getElementById('site-content');
document.getElementById('logoutBtn').addEventListener('click', onLogout);

page(decorateContext);
page('/', homePage);
page('/login', loginPage);
page('/register', registerPage);
page('/create', createPage);
page('/details/:id', detailsPage);
page('/edit/:id', editPage);
page('/catalog', catalogPage);
page('/mycars', myCarsPage);


updateUserNav();
page.start();



function decorateContext(ctx, next) {
    ctx.render = (content) => render(content, root);
    ctx.updateUserNav = updateUserNav;

    next();
}

function onLogout() {
    logout();
    updateUserNav();
    page.redirect('/');
}

// function updateUserNav() {
//     const userData = getUserData();

//     if (userData) {
//         document.getElementById('profile').style.display = 'inline-block';
//         document.getElementById('guest').style.display = 'none';
//         document.querySelector('#profile a').textContent = `Welcome, ${userData.username}`;
//     } else {
//         document.getElementById('profile').style.display = 'none';
//         document.getElementById('guest').style.display = 'inline-block';
//     }
// }

function updateUserNav() {
    const userData = getUserData();
    if (userData) {
        document.getElementById('profile').style.display = 'inline-block';
        document.getElementById('guest').style.display = 'none';
        document.querySelector('#profile a').textContent = `Welcome, ${userData.username}`;
    } else {
        document.getElementById('profile').style.display = 'none';
        document.getElementById('guest').style.display = 'inline-block';
    }
}

// import * as api from './api/data.js';
// window.api = api;