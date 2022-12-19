import { Given, When,After, Then } from "@badeball/cypress-cucumber-preprocessor";
import { HomePage } from "../../../page-objects/home-page";
import { PhotographerPage } from "../../../page-objects/photographer-page";
import { CollectionService } from "../../../services/collection-service";
import { PhotoService } from "../../../services/photo-service";
import { CollectionPage } from "../../../page-objects/collection-page";
import { COLLECTION_URL } from "../../../constants/url-constants";

Given("I click the first photo on home page", () => {
    HomePage.clickIMG()
})
When("I hover on icon user at the top left corner",()=>{
    HomePage.clickIconUser()
})
When("I click the Follow button",()=>{
    HomePage.clickButtonFollow()
})
Then("I observe button background color turn into white",()=>{
    PhotographerPage.getBtnFollowing()
        .should("have.css","background-color")
        .and('eq', 'rgb(238, 238, 238)')
})
Then("The button text turn into Following",()=>{
    PhotographerPage.getBtnFollowing().should("be.visible")
})
After({ tags: '@follow' }, function () {
    PhotographerPage.clickFollowing()
});
