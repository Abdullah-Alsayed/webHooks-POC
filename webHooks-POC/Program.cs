namespace webHooks_POC
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var app = builder.Build();

            app.MapPost(
                "/webhooks",
                async context =>
                {
                    var requestBody = await context.Request.ReadFromJsonAsync<WebhooksPayload>();
                    Console.WriteLine($"Heder:{requestBody?.Header} , Body:{requestBody?.Body}");
                    context.Response.StatusCode = 200;
                    await context.Response.WriteAsync("Webhooks Done!");
                }
            );

            app.Run();
        }

        public record WebhooksPayload(string Header, string Body);
    }
}
