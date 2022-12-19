@follow
Feature: Follow
    Scenario: Follow a photographer successfully
        Given I logged into the application
        And I click the first photo on home page
        When I hover on icon user at the top left corner
        And I click the Follow button
        Then The button text turn into Following
        And I observe button background color turn into white