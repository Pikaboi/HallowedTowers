using System;
using UnityEngine;

namespace ES3Types
{
	[UnityEngine.Scripting.Preserve]
	[ES3PropertiesAttribute("m_health", "loaded")]
	public class ES3UserType_WorldCharacter : ES3ComponentType
	{
		public static ES3Type Instance = null;

		public ES3UserType_WorldCharacter() : base(typeof(WorldCharacter)){ Instance = this; priority = 1;}


		protected override void WriteComponent(object obj, ES3Writer writer)
		{
			var instance = (WorldCharacter)obj;
			
			writer.WriteProperty("m_health", instance.m_health, ES3Type_float.Instance);
			writer.WriteProperty("loaded", instance.loaded, ES3Type_bool.Instance);
		}

		protected override void ReadComponent<T>(ES3Reader reader, object obj)
		{
			var instance = (WorldCharacter)obj;
			foreach(string propertyName in reader.Properties)
			{
				switch(propertyName)
				{
					
					case "m_health":
						instance.m_health = reader.Read<System.Single>(ES3Type_float.Instance);
						break;
					case "loaded":
						instance.loaded = reader.Read<System.Boolean>(ES3Type_bool.Instance);
						break;
					default:
						reader.Skip();
						break;
				}
			}
		}
	}


	public class ES3UserType_WorldCharacterArray : ES3ArrayType
	{
		public static ES3Type Instance;

		public ES3UserType_WorldCharacterArray() : base(typeof(WorldCharacter[]), ES3UserType_WorldCharacter.Instance)
		{
			Instance = this;
		}
	}
}