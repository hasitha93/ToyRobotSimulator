using ToyRobotSimulator.Application.Interfaces;
using ToyRobotSimulator.Domain.Models;

namespace ToyRobotSimulator.Application.Commands;

public class MoveCommand : ICommand
{
    public void Execute(Robot robot) => robot.Move();
}
