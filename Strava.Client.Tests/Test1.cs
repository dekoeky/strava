using Strava.Client.Json;
using Strava.Client.Models;
using System.Text.Json;

namespace Strava.Client.Tests;

[TestClass]
public class Test1
{
    [TestMethod]
    public void DeserializeAthlete()
    {
        //Arrange
        var json = File.ReadAllText("testdata/Athlete.json");

        //Act
        var data = JsonSerializer.Deserialize<DetailedAthlete>(json, SourceGenerationContext.Default.DetailedAthlete);

        //Assert
        Assert.IsNotNull(data);
    }

    [TestMethod]
    public void DeserializeAthleteActivities()
    {
        //Arrange
        var json = File.ReadAllText("testdata/AthleteActivities.json");

        //Act
        var data = JsonSerializer.Deserialize<SummaryActivity[]>(json, SourceGenerationContext.Default.SummaryActivityArray);

        //Assert
        Assert.IsNotNull(data);
        Assert.IsTrue(data.Length > 0);
    }
}