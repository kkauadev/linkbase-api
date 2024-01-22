using LinkBaseApi.Application.DTOs;
using LinkBaseApi.Application.Wrappers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkBaseApi.Application.UseCases.Users.UpdateUser
{
    public record UpdateUserRequest : IRequest<Response<UserResponse>>
	{
		public Guid Id { get; set; }
		public string? Name { get; set; }
		public string? Bio { get; set; }
	}
}
