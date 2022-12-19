// ***********************************************
// This example commands.js shows you how to
// create various custom commands and overwrite
// existing commands.
//
// For more comprehensive examples of custom
// commands please read more here:
// https://on.cypress.io/custom-commands
// ***********************************************
//
//
// -- This is a parent command --
// Cypress.Commands.add('login', (email, password) => { ... })
//
//
// -- This is a child command --
// Cypress.Commands.add('drag', { prevSubject: 'element'}, (subject, options) => { ... })
//
//
// -- This is a dual command --
// Cypress.Commands.add('dismiss', { prevSubject: 'optional'}, (subject, options) => { ... })
//
//
// -- This will overwrite an existing command --
// Cypress.Commands.overwrite('visit', (originalFn, url, options) => { ... })

import { LoginPage } from "../page-objects/login-page.js";
Cypress.Commands.add("login", function (email, password) {
  cy.session([email, password], function () {
    LoginPage.visitLoginPage();
    LoginPage.fillEmail(email);
    LoginPage.fillPassword(password);
    LoginPage.clickLogin();
  });
  cy.visit("/")
  
});

Cypress.Commands.add("hover", function (element) {
  cy.get(element).rightclick()
});
require('cypress-downloadfile/lib/downloadFileCommand');
