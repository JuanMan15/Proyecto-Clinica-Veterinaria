using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetFriends.Models
{
    public class ProductoVenta
    {
        public int ProductId { get; set; }
        public int Quantity { get; set; }

        public string NombreProducto { get; set; }
        public decimal Precio { get; set; }


    }

}