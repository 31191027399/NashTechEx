import { ApiConstants } from "../constants/api-constant";

export const PhotoService = {
    addPhoto(collection_id,photo_id,token) {
        return cy.request({
            method: 'POST', auth: { bearer: token },
            url: ApiConstants.postPhoto(Cypress.env('apiUrl'),collection_id,photo_id)
        });
    },
    unlikePhoTo(photo_id,token) {
        return cy.request({ method: 'DELETE', auth:{ bearer: token },
         url: ApiConstants.unLikePhoto(Cypress.env('apiUrl'),photo_id)
        })
    },
    getLikedPhotos(userName,token){
        return cy.request({ method: 'GET', auth:{ bearer: token},
        url:ApiConstants.getLikedPhotos(Cypress.env('apiUrl'),userName)
    })
    },
    randomPhoto(photo_count,token)
    {
        return cy.request({ method: 'GET', auth:{ bearer: token},
        url: ApiConstants.randomPhoto(Cypress.env('apiUrl'),photo_count)
    })
    },
    likePhoto(photo_id, token) {
        return cy.request({
            method: 'POST', auth: { bearer: token },
            url: ApiConstants.likePhoto(Cypress.env('apiUrl'), photo_id)
        });
    },
    getARandomPhoto(token){
        return cy.request({
            method: 'GET', auth: { bearer: token },
            url: ApiConstants.getRandomPhoto(Cypress.env('apiUrl'),token)
        });
    },
    getPhotoDownloadLink(token, url){
        return cy.request({
            method: 'GET', auth: { bearer: token },
            url: ApiConstants.getPhotoDownloadLink(url,token)
        });
    }
}
