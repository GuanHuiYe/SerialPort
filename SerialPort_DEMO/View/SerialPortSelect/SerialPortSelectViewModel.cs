using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Management;

namespace SerialPort_DEMO.View.SerialPortSelect
{
  public struct SerialPortSession
  {
    public string SerialName { get; set; }
    public string SerialLine { get; set; }
    public int Speed { get; set; }

    public SerialPortSession(string SerialName, string SerialLine, int Speed)
    {
      this.SerialName = SerialName;
      this.SerialLine = SerialLine;
      this.Speed = Speed;
    }
  }

  public class SerialPortSelectViewModel : ModelBase
  {
    public override string Name => "SerialPortSelect";

    private SerialPortSession _SelectSerialPort = new SerialPortSession();


    public SerialPortSession SelectSerialPort
    {
      get => _SelectSerialPort;
      set
      {
        if (_SelectSerialPort.SerialLine != value.SerialLine)
        {
          _SelectSerialPort = value;
          NotifyPropertyChanged();
        }
      }
    }

    public ObservableCollection<SerialPortSession> SessionList { get; set; }

    public SerialPortSelectViewModel()
    {    
      SessionList = new ObservableCollection<SerialPortSession>();
      ScanSerialPort();
    }

    public void ScanSerialPort()
    {
      SessionList.Clear();
      ManagementObjectSearcher searcher = new ManagementObjectSearcher(@"root\cimv2", "SELECT * FROM Win32_SerialPort");
      foreach (ManagementObject queryObj in searcher.Get())
      {
        var tmp_session = new SerialPortSession(
          queryObj.GetPropertyValue("Name").ToString(), queryObj.GetPropertyValue("DeviceID").ToString(), 115200);

          SessionList.Add(tmp_session);        
      }
    }


  }
}
