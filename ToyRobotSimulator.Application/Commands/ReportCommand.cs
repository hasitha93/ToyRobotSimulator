using ToyRobotSimulator.Application.Interfaces;
using ToyRobotSimulator.Domain.Models;

namespace ToyRobotSimulator.Application.Commands;

public class ReportCommand : IReport
{
    public string GetReport(Robot robot)
    {
        return null;
    }
}
