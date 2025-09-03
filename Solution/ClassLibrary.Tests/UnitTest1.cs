using Xunit;
using ClassLibrary;

namespace ClassLibrary.Tests;

public class SolutionTests
{
    [Fact]
    public void RobotSim_NoObstacles_ReturnsCorrectDistance()
    {
        var solution = new Solution();
        int[] commands = {4, -1, 3};
        int[][] obstacles = new int[0][];
        int result = solution.RobotSim(commands, obstacles);
        Assert.Equal(25, result); // (3,4) => 3*3+4*4=25
    }

    [Fact]
    public void RobotSim_WithObstacle_StopsAtObstacle()
    {
        var solution = new Solution();
        int[] commands = {4, -1, 4, -2, 4};
        int[][] obstacles = new int[][] { new int[] {2, 4} };
        int result = solution.RobotSim(commands, obstacles);
        Assert.Equal(65, result); // Should stop at (1,4) before obstacle
    }

    [Fact]
    public void RobotSim_OnlyTurns_NoMovement()
    {
        var solution = new Solution();
        int[] commands = {-1, -2, -1, -2};
        int[][] obstacles = new int[0][];
        int result = solution.RobotSim(commands, obstacles);
        Assert.Equal(0, result); // Never moves
    }

    [Fact]
    public void RobotSim_MultipleObstacles()
    {
        var solution = new Solution();
        int[] commands = {2, 2, 2};
        int[][] obstacles = new int[][] { new int[] {0, 2}, new int[] {2, 2} };
        int result = solution.RobotSim(commands, obstacles);
        Assert.Equal(1, result); // Stops at (0,1)
    }
}
