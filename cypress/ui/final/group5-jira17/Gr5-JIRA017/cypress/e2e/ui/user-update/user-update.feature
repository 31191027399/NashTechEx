Feature: Update user in Unsplash
    As a user
    I want to update my information in Unsplash
    Scenario: Update the user in the Profile page
        Given I logged into the application
        And I go to the Profile page
        And I click Edit tags link
        And I enter first name is "<FirstName>"
        And I enter last name is "<LastName>"
        And I enter email is "<Email>"
        And I enter username is "<Username>"
        And I enter location is "<Location>"
        And I enter portfolio is "<Portfolio>"
        And I enter bio is "<Bio>"
        And I enter interest is "<Interest>"
        And I enter instagram is "<Instagram>"
        And I enter twitter is "<Twitter>"
        And I enter donation is "<Donation>"
        And I click the Update Account button
        When I go to Profile page with new username "<Username>"
        Then I observe that it will take me to the Profile page
        And My full name is displayed as "<FullName>"

        Examples:
            | FirstName | LastName | Email                   | Username        | Location | Portfolio                     | Bio       | Interest | Instagram | Twitter  | Donation | FullName    |
            | Phúc      | Huỳnh    | phuchuynh6501@gmail.com | phuchuynh060501 | HCM City | https://cmtchuong.netlify.app | a cabbage | suffer   | hhp0605   | hph06050 | hhppp    | Phúc Huỳnh  |