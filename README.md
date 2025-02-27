# Old Phone Pad Coding Challenge

## Overview
This project simulates text input using an old mobile phone, where multiple keypresses determine the selected letter. It includes a console-based application and NUnit tests for validation.

## How It Works
- The program interprets number key presses based on mobile text input rules.
- The user enters a sequence ending with `#`.
- `*` is used to delete the last entered character.

## Setup & Installation
### 1. Clone the Repository
```sh
git clone https://github.com/amd23/IronCodingChallenge.git
cd OldPhonePadCodingChallenge
```
### 2. Open in Visual Studio
- Open `OldPhonePadCodingChallenge.sln` in Visual Studio.
- Ensure the project targets **.NET Framework 4.8**.

### 3. Install Dependencies
Open **NuGet Package Manager** for the test project and install:
```sh
Install-Package NUnit
Install-Package NUnit3TestAdapter
```
---

## Running the Application
- Run the **OldPhonePadCodingChallenge** project.
- Enter an input string ending with `#`.
- The program will process and display the corresponding text.

---

## Unit Testing

### Running Tests
- Open **Test Explorer** in Visual Studio.
- Click **Run All** to execute all tests.

---

## Contributing
Contributions are welcome! Feel free to:
- Open issues for **bug reports** or **feature requests**.
- Submit **pull requests** with improvements.

