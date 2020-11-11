using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace CapacityCounter.Hubs
{
    public class InOutHub : Hub
    {
        public async Task Signal(string direction, int count)
        {
            switch (direction)
            {
                case "inc":
                    count++;
                    break;

                case "dec":
                    count--;
                    break;
            }

            await Clients.All.SendAsync("broadcast", count).ConfigureAwait(false);
        }
    }
}