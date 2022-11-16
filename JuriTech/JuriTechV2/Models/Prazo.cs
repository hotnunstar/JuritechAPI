/*
*	<copyright file="Prazo.cs" company="JuriTech">
*		Copyright (c) 2022 All Rights Reserved
*	</copyright>
* 	<author>JuriTech Team</author>
*   <date>01/04/2022</date>
*	<description>Classe Prazo</description>
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
    [Keyless]
    public class Prazo
    {
        #region Attributes
        int idPrazoCodigo, idUtilizador, idCodigo, nrArtigo;
        string nrProcesso;
        string dataInicial, dataFinal;
 
        #endregion

        #region Constructors
        /// <summary>
        /// The default Constructor.
        /// </summary>
        public Prazo(int idPrazoCodigo, string nrProcesso, string dataInicial, string dataFinal, int idUtilizador,int idCodigo,int nrArtigo)
        {
            this.idPrazoCodigo = idPrazoCodigo;
            this.nrProcesso = nrProcesso;
            this.dataInicial = dataInicial;
            this.dataFinal = dataFinal;
            this.idUtilizador = idUtilizador;
            this.idCodigo = idCodigo;
            this.nrArtigo = nrArtigo;
        }

        public Prazo() { }
        #endregion

        #region Properties
        public int IdPrazoCodigo { get { return idPrazoCodigo; } set { idPrazoCodigo = value; } }
        public string NrProcesso { get { return nrProcesso; } set { nrProcesso = value; } }
        public string DataInicial { get { return dataInicial; } set { dataInicial = value; } }
        public string DataFinal { get { return dataFinal; } set { dataFinal = value; } }
        public int IdUtilizador { get { return idUtilizador; } set { idUtilizador = value; } }
        public int IdCodigo { get { return idCodigo; } set { idCodigo = value; } }
        public int NrArtigo { get { return nrArtigo; } set { nrArtigo = value; } }
        #endregion

        #region Metodos
        /// <summary>
        /// Funçao que retorna a data final de um prazo processual (nota : o calculo é efetuado tendo em conta apenas dias)
        /// </summary>
        /// <param name="d1"></param>
        /// <param name="dataInicial"></param>
        /// <returns></returns>
        public DateTime RetornaCalculoDiasProcessual(Artigo d1, string data1)
        {
            DateTime dataInicial = DateTime.Parse(data1);
            if (d1.Dias != 0)
            {
                Dictionary<string, bool> lista = new Dictionary<string, bool>();
                DateTime dataFinal = dataInicial.AddDays(d1.Dias);
                Console.WriteLine(dataFinal);
                DateTime NatalFinal = new DateTime(dataInicial.Year + 1, 01, 03);
                DateTime NatalInicial = new DateTime(dataInicial.Year, 12, 22);

                int diasNaoContam = 0;

                dataInicial = dataInicial.AddDays(1);
                for (DateTime data = dataInicial; data < dataFinal; data = data.AddDays(1))
                {
                    if (d1.FeriasPascoa(data) || d1.FeriasVerao(data, data.Year) || d1.FeriasNatal(data, NatalFinal, NatalInicial))
                    {
                        diasNaoContam += 1;
                        lista.Add(data.ToString(), false);
                    }
                    else lista.Add(data.ToString(), true);

                    if ((d1.FeriasNatal(data, NatalFinal, NatalInicial) == false) && (d1.FeriasNatal(data.AddDays(-1), NatalFinal, NatalInicial) == true))
                    {
                        NatalInicial = NatalInicial.AddYears(1);
                        NatalFinal = NatalFinal.AddYears(1);
                    }
                    dataInicial = data;
                }

                dataInicial = dataInicial.AddDays(1);

                while (diasNaoContam > 0)
                {
                    if (d1.FeriasPascoa(dataInicial) || d1.FeriasVerao(dataInicial, dataInicial.Year) || d1.FeriasNatal(dataInicial, NatalFinal, NatalInicial)) lista.Add(dataInicial.ToString(), false);
                    else
                    {
                        diasNaoContam -= 1;
                        lista.Add(dataInicial.ToString(), true);
                    }

                    if ((d1.FeriasNatal(dataInicial, NatalFinal, NatalInicial) == false) && (d1.FeriasNatal(dataInicial.AddDays(-1), NatalFinal, NatalInicial) == true))
                    {
                        NatalInicial = NatalInicial.AddYears(1);
                        NatalFinal = NatalFinal.AddYears(1);
                    }
                    dataInicial = dataInicial.AddDays(1);
                }

                while (d1.fimSemana(dataInicial) || d1.feriado(dataInicial.Year, dataInicial)) dataInicial = dataInicial.AddDays(1);
            }
            return dataInicial;
        }

        /// <summary>
        /// Funçao que retorna a data final de um prazo processual em caso de urgência (nota : o calculo é efetuado tendo em conta apenas dias)
        /// </summary>
        /// <param name="d1"></param>
        /// <param name="dataInicial"></param>
        /// <returns></returns>
        public DateTime RetornaCalculoDiasProcessualSos(Artigo d1, string data1)
        {
            DateTime dataInicial = DateTime.Parse(data1);
            DateTime dataFinal = dataInicial.AddDays(d1.Dias);
            while (d1.fimSemana(dataFinal) || d1.feriado(dataFinal.Year, dataFinal)) dataFinal = dataFinal.AddDays(1);

            return dataFinal;
        }

        /// <summary>
        /// funçao que retorna a data final de um prazo procedimental (nota : o calculo é efetuado tendo em conta apenas dias)
        /// </summary>
        /// <param name="d1"></param>
        /// <param name="dataInicial"></param>
        /// <returns></returns>
        public DateTime RetornaCalculoDiasProcedimental(Artigo d1, string data1)
        {
            DateTime dataInicial = DateTime.Parse(data1);
            if (d1.Dias != 0)
            {
                Dictionary<string, bool> lista = new Dictionary<string, bool>();
                DateTime dataFinal = dataInicial.AddDays(d1.Dias);
                Console.WriteLine(dataFinal);
                DateTime NatalFinal = new DateTime(dataInicial.Year + 1, 01, 03);
                DateTime NatalInicial = new DateTime(dataInicial.Year, 12, 22);

                int diasNaoContam = 0;

                dataInicial = dataInicial.AddDays(1);
                for (DateTime data = dataInicial; data < dataFinal; data = data.AddDays(1))
                {
                    if (d1.feriado(data.Year, data) || d1.fimSemana(data))
                    {
                        diasNaoContam += 1;
                        lista.Add(data.ToString(), false);
                    }
                    else lista.Add(data.ToString(), true);

                    dataInicial = data;
                }

                dataInicial = dataInicial.AddDays(1);

                while (diasNaoContam > 0)
                {
                    if (d1.feriado(dataInicial.Year, dataInicial) || d1.fimSemana(dataInicial)) lista.Add(dataInicial.ToString(), false);
                    else
                    {
                        diasNaoContam -= 1;
                        lista.Add(dataInicial.ToString(), true);
                    }
                    dataInicial = dataInicial.AddDays(1);
                }
                while (d1.fimSemana(dataInicial) || d1.feriado(dataInicial.Year, dataInicial)) dataInicial = dataInicial.AddDays(1);
            }
            return dataInicial;
        }

        /// <summary>
        /// funçao que retorna a data final de um prazo prescriçao (nota : o calculo é efetuado tendo em conta apenas dias)
        /// </summary>
        /// <param name="d1"></param>
        /// <param name="dataInicial"></param>
        /// <returns></returns>
        public DateTime RetornaCalculoDiasPrescricao(Artigo d1, string data1)
        {
            DateTime dataInicial = DateTime.Parse(data1);
            DateTime dataFinal = dataInicial.AddDays(d1.Dias);
            return dataFinal;
        }

        /// <summary>
        /// funçao que retorna a data final de um prazo de caducidade (nota : o calculo é efetuado tendo em conta apenas dias)
        /// </summary>
        /// <param name="d1"></param>
        /// <param name="dataInicial"></param>
        /// <returns></returns>
        public DateTime RetornaCalculoDiasCaducidade(Artigo d1, string data1)
        {
            DateTime dataInicial = DateTime.Parse(data1);
            DateTime dataFinal = dataInicial.AddDays(d1.Dias);
            while (d1.fimSemana(dataFinal) || d1.feriado(dataFinal.Year, dataFinal))
            {

                dataFinal = dataFinal.AddDays(1);

            }
            return dataFinal;
        }

        #endregion

        #region Overrides
        #endregion

        #region Destructor
        /// <summary>
        /// The destructor.
        /// </summary>
        ~Prazo()
        {
        }
        #endregion


    }
}
