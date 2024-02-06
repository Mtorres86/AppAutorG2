using System;
using SQLite;
using AppAutorG2.Models;



namespace AppAutorG2.Controllers
{

	public class AutoresControllers
	{
		//Create Var SQLiteAsync
		SQLiteAsyncConnection _connection;

		public AutoresControllers(){}


        //Create flats a
        public async Task Init()
        {
            if (_connection is not null)
            {
                return;
            }

            SQLite.SQLiteOpenFlags extensiones = SQLite.SQLiteOpenFlags.ReadWrite |
                                                SQLite.SQLiteOpenFlags.Create |
                                                SQLite.SQLiteOpenFlags.SharedCache;
            _connection = new SQLiteAsyncConnection(Path.Combine(FileSystem.AppDataDirectory, "DBAutores.db3"), extensiones);

            var creacion = await _connection.CreateTableAsync<Models.Autores>();


        }

        //Create CRUD

        public async Task<int> StoreAutor(Autores autores)
        {
            Console.WriteLine(autores);

            await Init();

            if (autores.Id == 0)
            {
                return await _connection.InsertAsync(autores);

            }
            else
            {
                await Init();
                return await _connection.UpdateAsync(autores);
            }
        }

        //READ, podemos retornar un solo valor o todos los elementos de manera asincrona.

        public async Task<List<Models.Autores>> GetListAutores()
        {
            await Init();
            return await _connection.Table<Autores>().ToListAsync();
        }

        // Read Element
        public async Task<Models.Autores> GetAutores(int pid)
        {
            await Init();
            return await _connection.Table<Autores>().Where(i => i.Id == pid).FirstOrDefaultAsync();
        }

        //Delete element

        public async Task<int> DeletePerson(Autores autores)
        {
            await Init();
            return await _connection.DeleteAsync(autores);
        }




    }
}

