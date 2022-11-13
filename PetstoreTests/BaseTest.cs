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
    public int? Id { get ; set; }
    public string? name { get ; set; }

}

public class Tag
{
    public int? Id { get ; set; }
    public string? name { get ; set; }
}

public class Pet
{
    public int? Id { get; set; }
    public Category? Category { get; set; }
    public string? Name { get; set; }
    public List<string>? PhotoUrls { get; set; }
    public List<Tag>? Tags { get; set; }
    public string? Status { get; set; }
    public int? Code { get; set; }
    public string? Type { get; set; }
    public string? Message { get; set; }

}

public class Order
{
    public int? Id { get; set; }
    public int? PetId { get; set; }
    public int? Quantity { get; set; }
    public string? ShipDate { get; set; }
    public string? Status { get; set; }
    public bool? Complete { get; set; }
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
        var body = new {
            id = 0,
            category = new{
                id = 0,
                name = "string"
            },
            name = name,
            photoUrls = new List<string>{
                "string"
            },
            tags = new List<object>{
                new {
                    id = 1,
                    name = "string"
                }
            },
            status = "available"
        };
        var request = new RestRequest("/pet", Method.Post);
        request.AddHeader("Content-type","application/json");
        request.AddJsonBody(
            new {
                id = 0,
                category = new{
                    id = 0,
                    name = "string"
                },
                name = name,
                photoUrls = new List<string>{
                    "string"
                },
                tags = new List<object>{
                    new {
                        id = 1,
                        name = "string"
                    }
                },
                status = "available"
            }
        );
        return client.PostAsync<Pet>((request)).GetAwaiter().GetResult();
    }

    protected void RemovePet(Pet pet)
    {
        var request = new RestRequest($"/pet/{pet.Id}");
        client.DeleteAsync(request);
    }

    protected Pet? GetPet(int petId)
    {
        var request = new RestRequest("/store/"+petId);
        var result = client.GetAsync<Pet>((request)).GetAwaiter().GetResult();
        return result;
    }

    protected Order? OrderPet(Pet pet, int quantity)
    {
        var request = new RestRequest("/store/"+pet+quantity);
        var result = client.GetAsync<Order>((request)).GetAwaiter().GetResult();
        return result;
    }
}