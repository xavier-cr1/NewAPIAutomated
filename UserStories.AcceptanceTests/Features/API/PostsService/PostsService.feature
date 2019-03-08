Feature: PostsService
    In order to test basic functionality
    As a requester
    I want to be correctly responsed

Scenario: Get a owner of the post by id of the last day passed
    Given The user gets a list of posts with the following properties
        | FromDate   | ToDate     | Order | Sort     |
        | 01-03-2019 | 05-03-2019 | desc  | activity |
    And The response code of the post service is '200'
    When The user has the 'id'
    Then The values of this owner are 'asda' 'adsa' 'asdad'
