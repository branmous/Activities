using Actividades.Web.Data.Entidades;
using System;
using System.ComponentModel.DataAnnotations;

namespace Activity.Web.Data.Entidades
{
    public class Activity : IEntity
    {
        public int Id { get; set; }

        [Required(ErrorMessage ="Debe ingresar la descripción de la tarea")]
        [Display(Name = "Descripción")]
        public string Descripcion { get; set; }

        [Required]
        [Display(Name = "Fecha de Creación")]
        public DateTime CreationDate { get; set; }

        [Display(Name = "Completa la tarea")]
        public bool IsComplete { get; set; }

        public User User { get; set; }
    }
}
