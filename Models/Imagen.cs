using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
 
    public class Imagen
    {
        public int Id { get; set; }

        public int IdArticulo { get; set; }

        [DisplayName("URL")]
        public string ImagenUrl { get; set; }

        public override string ToString()
        {
            return ImagenUrl;
        }
    }
}
