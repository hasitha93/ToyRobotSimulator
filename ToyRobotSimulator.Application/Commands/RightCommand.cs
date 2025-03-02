using ToyRobotSimulator.Application.Interfaces;
using ToyRobotSimulator.Domain.Models;

namespace ToyRobotSimulator.Application.Commands;

public class RightCommand : ICommand
{
    public void Execute(Robot robot) => robot.Right();
}
