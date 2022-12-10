@addBookToCollection

Feature: Add book to collection
    User wants to add book to personal collection

    Scenario Outline: Add book to personal collection
        Given the user logs into application by "<username>" and "<password>"
        And the user is on Book Store page
        When the user selects a book "<bookTitle>"
        Then an alert "<alertMessage>" is shown
        And "<bookTitle>" is shown in user profile
        Examples:
            | Scenario                            | username | password       | bookTitle        | alertMessage                   |
            | Add book to collection successfully | PKH123   | PKH1234!@#$abc | Git Pocket Guide | Book added to your collection. | 