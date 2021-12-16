import { deletePlay, getPlayById, getLikesByThetherId, getMyLikeByBookId } from '../api/data.js';
import { html } from '../lib.js';
import { getUserData } from '../util.js';

const detailsTemplate = (play, isOwner, onDelete, likes, showLikeBtn) => html `
<section id="detailsPage">
    <div id="detailsBox">
        <div class="detailsInfo">
            <h1>Title: ${play.title}</h1>
            <div>
                <img src="${play.imageUrl}" />
            </div>
        </div>

        <div class="details">
            <h3>Theater Description</h3>
            <p>${play.description}</p>
            <h4>Date: ${play.date}</h4>
            <h4>Author: ${play.author}</h4>

            ${isOwner
                ? html`<div class="buttons">
                <a @click=${onDelete} class="btn-delete" href="javascript:void(0)">Delete</a>
                <a class="btn-edit" href="/edit/${play._id}">Edit</a>
                ${likeControlTemplate(showLikeBtn)}
                </div>`
                : null}

            <p class="likes">Likes: ${likes}</p>
        </div>
    </div>
</section>`;




const likeControlTemplate = (showLikeBtn) => {
    if (showLikeBtn) {
        return html `<a class="btn-like" href="/like">Like</a>`;
    } else {
        return null;
    }
}

export async function detailsPage(ctx) {
    const userData = getUserData();

    const [play, likes, hasLike] = await Promise.all([
        getPlayById(ctx.params.id),
        getLikesByThetherId(ctx.params.id),
        userData ? getMyLikeByBookId(ctx.params.id, userData.id) : 0
    ])


    const isOwner = userData && userData.id == play._ownerId;
    const showLikeBtn = userData != null && isOwner == false && hasLike == false;

    ctx.render(detailsTemplate(play, isOwner, onDelete, likes, showLikeBtn)); //owner

    async function onDelete() {
        const choice = confirm(`Are you sure you want to delete ${play.title}`);

        if (choice) {
            await deletePlay(ctx.params.id);
            ctx.page.redirect('/');
        }
    }
}