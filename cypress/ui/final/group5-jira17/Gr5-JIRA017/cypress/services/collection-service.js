import { ApiConstants } from "../constants/api-constant";

export const CollectionService = {
    addCollection(title,token) {
        return cy.request({
            method: 'POST', auth: { bearer: token },
            url: ApiConstants.postCollection(Cypress.env('apiUrl'),title)
        });
    },
    deleteCollection(collectionId,token) {
        return cy.request({
            method: 'DELETE', auth: { bearer: token },
            url: ApiConstants.deleteCollection(Cypress.env('apiUrl'),collectionId)
        });
    }
}