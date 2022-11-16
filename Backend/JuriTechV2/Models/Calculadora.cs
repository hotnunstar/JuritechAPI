/*using System.ComponentModel.DataAnnotations;

namespace JuriTechV2.Models
{
    [Keyless]
    public class Calculadora
    {
        #region Attributes
        int ano, mes, dias;
        bool ferias;
        DateTime dataInicial = new DateTime();
        DateTime dataFinal = new DateTime();
        #endregion

        #region Methods

        #region Constructors
        /// <summary>
        /// The default Constructor.
        /// </summary>
        public Calculadora(int ano, int mes, int dias, DateTime dataInicial, DateTime dataFinal, bool ferias)
        {
            this.ano = ano;
            this.mes = mes;
            this.dias = dias;
            this.dataInicial = dataInicial;
            this.dataFinal = dataFinal;
            this.ferias = ferias;
        }
        public Calculadora()
        {

        }
        #endregion

        #region Properties
        public int Ano { get { return ano; } set { ano = value; } }
        public int Mes { get { return mes; } set { mes = value; } }
        public int Dias { get { return dias; } set { dias = value; } }
        public DateTime DataInicial { get { return dataInicial; } set { dataInicial = value; } }
        public DateTime DataFinal { get { return dataFinal; } set { dataFinal = value; } }
        public bool Ferias { get { return ferias; } set { ferias = value; } }
        #endregion

        #region Functions

        #endregion

        #region Overrides
        #endregion

        #region Destructor
        /// <summary>
        /// The destructor.
        /// </summary>
        ~Calculadora()
        {
        }
        #endregion

        #endregion
    }
}
*/