# Playwright Project – SauceDemo Automation

Automated UI tests for [SauceDemo](https://www.saucedemo.com)  
Using **Playwright with C# and SpecFlow (BDD)**.


##  Project Structure
- **LoginPage.cs / ProductsPage.cs** → Page Object Model (POM) classes  
- **LoginSteps.cs / ProductsSteps.cs** → Step definitions for SpecFlow  
- **Saucedemo.feature** → BDD feature file (login, sorting)  
- **user.cs** → User model (valid & invalid credentials)  

##  Test Scenarios

The project includes multiple automated scenarios written in **BDD (Gherkin)** format, such as:  
- Valid and invalid login flows  
- Product sorting by price and other criteria  
- Navigation and page validation  
- Error handling and validation messages  
- General user interaction with the platform  

These scenarios ensure both positive and negative paths are covered and can be easily extended for future test cases.

---

##  Run Tests
```bash
dotnet test
