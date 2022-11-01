using RestSharp;

namespace PetstoreTests;


public class Inventory                              
{
    public int Sold { get; set; }
    public int Pending { get; set; }
    public int Available { get; set; }
}

public class Category
{
    // complete this class
}

public class Tag
{
    // complete this class
}

public class Pet
{
    // complete this class
}

public class Order
{
    // complete this class
}

public class BaseTest
{
    protected RestClient client;

    [SetUp]
    public void Initialise()
    {
        client = new RestClient("http://localhost/v2");
    }

    // This method can used to generate random strings based on the prefix provided.
    // For example, var petName = randomName("Cat");
    // You may find it useful in your tests.
    protected static string RandomName(string prefix)
    {
        return prefix + new Random().Next(1, 10000).ToString();
    }

    protected Inventory? GetInventory()                
    {
        var request = new RestRequest("/store/inventory");
        return client.GetAsync<Inventory>((request)).GetAwaiter().GetResult(); 
    }
    
    protected Pet? CreatePet(string name)
    {
        return null; // replace this code
    }

    protected void RemovePet(Pet pet)
    {
        // complete this code
    }

    protected Pet? GetPet(int petId)
    {
        return null; // replace this code
    }

    protected Order? OrderPet(Pet pet, int quantity)
    {
        return null; // replace this code
    }
}