using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;

namespace UPS.Web.SignalR
{
    public class ShapeHub : Hub
    {
        public async Task MoveShape(int x, int y)
        {
            await Clients.Others.SendAsync("shapeMoved", x, y);
        }
    }
}