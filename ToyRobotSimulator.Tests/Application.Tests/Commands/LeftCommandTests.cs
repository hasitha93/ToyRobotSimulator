using ToyRobotSimulator.Application.Commands;
using ToyRobotSimulator.Domain.Enums;
using ToyRobotSimulator.Domain.Models;

namespace ToyRobotSimulator.Tests.Application.Tests.Commands;

public class LeftCommandTests
{
    [Fact]
    public void Execute_RobotTurnsWestFromNorth()
    {
        var robot = new Robot();
        robot.Place(0, 0, Direction.NORTH);
        var command = new LeftCommand();

        command.Execute(robot);

        Assert.Equal(Direction.WEST, robot.Facing);
    }
}
