using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api1.Entities
{
    public class Producto
    {
        public int Id { get; set; }
        public string Nombre { get; set; }

        public string Descripcion { get; set; }

        public int Stock { get; set; }

        public string ImgUrl { get; set; }

        public int Precio { get; set; }
    }

}
