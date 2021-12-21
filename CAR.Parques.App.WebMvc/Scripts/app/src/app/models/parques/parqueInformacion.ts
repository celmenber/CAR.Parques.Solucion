import { informacionPaque } from "./informacionParque";

export class parqueInformacion {
    ParqueId: number;
    NombreParque: string;
    InicialesParque: string;
    Activo: boolean;
    Direccion: string;
    MunicipioId: number;
    Telefono: string;
    Observacion: string;
    NombreMunicipio: string;
    DepartamentoId: number;
    NombreDepartamento: string;
    imagen: File;
    urlImagen: string;
    Color: string;
    colorFondo: string;
    LinkUbicacionGoogle: string;
    ListadoSeccioneInformacion: informacionPaque[];
}