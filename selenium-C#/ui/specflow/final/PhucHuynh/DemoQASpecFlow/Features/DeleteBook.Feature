@deleteBook

Feature: Delete book
    User wants to delete book from personal collection
    @focus
    Scenario Outline: User deletes book from personal collection successfully
        Given there is a book named "<bookTitle>" with "<bookIsbn>"
        And the user logs into the application with "<userName>" and "<password>"
        And the user is on the Profile page
        When the user search book "<bookTitle>"
        And the user clicks on Delete icon
        And the user clicks on OK button
        And the user clicks on OK button of alert "<alertMessage>"
        Then the book is not shown
        Examples:
            | Scenario                                                | userName | password       | bookTitle        | bookIsbn      | alertMessage  |
            | User deletes book from personal collection successfully | PKH123   | PKH1234!@#$abc | Git Pocket Guide | 9781449325862 | Book deleted. |