import {LikesPage} from "../../../page-objects/likes-page"
import {PhotoService} from "../../../services/photo-service"
import { Given, When, Then,Before} from "@badeball/cypress-cucumber-preprocessor";
Before({ tags: "@LikePhotos" },()=>{
    cy.fixture("user_data").then((user)=> {
        PhotoService.getLikedPhotos(user.ValidAccount.username,user.ValidAccount.access_token)
        .then((response)=> {
          response.body.forEach((photo)=>{
            PhotoService.unlikePhoTo(photo.id,user.ValidAccount.access_token)
          })  
        });
    })
})
Given("I like {int} random photos", (photoCount) => {
    cy.fixture("user_data").then((user)=>{
        PhotoService.randomPhoto(photoCount,user.ValidAccount.access_token)
        .then((response)=>{
            response.body.forEach((photo)=>{
            PhotoService.likePhoto(photo.id,user.ValidAccount.access_token)
            })
        })
    })
      
});
When("I go to likes page",()=>{
    cy.fixture("user_data").then((user)=>{
        LikesPage.visit(user.ValidAccount.username)
    })
})
Then("I see the number of likes is {int}",(photo_count) => {
    LikesPage.getLikedPhotosCount().should("have.text",photo_count)
})
Then("{int} photos appear in Likes section",(photo_count) => {
    LikesPage.getPhotosInLikesSection().should("have.length",photo_count)
})


