using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace unsernamespace
{
	public class SingleTarget : AttackMode
	{
		public override ModeType Type
		{
			get
			{
				return ModeType.SingleTarget;
			}
		}

		public override bool Attack()
		{
			throw new NotImplementedException();
		}
	}
}