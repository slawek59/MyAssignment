# MyAssignment

Automated Testing project. 

Task description Launch URL: https://www.saucedemo.com/

UC-1 Test Login form with empty credentials: Type any credentials into "Username" and "Password" fields. Clear the inputs. Hit the "Login" button. Check the error messages: "Username is required".

UC-2 Test Login form with credentials by passing Username: Type any credentials in username. Enter password. Clear the "Password" input. Hit the "Login" button. Check the error messages: "Password is required".

UC-3 Test Login form with credentials by passing Username & Password: Type credentials in username which are under Accepted username are sections. Enter password as secret sauce. Click on Login and validate the title “Swag Labs” in the dashboard. Provide parallel execution, add logging for tests and use Data Provider to parametrize tests.

- Parametrized and parallel testing;
- Supports multiple browsers (Chrome as default, Firefox, Edge);
- Using Selenium;
- Using MSTests;
- Using Fluent Assertions;
- Following Page Object Model design pattern.
  
