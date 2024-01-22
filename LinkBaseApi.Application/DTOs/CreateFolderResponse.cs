using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkBaseApi.Application.DTOs
{
	public class CreateFolderResponse
	{
		public Guid FolderId { get; set; }
		public Guid UserId { get; set; }
	}
}
