Feature: PostsService
    In order to test basic functionality
    As a requester
    I want to be correctly responsed

Scenario: Add two numbers
    Given I have entered 50 into the calculator
    And I have entered 70 into the calculator
    When I press add
    Then the result should be 120 on the screen
