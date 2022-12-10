@searchBook

Feature: Search book with multiple results
    User wants to Search book with multiple results

    Scenario Outline: Search book with multiple results
        Given there are books named "<bookTitles>"
        And the user is on the Book Store page
        When the user inputs book name "<searchText>"
        Then all books match with "<searchText>"  will be displayed
        Examples:
            | Scenario                          | bookTitles                                                                     | searchText |
            | Search book with multiple results | Learning JavaScript Design Patterns, Designing Evolvable Web APIs with ASP.NET | design     |
