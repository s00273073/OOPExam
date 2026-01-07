using System.Collections.Generic;
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



namespace OOP
{
    /// https://github.com/s00273073/OOPExam
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<Robot> _robots = new();

        public MainWindow()
        {
            InitializeComponent();
            _robots = CreateRobots();
        }

        private List<Robot> CreateRobots()
        {
            // Create household robots first so we can call DownloadSkill on them
            var houseBot = new HouseholdRobot(
                name: "HouseBot",
                powerCapacityKwh: 5.0,
                currentPowerKwh: 3.2,
                initialSkills: new[] { HouseholdSkill.Cleaning, HouseholdSkill.Cooking });

            var gardenMate = new HouseholdRobot(
                name: "GardenMate",
                powerCapacityKwh: 6.0,
                currentPowerKwh: 4.5,
                initialSkills: new[] { HouseholdSkill.Gardening, HouseholdSkill.Cleaning });

            var housemate3000 = new HouseholdRobot(
                name: "Housemate 3000",
                powerCapacityKwh: 7.5,
                currentPowerKwh: 6.0,
                initialSkills: new[] { HouseholdSkill.Cooking, HouseholdSkill.Laundry, HouseholdSkill.ChildCare });

            // Apply requested additional skills via DownloadSkill
            gardenMate.DownloadSkill(HouseholdSkill.Gardening);
            housemate3000.DownloadSkill(HouseholdSkill.Cooking);
            housemate3000.DownloadSkill(HouseholdSkill.Laundry);

            // Delivery robots
            var deliverBot = new DeliveryRobot(
                name: "DeliverBot",
                modeOfDelivery: DeliveryMode.Driving,
                maxLoadKg: 15.0,
                powerCapacityKwh: 12.0,
                currentPowerKwh: 9.0);

            var flyBot = new DeliveryRobot(
                name: "FlyBot",
                modeOfDelivery: DeliveryMode.Flying,
                maxLoadKg: 5.0,
                powerCapacityKwh: 8.0,
                currentPowerKwh: 7.0);

            var drive = new DeliveryRobot(
                name: "Drive",
                modeOfDelivery: DeliveryMode.Driving,
                maxLoadKg: 20.0,
                powerCapacityKwh: 15.0,
                currentPowerKwh: 15.0);

            var robots = new List<Robot>
            {
                houseBot,
                gardenMate,
                housemate3000,
                deliverBot,
                flyBot,
                drive
            };

            return robots;
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
          
        }

        private void TextBox_TextChanged_1(object sender, TextChangedEventArgs e)
        {

        }
        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
        }
    }
}