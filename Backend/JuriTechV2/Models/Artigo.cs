/*
*	<copyright file="Artigo.cs" company="JuriTech">
*		Copyright (c) 2022 All Rights Reserved
*	</copyright>
* 	<author>JuriTech Team</author>
*   <date>01/04/2022</date>
*	<description>Classe Artigo</description>
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

    public class Artigo
    {
        #region Attributes

        int idCodigo, nrArtigo, idUtilizador, dias, meses, anos;
        string nome;
        bool ferias, diasNaoUteis;
        #endregion



        #region Constructors
        /// <summary>
        /// The default Constructor.
        /// </summary>


        public Artigo(int idCodigo, int nrArtigo, int idUtilizador, int dias, int meses, int anos, bool diasNaoUteis, string nome, bool ferias)
        {
            this.idCodigo = idCodigo;
            this.nrArtigo = nrArtigo;
            this.idUtilizador = idUtilizador;
            this.dias = dias;
            this.meses = meses;
            this.anos = anos;
            this.diasNaoUteis = diasNaoUteis;
            this.nome = nome;
            this.ferias = ferias;
        }
        public Artigo() { }
        #endregion

        #region Properties
        public int IdCodigo { get { return idCodigo; } set { idCodigo = value; } }
        public int NrArtigo { get { return nrArtigo; } set { nrArtigo = value; } }
        public int IdUtilizador { get { return idUtilizador; } set { idUtilizador = value; } }
        public int Dias { get { return dias; } set { dias = value; } }
        public int Meses { get { return meses; } set { meses = value; } }
        public int Anos { get { return anos; } set { anos = value; } }
        public bool DiasNaoUteis { get { return diasNaoUteis; } set { diasNaoUteis = value; } }
        public string Nome { get { return nome; } set { nome = value; } }
        public bool Ferias { get { return ferias; } set { ferias = value; } }
        #endregion

        #region Metodos
        public int diasAno(int ano, int nrAnos)
        {
            int dias = 0;
            while (nrAnos > 0)
            {
                if (anoBissexto(ano)) dias += 366;
                else dias += 365;
                nrAnos--;
            }
            return dias;
        }
        public int diasMes(int mes, int ano, int nrMeses)
        {
            int dias = 0;
            while (nrMeses > 0)
            {
                if (mes == 1 || mes == 3 || mes == 5 || mes == 7 || mes == 8 || mes == 10 || mes == 12) dias += 31;
                else if ((mes == 2) && (!anoBissexto(ano))) dias += 28;
                else if ((mes == 2) && (anoBissexto(ano))) dias += 29;
                else dias += 30;
                nrMeses--;
            }
            return dias;
        }
        public bool anoBissexto(int ano)
        {
            if (((ano % 4 == 0) && (ano % 100 != 0)) || (ano % 400 == 0)) return true;
            else return false;
        }
        /// <summary>
        /// metodo que retorna um dicionario com o nome e data dos feriados todos em Portugal respetivo a cada ano
        /// </summary>
        /// <param name="yearParameter"></param>
        /// <returns></returns>
        public static Dictionary<string, DateTime> ListaComFeriadosDoAno(int? yearParameter = null)
        {
            var holidayList = new Dictionary<string, DateTime>();
            var year = DateTime.Now.Year;

            if (yearParameter != null)
                year = yearParameter.Value;

            holidayList.Add("Ano_novo", new DateTime(year, 1, 1)); //Ano novo 
            holidayList.Add("Dia_indepencia", new DateTime(year, 4, 25)); //25 Abril 
            holidayList.Add("dia_trabalhador", new DateTime(year, 5, 1)); //Dia do trabalhador
            holidayList.Add("Dia_Portugal", new DateTime(year, 6, 10)); //Dia de Portugal 
            holidayList.Add("Dia_assunção_nossa_senhora", new DateTime(year, 8, 15)); //Dia Assunçao nossa senhora       
            holidayList.Add("Proclamaçao_republica", new DateTime(year, 10, 5)); //Proclamação da República
            holidayList.Add("todos_santos", new DateTime(year, 11, 1)); //todos santos
            holidayList.Add("Restauraçao_idependencia", new DateTime(year, 12, 1)); //Restauração Idependencia
            holidayList.Add("Imaculada_conceiçao", new DateTime(year, 12, 8)); //Imaculada Conceição
            holidayList.Add("Natal", new DateTime(year, 12, 25)); //Natal 


            #region FeriadosMóveis

            int x, y;
            int a, b, c, d, e;
            int day, month;

            if (year >= 1900 & year <= 2099)
            {
                x = 24;
                y = 5;
            }
            else
                if (year >= 2100 & year <= 2199)
            {
                x = 24;
                y = 6;
            }
            else
                    if (year >= 2200 & year <= 2299)
            {
                x = 25;
                y = 7;
            }
            else
            {
                x = 24;
                y = 5;
            }

            a = year % 19;
            b = year % 4;
            c = year % 7;
            d = (19 * a + x) % 30;
            e = (2 * b + 4 * c + 6 * d + y) % 7;

            if ((d + e) > 9)
            {
                day = (d + e - 9);
                month = 4;
            }

            else
            {
                day = (d + e + 22);
                month = 3;
            }

            var pascoa = new DateTime(year, month, day);
            var sextaSanta = pascoa.AddDays(-2);
            var carnaval = pascoa.AddDays(-47);
            var corpusChristi = pascoa.AddDays(60);
            var diaRamos = pascoa.AddDays(-7);
            var segundaPascoa = pascoa.AddDays(1);

            holidayList.Add("Pascoa", pascoa);
            holidayList.Add("sexta_santa", sextaSanta);
            holidayList.Add("Carnaval", carnaval);
            holidayList.Add("Corpo_cristo", corpusChristi);
            holidayList.Add("dia_ramos", diaRamos);
            holidayList.Add("segunda_pascoa", segundaPascoa);

            #endregion

            return holidayList;
        }
        public bool fimSemana(DateTime date)
        {
            return date.DayOfWeek == DayOfWeek.Saturday || date.DayOfWeek == DayOfWeek.Sunday;
        }
        public bool feriado(int year, DateTime date)
        {
            var feriados = Artigo.ListaComFeriadosDoAno(year);
            foreach (var feriado in feriados)
            {


                if (date.ToString("d") == feriado.Value.ToString("d"))
                {

                    return true;
                }

            }
            return false;
        }
        public bool FeriasPascoa(DateTime date)
        {

            string date1 = date.ToString("d");
            var holidayList = new Dictionary<string, DateTime>(); // dicionario com o domingo de ramos e a segunda feira de pascoa de cada ano
            var year = date.Year; // o ano em que se encontra
            List<DateTime> listaDiasFeriasPascoa = new List<DateTime>(); // lista das ferias da pascoa de cada ano
            DateTime dataInicial = DateTime.Now;
            DateTime dataFinal = new DateTime();

            #region FeriadosMóveis

            int x, y;
            int a, b, c, d, e;
            int day, month;

            if (year >= 1900 & year <= 2099)
            {
                x = 24;
                y = 5;
            }
            else
                if (year >= 2100 & year <= 2199)
            {
                x = 24;
                y = 6;
            }
            else
                    if (year >= 2200 & year <= 2299)
            {
                x = 25;
                y = 7;
            }
            else
            {
                x = 24;
                y = 5;
            }

            a = year % 19;
            b = year % 4;
            c = year % 7;
            d = (19 * a + x) % 30;
            e = (2 * b + 4 * c + 6 * d + y) % 7;

            if ((d + e) > 9)
            {
                day = (d + e - 9);
                month = 4;
            }

            else
            {
                day = (d + e + 22);
                month = 3;
            }

            var pascoa = new DateTime(year, month, day);

            var diaRamos = pascoa.AddDays(-7);
            var segundaPascoa = pascoa.AddDays(1);

            holidayList.Add("dia_ramos", diaRamos);
            holidayList.Add("segunda_pascoa", segundaPascoa);

            #endregion
            foreach (var data in holidayList)
            {



                if (data.Key == "dia_ramos")
                {
                    data.Value.ToString("d");
                    dataInicial = data.Value;

                    dataFinal = data.Value.AddDays(8); // 8 dias do domingo ramos á segunda feira pascoa

                }
            }
            if (dataInicial == DateTime.Now) return false; // se a variavel data não modificar é porque não encontrou o primeiro dias das ferias da pascoa
            if (date >= dataInicial && date <= dataFinal) return true;
            return false;
        }

        /// <summary>
        /// retorna true ou false se um determinado dia num determinado ano se encontra em ferias de natal
        /// </summary>
        /// <param name="date"></param>
        /// <param name="ano"></param>
        /// <returns></returns>
        public bool FeriasNatal(DateTime date, DateTime dataFinal, DateTime dataInicial)
        {
            List<DateTime> listaDiasFeriasNatal = new List<DateTime>();
            if (date >= dataInicial && date <= dataFinal) return true;
            return false;

        }

        /// <summary>
        /// retorna true ou false se um determinado dia num determinado ano se encontra em ferias de verao
        /// </summary>
        /// <param name="date"></param>
        /// <param name="ano"></param>
        /// <returns></returns>

        public bool FeriasVerao(DateTime date, int ano)
        {
            string date1 = date.ToString("dd/MM/yyyy");
            List<DateTime> listaDiasFeriasNatal = new List<DateTime>();
            DateTime dataInicial = DateTime.Parse("16/07/" + ano);
            DateTime dataFinal = DateTime.Parse("31/08/" + ano);
            while (dataInicial <= dataFinal)
            {
                listaDiasFeriasNatal.Add(dataInicial);
                dataInicial = dataInicial.AddDays(1); // adiciona na lista as ferias da pascoa
            }
            foreach (var data in listaDiasFeriasNatal)
            {
                string cmp = data.ToString("dd/MM/yyyy"); // para ser comparavel no if
                if (date1 == cmp) return true;
            }
            return false;
        }
        #endregion

        #region Overrides
        #endregion

        #region Destructor
        /// <summary>
        /// The destructor.
        /// </summary>
        ~Artigo()
        {
        }
        #endregion


    }
}
