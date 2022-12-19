const BTN_FOLLOW ='button[title="Follow"]'
const BTN_FOLLOWING ='button[title="Following"]'
export const PhotographerPage = {
    clickFollow(){
        cy.get(BTN_FOLLOW).click()
    },
    getBtnFollowing(){
        return cy.get(BTN_FOLLOWING)
    },
    clickFollowing(){
        cy.get(BTN_FOLLOWING).click()
    }
}