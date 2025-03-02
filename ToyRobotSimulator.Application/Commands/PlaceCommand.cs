using ToyRobotSimulator.Application.Interfaces;
using ToyRobotSimulator.Domain.Enums;
using ToyRobotSimulator.Domain.Models;

namespace ToyRobotSimulator.Application.Commands;

public class PlaceCommand : ICommand
{
    private readonly int _x;
    private readonly int _y;
    private readonly Direction _facing;

    public PlaceCommand(int x, int y, Direction facing)
    {
        _x = x;
        _y = y;
        _facing = facing;
    }

    public void Execute(Robot robot)
    {
        
    }
}
