using System;
using System.Collections.Generic;
using System.Text;

namespace TiendaXamarin.Modelo
{
    
    public class Items 
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }
        public int CatId { get; set; }
        public decimal Precio { get; set; }
        public string Imagen { get; set; }

    }
}
