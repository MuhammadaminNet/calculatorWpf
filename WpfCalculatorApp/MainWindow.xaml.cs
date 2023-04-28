using System.Windows;

namespace WpfCalculatorApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly RequaredMethods requaredMethods;
        internal string tmpSaver = "0";

        public MainWindow()
        {
            InitializeComponent();
            requaredMethods = new RequaredMethods(this);
        }

        private void ACbtn_Click(object sender, RoutedEventArgs e) => (MainInput2.Text, tmpSaver) = ("0", "0");
        private void b9_Click(object sender, RoutedEventArgs e) => requaredMethods.NumberBtnClick('9');
        private void b8_Click(object sender, RoutedEventArgs e) => requaredMethods.NumberBtnClick('8');
        private void b7_Click(object sender, RoutedEventArgs e) => requaredMethods.NumberBtnClick('7');
        private void b6_Click(object sender, RoutedEventArgs e) => requaredMethods.NumberBtnClick('6');
        private void b5_Click(object sender, RoutedEventArgs e) => requaredMethods.NumberBtnClick('5');
        private void b4_Click(object sender, RoutedEventArgs e) => requaredMethods.NumberBtnClick('4');
        private void b3_Click(object sender, RoutedEventArgs e) => requaredMethods.NumberBtnClick('3');
        private void b2_Click(object sender, RoutedEventArgs e) => requaredMethods.NumberBtnClick('2');
        private void b1_Click(object sender, RoutedEventArgs e) => requaredMethods.NumberBtnClick('1');
        private void b0_Click(object sender, RoutedEventArgs e) => requaredMethods.NumberBtnClick('0');
        private void bdot_Click(object sender, RoutedEventArgs e) => requaredMethods.NumberBtnClick(',');
        private void bdivide_Click(object sender, RoutedEventArgs e) => requaredMethods.AddOperator(" / ");
        private void bmultiply_Click(object sender, RoutedEventArgs e) => requaredMethods.AddOperator(" * ");
        private void bsubtract_Click(object sender, RoutedEventArgs e) => requaredMethods.AddOperator(" - ");
        private void bplus_Click(object sender, RoutedEventArgs e) => requaredMethods.AddOperator(" + ");
        private void bpercentagedivide_Click(object sender, RoutedEventArgs e) => requaredMethods.AddOperator(" % ");
        private void bclear_Click(object sender, RoutedEventArgs e) => requaredMethods.Clear();
        private void bequal_Click(object sender, RoutedEventArgs e) => requaredMethods.Calculate();
    }
}
