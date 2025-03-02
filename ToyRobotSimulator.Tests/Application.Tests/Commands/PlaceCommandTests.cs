using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToyRobotSimulator.Application.Commands;
using ToyRobotSimulator.Domain.Enums;
using ToyRobotSimulator.Domain.Models;

namespace ToyRobotSimulator.Tests.Application.Tests.Commands;

public class PlaceCommandTests
{
    [Fact]
    public void Execute_ValidPlacement_RobotIsPlaced()
    {
        var robot = new Robot();
        var command = new PlaceCommand(0, 0, Direction.NORTH);

        command.Execute(robot);

        Assert.True(robot.IsPlaced);
        Assert.Equal(0, robot.X);
        Assert.Equal(0, robot.Y);
        Assert.Equal(Direction.NORTH, robot.Facing);
    }
}
