using LinkBaseApi.Application.UseCases.Links.GetLinks;
using LinkBaseApi.Application.Wrappers;
using MediatR;

namespace LinkBaseApi.Application.UseCases.Links.GetAllLinks
{
    public record GetLinksRequest : IRequest<Response<List<GetLinksResponse>>>;
}
