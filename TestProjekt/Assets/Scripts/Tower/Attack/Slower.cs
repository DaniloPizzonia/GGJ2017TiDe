using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace unsernamespace
{
	public class Slower : AttackMode
	{
		public override ModeType Type
		{
			get
			{
				return ModeType.Slower;
			}
		}

		public override bool Attack()
		{
			throw new NotImplementedException();
		}
	}
}