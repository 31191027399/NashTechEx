import {LIKE_URL} from "../constants/url-constants"
const LB_LIKES_NUMBER ="//span[text()='Likes']/following-sibling::span/span"
const IMG_LIKES = "div[data-test] figure"
export const LikesPage = {
    visit()
    {
        cy.fixture("user_data").then((user) => {
        cy.visit(LIKE_URL.like(user.ValidAccount.username))
        })
    },
    getLikedPhotosCount()
    {
        return cy.xpath(LB_LIKES_NUMBER)
    },
    getPhotosInLikesSection()
    {
      return cy.get(IMG_LIKES)  
    }
}