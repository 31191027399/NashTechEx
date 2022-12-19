const BTN_ADDTOCOLLECTIONS ='div[data-test="photos-route"] button[title="Add to collection"]'
const LNK_IMAGE ='figure[itemprop="image"]'
function getSpecificImageLocator(imageId)
{
    const LNK_SPECIFICIMAGE = `a[href="/photos/${imageId}"]`
    return LNK_SPECIFICIMAGE
}
function getSpecificCollectionLocator(collectionName)
{
    const BTN_SPECIFICCOLLECTION =  `//span[text()="${collectionName}"]/./ancestor::button`
    return BTN_SPECIFICCOLLECTION
}

export const CollectionPage = {
    clickOnSpecificImage(imageId){
        cy.get(getSpecificImageLocator(imageId)).click()
    },
    clickOnBtnAddToCollection(){
        cy.get(BTN_ADDTOCOLLECTIONS).click()
    },
    deleteImageFromSpecificCollection(collectionName){
        cy.xpath(getSpecificCollectionLocator(collectionName)).click()
    },
    getAnImage(imageId){
        return cy.get(getSpecificImageLocator(imageId))
    },
    getNumberOfImages(){
       return cy.get(LNK_IMAGE)
    }
}



