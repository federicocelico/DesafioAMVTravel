using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMVTravelBusiness.Enums
{
    public enum ReservaErrorCode
    {
        [Display(Description = "Éxito.")]
        Exito = 0,

        [Display(Description = "Error. La reserva no existe.")]
        ReservaNoExiste = 2001,

        [Display(Description = "Error. No se pudo obtener las reservas.")]
        ErrorAlObtenerReservas = 2002,

        [Display(Description = "Error. No se pudo eliminar la reserva.")]
        ErrorAlEliminarReserva = 2003,

        [Display(Description = "Error. No se pudo crear la reserva.")]
        ErrorCrearReserva = 2004,

        [Display(Description = "Error. Información de reserva inválida.")]
        InformacionDeReservaInvalida = 2005
    }
}
