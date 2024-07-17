using MauiSQLite.MVM.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiSQLite.Services;

public class AgendaService : IAgendaService
{
    private SQLiteAsyncConnection _dbConnection;
    public async Task InitializeAsync()
    {
        await SetupDb();
    }
    public async Task SetupDb()
    {
        if (_dbConnection == null)
        {
            string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Agenda.db3");

            _dbConnection = new SQLiteAsyncConnection(dbPath);
            await _dbConnection.CreateTableAsync<Contato>();
        }
    }

    public async Task<int> AddContato(Contato contato)
    {
        return await _dbConnection.InsertAsync(contato);
    }

    public async Task<int> DeleteContato(Contato contato)
    {
        return await _dbConnection.DeleteAsync(contato);
    }

    public async Task<Contato> GetContato(int contatoId)
    {
        return await _dbConnection.Table<Contato>().FirstOrDefaultAsync(c => c.Id == contatoId);
    }

    public async Task<List<Contato>> GetContatos()
    {
        return await _dbConnection.Table<Contato>().ToListAsync();
    }
    public async Task<int> UpdateContato(Contato contatoId)
    {
        return await _dbConnection.UpdateAsync(contatoId);
    }
}
