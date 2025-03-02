using ToyRobotSimulator.Application.Commands;
using ToyRobotSimulator.Domain.Enums;
using ToyRobotSimulator.Domain.Models;

namespace ToyRobotSimulator.Tests.Application.Tests.Commands;

public class RightCommandTests
{
    [Fact]
    public void Execute_RobotTurnsEastFromNorth()
    {
        var robot = new Robot();
        robot.Place(0, 0, Direction.NORTH);
        var command = new RightCommand();

        command.Execute(robot);

        Assert.Equal(Direction.EAST, robot.Facing);
    }
}
