using ToyRobotSimulator.Application.Commands;
using ToyRobotSimulator.Application.Interfaces;
using ToyRobotSimulator.Domain.Enums;
using ToyRobotSimulator.Domain.Models;
using ToyRobotSimulator.Infrastructure.Parsers;

namespace ToyRobotSimulator.Tests.Infrastructure.Tests;

public class CommandParserTests
{
    [Fact]
    public void Parse_ValidPlaceCommand_ReturnsPlaceCommand()
    {
        var input = "PLACE 0,0,NORTH";
        var robot = new Robot();

        var command = CommandParser.Parse(input);

        Assert.IsType<PlaceCommand>(command);
        if (command is ICommand executableCommand)
        {
            executableCommand.Execute(robot);
            Assert.Equal(0, robot.X);
            Assert.Equal(0, robot.Y);
            Assert.Equal(Direction.NORTH, robot.Facing);
        }
    }

    [Fact]
    public void Parse_InvalidPlaceCommand_ReturnsNull()
    {
        var input = "PLACE 0,0,INVALID";

        var command = CommandParser.Parse(input);

        Assert.Null(command);
    }

    [Fact]
    public void Parse_ValidMoveCommand_ReturnsMoveCommand()
    {
        var input = "MOVE";
        var robot = new Robot();
        robot.Place(0, 0, Direction.NORTH); // Place the robot first

        var command = CommandParser.Parse(input);

        Assert.IsType<MoveCommand>(command);
        if (command is ICommand executableCommand)
        {
            executableCommand.Execute(robot);
            Assert.Equal(0, robot.X);
            Assert.Equal(1, robot.Y); // Robot should move north
        }
    }

    [Fact]
    public void Parse_ValidLeftCommand_ReturnsLeftCommand()
    {
        var input = "LEFT";
        var robot = new Robot();
        robot.Place(0, 0, Direction.NORTH); // Place the robot first

        var command = CommandParser.Parse(input);

        Assert.IsType<LeftCommand>(command);
        if (command is ICommand executableCommand)
        {
            executableCommand.Execute(robot);
            Assert.Equal(Direction.WEST, robot.Facing); // Robot should face west after turning left
        }
    }

    [Fact]
    public void Parse_ValidRightCommand_ReturnsRightCommand()
    {
        var input = "RIGHT";
        var robot = new Robot();
        robot.Place(0, 0, Direction.NORTH); // Place the robot first

        var command = CommandParser.Parse(input);

        Assert.IsType<RightCommand>(command);
        if (command is ICommand executableCommand)
        {
            executableCommand.Execute(robot);
            Assert.Equal(Direction.EAST, robot.Facing); // Robot should face east after turning right
        }
    }

    [Fact]
    public void Parse_ValidReportCommand_ReturnsReportCommand()
    {
        var input = "REPORT";
        var robot = new Robot();
        robot.Place(1, 2, Direction.EAST); // Place the robot first

        var command = CommandParser.Parse(input);

        Assert.IsType<ReportCommand>(command);
        if (command is IReport reportableCommand)
        {
            var report = reportableCommand.GetReport(robot);
            Assert.Equal("1, 2, EAST", report); // Robot should report its position and facing direction
        }
    }

    [Fact]
    public void Parse_InvalidCommand_ReturnsNull()
    {
        var input = "INVALID";

        var command = CommandParser.Parse(input);

        Assert.Null(command);
    }
}
