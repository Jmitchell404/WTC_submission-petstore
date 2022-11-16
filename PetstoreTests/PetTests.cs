using QaVerification;

namespace PetstoreTests;

[TestFixture]
public class PetTests : BaseTest
{
    private Pet pet;

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
        Assert.That(result!.Id, Is.Null);    
    }

    [Grading]
    [Test]
    public void GetPetThatDoesNotExist()
    { 
        // Act
        var result = GetPet(99);

        // Assert
        Assert.That(result!.Id, Is.EqualTo(null));
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
        Pet? pet = GetPet(0);
        RemovePet(pet);
        var result = GetPet(0);

        Assert.That(result!.Id, Is.EqualTo(null));
    }
}