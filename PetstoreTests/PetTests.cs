using QaVerification;

namespace PetstoreTests;

[TestFixture]
public class PetTests : BaseTest
{
    private Pet? pet;

    public void petremoval()
    {
        RemovePet(pet);
    }

    [Grading]
    [Test]
    public void GetPetThatExists()
    {
        // Arrange
        // var request = new RestRequest("/pet/1");  

        // Act
        // var result = client<Pet>((request)).GetAwaiter().GetResult();   
        var result = GetPet(3);
        // var result = client.GetAsync<Pet>((request)).GetAwaiter().GetResult(); 
        // Assert
        Assert.IsInstanceOf<Pet>(result);
        Assert.That(result.Id, Is.Null);    
    }

    [Grading]
    [Test]
    public void GetPetThatDoesNotExist()
    {
        // Arrange
        // var request = new RestRequest("/pet/99");  

        // Act
        // var result = client.GetAsync<Pet>((request)).GetAwaiter().GetResult();   
        var result = GetPet(99);

        // Assert
        Assert.That(result!.Id, Is.EqualTo(null));    
        Assert.That(result!.Code, Is.EqualTo(404));
        Assert.That(result!.Type, Is.EqualTo("unknown"));
        Assert.That(result!.Message, Is.EqualTo("null for uri: http://localhost/v2/store/99"));
    }
    
    [Grading]
    [Test]
    public void AddPetTest()
    {
        pet = CreatePet("luke skywalker");
        Assert.That(pet.Name, Is.EqualTo("luke skywalker"));

    }

    [Grading]
    [Test]
    public void AddRemovePetTest()
    {
        Pet? pet = GetPet(1);
        RemovePet(pet);
        var result = GetPet(1);

        Assert.That(result!.Id, Is.EqualTo(null));
        Assert.That(result!.Code, Is.EqualTo(404));
        Assert.That(result!.Type, Is.EqualTo("unknown"));
        Assert.That(result!.Message, Is.EqualTo("null for uri: http://localhost/v2/store/1"));
    }
}