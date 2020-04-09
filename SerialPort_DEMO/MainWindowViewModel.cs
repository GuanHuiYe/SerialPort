using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using SerialPort_DEMO.View;
using SerialPort_DEMO.View.SerialPortSelect;
namespace SerialPort_DEMO
{
  class MainWindowViewModel : ModelBase
  {
   private ModelBase _CurrentViewModel = new ModelBase();

    public List<ModelBase> ViewModels { get; }
    public ModelBase CurrentViewModel
    {
      get => _CurrentViewModel; 
      set
      {        
        if (_CurrentViewModel.Name != value.Name)
        {
          _CurrentViewModel = value;
          NotifyPropertyChanged();
        }
      }
    }

    public MainWindowViewModel()
    {
      Name = "MainWindow";
      ViewModels = new List<ModelBase>();
      ViewModels.Add(new SerialPortSelectViewModel());
      CurrentViewModel = ViewModels[0];
    }

  }
}
