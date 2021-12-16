import { getMyPlays } from '../api/data.js';
import { html } from '../lib.js';
import { getUserData } from '../util.js';

const myPlaysTemplate = (play, userEmail) => html `
<section id="profilePage">
    <div class="userInfo">
        <div class="avatar">
            <img src="./images/profilePic.png">
        </div>
        <h2>${userEmail}</h2>
    </div>
    <div class="board">
        <!--If there are event-->
        ${play.length == 0
            ? html`<div class="no-events">
                        <p>This user has no events yet!</p>
                    </div>`
            : play.map(playCard)}

        <!--If there are no event-->
        
    </div>
</section>`;

const playCard = (play) => html `
<div class="eventBoard">
    <div class="event-info">
        <img src="${play.imageUrl}">
        <h2>${play.title}</h2>
        <h6>${play.date}</h6>
        <a href="/details/${play._id}" class="details-button">Details</a>
    </div>
</div>`


export async function myTheaterPage(ctx) {
    const userData = getUserData();
    const plays = await getMyPlays(userData.id);
    const userEmail = userData.email;
    ctx.render(myPlaysTemplate(plays, userEmail));
}