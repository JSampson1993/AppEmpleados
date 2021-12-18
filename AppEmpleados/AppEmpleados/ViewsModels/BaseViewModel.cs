
using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.Runtime.CompilerServices;

using Xamarin.Forms;
using System.Windows.Input;
using AppEmpleados.Models;
using AppEmpleados;

namespace Examen_3.ViewModels
{
     public class BaseViewModel : INotifyPropertyChanged
    {
        ArticulosMVVM articulosMVVM = new ArticulosMVVM();
        public event PropertyChangedEventHandler PropertyChanged;

        private int codigo;
        public int Codigo
        {
            get { return codigo; }
            set
            {
                codigo = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Codigo"));
            }
        }

        private int edad;
        public int Edad
        {
            get { return edad; }
            set
            {
                edad = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Edad"));
            }
        }

        private string nombre;
        public string Nombre
        {
            get { return nombre; }
            set
            {
                nombre = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Nombre"));
            }
        }

        private string apellidos;
        public string Apellidos
        {
            get { return apellidos; }
            set
            {
                apellidos = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Apellidos"));
            }
        }

        private string direccion;
        public string Direccion
        {
            get { return direccion; }
            set
            {
                direccion = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Direccion"));
            }
        }
        private string puesto;
        public string Puesto
        {
            get { return puesto; }
            set
            {
                apellidos = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Puesto"));
            }
        }
        private List<Empleado> taskList;
        public List<Empleado> TaskList
        {
            get { return taskList; }
            set
            {

                taskList = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("TaskList"));
            }
        }
        public Command cmdAddTask { get; set; }
        public Command cmdAddTask1 { get; set; }


        protected void OnPropertyChanged([CallerMemberName] string propertyName="")
        {
            var changed = PropertyChanged;
            if (changed == null)
                return;
            changed.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        bool isBussy = false;
        public bool IsBussy
        {
            get { return isBussy; }
            set
            {
                isBussy = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("isBussy"));
            }
        }
        public BaseViewModel()
        {
           cmdAddTask = new Command(AddTask);
            //cmdAddTask1 = new Command(deleteAsync1);
           getTask();
        }

      /* public ICommand EliminarCommand
        {
            get
            {
              //  return new RelayCommand(deleteAsync1);
            }
        }*/

        private async void AddTask(object obj)
        {
            var r = await App.BaseDatos.SaveTaskAsync(new Empleado
            {
                Nombre = nombre,
                Apellidos = apellidos,
                Edad = edad,
                Direccion=direccion,
                Puesto=puesto
                ///Photo_recibo=Photo
            });

            getTask();
        }

        
       public async void getTask()
        {
            TaskList = await App.BaseDatos.GetTaskAsync();
        }

       
    }
}
