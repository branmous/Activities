namespace Actividades.Web.Data.Entidades
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class TimeActivity : IEntity
    {
        public int Id { get; set; }

        [Display(Name = "Fecha")]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true) ]
        public DateTime StarDate { get; set; }

        [Range(1, 8, ErrorMessage = "El número de hora no debe ser superior a 8")]
        [Display(Name = "Horas")]
        public double Hours { get; set; }

    }
}
