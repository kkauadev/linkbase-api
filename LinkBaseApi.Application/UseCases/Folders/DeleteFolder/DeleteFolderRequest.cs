using LinkBaseApi.Application.Wrappers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkBaseApi.Application.UseCases.Folders.DeleteFolder
{
	public record DeleteFolderRequest : IRequest<Response<Guid>>
	{
		public Guid Id { get; set; }
	}
}
