# 🧪 WebTestingNUnit - www.saucedemo.com

**WebTestingNUnit** is an automated end-to-end testing project built with **.NET, Selenium, and NUnit**. It is designed to test key user interactions with a sample e-commerce application — from login and adding products to the cart, to completing the checkout process.

The project is built using the **Page Object Model (POM)** pattern for scalability and maintainability.

---

## 🚀 Technologies Used

- **C# / .NET**
- **Selenium WebDriver**
- **NUnit** – Testing framework
- **Visual Studio** – Development environment

---

## 📂 Project Structure
- Pages/ # Page Object Model classes (e.g. LoginPage, CartPage)
- Components/ # Reusable components (e.g. LogoutComponent)
- Tests/ # Test scenarios (e.g. TC_001_Login)
- Utils/ # Utility classes (e.g. AssertHelper)
- Base/ # Browser configuration (Chrome, Edge, Headless mode)
- README.md # This file 📄

## ✅ Sample Test Cases

- Valid and invalid login tests
- Adding multiple products to the cart
- Full checkout process with user data entry
- Validation of item total, tax, and final price
- Running tests in **headless mode** (ideal for CI/CD)

---

## 🛠️ How to Run Tests

1. **Clone the repository:**

   ```bash
   git clone https://github.com/your-username/WebTestingNUnit.git
   cd WebTestingNUnit

2. **Open in Visual Studio**
3. **Install dependencies via NuGet:**
- Selenium.WebDriver
- Selenium.Support
- NUnit
4. **Run the tests:**
- From Visual Studio: Test > Run All Tests
- Or from CLI:
```bash
 dotnet test
