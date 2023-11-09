using MyFinanceWeb.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFinanceWeb.Domain.Repositories;

public interface ITransacaoRepository
{
    Task<IEnumerable<Transacao>> FindAll();
    Task<Transacao> FindById(int id);
    Task<Transacao> Create(Transacao transacao);
    Task<Transacao> Delete(int id);
    Task<Transacao> Update(Transacao transacao);
}

