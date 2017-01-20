using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace unsernamespace
{
	public class AOE : AttackMode
	{
		public override ModeType Type
		{
			get
			{
				return ModeType.AOE;
			}
		}

		public override bool Attack()
		{
			throw new NotImplementedException();
		}
	}
}