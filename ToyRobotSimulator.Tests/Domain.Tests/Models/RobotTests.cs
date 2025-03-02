using ToyRobotSimulator.Domain.Enums;
using ToyRobotSimulator.Domain.Models;
using Xunit;

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

    [Theory]
    [InlineData(-1, 5, Direction.NORTH)]
    [InlineData(5, 6, Direction.SOUTH)]
    public void Place_InvalidPosition_RobotIsNotPlaced(int x, int y, Direction facing)
    {
        var robot = new Robot();

        robot.Place(x, y, facing);

        Assert.False(robot.IsPlaced);
    }

    [Fact]
    public void Move_ValidMoveNorth_PositionUpdated()
    {
        var robot = new Robot();

        robot.Place(0, 0, Direction.NORTH);
        robot.Move();

        Assert.Equal(0, robot.X);
        Assert.Equal(1, robot.Y);
    }

    [Fact]
    public void Move_InvalidMoveSouth_RobotDoesNotFall()
    {
        var robot = new Robot();

        robot.Place(0, 0, Direction.SOUTH);
        robot.Move();

        Assert.Equal(0, robot.X);
        Assert.Equal(0, robot.Y);
    }

    [Fact]
    public void Left_RobotTurnsWestFromNorth()
    {
        var robot = new Robot();

        robot.Place(0, 0, Direction.NORTH);
        robot.Left();

        Assert.Equal(Direction.WEST, robot.Facing);
    }

    [Fact]
    public void Right_RobotTurnsEastFromNorth()
    {
        var robot = new Robot();
        robot.Place(0, 0, Direction.NORTH);
        robot.Right();

        Assert.Equal(Direction.EAST, robot.Facing);
    }

    [Fact]
    public void Report_RobotPlaced_ReturnsCorrectPositionAndFacing()
    {
        var robot = new Robot();

        robot.Place(1, 2, Direction.EAST);
        var report = robot.Report();

        Assert.Equal("1, 2, EAST", report);
    }
}
