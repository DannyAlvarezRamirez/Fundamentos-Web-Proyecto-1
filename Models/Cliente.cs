using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Proyecto_1.Models
{
    /*
     * esta clase se encarga de modelar un cliente con los parametros respectivos del mismo,
     * contiene sus atributos, constructores (se agregan con la intencion de interpretar mejor 
     * la codificacion del proyecto) y sus parametros o metodos o funciones propias
     */
    public class Cliente
    {
        //atributos
        public int intTelefono;
        public string strNombreCompleto;

        //propiedades
        //CedulaCliente
        [Required]
        [Display(Name = "Cedula")]
        public int intCedulaCliente { get; set; }
        //TelefonoCliente
        [Required]
        [Display(Name = "Telefono")]
        public int TelefonoCliente
        {
            set
            {
                this.intTelefono = value;
            }
            get
            {
                return this.intTelefono;
            }
        }//fin TelefonoCliente
        //NombreCompletoCliente
        [Required]
        [Display(Name = "Nombre Completo")]
        [StringLength(60, MinimumLength = 10, ErrorMessage = "El nombre no puede mas largo que 60 caracteres y menos que 10")]
        public string NombreCompletoCliente
        {
            set
            {
                this.strNombreCompleto = value;
            }
            get
            {
                return this.strNombreCompleto;
            }
        }//fin NombreCompletoCliente
        //GetInformacionObjetoCliente: se incluye como un artefacto para hacer pruebas
        //public string GetInformacionObjetoCliente()
        //{
        //    return "Información del cliente*\nCedula = " + this.intCedula + ", \nNombre Completo = " + this.strNombreCompleto + ", " +
        //        "\nTelefono = " + this.strNombreCompleto;
        //}//fin GetInformacionObjetoCliente
    }//fin clase Cliente
}//fin Proyecto_1.Models
