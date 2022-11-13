using QaVerification;

namespace PetstoreTests;

[TestFixture]
public class OrderTests : BaseTest
{
    private Pet? pet;

    [TearDown]
    public void RemovePet(){
        RemovePet(pet);
    }
    
    [Grading]
    [Test]
    public void OrderPetTest()
    {
        pet = CreatePet("end my clone existance");
        var result = OrderPet(pet, 66);   

        Assert.That(result!.PetId, Is.Not.EqualTo(66));
        Assert.That(result!.Quantity, Is.EqualTo(null));                
    }
}