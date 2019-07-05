Feature: Appium android search
    In order to test search functionality in stackoverflow app
    As an user
    I want to be correctly responsed

@Type:AppiumAndroid
Scenario Outline: Question tags of all entrances are equal to user typed value into search input
    Given The user types the text value '<tag>' into search input
    #need add find by in apk
    Then All presented entrances have the tag '<tag>'

     Examples:
         | tag |
         | c#  |
