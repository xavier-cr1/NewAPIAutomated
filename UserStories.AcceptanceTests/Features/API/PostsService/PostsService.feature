Feature: PostsService
    In order to test basic functionality
    As a requester
    I want to be correctly responsed

Scenario Outline: The first post given by votes and between dates has expected id and owner
    Given The user gets a list of posts with the following properties
        | FromDate   | ToDate   | Order   | Sort   |
        | <fromDate> | <toDate> | <order> | <sort> |
    And The response code of the posts service is '200'
    Then The first post given has the id '<post_id>' and the owner '<userd_id>'

    Examples: 
        | fromDate   | toDate     | order | sort  | post_id  | user_id |
        | 04-03-2019 | 05-03-2019 | desc  | votes | 54992348 | 1048572 |
        | 01-03-2019 | 02-03-2019 | desc  | votes | 54946537 | 1602555 |

Scenario Outline: Get posts with wrong parameter
    Given The user gets a list of posts with the following properties
        | FromDate   | ToDate   | Order   | Sort   |
        | <fromDate> | <toDate> | <order> | <sort> |
    And The response code of the posts service is '400'

    Examples: 
        | fromDate | toDate     | order | sort  |
        | aaaa     | 05-03-2019 | desc  | votes |