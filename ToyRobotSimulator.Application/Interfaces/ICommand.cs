using ToyRobotSimulator.Domain.Models;

namespace ToyRobotSimulator.Application.Interfaces;

public interface ICommand: IBaseCommand
{
    void Execute(Robot robot);
}
