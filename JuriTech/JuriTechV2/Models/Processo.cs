/*
*	<copyright file="Processo.cs" company="JuriTech">
*		Copyright (c) 2022 All Rights Reserved
*	</copyright>
* 	<author>JuriTech Team</author>
*   <date>01/04/2022</date>
*	<description>Classe Processo</description>
**/

using System.ComponentModel.DataAnnotations;

namespace JuriTechV2.Models
{
    /// <summary>
    /// Purpose:
    /// Created by: JuriTech Team
    /// Created on: 01/04/2022
    /// </summary>
    /// <remarks></remarks>
    /// <example></example>
    public class Processo
    {
        #region Attributes
        int idTipo, idUtilizador;
        string nrProcesso, nome, notas;
        decimal valor;
        string dataEntrada;
        bool estado;
        #endregion

        #region Methods

        #region Constructors
        /// <summary>
        /// The default Constructor.
        /// </summary>
        public Processo(string nrProcesso, int idTipo, int idTema, int idUtilizador, decimal valor, string nome, string notas, string dataEntrada, bool estado)
        {
            this.nrProcesso = nrProcesso;
            this.idTipo = idTipo;
            this.idUtilizador = idUtilizador;
            this.valor = valor;
            this.nome = nome;
            this.notas = notas;
            this.dataEntrada = dataEntrada;
            this.estado = estado;
        }

        public Processo() { }
        #endregion

        #region Properties
        public string NrProcesso { get { return nrProcesso; } set { nrProcesso = value; } }
        public int IdTipo { get { return idTipo; } set { idTipo = value; } }
        public int IdUtilizador { get { return idUtilizador; } set { idUtilizador = value; } }
        public decimal Valor { get { return valor; } set { valor = value; } }
        public string Nome { get { return nome; } set { nome = value; } }
        public string Notas { get { return notas; } set { notas = value; } }
        public string DataEntrada { get { return dataEntrada; } set { dataEntrada = value; } }
        public bool Estado { get { return estado; } set { estado = value; } }
        #endregion

        #region Functions

        #endregion

        #region Overrides
        #endregion

        #region Destructor
        /// <summary>
        /// The destructor.
        /// </summary>
        ~Processo()
        {
        }
        #endregion

        #endregion
    }
}
