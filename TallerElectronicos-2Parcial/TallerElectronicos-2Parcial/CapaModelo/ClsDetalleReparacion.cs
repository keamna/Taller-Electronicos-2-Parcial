using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TallerElectronicos_2Parcial.CapaModelo
{
    public class ClsDetalleReparacion
    {
        public  static int detalleID { get; set; }
        public static int reparacionID { get; set; }
        public static string descripcionReparacion { get; set; }
        public static string fechaInicio { get; set; }
        public static string fechaFin { get; set; }

    }
}