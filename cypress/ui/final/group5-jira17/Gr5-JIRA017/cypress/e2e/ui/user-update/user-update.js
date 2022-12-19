import { HomePage } from "../../../page-objects/home-page";
import { ProfilePage } from "../../../page-objects/profile-page";
import { EditProfilePage } from "../../../page-objects/edit-profile-page";
import { Given, When, Then } from "@badeball/cypress-cucumber-preprocessor";

Given("I go to the Profile page", () => {
  HomePage.visitProfilePage();
});

Given("I click Edit tags link", () => {
  ProfilePage.clickEditProfile();
});

Given("I enter first name is {string}", (FirstName) => {
  EditProfilePage.enterFirstName(FirstName);
});

Given("I enter last name is {string}", (lastname) => {
  EditProfilePage.enterLastName(lastname);
});

Given("I enter email is {string}", (email) => {
  EditProfilePage.enterEmail(email);
});

Given("I enter username is {string}", (username) => {
  EditProfilePage.enterUsername(username);
});

Given("I enter location is {string}", (location) => {
  EditProfilePage.enterLocation(location);
});

Given("I enter portfolio is {string}", (portfolio) => {
  EditProfilePage.enterPortfolio(portfolio);
});

Given("I enter bio is {string}", (bio) => {
  EditProfilePage.enterBio(bio);
});

Given("I enter interest is {string}", (interest) => {
  EditProfilePage.enterInterest(interest);
});

Given("I enter instagram is {string}", (instagram) => {
  EditProfilePage.enterInstagram(instagram);
});

Given("I enter twitter is {string}", (twitter) => {
  EditProfilePage.enterTwitter(twitter);
});

Given("I enter donation is {string}", (donation) => {
  EditProfilePage.enterDonation(donation);
});

Given("I click the Update Account button", () => {
  EditProfilePage.clickUpdateButton();
});

When("I go to Profile page with new username {string}", (username) => {
  cy.visit(`https://unsplash.com/@${username}`);
});

Then("I observe that it will take me to the Profile page", () => {
  ProfilePage.getProfilePageName().should('be.visible');
  ProfilePage.getEditButton().should('be.visible');
  ProfilePage.getLikesButton().should('be.visible');
  ProfilePage.getPhotosButton().should('be.visible');
  ProfilePage.getStatsButton().should('be.visible');
  ProfilePage.getCollectionButton().should('be.visible');
});

Then("My full name is displayed as {string}", (fullname) => {
  ProfilePage.getProfilePageName().should("have.text", fullname);
});
