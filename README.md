# Toy Robot Simulator
This is a **Toy Robot Simulator** application built using **Clean Architecture** and the **Command Design Pattern**. The application simulates a toy robot moving on a 5x5 grid tabletop. Users can issue commands to place, move, rotate, and report the robot's position.

## Project Structure
The project follows **Clean Architecture**, which separates the application into distinct layers:

### 1. Domain Layer
- Contains the core business logic and entities.
- [Robot.cs](ToyRobotSimulator.Domain/Models/Robot.cs) represents the toy robot and encapsulates its state (position, facing direction) and behavior (move, rotate, report).
- [Direction.cs](ToyRobotSimulator.Domain/Enums/Direction.cs) defines the Direction enum (`NORTH`, `EAST`, `SOUTH`, `WEST`).

### 2. Application Layer
- Contains the application's use cases and commands.
- [Commands](ToyRobotSimulator.Application/Commands) contains the command classes (`PlaceCommand`, `MoveCommand`, `LeftCommand`, `RightCommand`, `ReportCommand`) that implement the `ICommand` or `IReport` interfaces.
- [Interfaces](ToyRobotSimulator.Application/Interfaces) contains the interfaces (`IBaseCommand`, `ICommand`, `IReport`) that define the contract for commands and reporting.

### 3. Infrastructure Layer
- Handles external concerns like parsing user input.
- [CommandParser.cs](ToyRobotSimulator.Infrastructure/Parsers/CommandParser.cs) parses user input into command objects.

### 4. Presentation Layer
- Handles user interaction.
- [Program.cs](ToyRobotSimulator.ConsoleApp/Program.cs) is the entry point of the application. It reads user input, parses it into commands, and executes them.

### 5. Tests
- Contains unit tests for the application.
- [ToyRobotSimulator.Tests](ToyRobotSimulator.Tests) contains tests for the `Robot` class and command classes.


## Command Design Pattern
The application uses the **Command Design Pattern** to encapsulate each command (PLACE, MOVE, LEFT, RIGHT, REPORT) as an object. This pattern allows us to:
1. **Decouple the command execution logic** from the main program.
2. **Easily extend the application** by adding new commands without modifying existing code.
3. **Support undo/redo functionality** (if needed in the future).

### Key Components of the Command Pattern
1. [ICommand](ToyRobotSimulator.Application/Interfaces/ICommand.cs) **Interface**: Defines the `Execute` method that all commands must implement.
2. [IReport](ToyRobotSimulator.Application/Interfaces/IReport.cs) **Interface**: Defines the `GetReport` method for commands that generate output (e.g., `ReportCommand`).

## How It Works
### 1. PLACE X,Y,FACING:
- Places the robot on the table at position `(X, Y)` facing `NORTH`, `SOUTH`, `EAST`, or `WEST`.
- Example: `PLACE 0,0,NORTH`

### 2. MOVE:
- Moves the robot one unit in the direction it is currently facing.
- Example: `MOVE`

### 3. LEFT:
- Rotates the robot 90° anticlockwise.
- Example: `LEFT`

### 4. RIGHT:
- Rotates the robot 90° clockwise.
- Example: `RIGHT`

### 5. REPORT:
- Outputs the robot's current position and facing direction.
- Example: `REPORT` => Output: `0, 0, NORTH`


## Example Usage
Input:
```
PLACE 0,0,NORTH
MOVE
REPORT
```

Output:
```
0, 1, NORTH
```

## Running the Application
1. Clone the repository:
```bash
git clone https://github.com/hasitha93/ToyRobotSimulator.git
```

2. Navigate to the `ToyRobotSimulator.ConsoleApp` folder:
```bash
cd ToyRobotSimulator/ToyRobotSimulator.ConsoleApp
```

3. Run the application:
```bash
dotnet run
```

4. Enter commands like PLACE 0,0,NORTH, MOVE, LEFT, RIGHT, and REPORT to control the robot.


## Running the Tests
1. Navigate to the `ToyRobotSimulator.Tests` folder:
```bash
cd ToyRobotSimulator/ToyRobotSimulator.Tests
```

2. Run the tests:
```bash
dotnet test
```

## Key Features
1. **Clean Architecture**: The application is divided into layers (`Domain`, `Application`, `Infrastructure`, `Presentation`) to ensure separation of concerns and maintainability.
2. **Command Design Pattern**: Each command is encapsulated as an object, making the code modular and extensible.
3. **Validation**: The robot is prevented from falling off the table. Invalid commands are ignored.
4. **Unit Tests**: Comprehensive unit tests ensure the application behaves as expected.
