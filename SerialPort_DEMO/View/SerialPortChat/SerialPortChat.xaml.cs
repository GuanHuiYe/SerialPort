using System;
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

namespace SerialPort_DEMO.View.SerialPortChat
{
  /// <summary>
  /// SerialPortChat.xaml 的互動邏輯
  /// </summary>
  public partial class SerialPortChat : UserControl
  {
    public event EventHandler BackRequest;

    public SerialPortChatViewModel ViewModel;

    public SerialPortChat()
    {
      InitializeComponent();
      if (this.DataContext != null)
      {
        ViewModel = (SerialPortChatViewModel)this.DataContext;
      }
     
    }
    private void UserControl_DataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
    {
      ViewModel = (SerialPortChatViewModel)this.DataContext;
    }

    private void Button_Click(object sender, RoutedEventArgs e)
    {
      BackRequest?.Invoke(this, new EventArgs());
    }

    
  }
}
