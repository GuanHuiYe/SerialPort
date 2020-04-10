using System;
using System.ComponentModel;
using System.Threading;

namespace System.SerialPort
{
    public class SerialPort
    {
        private bool _ConnectionStatus;
        private string _SerialLine;
        private int _Speed;
        private IO.Ports.SerialPort COM;

        private BackgroundWorker BackGroundRead;

        public bool ConnectionStatus
        {
            get => _ConnectionStatus;
            private set
            {
                _ConnectionStatus = value;
                ConnectionChange?.Invoke(this, new EventArgs());
            }
        }
        public string SerialLine { get => _SerialLine; private set => _SerialLine = value; }
        public int Speed { get => _Speed; private set => _Speed = value; }

        public delegate void ReadDataHandler(string data);

        public event EventHandler ConnectionChange;
        public event ReadDataHandler ReadData;

        public SerialPort()
        {
            SerialLine = "";
            Speed = 0;
        }

        public SerialPort(String SerialLine, int Speed)
        {
            this.SerialLine = SerialLine;
            this.Speed = Speed;
        }

        public void Open()
        {
            if (ConnectionStatus)
            {
                throw new Exception("SerialPort is Open");
            }

            COM = new IO.Ports.SerialPort();
            if (SerialLine == "" || Speed == 0)
            {
                throw new Exception("No SerialLine or Speed");
            }
            COM.PortName = SerialLine;
            COM.BaudRate = Speed;

            try
            {
                COM.Open();
                ConnectionStatus = true;


                BackGroundRead = new BackgroundWorker();
                BackGroundRead.WorkerSupportsCancellation = true;
                BackGroundRead.DoWork += BackGroundRead_DoWork;
                BackGroundRead.RunWorkerAsync();
            }
            catch
            {
                throw new Exception("SerialPort Error");
            }
        }

        private void BackGroundRead_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                while (true)
                {
                    if (BackGroundRead.CancellationPending == true)
                    {
                        e.Cancel = true;
                        break;
                    }
                    String data = COM.ReadLine();
                    ReadData?.Invoke(data);
                }
            }
            catch
            {
                BackGroundRead.CancelAsync();
            }
        }

        ~SerialPort()
        {
            if ((BackGroundRead??=new BackgroundWorker()).IsBusy)
            {
                BackGroundRead.CancelAsync();
            }

            COM?.Close();
            COM?.Dispose();
            ConnectionStatus = false;
        }

    }
}
