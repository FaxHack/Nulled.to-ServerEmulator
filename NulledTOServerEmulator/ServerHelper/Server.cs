using NetCoreServer;
using System.Drawing;
using System.Net;
using static NulledTOServerEmulator.Program;

namespace NulledTOServerEmulator.ServerHelper
{
    public class HttpsCacheSession : HttpsSession
    {
        private const int HTTPStatusCode = 200;
        public HttpsCacheSession(HttpsServer server) : base(server) { }

        protected override void OnReceivedRequest(HttpRequest Request)
        {
            Console.WriteLine("--------------------------------------------------------------------------------------------");
            Log($"Accepted request from: {Request.Url}", "SERVER", ConsoleColor.Magenta);
            var result = Request.ToString().Split("\n\r".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
            foreach (var data in result)
            {
                Log(data, "SERVER", ConsoleColor.Green);
            }
            if (Request.Method == "HEAD")
                SendResponseAsync(Response.MakeHeadResponse());
            else if (Request.Method == "GET")
            {
                SendResponseAsync(Response.MakeErrorResponse(200, $"[{DateTime.Now}] Nulled.to Server Emulator by ||  https://github.com/FaxHack\n\nhttps://github.com/FaxHack/Nulled.to-ServerEmulator"));
            }
            else if ((Request.Method == "POST") || (Request.Method == "PUT"))
            {
                SendResponseAsync(Response.MakeErrorResponse(200, Emulator.AuthEmulator.Credentials.GetValidResponse()));
            }
            Util.Leave();
        }
    }

    class HttpsCacheServer : NetCoreServer.HttpsServer
    {
        public HttpsCacheServer(SslContext context, IPAddress address, int port) : base(context, address, port) { }

        protected override SslSession CreateSession() { return new HttpsCacheSession(this); }
    }
}
