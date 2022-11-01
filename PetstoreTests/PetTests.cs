using QaVerification;

namespace PetstoreTests;

[TestFixture]
public class PetTests : BaseTest
{
    [Grading]
    [Test]
    public void GetPetThatExists()
    {
        Assert.Pass("Exercise 1: Replace with your code");
    }
    
    [Grading]
    [Test]
    public void GetPetThatDoesNotExist()
    {
        Assert.Pass("Exercise 1: Replace with your code");
    }
    
    [Grading]
    [Test]
    public void AddPetTest()
    {
        Assert.Pass("Exercise 2: Replace with your code");
    }

    [Grading]
    [Test]
    public void AddRemovePetTest()
    {
        Assert.Pass("Exercise 2: Replace with your code");
    }
}