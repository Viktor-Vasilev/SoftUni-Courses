// initialization
// - find relevant section

import { showView } from './dom.js';
import { e } from './dom.js';

// - detach section from DOM
const section = document.getElementById('movie-details');
section.remove();

// display logic - трябва да изпразни съдържанието на страницата и да добави своето
export function showDetails(movieId) {
   // console.log(movieId);
    showView(section);
    getMovie(movieId);
}

async function getMovie(id) {  // функция за взимане на конкретен филм
    section.replaceChildren(e('p', {}, 'Loading ...'));

    const requests = [  // бутаме всички заявки тука
        fetch('http://localhost:3030/data/movies/' + id), // намираме филма
        fetch(`http://localhost:3030/data/likes?where=movieId%3D%22${id}%22&distinct=_ownerId&count`), //за лайковете
        // fetch(`http://localhost:3030/data/likes?where=movieId%3D%22${id}%22%20and%20_ownerId%3D%22${userId}%22`), //дали го е лайкнал
    ]

    const userData = JSON.parse(sessionStorage.getItem('userData'));
    if (userData != null) {
        requests.push(fetch(`http://localhost:3030/data/likes?where=movieId%3D%22${id}%22%20and%20_ownerId%3D%22${userData.id}%22`)) //дали го е лайкнал);
    }

    const [movieRes, likesRes, hasLikedRes] = await Promise.all(requests); // hasLikedRes може да е undefined
    const [movieData, likes, hasLiked] = await Promise.all([
        movieRes.json(), 
        likesRes.json(),
        hasLikedRes && hasLikedRes.json() // ако първото е нъл, второто няма да се изпълни !!!
    ]);

    // const res = await fetch('http://localhost:3030/data/movies/' + id); // намираме филма
    // const data = await res.json();
    // console.log(data);

    section.replaceChildren(createDetails(movieData, likes, hasLiked)); // показваме новото съдържание 
    //return data;
}

function createDetails(movie, likes, hasLiked) { 
    console.log(hasLiked);
    const controls = e('div', { className: 'col-md-4 text-center' },
    e('h3', { className: 'my-3 '}, 'Movie Description' ),
    e('p', {}, movie.description)
    );

    const userData = JSON.parse(sessionStorage.getItem('userData'));  // за бутоните 

    if (userData != null) {  // ако имаме юзър
        if (userData.id == movie._ownerId) { // ако е собственик на филма
            controls.appendChild(e('a', {className: 'btn btn-danger', href: '#'}, 'Delete')); // добавяме бутони
            controls.appendChild(e('a', {className: 'btn btn-warning', href: '#'}, 'Edit'));
        } else { // имаме потребител, но не е собственик
            if (hasLiked.length > 0) {
                controls.appendChild(e('a', {className: 'btn btn-primary', href: '#', onClick: onUnlike}, 'Unlike')); //не забравяме да му закачим функцията!!
            } else {
                controls.appendChild(e('a', {className: 'btn btn-primary', href: '#', onClick: OnLike}, 'Like')); //не забравяме да му закачим функцията!!
            }
            
        }
    }
    controls.appendChild(e('span', {className: 'enrolled-span'}, `Liked ${likes}`)); // колко лайка има

    const element = e('div', { className: 'container' }, // правим си филм
    e('div', { className: 'row bg-light text-dark' },
        e('h1', {}, `Movie title: ${movie.title}`),
            e('div', { className: 'col-md-8' },
                e('img', { className: 'img-thumbnail', src: movie.img, alt: 'Movie' })
        ),
        controls
    )
    );
   


    return element;

    async function OnLike() {
        //console.log('liked');
        await fetch('http://localhost:3030/data/likes', {
            method: 'post',
            headers: {
                'Content-Type': 'application/json',
                'X-Authorization': userData.token
            },
            body: JSON.stringify({
                movieId: movie._id
            })
        });
    
        showDetails(movie._id);
        
    }

    async function onUnlike() { // трябва ни конкретния лайк!!
        const likeId = hasLiked[0]._id;
        await fetch('http://localhost:3030/data/likes/' + likeId, {
            method: 'delete',
            headers: {
                'X-Authorization': userData.token
            }
        });
    
        showDetails(movie._id);
    }
}







//така изглежда един филм
/*
 <div class="container">
                <div class="row bg-light text-dark">
                    <h1>Movie title: Black Widow</h1>

                    <div class="col-md-8">
                        <img class="img-thumbnail" src="https://miro.medium.com/max/735/1*akkAa2CcbKqHsvqVusF3-w.jpeg"
                            alt="Movie">
                    </div>
                    <div class="col-md-4 text-center">
                        <h3 class="my-3 ">Movie Description</h3>
                        <p>Natasha Romanoff aka Black Widow confronts the darker parts of her ledger when a dangerous
                            conspiracy
                            with ties to her past arises. Comes on the screens 2020.</p>
                        <a class="btn btn-danger" href="#">Delete</a>
                        <a class="btn btn-warning" href="#">Edit</a>
                        <a class="btn btn-primary" href="#">Like</a>
                        <span class="enrolled-span">Liked 1</span>
                    </div>
                </div>
            </div>
*/

// window.getMovie = getMovie;