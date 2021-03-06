﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PrimerParcial_Aplicada1.Entidades
{
    public class Articulos
    {
        [Key]
        public int ProductoId { get; set; }
        public string Descripcion { get; set; }
        public decimal Existencia { get; set; }
        public decimal Costo { get; set; }
        public decimal ValorInventario { get; set; }


        public Articulos()
        {
            ProductoId = 0;
            Descripcion = string.Empty;
            Existencia = 0;
            Costo = 0;
            ValorInventario = 0;

        }
    }
}
