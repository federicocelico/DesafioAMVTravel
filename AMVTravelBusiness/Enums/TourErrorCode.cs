using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMVTravelBusiness.Enums
{
    public enum TourErrorCode
    {
        [Display(Description = "Éxito.")]
        Exito = 2000,

        [Display(Description = "Error. Tour no encontrado.")]
        TourNoEncontrado = 2001,

        [Display(Description = "Error. Ya existe un tour con este nombre.")]
        TourYaExiste = 2002,

        [Display(Description = "Error. No se puede eliminar el tour.")]
        ErrorEliminarTour = 2003,

        [Display(Description = "Error. Ocurrió un problema al crear el tour.")]
        ErrorCrearTour = 2004
    }
}
