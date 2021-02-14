using Actividades.Web.Data.Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Actividades.Web.Models
{
    public class TimeActivityViewModel : TimeActivity
    {
        public int ActivityId { get; set; }

        public int TimeActivityId { get; set; }
    }
}

