Feature: UsersService
    In order to test basic functionality
    As a requester
    I want to be correctly responsed

#The inname parameter lets consumers filter the results 
#down to just those users with a certain substring in their display name.
#For example, inname=kevin will return all users with both users named simply "Kevin"
#or those with Kevin as one of (or part of) their names; such as "Kevin Montrose".
@Type:AP
Scenario: Expected badges for users filtered by username coincidences at a certain period of time
    Given The user gets a list of users with the following properties
        | FromDate   | ToDate     | Order | Sort       | InName        |
        | 2019-03-04 | 2019-03-05 | desc  | reputation | Pavel Smirnov |
    And The status code of the users service is 'OK'
    Then The amount of bronze badges are '14', silver are '1' and gold are '0'

Scenario: Filtering with non existent username
    Given The user gets a list of users with the following properties
        | FromDate   | ToDate     | Order | Sort       | InName        |
        | 2019-03-04 | 2019-03-05 | desc  | reputation | Pavel Smirnov |
