
using AppEmpleados.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
namespace Examen_3.ViewModels
{
    public class ArticulosMVVM
    {
        public SQLiteAsyncConnection _database;

        public ArticulosMVVM(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<Empleado>().Wait();
        }

        public ArticulosMVVM()
        {
        }

        public Task<List<Empleado>> GetTaskAsync()
        {
            return _database.Table<Empleado>().OrderByDescending(x => x.codigo).ToListAsync();
        }


        public Task<int> SaveTaskAsync(Empleado taskModel)
        {

            if (taskModel.codigo != 0)
            {
                return _database.UpdateAsync(taskModel);
            }
            else
            {
                return _database.InsertAsync(taskModel);
            }

        }



        public Task<int>UpdateTaskAsync(Empleado pagos)
        {
            return _database.UpdateAsync(pagos);
        }

        public Task<int> deleteAsync(Empleado pagos)
        {
            return _database.DeleteAsync(pagos);
        }

        public Task<Empleado> GetItemAsync(int personId)
        {
            return _database.Table<Empleado>().Where(i => i.codigo == personId).FirstOrDefaultAsync();
        }
    }
}