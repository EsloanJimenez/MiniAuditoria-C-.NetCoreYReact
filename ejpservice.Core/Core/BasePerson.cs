namespace ejpservice.Domain.Core
{
    public class BasePerson : BaseFollow
    {
        public string FirstName { get; set; }
        public string? LastName { get; set; }
        //EN LA BASE DE DATOS LA COLUMNA 'Phone' ACEPTABA
        //VALORES NULOS, PERO LA ACTUALICE, PARA QUE NO LO ACEPTE
        // ASI QUE CUANDO VALLA A DESPLEGAR TODO, TENGO QUE DECIRLE 
        //A ESTA PROPIEDAD QUE NO ACEPTA VALORES NULOS
        //ES DECIR QUITARLE EL SIGNO DE INTERROGACION '?'
        public string? Phone {  get; set; }
    }
}
