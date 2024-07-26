namespace ejpservice.Domain.Core.Models
{
    public class BasePhoneModel : BasePersonModel
    {
        //EN LA BASE DE DATOS LA COLUMNA 'Phone' ACEPTABA
        //VALORES NULOS, PERO LA ACTUALICE, PARA QUE NO LO ACEPTE
        //ASI QUE CUANDO VALLA A DESPLEGAR TODO, TENGO QUE DECIRLE 
        //A ESTA PROPIEDAD QUE NO ACEPTA VALORES NULOS
        //ES DECIR QUITARLE EL SIGNO DE INTERROGACION '?'
        public string? Phone { get; set; }
    }
}
