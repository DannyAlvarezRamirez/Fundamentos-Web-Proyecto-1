using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Proyecto_1.Models
{
    public class Proyecto
    {
        private int intIDProyecto;
        static private int contador;
        public Proyecto()
        {
            contador++;
            if (contador <= 10000)
            {
                intIDProyecto = intIDProyecto + contador;
            }//fin if
            else
            {
                //mensaje
            }//fin else
        }//fin constructor
        [Display(Name = "Cedula del Cliente dueno del Proyecto")]
        public int intClienteDueno { get; set; }

        [Range(1, 10000)]
        [Display(Name = "ID del Proyecto")]
        public int IDProyecto
        {
            set
            {
                intIDProyecto = value;
            }
            get
            {
                return intIDProyecto;
            }
        }//fin IDProyecto

        [StringLength(60, MinimumLength = 10, ErrorMessage = "El nombre no puede mas largo que 60 caracteres y menos que 10")]
        [Display(Name = "Nombre del Proyecto")]
        public String strNombreProyecto { get; set; }
        [Range(1, 6)]
        [Display(Name = "Cantidad de Dormitorios")]
        public int intCantidadDeDormitorios { get; set; }
        [Range(1, 5)]
        [Display(Name = "Cantidad de Banos Completos")]
        public int intCantidadDeBanosCompletos { get; set; }
        [Range(1, 3)]
        [Display(Name = "Cantidad de Medios Banos")]
        public int intCantidadDeMediosBanos { get; set; }
        [Display(Name = "La sala esta integrada con la Cocina")]
        public Boolean boolSalaEstaIntegradaConLaCocina { get; set; }
        [Display(Name = "El area de pilas es abierta")]
        public Boolean boolAreaDePilasEsAbierta { get; set; }
        public Terraza Terraza { get; set; }
        [Display(Name = "Tipo de Piso")]
        public TipoDePiso TipoDePiso { get; set; }
        [Display(Name = "Muebles de Cocina")]
        public MuebleDeCocina MuebleDeCocina { get; set; }
        [Display(Name = "Metros de construccion aproximado")]
        public MetrosDeConstruccionAproximado MetrosDeConstruccionAproximado { get; set; }
        [Display(Name = "Costo Final")]
        public double CostoAproximadoPorMetroCuadrado { get; set; }
        public int ConvertirSalaEstaIntegradaConLaCocina()
        {
            int valor = 0;
            if (boolSalaEstaIntegradaConLaCocina == true)
            {
                valor = 2;
            }//fin if true
            else
            {
                valor = 3;
            }//fin else false
            return valor;
        }//fin ConvertirSalaEstaIntegradaConLaCocina
        public int ConvertirAreaDePilasEsAbierta()
        {
            int valor = 0;
            if (boolAreaDePilasEsAbierta == true)
            {
                valor = 2;
            }//fin if true
            else
            {
                valor = 3;
            }//fin else false
            return valor;
        }//fin ConvertirAreaDePilasEsAbierta
        public double CostoFinal()
        {
            CostoAproximadoPorMetroCuadrado =
                ((intCantidadDeDormitorios + intCantidadDeBanosCompletos + intCantidadDeMediosBanos +
                ((int)Terraza) + ((int)TipoDePiso) + ((int)MuebleDeCocina)) +
                (ConvertirSalaEstaIntegradaConLaCocina() + ConvertirAreaDePilasEsAbierta() * ((int)MetrosDeConstruccionAproximado)))
                * 20000;
            return CostoAproximadoPorMetroCuadrado;
        }//fin CostoFinal
    }//fin clase Proyecto
}//fin Proyecto_1.Models


















































































