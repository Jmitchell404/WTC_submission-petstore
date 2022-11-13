using QaVerification;
using RestSharp;

namespace PetstoreTests;

[TestFixture]
public class PetTests : BaseTest
{
    private Pet darth_vader;

    // [TearDown]
    public void removedpet()
    {
        RemovePet(darth_vader);
    }

    [Grading]
    [Test]
    public void GetPetThatExists()
    {
        // Arrange
        var request = new RestRequest("/pet/1");  

        // Act
        var result = client.GetAsync<Pet>((request)).GetAwaiter().GetResult();   

        // Assert
        Assert.That(result.Id, Is.EqualTo(1));    
        Assert.That(result.Category.GetType, Is.Not.EqualTo(null));
    }
    
    [Grading]
    [Test]
    public void GetPetThatDoesNotExist()
    {
        // Arrange
        var request = new RestRequest("/pet/99");  

        // Act
        var result = client.GetAsync<Pet>((request)).GetAwaiter().GetResult();   

        // Assert
        Assert.That(result.Id, Is.EqualTo(null));    
        Assert.That(result.Category, Is.EqualTo(null));
    }
    
    [Grading]
    [Test]
    public void AddPetTest()
    {
        darth_vader = CreatePet("luke skywalker");
        Assert.That(darth_vader!.Name, Is.EqualTo("luke skywalker"));

    }

    [Grading]
    [Test]
    public void AddRemovePetTest()
    {
        Pet? pet = GetPet(1);
        RemovePet(pet);
        var result = GetPet(1);

        Assert.That(result?.Id, Is.Null);
        Assert.That(result?.Code, Is.EqualTo(404));
        Assert.That(result?.Type, Is.EqualTo("unknown"));
        Assert.That(result?.Message, Is.EqualTo("null for uri: http://localhost/v2/store/1"));
    }
}