const BTN_COLLECTIONS ='//span[text()="Collections"]'
const LBL_USER = '//div[text()][following-sibling::div//a[text()="Edit profile"]]'
const BTN_EDIT = '//a[text()="Edit profile"]'
const BTN_PHOTOS = '//span[text()="Photos"]'
const BTN_LIKES = '//span[text()="Likes"]'
const BTN_STATS = '//span[text()="Stats"]'
function getSpecificCollectionLocator(collectionName)
{
    const LNK_SPECIFICCOLLECTION =  `//div[text()="${collectionName}"]/ancestor::div[@data-test='collection-feed-card']`
    return LNK_SPECIFICCOLLECTION;
}
export const ProfilePage = {
    clickOnBtnCollections(){
        cy.xpath(BTN_COLLECTIONS).click()
    },

    getProfilePageName() {
        return cy.xpath(LBL_USER)
    },
    getEditButton(){
        return cy.xpath(BTN_EDIT)
    },
    getCollectionButton(){
        return cy.xpath(BTN_COLLECTIONS)
    },
    getPhotosButton(){
        return cy.xpath(BTN_PHOTOS)
    },
    getLikesButton(){
        return cy.xpath(BTN_LIKES)
    },
    getStatsButton(){
        return cy.xpath(BTN_STATS)
    },
    clickEditProfile() {
        cy.xpath(BTN_EDIT).click()
    },
    clickOnSpecificCollection(collectionName){
        cy.xpath(getSpecificCollectionLocator(collectionName)).click();
    }

}


