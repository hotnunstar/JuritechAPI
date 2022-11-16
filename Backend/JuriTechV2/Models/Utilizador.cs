/*
*	<copyright file="Utilizador.cs" company="JuriTech">
*		Copyright (c) 2022 All Rights Reserved
*	</copyright>
* 	<author>JuriTech Team</author>
*   <date>01/04/2022</date>
*	<description>Classe Utilizador</description>
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
    public class Utilizador
    {
        #region Attributes
        int id;             // Automático
        string nome;        // Não nulo!
        string email;       // Verificar formato correto!
        string password;
        #endregion

        #region Methods

        #region Constructors
        /// <summary>
        /// The default Constructor.
        /// </summary>

        public Utilizador() { }
        public Utilizador(int id, string nome, string email, string password)
        {
            this.id = id;
            this.nome = nome;
            this.email = email;
            this.password = password;
        }
        #endregion

        #region Properties
        public int Id { get { return id; } set { id = value; } }
        public string Nome { get { return nome; } set { nome = value; } }
        public string Email { get { return email; } set { email = value; } }
        public string Password { get { return password; } set { password = value; } }
        #endregion

        #region Functions
        #endregion

        #region Overrides
        #endregion

        #region Destructor
        /// <summary>
        /// The destructor.
        /// </summary>
        ~Utilizador()
        {
        }
        #endregion

        #endregion
    }
}
