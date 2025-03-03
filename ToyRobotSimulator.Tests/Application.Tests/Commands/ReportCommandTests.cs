using ToyRobotSimulator.Application.Commands;
using ToyRobotSimulator.Domain.Enums;
using ToyRobotSimulator.Domain.Models;

namespace ToyRobotSimulator.Tests.Application.Tests.Commands;

public class ReportCommandTests
{
    [Fact]
    public void Execute_RobotPlaced_ReturnsCorrectPositionAndFacing()
    {
        var robot = new Robot();
        robot.Place(1, 2, Direction.EAST);
        var command = new ReportCommand();

        var result = command.GetReport(robot);

        Assert.Equal($"1, 2, {Direction.EAST}", result);
    }
}
