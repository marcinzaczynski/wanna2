using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wanna2.Helpers;
using EasyModbus;
using System.ComponentModel;

namespace wanna2.ViewModel
{
    class WannaViewModel : INotifyPropertyChanged
    {
        #region region PropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
        #endregion

        #region region private
        private List<wanna_status> listaStatus;
        private wanna_status status;
        private string PLC_IP = "192.168.20.167";
        private int PLC_PORT = 502;

        private float cisnienieZadaneN1;
        private float cisnienieZadaneN2;
        private float cisnienieZadaneN3;
        private float cisnienieZadaneN4;

        private float tolerancjaCisnieniaN1;
        private float tolerancjaCisnieniaN2;
        private float tolerancjaCisnieniaN3;
        private float tolerancjaCisnieniaN4;

        private float cisnienieN1;
        private float cisnienieN2;
        private float cisnienieN3;
        private float cisnienieN4;

        private int[] probkowanieCisnienia;
        private int[] probkowanieTemperatury;

        private int czasPomiaru_N1;
        private bool[] pracaGrzalek;
        private bool[] pracaMieszadla;

        private bool[] elektrozawor_N1;
        private bool[] elektrozawor_N2;
        private bool[] elektrozawor_N3;
        private bool[] elektrozawor_N4;

        private float temperaturaZadana;
        private float tolerancjaTemperatury;
        private float temperatura_T1;
        private float temperatura_T2;
        private float temperaturaSrednia;

        private bool[] grzanieWody;
        private bool[] wodaNagrzana;

        private bool[] badanieZasadnicze;

        private System.Windows.Media.Brush kolor;

        #endregion

        #region region public PropertyChanged
        public wanna_status Status
        {
            get { return status; }
            set { status = value; OnPropertyChanged("Status"); }
        }

        public float CisnienieZadaneN1
        {
            get { return cisnienieZadaneN1; }
            set { cisnienieZadaneN1 = value; OnPropertyChanged("CisnienieZadaneN1"); }
        }

        public float CisnienieZadaneN2
        {
            get { return cisnienieZadaneN2; }
            set { cisnienieZadaneN2 = value; OnPropertyChanged("CisnienieZadaneN2"); }
        }

        public float CisnienieZadaneN3
        {
            get { return cisnienieZadaneN3; }
            set { cisnienieZadaneN3 = value; OnPropertyChanged("CisnienieZadaneN3"); }
        }

        public float CisnienieZadaneN4
        {
            get { return cisnienieZadaneN4; }
            set { cisnienieZadaneN4 = value; OnPropertyChanged("CisnienieZadaneN4"); }
        }

        public float TolerancjaCisnieniaN1
        {
            get { return tolerancjaCisnieniaN1; }
            set { tolerancjaCisnieniaN1 = value; OnPropertyChanged("TolerancjaCisnieniaN1"); }
        }

        public float TolerancjaCisnieniaN2
        {
            get { return tolerancjaCisnieniaN2; }
            set { tolerancjaCisnieniaN2 = value; OnPropertyChanged("TolerancjaCisnieniaN2"); }
        }

        public float TolerancjaCisnieniaN3
        {
            get { return tolerancjaCisnieniaN3; }
            set { tolerancjaCisnieniaN3 = value; OnPropertyChanged("TolerancjaCisnieniaN3"); }
        }

        public float TolerancjaCisnieniaN4
        {
            get { return tolerancjaCisnieniaN4; }
            set { tolerancjaCisnieniaN4 = value; OnPropertyChanged("TolerancjaCisnieniaN4"); }
        }

        public float CisnienieN1
        {
            get { return cisnienieN1; }
            set { cisnienieN1 = value; OnPropertyChanged("CisnienieN1"); }
        }

        public float CisnienieN2
        {
            get { return cisnienieN2; }
            set { cisnienieN2 = value; OnPropertyChanged("CisnienieN2"); }
        }

        public float CisnienieN3
        {
            get { return cisnienieN3; }
            set { cisnienieN3 = value; OnPropertyChanged("CisnienieN3"); }
        }

        public float CisnienieN4
        {
            get { return cisnienieN4; }
            set { cisnienieN4 = value; OnPropertyChanged("CisnienieN4"); }
        }

        public int[] ProbkowanieCisnienia
        {
            get { return probkowanieCisnienia; }
            set { probkowanieCisnienia = value; OnPropertyChanged("ProbkowanieCisnienia"); }
        }

        public int[] ProbkowanieTemperatury
        {
            get { return probkowanieTemperatury; }
            set { probkowanieTemperatury = value; OnPropertyChanged("ProbkowanieTemperatury"); }
        }

        public int CzasPomiaru_N1
        {
            get { return czasPomiaru_N1; }
            set { czasPomiaru_N1 = value; OnPropertyChanged("CzasPomiaru_N1"); }
        }

        public bool[] PracaGrzalek
        {
            get { return pracaGrzalek; }
            set { pracaGrzalek = value; OnPropertyChanged("PracaGrzalek"); }
        }

        public bool[] PracaMieszadla
        {
            get { return pracaMieszadla; }
            set { pracaMieszadla = value; OnPropertyChanged("PracaMieszadla"); }
        }

        public bool[] Elektrozawor_N1
        {
            get { return elektrozawor_N1; }
            set { elektrozawor_N1 = value; OnPropertyChanged("Elektrozawor_N1"); }
        }

        public bool[] Elektrozawor_N2
        {
            get { return elektrozawor_N2; }
            set { elektrozawor_N2 = value; OnPropertyChanged("Elektrozawor_N2"); }
        }

        public bool[] Elektrozawor_N3
        {
            get { return elektrozawor_N3; }
            set { elektrozawor_N3 = value; OnPropertyChanged("Elektrozawor_N3"); }
        }

        public bool[] Elektrozawor_N4
        {
            get { return elektrozawor_N4; }
            set { elektrozawor_N4 = value; OnPropertyChanged("Elektrozawor_N4"); }
        }

        public float TemperaturaZadana
        {
            get { return temperaturaZadana; }
            set { temperaturaZadana = value; OnPropertyChanged("TemperaturaZadana"); }
        }

        public float TolerancjaTemperatury
        {
            get { return tolerancjaTemperatury; }
            set { tolerancjaTemperatury = value; OnPropertyChanged("TolerancjaTemperatury"); }
        }

        public float Temperatura_T1
        {
            get { return temperatura_T1; }
            set { temperatura_T1 = value; OnPropertyChanged("Temperatura_T1"); }
        }

        public float Temperatura_T2
        {
            get { return temperatura_T2; }
            set { temperatura_T2 = value; OnPropertyChanged("Temperatura_T2"); }
        }

        public float TemperaturaSrednia
        {
            get { return temperaturaSrednia; }
            set { temperaturaSrednia = value; OnPropertyChanged("TemperaturaSrednia"); }
        }

        public bool[] GrzanieWody
        {
            get { return grzanieWody; }
            set { grzanieWody = value; OnPropertyChanged("GrzanieWody"); }
        }

        public bool[] WodaNagrzana
        {
            get { return wodaNagrzana; }
            set { wodaNagrzana = value; OnPropertyChanged("WodaNagrzana"); }
        }

        public bool[] BadanieZasadnicze
        {
            get { return badanieZasadnicze; }
            set { badanieZasadnicze = value; OnPropertyChanged("BadanieZasadnicze"); }
        }

        public System.Windows.Media.Brush Kolor
        {
            get { return kolor; }
            set { kolor = value; OnPropertyChanged("Kolor"); }
        }
        #endregion

        public WannaViewModel()
        {
            // zanim się podączę do PLC potrzebuję mieć dostęp do statusu, żeby wyświetlić np. brak komunikacji
            List<wanna_status> listaStatus = new List<wanna_status>();
            WypelnijListeStatusow(listaStatus);
            // próba skomunikowania się z PLC
            try
            {
                
                OdczytajRejestry();
                
            }
            catch (Exception)
            {
                Status = listaStatus.SingleOrDefault(s => s.Id == 0);
                //throw;
            }
        }
        public void OdczytajRejestry()
        {
            ModbusClient modbusClient = new ModbusClient(PLC_IP, PLC_PORT);    //Ip-Address and Port of Modbus-TCP-Server
            modbusClient.Connect();

            CisnienieZadaneN1 = ModbusClient.ConvertRegistersToFloat(modbusClient.ReadHoldingRegisters(4512, 2));
            CisnienieZadaneN2 = ModbusClient.ConvertRegistersToFloat(modbusClient.ReadHoldingRegisters(4514, 2));
            CisnienieZadaneN3 = ModbusClient.ConvertRegistersToFloat(modbusClient.ReadHoldingRegisters(4516, 2));
            CisnienieZadaneN4 = ModbusClient.ConvertRegistersToFloat(modbusClient.ReadHoldingRegisters(4518, 2));

            TolerancjaCisnieniaN1 = ModbusClient.ConvertRegistersToFloat(modbusClient.ReadHoldingRegisters(4510, 2));
            TolerancjaCisnieniaN2 = ModbusClient.ConvertRegistersToFloat(modbusClient.ReadHoldingRegisters(4526, 2));
            TolerancjaCisnieniaN3 = ModbusClient.ConvertRegistersToFloat(modbusClient.ReadHoldingRegisters(4528, 2));
            TolerancjaCisnieniaN4 = ModbusClient.ConvertRegistersToFloat(modbusClient.ReadHoldingRegisters(4530, 2));

            CisnienieN1 = ModbusClient.ConvertRegistersToFloat(modbusClient.ReadHoldingRegisters(2000, 2));
            CisnienieN2 = ModbusClient.ConvertRegistersToFloat(modbusClient.ReadHoldingRegisters(2002, 2));
            CisnienieN3 = ModbusClient.ConvertRegistersToFloat(modbusClient.ReadHoldingRegisters(2004, 2));
            CisnienieN4 = ModbusClient.ConvertRegistersToFloat(modbusClient.ReadHoldingRegisters(2006, 2));

            CzasPomiaru_N1 = ModbusClient.ConvertRegistersToInt(modbusClient.ReadHoldingRegisters(4532, 2));

            PracaGrzalek = modbusClient.ReadCoils(1296, 1);

            PracaMieszadla = modbusClient.ReadCoils(1298, 1);

            Elektrozawor_N1 = modbusClient.ReadCoils(1298, 1);
            Elektrozawor_N2 = modbusClient.ReadCoils(1299, 1);
            Elektrozawor_N3 = modbusClient.ReadCoils(1300, 1);
            Elektrozawor_N4 = modbusClient.ReadCoils(1301, 1);

            TemperaturaZadana = ModbusClient.ConvertRegistersToFloat(modbusClient.ReadHoldingRegisters(4506, 2));

            TolerancjaTemperatury = ModbusClient.ConvertRegistersToFloat(modbusClient.ReadHoldingRegisters(4508, 2));

            Temperatura_T1 = ModbusClient.ConvertRegistersToFloat(modbusClient.ReadHoldingRegisters(2008, 2));
            Temperatura_T2 = ModbusClient.ConvertRegistersToFloat(modbusClient.ReadHoldingRegisters(2010, 2));
            TemperaturaSrednia = ModbusClient.ConvertRegistersToFloat(modbusClient.ReadHoldingRegisters(2012, 2));

            GrzanieWody = modbusClient.ReadCoils(2248, 1);

            WodaNagrzana = modbusClient.ReadCoils(2251, 1);

            BadanieZasadnicze = modbusClient.ReadCoils(2249, 1);

            ProbkowanieCisnienia = modbusClient.ReadHoldingRegisters(4504, 1);

            ProbkowanieTemperatury = modbusClient.ReadHoldingRegisters(4505, 1);

            modbusClient.Disconnect();
        }

        private void WypelnijListeStatusow(List<wanna_status> listaStatus)
        {

            wanna_status stat0 = new wanna_status(0, "Brak komunikacji");
            listaStatus.Add(stat0);
            wanna_status stat1 = new wanna_status(1, "Trwa badanie");
            listaStatus.Add(stat1);
            wanna_status stat2 = new wanna_status(2, "Gotowa do badania");
            listaStatus.Add(stat2);
        }
    }
}

