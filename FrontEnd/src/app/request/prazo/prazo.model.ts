export interface Prazo {
    idPrazoCodigo?: number,
    idUtilizador?: number,
    idCodigo?: number,
    nrArtigo?: number,
    nrProcesso?: string,
    dataInicial?: string,
    dataFinal?: string
}

export interface Aux {
    prioritarios?: boolean,
    num?: number
}