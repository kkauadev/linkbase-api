using LinkBaseApi.Domain.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkBaseApi.Application.DTOs
{
	public record UserResponseWithFolders : UserResponse
	{
		public required Collection<Folder> Folders { get; set; }
	}
}
