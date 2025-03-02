using ToyRobotSimulator.Application.Commands;
using ToyRobotSimulator.Domain.Enums;
using ToyRobotSimulator.Domain.Models;

namespace ToyRobotSimulator.Tests.Application.Tests.Commands;

public class MoveCommandTests
{
    [Fact]
    public void Execute_ValidMoveNorth_RobotMoves()
    {
        var robot = new Robot();
        robot.Place(0, 0, Direction.NORTH);
        var command = new MoveCommand();

        command.Execute(robot);

        Assert.Equal(0, robot.X);
        Assert.Equal(1, robot.Y);
    }
}
