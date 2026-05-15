using _009_HTTP;

/*HttpClient httpClient = new HttpClient();
string uri = "https://github.com/bratbober/NP";

using HttpRequestMessage requestMessage = new HttpRequestMessage(HttpMethod.Get, uri); // Get, Post, Put, Delete, Patch

using HttpResponseMessage response = await httpClient.SendAsync(requestMessage);

Console.WriteLine(response.StatusCode);

Console.WriteLine("Headers!");
foreach(var header in response.Headers)
{
    Console.Write($"{header.Key}: ");
    foreach(var value in header.Value)
    {
        Console.WriteLine(value);
    }
}

Console.WriteLine("Content");

string content = await response.Content.ReadAsStringAsync();
Console.WriteLine(content);*/

/*HttpClient httpClient = new HttpClient();
string uri = "https://github.com/bratbober/NP";

using HttpResponseMessage responce = await httpClient.GetAsync(uri);

string content = await responce.Content.ReadAsStringAsync();

Console.WriteLine(content);*/

/*HttpClient httpClient = new HttpClient();
string uri = "https://www.gutenberg.org/cache/epub/2265/pg2265.txt";

byte[] data = await httpClient.GetByteArrayAsync(uri);
string path = @"C:/TestFiles/book.txt";
File.WriteAllBytes(path, data);*/

/*HttpClient httpClient = new HttpClient();
string uri = "https://static9.depositphotos.com/1064045/1188/i/450/depositphotos_11889482-stock-photo-butterfly.jpg";

byte[] data = await httpClient.GetByteArrayAsync(uri);
string path = @"C:/TestFiles/picture.jpg";
File.WriteAllBytes(path, data);*/

/*HttpClient httpClient = new HttpClient();
string uri = "http://resources.finance.ua/ua/public/metal-cash.xml";

string content = await httpClient.GetStringAsync(uri);

Source source = Serializer.Deserialize<Source>(content);

List<Organization> organizations = source.Organizations.Organization;

foreach (Organization org in organizations)
    Console.WriteLine(org.Title);*/


// Вводимо назви банку. Вивести всі його метали 

/*string bank = "Індустріалбанк";
HttpClient httpClient = new HttpClient();
string uri = "http://resources.finance.ua/ua/public/metal-cash.xml";

string content = await httpClient.GetStringAsync(uri);

Source source = Serializer.Deserialize<Source>(content);

Organization organization = source.Organizations.Organization.Where((o) => o.Title == bank).FirstOrDefault();
List<Metal> metal = organization.Metals.Metal;

foreach(Metal met in metal)
{
    Console.WriteLine($"{met.Id}: ");
    foreach (var metal1 in met.N) 
    {
        Console.WriteLine($"{metal1.Id}, {metal1.Ar}, {metal1.Br}");
    }
}*/

