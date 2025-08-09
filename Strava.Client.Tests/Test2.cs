namespace Strava.Client.Tests;

[TestClass]
public class Test2
{
    [TestMethod]
    public void ParameterlessConstructor()
    {
        //Arrange

        //Act
        var client = new StravaApiClient();

        //Assert
        Assert.IsNotNull(client);
    }

    [TestMethod]
    public async Task DeserializeAthlete()
    {
        //Arrange
        var client = new StravaApiClient();

        //Act
        var activities = await client.GetLoggedInAthleteActivities();

        //Assert
        Assert.IsNotNull(client);
    }
}