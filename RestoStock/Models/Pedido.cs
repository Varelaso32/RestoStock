﻿using System.ComponentModel.DataAnnotations;

namespace RestoStock.Models
{
    public class Pedido
    {
        [Key]
        public int IdProveedor { get; set; }
        public string FechaPedido { get; set; }
        public int Total { get; set; }
        public int FkProveedor { get; set; }
        public Proveedor Proveedores { get; set; }
    }
}