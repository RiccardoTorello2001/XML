using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml.Linq;

namespace Demoxml
{
	/// <summary>
	/// Logica di interazione per MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		public MainWindow()
		{
			InitializeComponent();
		}

		bool flag = false;

		private void Btn_aggiorna_Click(object sender, RoutedEventArgs e)
		{
			Lst_calciatori.Items.Clear();
			Task.Factory.StartNew(()=>CaricaDati());
			flag = true;
		}

		private void CaricaDati()
		{
			Calciatore giocatori =new Calciatore();
			string path = @"Calciatori.xml";
			XDocument xmlDoc = XDocument.Load(path);
			XElement xmlcalciatori = xmlDoc.Element("calciatori");
			var xmlcalciatore = xmlcalciatori.Elements("calciatore");
			foreach (var item in xmlcalciatore)
			{
				XElement xmlFirstName = item.Element("nome");
				XElement xmlLastName = item.Element("cognome");
				XElement xmlSquadra = item.Element("squadra");
				XElement xmlNascita = item.Element("data");
				Calciatore a = new Calciatore();
				a.Nome = xmlFirstName.Value;
				a.Cognome = xmlLastName.Value;
				a.Squadra = xmlSquadra.Value;
				a.Data = Convert.ToDateTime(xmlNascita.Value);
				giocatori = a;
				Dispatcher.Invoke(() => Lst_calciatori.Items.Add(giocatori));
				Thread.Sleep(300);
				if (!flag)
				{
					break;

				}
			}
			
		}

		private void Btn_stop_Click(object sender, RoutedEventArgs e)
		{
			flag = false;
		}

		private void btn_modifica_Click(object sender, RoutedEventArgs e)
		{
			string path = @"Calciatori.xml";
			XDocument xmldoc = XDocument.Load(path);
			XElement xmlgiocatore = xmldoc.Element("calciatori");
			var xmlcalciatore = xmlgiocatore.Elements("calciatore");
			foreach (var item in xmlcalciatore)
			{
				XElement xmlName = item.Element("nome");
				XElement xmlCognome = item.Element("cognome");
				XElement xmlsquadra = item.Element("squadra");
				XElement xmlnascita = item.Element("data");

				Calciatore p = new Calciatore();
				p.Nome = xmlName.Value;
				p.Cognome = xmlCognome.Value;
				p.Squadra = xmlsquadra.Value;
				p.Data = Convert.ToDateTime(xmlnascita.Value);

				if (Convert.ToString(Lst_calciatori.SelectedItem)==p.Nome)
				{
					txt_nome.Text = p.Nome;
					txt_cognome.Text = p.Cognome;
					txt_squadra.Text = p.Squadra;
					txt_eta.Text =Convert.ToString(p.Data);
					break;

				}
			}


		}

		int flag1 = 0;

		private void btn_salva_Click(object sender, RoutedEventArgs e)
		{
			int flag2 = 0;
			string path = @"Calciatori.xml";
			XDocument xmldoc = XDocument.Load(path);
			XElement xmlgiocatore = xmldoc.Element("calciatori");
			var xmlcalciatore = xmlgiocatore.Elements("calciatore");
			foreach (var item in xmlcalciatore)
			{
				XElement xmlName = item.Element("nome");
				XElement xmlCognome = item.Element("cognome");
				XElement xmlsquadra = item.Element("squadra");
				XElement xmlnascita = item.Element("data");
				
				if (flag1 == flag2)
				{
					item.SetElementValue("nome", txt_nome.Text);
					item.SetElementValue("cognome", txt_cognome.Text);
					item.SetElementValue("squadra", txt_squadra.Text);
					item.SetElementValue("data", txt_eta.Text);
					break;

				}

				flag2++;
			}
			xmldoc.Save("Calciatori.xml");

		}
	}
}
