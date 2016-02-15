using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Forms;
using BasicOperations.Factories;

namespace BasicsViewer {
	/// <summary>
	/// Interaction logic for CreationPage.xaml
	/// </summary>
	public partial class CreationPage : Page {
		public CreationPage() {
			InitializeComponent();

			Type type;
			TypeFactory.Singleton.QualifierName = "Kingdoms";
			TypeFactory.Singleton.CreateClassificationType("Kingdom", "Kingdom");

			//create kingdom like Animalia
			TypeFactory.Singleton.CreateClassificationType("Plantea", "Plants");
			type = TypeFactory.Singleton.GetClassification("Plants");

			latinKingdomText.DataContext = TypeFactory.Singleton;
			//kingdomBox.ItemsSource = TypeFactory.Singleton.RegisteredTypes;
			kingdomBox.ItemsSource = new BindingSource(TypeFactory.Singleton.RegisteredTypes, null);
			//kingdomBox.DisplayMember = "Value";
		}
	}
}
