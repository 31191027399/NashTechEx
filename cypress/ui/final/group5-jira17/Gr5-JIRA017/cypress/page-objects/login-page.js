const TXTEMAIL = 'input[id="user_email"]'
const TXTPASSWORD = 'input[id="user_password"]'
const BTNLOGIN = 'input[value="Login"]'

export const LoginPage = {
    visitLoginPage() {
        cy.visit('/login')
    },

    fillEmail(email) {
        cy.get(TXTEMAIL).type(email)
    },

    fillPassword(password) {
        cy.get(TXTPASSWORD).type(password)
    },

    clickLogin() {
        cy.get(BTNLOGIN).click()
    }
}
