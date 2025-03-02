using ToyRobotSimulator.Domain.Enums;
using ToyRobotSimulator.Domain.Models;

namespace ToyRobotSimulator.Tests.Domain.Tests.Models;

public class RobotTests
{
    [Fact]
    public void Place_ValidPosition_RobotIsPlaced()
    {
        var robot = new Robot();

        robot.Place(0, 0, Direction.NORTH);

        Assert.True(robot.IsPlaced);
        Assert.Equal(0, robot.X);
        Assert.Equal(0, robot.Y);
        Assert.Equal(Direction.NORTH, robot.Facing);
    }
}
