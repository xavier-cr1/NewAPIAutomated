Feature: PostsService
    In order to test basic functionality
    As a requester
    I want to be correctly responsed

@Type:API
Scenario Outline: The first post given by votes and between dates has expected id and owner
    Given The user gets a list of posts with the following properties
        | FromDate   | ToDate   | Order   | Sort   |
        | <fromDate> | <toDate> | <order> | <sort> |
    And The status code of the posts service is 'OK'
    Then The first post given has the id '<post_id>' and the owner '<userd_id>'

    Examples: 
        | fromDate   | toDate     | order | sort  | post_id  | user_id |
        | 2019-03-04 | 2019-03-05 | desc  | votes | 54992348 | 1048572 |
        | 2019-03-01 | 2019-03-02 | desc  | votes | 54946537 | 1602555 |

@Type:API
Scenario Outline: Get posts with wrong parameter
    Given The user gets a list of posts with the following properties
        | FromDate   | ToDate   | Order   | Sort   |
        | <fromDate> | <toDate> | <order> | <sort> |
    And The status code of the posts service is 'Bad Request'

    Examples: 
        | fromDate | toDate     | order | sort  |
        | aaaa     | 2019-03-05 | desc  | votes |