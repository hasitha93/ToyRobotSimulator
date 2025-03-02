using ToyRobotSimulator.Application.Interfaces;
using ToyRobotSimulator.Domain.Models;
using ToyRobotSimulator.Infrastructure.Parsers;

namespace ToyRobotSimulator.ConsoleApp;

public class Program
{
    static void Main(string[] args)
    {
        Robot robot = new();
        Console.WriteLine("Toy Robot Simulator. Enter commands (PLACE X,Y,FACING, MOVE, LEFT, RIGHT, REPORT):");

        while (true)
        {
            string? input = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(input)) continue;

            IBaseCommand command = CommandParser.Parse(input.Trim().ToUpper());

            if (command == null)
            {
                Console.WriteLine("Invalid command. Please try again.");
                continue;
            }

            if (command is ICommand executableCommand)
            {
                executableCommand.Execute(robot);
            }
            else if (command is IReport reportableCommand)
            {
                Console.WriteLine(reportableCommand.GetReport(robot));
            }
        }
    }
}
