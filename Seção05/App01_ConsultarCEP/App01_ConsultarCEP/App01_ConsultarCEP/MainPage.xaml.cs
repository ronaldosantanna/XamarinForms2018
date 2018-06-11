using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using App01_ConsultarCEP.Serviço.Modelo;
using App01_ConsultarCEP.Serviço;

namespace App01_ConsultarCEP
{
	public partial class MainPage : ContentPage
	{
		public MainPage()
		{
			InitializeComponent();

            BOTAO.Clicked += BuscarCEP;

		}
        private void BuscarCEP(object sender, EventArgs args)
        {
            string cep = CEP.Text.Trim();
            if (isValid(cep))
            {
                try {
                    Endereco end = ViaCepServico.BuscarEnderecoViaCEP(cep);

                    RESULTADO.Text = string.Format("Endereço: {2}, {3}, {0}-{1}", end.localidade, end.uf, end.logradouro, end.bairro);
                }catch(Exception e)
                {
                    DisplayAlert("ERRO CRÍTICO", e.Message, "OK");
                }
            }
            }
        private bool isValid(string cep)
        {
            bool valido = true;

            if (cep.Length != 8)
            {
                DisplayAlert("ERRO", "CEP Inválido! O CEP deve conter 8 caracteres.", "OK");
                valido = false;
            }
            int novoCEP = 0;
            if (!int.TryParse(cep, out novoCEP))
            {
                DisplayAlert("ERRO", "CEP Inválido! O CEP deve ser composto apenas por números.", "OK");
                valido = false;
            }
            return valido;
        }
	}
}
