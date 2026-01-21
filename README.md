# ♟️ Console Chess (C#)

A complete chess game system developed in C# and .NET, running directly in the console. This project focuses on the practical application of **Programming Logic** and **Object-Oriented Programming (OOP)**, implementing all official game rules.

## 📋 About the Project

This is a console-based application that simulates a chess match. The main goal was to build a robust architecture capable of validating complex moves and managing the match state turn by turn.

The system handles exceptions to prevent illegal moves and ensures strict adherence to chess rules.

## ⚙️ Features and Implemented Rules

The game goes beyond basic movement, supporting special moves and critical state detection:

* **Turn System:** Automatic control of current player (White/Black).
* **Color Handling:**
    * White Pieces: Displayed in **White**.
    * Black Pieces: Displayed in **Yellow** (for better visibility on dark terminals).
* **Special Moves:**
    * ✅ **Castling:** Kingside and Ladyside.
    * ✅ **En Passant:** Special pawn capture.
    * ✅ **Promotion:** Pawn transformation upon reaching the last rank.
* **Game States:** Automatic detection of **Check** and **Checkmate**, ending the match when necessary.

## 📂 Project Structure

The project is organized into two main layers to ensure separation of concerns:

* **Board Layer:** Handles the generic logic of the board, pieces, and positioning (reusable for other board games).
* **Chess Layer:** Implements specific chess rules, special moves, and match logic.

## 🛠 Technologies and Concepts

* **C#**
* **.NET**
* **OOP:** Encapsulation, Inheritance, Polymorphism, and Overloading.
* **Matrices:** 2D grid positioning logic.
* **Exception Handling:** Shielding against invalid user inputs.

## 🚀 How to Run

Prerequisite: **.NET SDK** installed.

1. **Clone the repository:**
   ```bash
   git clone: https://github.com/montenegro04/GameChessproject
    ```
2.  **Navigate to the project folder:**
    ```bash
    cd GameChessproject
    ```
3.  **Run the application:**
    ```bash
    dotnet run
    ```
## 👨‍💻 Author

**Gustavo Palmeira Montenegro**
Control and Automation Engineering Student - UFPel

## 🔮 Future Improvements

* [ ] Implement a simple AI to play against the computer.
* [ ] Add a "graveyard" feature to visualize captured pieces.
* [ ] Create a match Save/Load system.
* [ ] Develop a graphical Web UI using HTML, CSS, and JavaScript.