using DemoIMC.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace DemoIMC.Services
{
    public class Services<T> : IServices<T> where T : class, new()
    {
        #region Attributes
        SQLiteAsyncConnection _conecction;
        #endregion
        
        #region Constructors
        public Services()
        {
            string FilePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
                "db_imc.db3");

            _conecction = new SQLiteAsyncConnection(FilePath);
            _conecction.CreateTableAsync<Usuarios>().Wait();
            _conecction.CreateTableAsync<Imcs>().Wait();
        }
        #endregion

        #region CRUD
        public Task<int> Delete(T obj)
        {
            return _conecction.DeleteAsync(obj);
        }

       

        public Task<List<T>> GetAll()
        {
            return _conecction.Table<T>().ToListAsync();
        }

        public Task<List<T>> GetUserAndImc()
        {
            return _conecction.Table<T>().ToListAsync();

            //  var DatosImc =  _conecction.Table<Imcs>().ToListAsync();

            //  //Imcs.ToList().Join(Usuarios, i => i.UsuarioID, u => u.UsuarioID, (u, i) =>
            //  //new { i.UsuarioID, u.Nombre, u.Apellido, u.Peso, u.Estatura, i.Imc }).Select(i => i).ToList();
            //var Result =  Imcs.ToList().Join
            //      (Usuarios, imc => imc.UsuarioID, u =>
            //       u.ID, (imc, u) => u).ToList();
            //  //return _conecction.QueryAsync<T>("select u.Nombre, u.Apellido, u.Peso, u.Estatura, i.Imc from Imcs  i" +
            //  //    "inner join Usuarios u" + "on i.UsuarioID = i.UsuarioID").ToList();

        }

        public Task<int> Insert(T obj)
        {
            return _conecction.InsertAsync(obj);
        }

        public Task<int> Update(T obj)
        {
            return _conecction.UpdateAsync(obj);
        } 
        #endregion
    }
}
