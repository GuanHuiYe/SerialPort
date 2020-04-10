using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using SerialPort_DEMO.View;
using SerialPort_DEMO.View.SerialPortSelect;
using SerialPort_DEMO.View.SerialPortChat;
namespace SerialPort_DEMO
{
 
  public enum EnViewModels:int
  {
    SerialPortSelect,
    SerialPortChat
  }


  class MainWindowViewModel : ModelBase
  {
    public override String Name => "MainWindow";

    private ModelBase _CurrentViewModel;

    public List<ModelBase> ViewModels { get; }
    public ModelBase CurrentViewModel
    {
      get => _CurrentViewModel;
      set
      {
        if (_CurrentViewModel?.Name != value.Name)
        {
          _CurrentViewModel = value;
          NotifyPropertyChanged();
        }
      }
    }

    public MainWindowViewModel()
    {
      ViewModels = new List<ModelBase>();


      ViewModels.Add(new SerialPortSelectViewModel());
      ViewModels.Add(new SerialPortChatViewModel());

      CurrentViewModel = ViewModels[(int)EnViewModels.SerialPortSelect];
    }

  }
}
