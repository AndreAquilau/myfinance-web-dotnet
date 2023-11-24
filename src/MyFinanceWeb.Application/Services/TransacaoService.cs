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
        _transacaoRepository = transacaoRepository;
    }
    public async Task<TransacaoReadDTO> Create(TransacaoCreateDTO transacaoCreateDTO)
    {
        var transacao = _mapper.Map<Transacao>(transacaoCreateDTO);
        var transacaoCreated = await _transacaoRepository.Create(transacao);
        var transacaoReadDto = _mapper.Map<TransacaoReadDTO>(transacaoCreated);

        return transacaoReadDto;
    }

    public async Task<TransacaoReadDTO> Delete(int id)
    {
        var transacaoDelete = await _transacaoRepository.Delete(id);
        var transacaoReadDto = _mapper.Map<TransacaoReadDTO>(transacaoDelete);

        return transacaoReadDto;
    }

    public async Task<IEnumerable<TransacaoReadDTO>> FindAll()
    {
        var transacoes = await _transacaoRepository.FindAll();
        var transacoesReadDto = _mapper.Map<IEnumerable<TransacaoReadDTO>>(transacoes);

        return transacoesReadDto;
    }

    public async Task<TransacaoReadDTO> FindById(int id)
    {
        var transacao = await _transacaoRepository.FindById(id);
        var transacaoReadDto = _mapper.Map<TransacaoReadDTO>(transacao);

        return transacaoReadDto;
    }

    public async Task<TransacaoReadDTO> Update(TransacaoUpdateDTO transacaoUpdateDTO)
    {
        var transacao = _mapper.Map<Transacao>(transacaoUpdateDTO);
        var transacaoUpdated = await _transacaoRepository.Update(transacao);
        var transacaoReadDto = _mapper.Map<TransacaoReadDTO>(transacaoUpdated);

        return transacaoReadDto;
    }
}

