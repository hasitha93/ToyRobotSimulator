using ToyRobotSimulator.Application.Commands;
using ToyRobotSimulator.Application.Interfaces;
using ToyRobotSimulator.Domain.Enums;

namespace ToyRobotSimulator.Infrastructure.Parsers;

/// <summary>
/// Parsing user input and converting it into the appropriate command object.
/// </summary>
public class CommandParser
{
    public static IBaseCommand Parse(string input)
    {
        if (input.StartsWith("PLACE"))
        {
            var parts = input.Split([' ', ','], StringSplitOptions.RemoveEmptyEntries);
            if (parts.Length == 4 && int.TryParse(parts[1], out int x) && int.TryParse(parts[2], out int y) && Enum.TryParse(parts[3], out Direction facing))
            {
                return new PlaceCommand(x, y, facing);
            }
        }
        else if (input == "MOVE")
        {
            return new MoveCommand();
        }
        else if (input == "LEFT")
        {
            return new LeftCommand();
        }
        else if (input == "RIGHT")
        {
            return new RightCommand();
        }
        else if (input == "REPORT")
        {
            return new ReportCommand();
        }
        return null;
    }
}
