using System.Net;
using System.Net.Http.Json;

public class MyTodoApiClientConsole
{
    static HttpClient client = new HttpClient();

    public class Kunde
    {
        public int KundenId { get; set; }
        public string Vorname { get; set; }
        public int Punkte { get; set; }
    }

    public static async Task Main()
    {
        Console.WriteLine("Bitte drücken Sie eine Taste");
        Console.ReadLine();
        Console.WriteLine("Hello Campus02");

        Kunde kundePost = new Kunde
        {
            KundenId = 7,
            Vorname = "Johann",
            Punkte = 100
        };

        
        HttpStatusCode statusCode = await PostKundeSimple(kundePost);

        
        Console.WriteLine($"Status Code: {statusCode} ({(int)statusCode})");
        
        if (statusCode == HttpStatusCode.Created || statusCode == HttpStatusCode.OK)
        {
            Console.WriteLine("Kunde wurde erfolgreich angelegt!");
        }
        else
        {
            Console.WriteLine($"Fehler beim Anlegen des Kunden: {statusCode}");
        }
        Console.ReadLine();
    }

    static async Task<HttpStatusCode> PostKundeSimple(Kunde neuerKunde)
    {
        try
        {
            HttpResponseMessage response = await client.PostAsJsonAsync(
                "https://localhost:7215/api/kunden", neuerKunde);

            return response.StatusCode;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Exception: {ex.Message}");            
            return HttpStatusCode.ServiceUnavailable;
        }
    }
}