using ToyRobotSimulator.Domain.Models;

namespace ToyRobotSimulator.Application.Interfaces;

public interface IReport: IBaseCommand
{
    string GetReport(Robot robot);
}
