using ToyRobotSimulator.Domain.Enums;

namespace ToyRobotSimulator.Domain.Models;

public class Robot
{
    private const int TABLE_SIZE = 5;
    public int X { get; private set; }
    public int Y { get; private set; }
    public Direction Facing { get; private set; }
    public bool IsPlaced { get; private set; }

    public Robot()
    {
        IsPlaced = false;
    }

    public void Place(int x, int y, Direction facing)
    {

    }
}
