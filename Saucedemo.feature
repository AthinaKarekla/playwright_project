Feature: Login and sort products on SauceDemo

  Scenario: Successful login with valid user
    Given the user navigates to the saucedemo site
    When a valid user logs in
    Then the user should see the products page

  Scenario: Failed login with invalid user
    Given the user navigates to the saucedemo site
    When an invalid user logs in
    Then the user should see an error message

  Scenario: Sort products by price from low to high
    Given the user navigates to the saucedemo site
    When a valid user logs in
    And the user sorts products by price from low to high
    Then the products should be sorted in ascending order

   Scenario: Sort products by price descending
    Given the user navigates to the saucedemo site
    When a valid user logs in
    And the user sorts products by price from high to low
    Then the products should be sorted in descending order
