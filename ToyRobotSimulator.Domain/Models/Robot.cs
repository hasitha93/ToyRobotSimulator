﻿using ToyRobotSimulator.Domain.Enums;

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

        switch (Facing)
        {
            case Direction.NORTH:
                Y++;
                break;
            case Direction.SOUTH:
                Y--;
                break;
            case Direction.EAST:
                X++;
                break;
            case Direction.WEST:
                X--;
                break;
        }
    }

    private static bool IsValidPosition(int x, int y) => x >= 0 && x < TABLE_SIZE && y >= 0 && y < TABLE_SIZE;
}
