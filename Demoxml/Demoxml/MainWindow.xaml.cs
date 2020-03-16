using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
		List<Calciatore> calciatori;
		public MainWindow()
		{
			InitializeComponent();
		}

		private void Btn_aggiorna_Click(object sender, RoutedEventArgs e)
		{
			Task.Factory.StartNew(()=>CaricaDati());

		}

		private void CaricaDati()
		{
			calciatori = new List<Calciatore>();
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
				calciatori.Add(a);
			}
			Dispatcher.Invoke(()=>Lst_calciatori.ItemsSource = calciatori);
		}
	}
}
