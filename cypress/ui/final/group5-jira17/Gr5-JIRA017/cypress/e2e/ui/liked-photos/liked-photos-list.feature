Feature: Manage like photos list
@LikePhotos
    Scenario: List of liked photos
    Given I logged into the application    
    And I like 3 random photos
    When I go to likes page
    Then I see the number of likes is 3
    And 3 photos appear in Likes section