using LinkBaseApi.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkBaseApi.Application.DTOs.Folder
{
	public class FolderResponseWithLinks : FolderResponse
	{
		public required ICollection<Link> Links { get; set; }
	}
}
