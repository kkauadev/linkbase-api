using LinkBaseApi.Application.DTOs;
using LinkBaseApi.Application.Wrappers;
using MediatR;

namespace LinkBaseApi.Application.UseCases.Links.GetAllLinks
{
    public record GetLinksRequest : IRequest<Response<List<LinkResponse>>>;
}
