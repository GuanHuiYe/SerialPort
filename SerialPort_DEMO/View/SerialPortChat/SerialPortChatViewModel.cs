using System;
using System.Collections.Generic;
using System.Text;
using System.SerialPort;

namespace SerialPort_DEMO.View.SerialPortChat
{
  public class SerialPortChatViewModel : ModelBase
  {
    public override string Name => "SerialPortChatViewModel";

    private String _ConsoleLog;
    private SerialPort serialPort=new SerialPort();

    public String ConsoleLog
    {
      get => _ConsoleLog; 
      set
      {
        if (_ConsoleLog != value)
        {
          _ConsoleLog = value;
          NotifyPropertyChanged();
        }
      }
    }

    public String SerialPortConnectionStatus { get => (bool)serialPort?.ConnectionStatus?"已連線":"未連線"; }

    public SerialPortChatViewModel()
    {
      
    }

    public void ConnectSerialPort(String SerialLine,int SerialSpeed)
    {      
      serialPort = new SerialPort(SerialLine, SerialSpeed);
      serialPort.ConnectionChange += (object sender,EventArgs e) => NotifyPropertyChanged("SerialPortConnectionStatus");
      serialPort.Open();
    }
  }
}
