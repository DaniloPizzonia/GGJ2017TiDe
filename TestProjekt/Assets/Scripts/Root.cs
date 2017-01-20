using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace unsernamespace
{
	public class Root
	{
		private static Dictionary<Type , RootComponent> component_collection = new Dictionary<Type , RootComponent>();
		private static Root instance;

		/// <summary>
		/// Getter for singelton
		/// </summary>
		public static Root I
		{
			get
			{
				if ( null == instance )
				{
					instance = new Root();
				}

				return instance;
			}
		}

		/// <summary>
		/// Gets the instance of given type and load it if needed
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <returns></returns>
		public T Get<T>() where T : RootComponent, new()
		{
			Type type = typeof( T );

			if ( !component_collection.ContainsKey( type ) )
			{
				component_collection[ type ] = new T();
			}

			return component_collection[ type ] as T;
		}
	}