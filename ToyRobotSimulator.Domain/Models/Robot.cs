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
        if (IsValidPosition(x, y))
        {
            X = x;
            Y = y;
            Facing = facing;
            IsPlaced = true;
        }
    }

    public void Move()
    {
        if (!IsPlaced) return;

        int newX = X;
        int newY = Y;

        switch (Facing)
        {
            case Direction.NORTH:
                newY++;
                break;
            case Direction.SOUTH:
                newY--;
                break;
            case Direction.EAST:
                newX++;
                break;
            case Direction.WEST:
                newX--;
                break;
        }

        if (IsValidPosition(newX, newY))
        {
            X = newX;
            Y = newY;
        }
    }

    public void Left()
    {
        if (!IsPlaced) return;

        switch (Facing)
        {
            case Direction.NORTH:
                Facing = Direction.WEST;
                break;
            case Direction.WEST:
                Facing = Direction.SOUTH;
                break;
            case Direction.SOUTH:
                Facing = Direction.EAST;
                break;
            case Direction.EAST:
                Facing = Direction.NORTH;
                break;
        }
    }

    private static bool IsValidPosition(int x, int y) => x >= 0 && x < TABLE_SIZE && y >= 0 && y < TABLE_SIZE;
}
