using HomesteadManager.Shared.Models;

namespace HomesteadManager.Shared.Requests
{
    public class BedRequest
    {
        public int BedId { get; set; }
        public Size Size { get; set; }
    }
}
