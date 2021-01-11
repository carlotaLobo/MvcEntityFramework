using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcEntityFramework.Models
{
    public class Deportivo : Coche, ICoche
    {
        public Deportivo(String marca, String modelo, String imagen, int velocidadmax)
        {
            this.Marca = marca;
            this.Modelo = modelo;
            this.Imagen = imagen;
            this.VelocidadMax = velocidadmax;
        }
        public Deportivo()
        {
            this.Marca = "Pontiac";
            this.Imagen = "FireBird.jpg";
            this.Modelo = "FireBird";
            this.Velocidad = 0;
            this.VelocidadMax = 240;
        }
    }
}
