using MauiSQLite.MVM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiSQLite.Services;

public interface IAgendaService
{
    public Task InitializeAsync();
    public Task<List<Contato>> GetContatos();
    Task<Contato> GetContato(int contatoId);
    public Task<int> AddContato(Contato contato);
    Task<int> UpdateContato(Contato contatoId);
    Task<int> DeleteContato(Contato contato);
}
