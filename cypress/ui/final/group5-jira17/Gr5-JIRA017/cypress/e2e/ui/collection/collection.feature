Feature: Manage Collection
    @RemovePhoto
    Scenario: Remove photo from personal collection
        Given There is a private collection "<collectionName>"
        And Photo 1 with "<photoId1>" is in the collection
        And Photo 2 with "<photoId2>" is in the collection
        And I logged into the application
        And I remove photo with "<removedPhotoId>" from the collection
        When I go to the collection page
        Then the photo has been removed successfully from the collection
        And there is only 1 remaining photo with "<remainedPhototId>" in the collection

        Examples:
            | collectionName | photoId1    | photoId2    | removedPhotoId | remainedPhototId |
            | Luonvuituoi    | S_YOuAUMm2o | 3xzsE4QCn5I | 3xzsE4QCn5I    | S_YOuAUMm2o      |