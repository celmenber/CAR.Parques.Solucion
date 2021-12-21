export interface IGestorContenidoModel {
  ContenidoId: number;
  TipoContenidoId: number;
  NombreContenido: string;
  TituloContenido: string;
  CuerpoContenido: string;
  ImagenContenido: File;
  URLRedireccion: string;
  FechaInicioVigencia: string;
  FechaFinVigencia: string;
  Activo: boolean;
}
