# Playwright Project – SauceDemo Automation

Automated UI tests for [SauceDemo](https://www.saucedemo.com)  
using **Playwright with C# and SpecFlow (BDD)**.


##  Project Structure
- **LoginPage.cs / ProductsPage.cs** → Page Object Model (POM) classes  
- **LoginSteps.cs / ProductsSteps.cs** → Step definitions for SpecFlow  
- **Saucedemo.feature** → BDD feature file (login, sorting)  
- **user.cs** → User model (valid & invalid credentials)  
- **SaucedemoTestSuite.csproj** → Test project configuration  
- **README.md** → Project documentation  

---

##  BDD Scenarios
```gherkin
Feature: SauceDemo Automation

  Scenario: Successful login with valid user
    Given I am on the SauceDemo login page
    When I login with valid credentials
    Then I should be redirected to the Products page

  Scenario: Failed login with invalid user
    Given I am on the SauceDemo login page
    When I login with invalid credentials
    Then I should see an error message

  Scenario: Sort products from lowest to highest price
    Given I am logged in as a valid user
    When I sort products from low to high
    Then the products should be displayed in ascending order


