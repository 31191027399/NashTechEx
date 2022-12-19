const BTN_USER = 'button[title="Your personal menu button"]'
const BTN_PROFILE = '//a[text()="View profile"]'
const FIRST_IMG ='(//figure[@itemprop="image"])[2]'
const ICON_USER = 'div[data-test="photos-route"] header div:nth-child(1)>span'

export const HomePage = {
    visitProfilePage() {
        cy.visit('/')
        cy.log("Click user button")
        cy.get(BTN_USER).click()
        cy.log("Click user profile")
        cy.xpath(BTN_PROFILE).click()
    },
    clickIMG() {
        cy.wait(2000)
        cy.log("Click First Image")
        cy.xpath(FIRST_IMG).click()
    },
    clickIconUser(){
        cy.log("Click user icon")
        cy.hover(ICON_USER);
    },
    clickButtonFollow(){
        cy.log("Click follow button")
        cy.get('button[title="Follow"]').click()
    }
}

