Feature: UsersService
    In order to test basic functionality
    As a requester
    I want to be correctly responsed

@Type:API
Scenario Outline: Expected badges for users filtered by username coincidences at a certain period of time
    Given The user gets a list of users with the following properties
        | FromDate   | ToDate   | Order   | Sort   | InName   |
        | <fromDate> | <toDate> | <order> | <sort> | <inName> |
    And The status code of the users service is 'OK'
    Then The amount of bronze badges are '18', silver are '9' and gold are '2'

    Examples: 
        | fromDate   | toDate     | order | sort       | inName        |
        | 2019-03-04 | 2019-03-05 | desc  | reputation | Pavel Smirnov |

@Type:API
Scenario Outline: Filtering with non existent username
    Given The user gets a list of users with the following properties
        | FromDate   | ToDate   | Order   | Sort   | InName   |
        | <fromDate> | <toDate> | <order> | <sort> | <inName> |
    And The status code of the users service is 'OK'
    Then The users response is empty

    Examples: 
        | fromDate   | toDate     | order | sort       | inName             |
        | 2019-03-04 | 2019-03-05 | desc  | reputation | notexisting_InName |