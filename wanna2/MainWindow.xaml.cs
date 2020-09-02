using EasyModbus;
using System.Globalization;
using System.Windows;

namespace wanna2
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string PLC_IP = "192.168.20.167";

        public MainWindow()
        {
            InitializeComponent();
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //var hosts = Pinger.PingAll("192.168.20.254");
            try
            {
                ModbusClient modbusClient = new ModbusClient("192.168.20.167", 502);    //Ip-Address and Port of Modbus-TCP-Server
                modbusClient.Connect();
                //int[] readHoldingRegisters = modbusClient.ReadHoldingRegisters(310, 2);

                float CisnienieZadaneN1 = ModbusClient.ConvertRegistersToFloat(modbusClient.ReadHoldingRegisters(4512, 2));
                float CisnienieZadaneN2 = ModbusClient.ConvertRegistersToFloat(modbusClient.ReadHoldingRegisters(4514, 2));
                float CisnienieZadaneN3 = ModbusClient.ConvertRegistersToFloat(modbusClient.ReadHoldingRegisters(4516, 2));
                float CisnienieZadaneN4 = ModbusClient.ConvertRegistersToFloat(modbusClient.ReadHoldingRegisters(4518, 2));

                txtCisnienieZadane_N1.Text = CisnienieZadaneN1.ToString();
                txtCisnienieZadane_N2.Text = CisnienieZadaneN2.ToString();
                txtCisnienieZadane_N3.Text = CisnienieZadaneN3.ToString();
                txtCisnienieZadane_N4.Text = CisnienieZadaneN4.ToString();

                float TolerancjaCisnienia_N1 = ModbusClient.ConvertRegistersToFloat(modbusClient.ReadHoldingRegisters(4510, 2));
                float TolerancjaCisnienia_N2 = ModbusClient.ConvertRegistersToFloat(modbusClient.ReadHoldingRegisters(4526, 2));
                float TolerancjaCisnienia_N3 = ModbusClient.ConvertRegistersToFloat(modbusClient.ReadHoldingRegisters(4528, 2));
                float TolerancjaCisnienia_N4 = ModbusClient.ConvertRegistersToFloat(modbusClient.ReadHoldingRegisters(4530, 2));

                txtCisnienieTolerancja_N1.Text = TolerancjaCisnienia_N1.ToString();
                txtCisnienieTolerancja_N2.Text = TolerancjaCisnienia_N2.ToString();
                txtCisnienieTolerancja_N3.Text = TolerancjaCisnienia_N3.ToString();
                txtCisnienieTolerancja_N4.Text = TolerancjaCisnienia_N4.ToString();

                float CisnienieN1 = ModbusClient.ConvertRegistersToFloat(modbusClient.ReadHoldingRegisters(2000, 2));
                float CisnienieN2 = ModbusClient.ConvertRegistersToFloat(modbusClient.ReadHoldingRegisters(2002, 2));
                float CisnienieN3 = ModbusClient.ConvertRegistersToFloat(modbusClient.ReadHoldingRegisters(2004, 2));
                float CisnienieN4 = ModbusClient.ConvertRegistersToFloat(modbusClient.ReadHoldingRegisters(2006, 2));

                lblCisnienie_N1.Content = CisnienieN1.ToString();
                lblCisnienie_N2.Content = CisnienieN2.ToString();
                lblCisnienie_N3.Content = CisnienieN3.ToString();
                lblCisnienie_N4.Content = CisnienieN4.ToString();

                int CzasPomiaru_N1 = ModbusClient.ConvertRegistersToInt(modbusClient.ReadHoldingRegisters(4532, 2));

                txtCzasPomiaru_N1.Text = CzasPomiaru_N1.ToString();

                bool[] PracaGrzalek = modbusClient.ReadCoils(1296, 1);
                lblPracaGrzalek.Content = PracaGrzalek[0].ToString();

                bool[] PracaMieszadla = modbusClient.ReadCoils(1298, 1);
                lblPracaMieszadla.Content = PracaMieszadla[0].ToString();

                bool[] Elektrozawor_N1 = modbusClient.ReadCoils(1298, 1);
                bool[] Elektrozawor_N2 = modbusClient.ReadCoils(1299, 1);
                bool[] Elektrozawor_N3 = modbusClient.ReadCoils(1300, 1);
                bool[] Elektrozawor_N4 = modbusClient.ReadCoils(1301, 1);
                lblElektrozawor_N1.Content = Elektrozawor_N1[0].ToString();
                lblElektrozawor_N2.Content = Elektrozawor_N2[0].ToString();
                lblElektrozawor_N3.Content = Elektrozawor_N3[0].ToString();
                lblElektrozawor_N4.Content = Elektrozawor_N4[0].ToString();

                float TemperaturaZadana = ModbusClient.ConvertRegistersToFloat(modbusClient.ReadHoldingRegisters(4506, 2));
                txtTemperaturaZadana.Text = TemperaturaZadana.ToString();

                float TolerancjaTemperatury = ModbusClient.ConvertRegistersToFloat(modbusClient.ReadHoldingRegisters(4508, 2));
                txtTolerancjaTemperatury.Text = TolerancjaTemperatury.ToString();

                float Temperatura_T1 = ModbusClient.ConvertRegistersToFloat(modbusClient.ReadHoldingRegisters(2008, 2));
                float Temperatura_T2 = ModbusClient.ConvertRegistersToFloat(modbusClient.ReadHoldingRegisters(2010, 2));
                float TemperaturaSrednia = ModbusClient.ConvertRegistersToFloat(modbusClient.ReadHoldingRegisters(2012, 2));
                lblTemperaturaWody1.Content = Temperatura_T1.ToString();
                lblTemperaturaWody2.Content = Temperatura_T2.ToString();
                lblTemperaturaSrednia.Content = TemperaturaSrednia.ToString();

                bool[] GrzanieWody = modbusClient.ReadCoils(2248, 1);
                lblGrzanieWody.Content = GrzanieWody[0].ToString();

                bool[] WodaNagrzana = modbusClient.ReadCoils(2251, 1);
                lblWodaNagrzana.Content = WodaNagrzana[0].ToString();

                bool[] BadanieZasadnicza = modbusClient.ReadCoils(2249, 1);
                lblBadanieZasadnicze.Content = BadanieZasadnicza[0].ToString();

                int[] ProbkowanieCisnienia = modbusClient.ReadHoldingRegisters(4504, 1);
                txtProbkowanieCisnienia.Text = ProbkowanieCisnienia[0].ToString();

                int[] ProbkowanieTemperatury = modbusClient.ReadHoldingRegisters(4505, 1);
                txtProbkowanieTemperatury.Text = ProbkowanieTemperatury[0].ToString();

                modbusClient.Disconnect();
            }
            catch
            {
                MessageBox.Show("nie można podłączyć PLC");
            }

           
            
        }

        private void TnUstawCisnienie_N1_Click(object sender, RoutedEventArgs e)
        {
            ModbusClient modbusClient = new ModbusClient("192.168.1.101", 502);    //Ip-Address and Port of Modbus-TCP-Server
            modbusClient.Connect();
            float CisnienieZadane_N1 = float.Parse(txtCisnienieZadane_N1.Text);
            int[] aaa = ModbusClient.ConvertFloatToRegisters(CisnienieZadane_N1);
            modbusClient.WriteMultipleRegisters(4512, aaa);
            modbusClient.Disconnect();
        }

        private void TnUstawCisnienie_N2_Click(object sender, RoutedEventArgs e)
        {
            ModbusClient modbusClient = new ModbusClient("192.168.1.101", 502);    //Ip-Address and Port of Modbus-TCP-Server
            modbusClient.Connect();
            float CisnienieZadane_N2 = float.Parse(txtCisnienieZadane_N2.Text);
            int[] aaa = ModbusClient.ConvertFloatToRegisters(CisnienieZadane_N2);
            modbusClient.WriteMultipleRegisters(4514, aaa);
            modbusClient.Disconnect();
        }

        private void TnUstawCisnienie_N3_Click(object sender, RoutedEventArgs e)
        {
            ModbusClient modbusClient = new ModbusClient("192.168.1.101", 502);    //Ip-Address and Port of Modbus-TCP-Server
            modbusClient.Connect();
            float CisnienieZadane_N3 = float.Parse(txtCisnienieZadane_N3.Text);
            int[] aaa = ModbusClient.ConvertFloatToRegisters(CisnienieZadane_N3);
            modbusClient.WriteMultipleRegisters(4516, aaa);
            modbusClient.Disconnect();
        }

        private void TnUstawCisnienie_N4_Click(object sender, RoutedEventArgs e)
        {
            ModbusClient modbusClient = new ModbusClient("192.168.1.101", 502);    //Ip-Address and Port of Modbus-TCP-Server
            modbusClient.Connect();
            float CisnienieZadane_N4 = float.Parse(txtCisnienieZadane_N4.Text);
            int[] aaa = ModbusClient.ConvertFloatToRegisters(CisnienieZadane_N4);
            modbusClient.WriteMultipleRegisters(4518, aaa);
            modbusClient.Disconnect();
        }

        private void btnTemperatuaZadana(object sender, RoutedEventArgs e)
        {
            ModbusClient modbusClient = new ModbusClient("192.168.1.101", 502);    //Ip-Address and Port of Modbus-TCP-Server
            modbusClient.Connect();
            float TemperaturaZadana = float.Parse(txtTemperaturaZadana.Text);
            int[] aaa = ModbusClient.ConvertFloatToRegisters(TemperaturaZadana);
            modbusClient.WriteMultipleRegisters(4506, aaa);
            modbusClient.Disconnect();
        }

        private void BtnStartGrzania_Click(object sender, RoutedEventArgs e)
        {
            ModbusClient modbusClient = new ModbusClient("192.168.1.101", 502);    //Ip-Address and Port of Modbus-TCP-Server
            modbusClient.Connect();
            modbusClient.WriteSingleCoil(2266, true);
            modbusClient.Disconnect();
        }

        private void btnStartPomiaru(object sender, RoutedEventArgs e)
        {
            ModbusClient modbusClient = new ModbusClient("192.168.1.101", 502);    //Ip-Address and Port of Modbus-TCP-Server
            modbusClient.Connect();
            modbusClient.WriteSingleCoil(2267, true);
            modbusClient.Disconnect();
        }

        private void BtnCzasPomiaru_N1_Click(object sender, RoutedEventArgs e)
        {
            ModbusClient modbusClient = new ModbusClient("192.168.1.101", 502);    //Ip-Address and Port of Modbus-TCP-Server
            modbusClient.Connect();
            int CzasPomiaru_N1 = int.Parse(txtCzasPomiaru_N1.Text);
            int[] aaa = ModbusClient.ConvertIntToRegisters(CzasPomiaru_N1);
            modbusClient.WriteMultipleRegisters(4532, aaa);
            modbusClient.Disconnect();
        }

        private void BtnCzasPomiaru_N2_Click(object sender, RoutedEventArgs e)
        {
            ModbusClient modbusClient = new ModbusClient("192.168.1.101", 502);    //Ip-Address and Port of Modbus-TCP-Server
            modbusClient.Connect();
            int CzasPomiaru_N2 = int.Parse(txtCzasPomiaru_N2.Text);
            int[] aaa = ModbusClient.ConvertIntToRegisters(CzasPomiaru_N2);
            modbusClient.WriteMultipleRegisters(4532, aaa);
            modbusClient.Disconnect();
        }

        private void BtnCzasPomiaru_N3_Click(object sender, RoutedEventArgs e)
        {
            ModbusClient modbusClient = new ModbusClient("192.168.1.101", 502);    //Ip-Address and Port of Modbus-TCP-Server
            modbusClient.Connect();
            int CzasPomiaru_N3 = int.Parse(txtCzasPomiaru_N3.Text);
            int[] aaa = ModbusClient.ConvertIntToRegisters(CzasPomiaru_N3);
            modbusClient.WriteMultipleRegisters(4532, aaa);
            modbusClient.Disconnect();
        }

        private void BtnCzasPomiaru_N4_Click(object sender, RoutedEventArgs e)
        {
            ModbusClient modbusClient = new ModbusClient("192.168.1.101", 502);    //Ip-Address and Port of Modbus-TCP-Server
            modbusClient.Connect();
            int CzasPomiaru_N4 = int.Parse(txtCzasPomiaru_N4.Text);
            int[] aaa = ModbusClient.ConvertIntToRegisters(CzasPomiaru_N4);
            modbusClient.WriteMultipleRegisters(4532, aaa);
            modbusClient.Disconnect();
        }

        private void BtnUstawTolerancjeCisnienia_N1_Click(object sender, RoutedEventArgs e)
        {
            ModbusClient modbusClient = new ModbusClient("192.168.1.101", 502);    //Ip-Address and Port of Modbus-TCP-Server
            modbusClient.Connect();
            float TolerancjaCisnienia_N1 = float.Parse(txtCisnienieTolerancja_N1.Text);
            int[] aaa = ModbusClient.ConvertFloatToRegisters(TolerancjaCisnienia_N1);
            modbusClient.WriteMultipleRegisters(4510, aaa);
            modbusClient.Disconnect();
        }

        private void BtnUstawTolerancjeCisnienia_N2_Click(object sender, RoutedEventArgs e)
        {
            ModbusClient modbusClient = new ModbusClient("192.168.1.101", 502);    //Ip-Address and Port of Modbus-TCP-Server
            modbusClient.Connect();
            float TolerancjaCisnienia_N2 = float.Parse(txtCisnienieTolerancja_N2.Text);
            int[] aaa = ModbusClient.ConvertFloatToRegisters(TolerancjaCisnienia_N2);
            modbusClient.WriteMultipleRegisters(4526, aaa);
            modbusClient.Disconnect();
        }

        private void BtnUstawTolerancjeCisnienia_N3_Click(object sender, RoutedEventArgs e)
        {
            ModbusClient modbusClient = new ModbusClient("192.168.1.101", 502);    //Ip-Address and Port of Modbus-TCP-Server
            modbusClient.Connect();
            float TolerancjaCisnienia_N3 = float.Parse(txtCisnienieTolerancja_N3.Text);
            int[] aaa = ModbusClient.ConvertFloatToRegisters(TolerancjaCisnienia_N3);
            modbusClient.WriteMultipleRegisters(4528, aaa);
            modbusClient.Disconnect();
        }

        private void BtnUstawTolerancjeCisnienia_N4_Click(object sender, RoutedEventArgs e)
        {
            ModbusClient modbusClient = new ModbusClient("192.168.1.101", 502);    //Ip-Address and Port of Modbus-TCP-Server
            modbusClient.Connect();
            float TolerancjaCisnienia_N4 = float.Parse(txtCisnienieTolerancja_N4.Text);
            int[] aaa = ModbusClient.ConvertFloatToRegisters(TolerancjaCisnienia_N4);
            modbusClient.WriteMultipleRegisters(4530, aaa);
            modbusClient.Disconnect();
        }

        private void BtnUstawProbkowanieCisnienia_Click(object sender, RoutedEventArgs e)
        {
            ModbusClient modbusClient = new ModbusClient("192.168.1.101", 502);    //Ip-Address and Port of Modbus-TCP-Server
            modbusClient.Connect();
            int ProbkowanieCisnienia = int.Parse(txtProbkowanieCisnienia.Text);
            //int[] aaa = ModbusClient.ConvertIntToRegisters(CzasPomiaru_N1);
            modbusClient.WriteSingleRegister(4504, ProbkowanieCisnienia);
            modbusClient.Disconnect();
        }

        private void BtnUstawProbkowanieTemperatury_Click(object sender, RoutedEventArgs e)
        {
            ModbusClient modbusClient = new ModbusClient("192.168.1.101", 502);    //Ip-Address and Port of Modbus-TCP-Server
            modbusClient.Connect();
            int ProbkowanieTemperatury = int.Parse(txtProbkowanieTemperatury.Text);
            //int[] aaa = ModbusClient.ConvertIntToRegisters(CzasPomiaru_N1);
            modbusClient.WriteSingleRegister(4505, ProbkowanieTemperatury);
            modbusClient.Disconnect();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            ModbusClient modbusClient = new ModbusClient("192.168.1.101", 502);    //Ip-Address and Port of Modbus-TCP-Server
            modbusClient.Connect();
            float TolerancjaTemperatury = float.Parse(txtTolerancjaTemperatury.Text);
            int[] aaa = ModbusClient.ConvertFloatToRegisters(TolerancjaTemperatury);
            modbusClient.WriteMultipleRegisters(4508, aaa);
            modbusClient.Disconnect();
        }

        private void btnBadanie_Click(object sender, RoutedEventArgs e)
        {
            WindowPomiar wp = new WindowPomiar();
            wp.ShowDialog();
        }
    }
}
