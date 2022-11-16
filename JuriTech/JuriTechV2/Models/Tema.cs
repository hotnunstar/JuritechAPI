/*
*	<copyright file="Tema.cs" company="JuriTech">
*		Copyright (c) 2022 All Rights Reserved
*	</copyright>
* 	<author>JuriTech Team</author>
*   <date>01/04/2022</date>
*	<description>Classe Tema</description>
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
    public class Tema
    {
        #region Attributes
        int id, idUtilizador;
        string nome;
        #endregion

        #region Methods

        #region Constructors
        /// <summary>
        /// The default Constructor.
        /// </summary>
        public Tema() { }
        public Tema(int id, int idUtilizador, string nome)
        {
            this.id = id;
            this.idUtilizador = idUtilizador;
            this.nome = nome;
        }
        #endregion

        #region Properties
        public int Id { get { return id; } set { id = value; } }
        public int IdUtilizador { get { return idUtilizador; } set { idUtilizador = value; } }
        public string Nome { get { return nome; } set { nome = value; } }
        #endregion

        #region Functions

        #endregion

        #region Overrides
        #endregion

        #region Destructor
        /// <summary>
        /// The destructor.
        /// </summary>
        ~Tema()
        {
        }
        #endregion

        #endregion
    }
}