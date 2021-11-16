// initialization
// - find relevant section

import { showView } from './dom.js';
import { e } from './dom.js';
import { showCreate } from './create.js';
import { showDetails } from './details.js';

let moviesCache = null;


// - detach section from DOM
const section = document.getElementById('home-page');
const catalog = section.querySelector('.card-deck.d-flex.justify-content-center'); // хващаме мястото където да сложим новвия филм
             

// за създаването
section.querySelector('#createLink').addEventListener('click', (event) => {
    event.preventDefault(); // премахва презареждането
    showCreate(); // вика нужното вю
});

// да азберем на кой филм е цъкнал юзъра
catalog.addEventListener('click', (event) => {
    event.preventDefault();
    let target = event.target;
    if(target.tagName == 'BUTTON') {  
        target = target.parentElement;
    }
    if (target.tagName == 'A') { 
        const unslicedId = target.dataset.id; // WTF откъде се взима това href ?!?
        const id = unslicedId.slice(0, -8);
        console.log(id);
        showDetails(id);     
    }
    // if (target.tagName == 'A') { 
    //     const id = target.dataset.id;
    //     console.log(id);
    //     showDetails(id);     
    // }

});

section.remove();

// display logic - трябва да изпразни съдържанието на страницата и да добави своето
export function showHome() {
    showView(section);

    getMovies();
}

// взимаме данни
async function getMovies() {
    catalog.replaceChildren(e('p', {}, 'Loading ...')); // само визуално подобрение

    // if (moviesCache == null) { // за кеширане
    //     const res = await fetch('http://localhost:3030/data/movies');
    //     const data = await res.json();
    //     moviesCache = data;
    // }
     
        const res = await fetch('http://localhost:3030/data/movies');
        const data = await res.json();

    catalog.replaceChildren(...data.map(createMovieCard)); // получената data я мапваме през функцията, което връща масив от елементи, който после трябва да го закачим в секцията
}

//правим си карта на филм, за да можем да ги заредим
function createMovieCard(movie) {
    const element = e('div', { className: 'card mb-4' }); // ползваме фукцията e за да сетнем по-лесно класа на дива
    element.innerHTML = `
    <img class="card-img-top" src="${movie.img}"
    alt="Card image cap" width="400">
<div class="card-body">
    <h4 class="card-title">${movie.title}</h4>
</div>
<div class="card-footer">
    <a data-id=${movie._id}href="#">
        <button type="button" class="btn btn-info">Details</button>
    </a>
</div>`;

    return element;
}

//така изглежда един филм
/*
<div class="card mb-4">
<img class="card-img-top" src="https://pbs.twimg.com/media/ETINgKwWAAAyA4r.jpg"
    alt="Card image cap" width="400">
<div class="card-body">
    <h4 class="card-title">Wonder Woman 1984</h4>
</div>
<div class="card-footer">
    <a href="#/details/6lOxMFSMkML09wux6sAF">
        <button type="button" class="btn btn-info">Details</button>
    </a>
</div>
</div>
*/

// window.getMovies = getMovies; // за да тестваме