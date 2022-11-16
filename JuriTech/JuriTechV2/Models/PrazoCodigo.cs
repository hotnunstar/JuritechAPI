/*
*	<copyright file="PrazoCodigo.cs" company="JuriTech">
*		Copyright (c) 2022 All Rights Reserved
*	</copyright>
* 	<author>JuriTech Team</author>
*   <date>01/04/2022</date>
*	<description>Classe Prazo Código</description>
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
    public class PrazoCodigo
    {
        #region Attributes
        int id, idTipoPrazo, idCodigo;
        #endregion

        #region Methods

        #region Constructors

        /// <summary>
        /// The default Constructor.
        /// </summary>
        public PrazoCodigo(int id, int idTipoPrazo, int idCodigo)
        {
            this.id = id;
            this.idTipoPrazo = idTipoPrazo;
            this.idCodigo = idCodigo;
        }

        public PrazoCodigo(){}
        #endregion

        #region Properties
        public int Id { get { return id; } set { id = value; } }
        public int IdTipoPrazo { get { return idTipoPrazo; } set { idTipoPrazo = value; } }
        public int IdCodigo { get { return idCodigo; } set { idCodigo = value; } }
        #endregion

        #region Functions

        #endregion

        #region Overrides
        #endregion

        #region Destructor
        /// <summary>
        /// The destructor.
        /// </summary>
        ~PrazoCodigo()
        {
        }
        #endregion

        #endregion
    }
}