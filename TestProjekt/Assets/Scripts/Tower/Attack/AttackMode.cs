using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace unsernamespace
{
	public abstract class AttackMode
	{
		public abstract ModeType Type
		{
			get;
		}

		public abstract bool Attack();
	}
}