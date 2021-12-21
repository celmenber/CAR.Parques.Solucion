export class MenuItem {
    MenuId: number;
    NombreMenu: string;
    TipoModuloId: number;
    RutaMenu: string;
    OrdenMenu: number;
    DescripcionMenu: string;
    MenuPadreId: number;
}

export class ResultadoEjecucionItem {
    Codigo: number;
    Descripcion: string;
    Entidad: MenuItem[];
}