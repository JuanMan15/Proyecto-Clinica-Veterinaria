using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetFriends.ExtraConfig
{
    public class VentaEventArgs : EventArgs
    {
        public int VentaId { get; set; }
        public decimal Total { get; set; }
    }
}
