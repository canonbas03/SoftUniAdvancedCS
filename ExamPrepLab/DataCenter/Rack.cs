using System.Diagnostics.Metrics;
using System.Drawing;
using System.Text;

namespace DataCenter
{
    public class Rack
    {
        public int Slots { get; set; }
        public List<Server> Servers { get; set; }
        public int GetCount => Servers.Count;

        public Rack(int slots)
        {
            this.Slots = slots;
            Servers = new List<Server>();
        }

        public void AddServer(Server server)
        {
            if(GetCount < Slots && !Servers.Any(s => s.SerialNumber == server.SerialNumber))
            {
                Servers.Add(server);    
            }
        }

        public bool RemoveServer(string serialNumber)
        {
            Server server = Servers.FirstOrDefault(s => s.SerialNumber == serialNumber);
            return Servers.Remove(server);
        }

        public string GetHighestPowerUsage()
        {
            Server server = Servers.MaxBy(s => s.PowerUsage);
            return server.ToString();
        }

        public int GetTotalCapacity()
        {
            return Servers.Sum(s => s.Capacity);
        }

        public string DeviceManager()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"{GetCount} servers operating:");
            foreach (Server server in Servers)
            {
                sb.AppendLine(server.ToString());
            }

            return sb.ToString().TrimEnd();
        }
    }
}
