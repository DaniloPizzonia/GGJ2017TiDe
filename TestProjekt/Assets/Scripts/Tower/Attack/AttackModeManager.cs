using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace unsernamespace
{
	public class AttackModeManager : RootComponent
	{
		private AttackMode[] mode_all = new AttackMode[]
		{
			new AOE(),
			new SingleTarget(),
			new Slower()
		};

		public AttackMode GetModeOfType( ModeType type )
		{
			return mode_all.FirstOrDefault( a => a.Type == type );
		}
	}
}
