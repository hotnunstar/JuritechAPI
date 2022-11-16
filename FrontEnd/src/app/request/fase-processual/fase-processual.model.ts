export interface FaseProcessual {
    idEstado?: number,
    idUtilizador?: number,
    nrProcesso?: string,
    dataEntrada?: string,
    nrDias?: number,
    dataSaida?: string,
}

export interface Aux {
    ativasNaoAtivas?: boolean,
    todas?: boolean,
    idEst?: number,
}