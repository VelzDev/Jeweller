﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jeweller.Concrete
{
	public class Favorite
	{
		public int Id { get; set; }
		public int UserId { get; set; }
		public int ProductId { get; set; }

		public virtual User User { get; set; }
		public virtual Product Product { get; set; }
	}
}
