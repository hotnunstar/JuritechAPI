/*
*	<copyright file="TipoProcesso.cs" company="JuriTech">
*		Copyright (c) 2022 All Rights Reserved
*	</copyright>
* 	<author>JuriTech Team</author>
*   <date>01/04/2022</date>
*	<description>Classe Tipo de Processo</description>
**/

namespace JuriTechV2.Models
{
    /// <summary>
    /// Purpose:
    /// Created by: JuriTech Team
    /// Created on: 01/04/2022
    /// </summary>
    /// <remarks></remarks>
    /// <example></example>
    public class TipoProcesso
    {
        #region Attributes
        int id, idTema, idUtilizador;
        string nome;
        #endregion

        #region Methods

        #region Constructors
        /// <summary>
        /// The default Constructor.
        /// </summary>
        public TipoProcesso() { }
        public TipoProcesso(int id, int idUtilizador, string nome, int idTema)
        {
            this.id = id;
            this.idUtilizador = idUtilizador;
            this.nome = nome;
            this.idTema = idTema;
        }
        #endregion

        #region Properties
        public int Id { get { return id; } set { id = value; } }
        public int IdUtilizador { get { return idUtilizador; } set { idUtilizador = value; } }
        public string Nome { get { return nome; } set { nome = value; } }
        public int IdTema { get { return idTema; } set { idTema = value; } }
        #endregion

        #region Functions

        #endregion

        #region Overrides
        #endregion

        #region Destructor
        /// <summary>
        /// The destructor.
        /// </summary>
        ~TipoProcesso()
        {
        }
        #endregion

        #endregion
    }
}
