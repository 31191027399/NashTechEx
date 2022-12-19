Feature: Interaction in photo detail page
    Scenario: Download photo successfully
        Given I logged into the application
        When I open a random photo
        And I download this photo
        Then I notice that the image is downloadable and the correct image has been saved