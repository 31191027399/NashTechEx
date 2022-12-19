import { Given } from "@badeball/cypress-cucumber-preprocessor";

Given("I logged into the application", () => {

    cy.fixture("user_data").then(function (userFixture) {
        cy.login(userFixture.ValidAccount.email, userFixture.ValidAccount.password);
    })
});
