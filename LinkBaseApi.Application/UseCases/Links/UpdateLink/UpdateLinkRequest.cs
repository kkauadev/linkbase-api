using LinkBaseApi.Application.Wrappers;
using MediatR;

namespace LinkBaseApi.Application.UseCases.Links.UpdateLink
{
    public record UpdateLinkRequest : IRequest<Response<UpdateLinkResponse>>
    {
        public Guid Id { get; set; }
        public string? Title { get; set; }
        public string? Url { get; set; }
        public string? Description { get; set; }
    }
}
