﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcEntityFramework.Models
{
   public interface ICoche
    {
         String Marca { get; set; }
         String Modelo { get; set; }
         String Imagen { get; set; }
         int VelocidadMax { get; set; }
         int Velocidad { get; set; }
         void Acelerar();
         void Frenar();
    }
}
