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

namespace SerialPort_DEMO.View.SerialPortSelect
{
  /// <summary>
  /// SerialPortSelect.xaml 的互動邏輯
  /// </summary>
  public partial class SerialPortSelect : UserControl
  {
    public SerialPortSelectViewModel ViewModel;

    public event EventHandler SelectionChanged;

    public SerialPortSelect()
    {
 
      InitializeComponent();
      if (this.DataContext != null)
      {
        ViewModel = (SerialPortSelectViewModel)this.DataContext; 
      }
    }
    private void UserControl_DataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
    {
      ViewModel = (SerialPortSelectViewModel)this.DataContext;
    }

    private void Button_Click(object sender, RoutedEventArgs e)
    {
      ViewModel.ScanSerialPort();
    }


    private void LV_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
      if (LV.SelectedIndex >= 0)
      {
        ViewModel.SelectSerialPort = ViewModel.SessionList[LV.SelectedIndex];
      }
    }
    private void TextBlock_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
    {
      if (LV.SelectedIndex >= 0)
      {
        SelectionChanged?.Invoke(this, new EventArgs());
      }
    }

    private void Button_Click_1(object sender, RoutedEventArgs e)
    {
      if (LV.SelectedIndex >= 0)
      {
        SelectionChanged?.Invoke(this, new EventArgs());
      }
    }

 
  }
}
