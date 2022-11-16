/*
*	<copyright file="FaseProcessual.cs" company="JuriTech">
*		Copyright (c) 2022 All Rights Reserved
*	</copyright>
* 	<author>JuriTech Team</author>
*   <date>01/04/2022</date>
*	<description>Classe Fase Processual</description>
**/

using Newtonsoft.Json;

namespace JuriTechV2.Models
{
    /// <summary>
    /// Purpose:
    /// Created by: JuriTech Team
    /// Created on: 01/04/2022
    /// </summary>
    /// <remarks></remarks>
    /// <example></example>
    [Keyless]
    public class FaseProcessual
    {
        #region Attributes
        int idEstado, idUtilizador; 
        string nrProcesso;
        int? nrDias;
        string dataEntrada;
        string? dataSaida;
        #endregion

        #region Methods

        #region Constructors
        /// <summary>
        /// The default Constructor.
        /// </summary>
        public FaseProcessual(int idEstado, string nrProcesso, int? nrDias, string dataEntrada, string dataSaida, int idUtilizador)
        {
            this.idEstado = idEstado;
            this.nrProcesso = nrProcesso;
            this.nrDias = nrDias;
            this.dataEntrada = dataEntrada;
            this.dataSaida = dataSaida;
            this.idUtilizador = idUtilizador;
        }
        public FaseProcessual() { }
        #endregion

        #region Properties
        public int IdEstado { get { return idEstado; } set { idEstado = value; } }
        public string NrProcesso { get { return nrProcesso; } set { nrProcesso = value; } }
        public int? NrDias { get { return nrDias; } set { nrDias = value; } }
        public string DataEntrada { get { return dataEntrada; } set { dataEntrada = value; } }
        public string? DataSaida { get { return dataSaida; } set { dataSaida = value; } }
        public int IdUtilizador { get { return idUtilizador; } set { idUtilizador= value; } }

        #endregion

        #region Functions

        #endregion

        #region Overrides
        #endregion

        #region Destructor
        /// <summary>
        /// The destructor.
        /// </summary>
        ~FaseProcessual()
        {
        }
        #endregion

        #endregion
    }
}
