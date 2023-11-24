using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MyFinanceWeb.Application.DTOs.TransacaoDTOs;
using MyFinanceWeb.Domain.Entities;

namespace MyFinanceWeb.Application.Profiles;
public class TransacaoProfile : Profile
{
    public TransacaoProfile()
    {
        CreateMap<TransacaoDTO, Transacao>();
        CreateMap<TransacaoCreateDTO, Transacao>();
        CreateMap<TransacaoReadDTO, Transacao>();
        CreateMap<TransacaoUpdateDTO, Transacao>();
    }
}
