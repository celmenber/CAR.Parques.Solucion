import { detalleReserva } from "./detalleReserva";

export class reservaDetalle {
    ReservaId: number;
    EstadoId: number;
    NombreEstado: string;
    UsuarioReserva: string;
    CorreoUsuario: string;
    FechaGeneracionReserva: string;
    ObservacionReserva: string;
    PrecioTotalReserva: number;
    UsuarioReservaId: number;
    ListadoDetalleReserva: detalleReserva[] = [];
}