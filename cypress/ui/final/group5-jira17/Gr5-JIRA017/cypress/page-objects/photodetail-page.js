const BTN_DOWNLOAD ='//span[text()="Download"]/..'
function getDownloadedFileName(fullName, imageId)
{
    let user='';
    const array =fullName.toLowerCase().split(' ');
    for(let i=0; i<array.length;i++)
    {
        user= user + array[i] +'-'
    }
    const FILENAME =`cypress/downloads/${user}${imageId}-unsplash.jpg`;
    return FILENAME;
}
export const PhotoDetailPage = {
    visitPhoto(photoId) {
        cy.visit(`/photos/${photoId}`)
    },
    downloadPhotoByUI() {
        cy.xpath(BTN_DOWNLOAD).click()
    },
    downloadPhotoWithAPILink(downloadLink)
    {
        cy.downloadFile(downloadLink,'cypress/downloads','expected-photo.jpg')
    },
    readPhotoDownLoadedByUI(fullName, imageId)
    {
        return cy.readFile(getDownloadedFileName(fullName, imageId))
    },
    readPhotoDownloadedWithAPILink()
    {
        return cy.readFile('cypress/downloads/expected-photo.jpg')
    },
    checkThatCorrectImageIsDownloaded(fullname, imageId)
    {
        cy.verifyDownload(getDownloadedFileName(fullname, imageId))
    }
}