import * as api from './api.js';

export const login = api.login;
export const register = api.register;
export const logout = api.logout;

export async function getAllPlays() {
    return api.get('/data/theaters?sortBy=_createdOn%20desc&distinct=title');
}

export async function getPlayById(id) {
    return api.get('/data/theaters/' + id);
}

export async function getMyPlays(userId) {
    return api.get(`/data/theaters?where=_ownerId%3D%22${userId}%22&sortBy=_createdOn%20desc`);
}

export async function createPlay(play) {
    return api.post('/data/theaters', play);
}

export async function editPlay(id, play) {
    return api.put('/data/theaters/' + id, play);
}

export async function deletePlay(id) {
    return api.del('/data/theaters/' + id);
}

export async function likeTheather(theaterId) {
    return api.post('/data/likes', {
        theaterId
    });
}

export async function getLikesByThetherId(theaterId) {
    return api.get(`/data/likes?where=theaterId%3D%22${theaterId}%22&distinct=_ownerId&count`);
}

export async function getMyLikeByBookId(theaterId, userId) {
    return api.get(`/data/likes?where=theaterId%3D%22${theaterId}%22%20and%20_ownerId%3D%22${userId}%22&count`);
}