using AutoMapper;
using Hiwapardaz.SepehrBarin.Domain.Features.Workflow.Dto;
using Hiwapardaz.SepehrBarin.Domain.Features.Workflow.Entities;

namespace Hiwapardaz.SepehrBarin.Application.Features.Workflow.Mapper
{
    public class RequestMapper:Profile
    {
        public RequestMapper()
        {
            CreateMap<RequestAddDto, Request>();
            CreateMap<Request, RequestQueryDto>();
        }
    }
}
