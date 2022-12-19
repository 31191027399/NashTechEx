
const TXT_FIRSTNAME = 'input[id="user_first_name"]';
const TXT_LASTNAME = 'input[id="user_last_name"]';
const TXT_EMAIL = 'input[id="user_email"]';
const TXT_USERNAME = 'input[id="user_username"]';
const TXT_LOCATION = 'input[id="user_location"]';
const TXT_PORTFOLIO = 'input[id="user_url"]';
const TXT_BIO = 'textarea[id="user_bio"]';
const TXT_INTEREST = 'input[id="user_interests_tag"]';
const TXT_INSTAGRAM = 'input[id="user_instagram_username"]';
const TXT_TWITTER = 'input[id="twitter_username"]';
const TXT_DONATION = 'input[id="user_paypal"]';
const BTN_UPDATE = 'input[value="Update account"]';
const LBL_UPDATED = 'div[class="flash__message"]';

export const EditProfilePage = {


    
    enterFirstName(firstname) {
        cy.get(TXT_FIRSTNAME).clear().type(firstname);
    },

    enterLastName(lastname) {
        cy.get(TXT_LASTNAME).clear().type(lastname);
    },

    enterEmail(email) {
        cy.get(TXT_EMAIL).clear().type(email);
    },

    enterUsername(username) {
        cy.get(TXT_USERNAME).clear().type(username);
    },

    enterLocation(location) {
        cy.get(TXT_LOCATION).clear().type(location);
    },

    enterPortfolio(portfolio) {
        cy.get(TXT_PORTFOLIO).clear().type(portfolio);
    },

    enterBio(bio) {
        cy.get(TXT_BIO).clear().type(bio);
    },

    enterInterest(interest) {
        cy.get(TXT_INTEREST).clear().type(interest);
    },

    enterInstagram(instagram) {
        cy.get(TXT_INSTAGRAM).clear().type(instagram);
    },

    enterTwitter(twitter) {
        cy.get(TXT_TWITTER).clear().type(twitter);
    },

    enterDonation(donation) {
        cy.get(TXT_DONATION).clear().type(donation);
    },
  
    clickUpdateButton() {
        cy.get(BTN_UPDATE).click();
    },

    checkUpdated() {
        cy.get(LBL_UPDATED).should("have.text", "User Updated!");
    }

}