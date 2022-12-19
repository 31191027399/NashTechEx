import { Given, When, Then } from "@badeball/cypress-cucumber-preprocessor";
import { PhotoDetailPage } from "../../../page-objects/photodetail-page";
import { PhotoService } from "../../../services/photo-service";


let token;
When('I open a random photo', () => {
    cy.fixture("user_data").then(function (userInfo) {
        token = userInfo.ValidAccount.access_token;
        PhotoService.getARandomPhoto(token).as('imageInfo')
    })
    cy.get('@imageInfo').then((imageInfo) => {
        PhotoDetailPage.visitPhoto(imageInfo.body.id);
    })
})
When('I download this photo', () => {
    PhotoDetailPage.downloadPhotoByUI()
})

Then('I notice that the image is downloadable and the correct image has been saved', () => {
    cy.get('@imageInfo').then((imageInfo) => {
        PhotoService.getPhotoDownloadLink(token, imageInfo.body.links.download_location).then((downloadLink) => {
            PhotoDetailPage.downloadPhotoWithAPILink(downloadLink.body.url)
            //Download using link get by API to compared with image which downloaded by UI
        })
        PhotoDetailPage.readPhotoDownloadedWithAPILink().then((image)=>{
            PhotoDetailPage.readPhotoDownLoadedByUI(imageInfo.body.user.name, imageInfo.body.id).should('equal',image)
        })
        //Assertion is not completed because this is not an optimal way to compare image

        //PhotoDetailPage.checkThatCorrectImageIsDownloaded(imageInfo.body.user.name, imageInfo.body.id);
        //=> Func is commented because Plugin @cy-verify-downloads is unusable,
        //  issues occured in nodes_modules/cy-verify-downloads/index.js row 1->3
    })
})