using AutoMapper;
using MyFinanceWeb.Application.DTOs.TransacaoDTOs;
using MyFinanceWeb.Application.Interfaces;
using MyFinanceWeb.Domain.Entities;
using MyFinanceWeb.Domain.Repositories;

namespace MyFinanceWeb.Application.Services;

public class TransacaoService : ITransacaoService
{
    private readonly IMapper _mapper;

    private readonly ITransacaoRepository _transacaoRepository;

    private readonly IPlanoContaRepository _planoContaRepository;

    public TransacaoService(IMapper mapper, ITransacaoRepository transacaoRepository, IPlanoContaRepository planoContaRepository)
    {
        _mapper = mapper;
        _transacaoRepository = transacaoRepository ?? throw new ArgumentNullException(nameof(transacaoRepository));
        _planoContaRepository = planoContaRepository ?? throw new ArgumentNullException(nameof(planoContaRepository));
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

        // Buscar plano de conta
        var planoConta = await _planoContaRepository.FindById(transacaoUpdateDTO.PlanoContaId);
        transacao.PlanoConta = _mapper.Map<PlanoConta>(planoConta);

        // Atualizar transação
        var transacaoUpdated = await _transacaoRepository.Update(transacao);
        var transacaoReadDto = _mapper.Map<TransacaoDTO>(transacaoUpdated);

        return transacaoReadDto;
    }
}

