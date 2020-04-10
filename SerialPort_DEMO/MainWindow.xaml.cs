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
using System.SerialPort;
using MahApps.Metro.Controls;
using SerialPort_DEMO.View.SerialPortChat;
using SerialPort_DEMO.View.SerialPortSelect;

namespace SerialPort_DEMO
{
  /// <summary>
  /// Interaction logic for MainWindow.xaml
  /// </summary>
  public partial class MainWindow : MetroWindow
  {
    private MainWindowViewModel ViewModel;
    public MainWindow()
    {
      InitializeComponent();
      ViewModel = (MainWindowViewModel)this.DataContext;
    }

    private void SerialPortSelect_SelectionChanged(object sender, EventArgs e)
    {
      SerialPortSelectViewModel serialPortSelect =
        (SerialPortSelectViewModel)ViewModel.ViewModels[(int)EnViewModels.SerialPortSelect];
      ((SerialPortChatViewModel)ViewModel.ViewModels[(int)EnViewModels.SerialPortChat])
        .ConnectSerialPort(serialPortSelect.SelectSerialPort.SerialLine, serialPortSelect.SelectSerialPort.Speed);


      ViewModel.CurrentViewModel = ViewModel.ViewModels[(int)EnViewModels.SerialPortChat];      
    }

    private void SerialPortChat_BackRequest(object sender, EventArgs e)
    {
      ViewModel.CurrentViewModel = ViewModel.ViewModels[(int)EnViewModels.SerialPortSelect];
    }
  }
}
