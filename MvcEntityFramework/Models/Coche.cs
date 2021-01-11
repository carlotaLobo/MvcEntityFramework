using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcEntityFramework.Models
{
    public class Coche : ICoche
    {
        public String Marca { get; set; }
        public String Modelo { get; set; }
        public String Imagen { get; set; }
        public int VelocidadMax { get; set; }
        public int Velocidad { get; set; }
        public Coche() {

            this.Marca = "volkswagen";
            this.Modelo = "Escarabajo";
            this.Imagen = "volkswagen.jpg";
            this.VelocidadMax = 90;
            this.Velocidad = 0;
        }

        public void Acelerar()
        {
            this.Velocidad += 10;

            if(this.Velocidad >= this.VelocidadMax)
            {
                this.Velocidad = this.VelocidadMax;
            }
         
        }
        public void Frenar()
        {
            this.Velocidad -= 10;

            if(this.Velocidad < 0)
            {
                this.Velocidad = 0;
            }
          
        }
    }
}
