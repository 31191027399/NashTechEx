import { ProfilePage } from "../../../page-objects/profile-page.js";
import { Given, When, Then, Before, afterRunHandler, After } from "@badeball/cypress-cucumber-preprocessor";
import { HomePage } from "../../../page-objects/home-page.js";
import { CollectionService } from "../../../services/collection-service";
import { PhotoService } from "../../../services/photo-service";
import { CollectionPage } from "../../../page-objects/collection-page.js";
import { COLLECTION_URL } from "../../../constants/url-constants";

let deletedImageId;
let chosenCollectionName;
let collectionId;
let token;


After({ tags: "@RemovePhoto" },function(){
    cy.fixture("user_data").then(function (userFixture) {
        cy.get("@collection_info").then(function(collectionFixture){
            CollectionService.deleteCollection(collectionFixture.body.id,userFixture.ValidAccount.access_token)
        })
        })
})
Given("There is a private collection {string}", (collectionName) => {
    cy.fixture("user_data").then(function (userInfo) {
        token = userInfo.ValidAccount.access_token,
            chosenCollectionName = collectionName,
            CollectionService.addCollection(collectionName,token).as('collection_info')
    })
})
Given("Photo 1 with {string} is in the collection", (photoId) => {
    cy.get("@collection_info").then((collectionInfo) => {
        collectionId = collectionInfo.body.id,
            PhotoService.addPhoto(collectionId, photoId, token)
    })
})
Given("Photo 2 with {string} is in the collection", (photoId) => {
    PhotoService.addPhoto(collectionId, photoId, token)
})


Given("I remove photo with {string} from the collection", (removedPhotoId) => {
    deletedImageId=removedPhotoId,
    HomePage.visitProfilePage(),
    ProfilePage.clickOnBtnCollections(),
    ProfilePage.clickOnSpecificCollection(chosenCollectionName),
    CollectionPage.clickOnSpecificImage(removedPhotoId),
    CollectionPage.clickOnBtnAddToCollection(),
    CollectionPage.deleteImageFromSpecificCollection(chosenCollectionName)
})

When("I go to the collection page", () => {
    cy.visit(COLLECTION_URL.specificCollection(collectionId))
});

Then("the photo has been removed successfully from the collection", () => {
    CollectionPage.getAnImage(deletedImageId).should('not.exist')
})

Then("there is only 1 remaining photo with {string} in the collection", (remainedPhototId) => {
    CollectionPage.getAnImage(remainedPhototId).should('exist');
    CollectionPage.getNumberOfImages().should('have.length',1)
})







