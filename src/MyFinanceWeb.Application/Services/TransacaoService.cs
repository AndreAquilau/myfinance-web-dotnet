using AutoMapper;
using MyFinanceWeb.Application.DTOs.TransacaoDTOs;
using MyFinanceWeb.Application.Interfaces;
using MyFinanceWeb.Domain.Entities;
using MyFinanceWeb.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFinanceWeb.Application.Services;

public class TransacaoService : ITransacaoService
{
    private readonly IMapper _mapper;
    private readonly ITransacaoRepository _transacaoRepository;
    public TransacaoService(ITransacaoRepository transacaoRepository, IMapper mapper)
    {
        _mapper = mapper;
        _transacaoRepository = transacaoRepository ?? throw new ArgumentNullException(nameof(transacaoRepository));
    }
    public async Task<TransacaoDTO> Create(TransacaoDTO transacaoCreateDTO)
    {
        var transacao = _mapper.Map<Transacao>(transacaoCreateDTO);
  
        var transacaoCreated = await _transacaoRepository.Create(transacao);
        var transacaoReadDto = _mapper.Map<TransacaoDTO>(transacaoCreated);

        return transacaoReadDto;
    }

    public async Task<TransacaoDTO> Delete(int id)
    {
        var transacaoDelete = await _transacaoRepository.Delete(id);
        var transacaoReadDto = _mapper.Map<TransacaoDTO>(transacaoDelete);

        return transacaoReadDto;
    }

    public async Task<IEnumerable<TransacaoDTO>> FindAll()
    {
        var transacoes = await _transacaoRepository.FindAll();
        var transacoesReadDto = _mapper.Map<IEnumerable<TransacaoDTO>>(transacoes);

        return transacoesReadDto;
    }

    public async Task<TransacaoDTO> FindById(int id)
    {
        var transacao = await _transacaoRepository.FindById(id);
        var transacaoReadDto = _mapper.Map<TransacaoDTO>(transacao);

        return transacaoReadDto;
    }

    public async Task<TransacaoDTO> Update(TransacaoDTO transacaoUpdateDTO)
    {
        var transacao = _mapper.Map<Transacao>(transacaoUpdateDTO);
        var transacaoUpdated = await _transacaoRepository.Update(transacao);
        var transacaoReadDto = _mapper.Map<TransacaoDTO>(transacaoUpdated);

        return transacaoReadDto;
    }
}

