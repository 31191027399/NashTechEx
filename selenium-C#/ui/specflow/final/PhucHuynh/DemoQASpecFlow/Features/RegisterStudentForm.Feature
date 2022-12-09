@registerStudentForm

Feature: Register Student Form
    User want to Register a new student

    Scenario Outline: Register student form successfully
        Given User is on Student Registration Form
        When the user input valid data into all fields
            | Field          | Value            |
            | firstName      | <firstName>      |
            | lastName       | <lastName>       |
            | email          | <email>          |
            | gender         | <gender>         |
            | mobile         | <mobile>         |
            | dateOfBirth    | <dateOfBirth>    |
            | subjects       | <subjects>       |
            | hobbies        | <hobbies>        |
            | picture        | <picture>        |
            | currentAddress | <currentAddress> |
            | state          | <state>          |
            | city           | <city>           |
        And the user clicks on Submit button
        Then a successful message is shown
        And all information of the student form is shown correctly
            | Field          | Value            |
            | firstName      | <firstName>      |
            | lastName       | <lastName>       |
            | email          | <email>          |
            | gender         | <gender>         |
            | mobile         | <mobile>         |
            | dateOfBirth    | <dateOfBirth>    |
            | subjects       | <subjects>       |
            | hobbies        | <hobbies>        |
            | picture        | <picture>        |
            | currentAddress | <currentAddress> |
            | state          | <state>          |
            | city           | <city>           |
        Examples:
            | Scenario                                           | firstName | lastName | email          | gender | mobile     | dateOfBirth      | subjects         | hobbies         | picture   | currentAddress | state | city  |
            | Register student form with all fields successfully | Phuc      | Huynh    | zsad@gmail.com | Male   | 0123456789 | 08 December,2001 | Maths, Chemistry | Sports, Reading | image.jpg | 45 Bahama      | NCR   | Noida |
            | Register student form with required fields only    | Phuc      | Huynh    |                | Male   | 0123456789 |                  |                  |                 |           |                |       |       |