using System;
using UnityEngine;

namespace ES3Types
{
	[UnityEngine.Scripting.Preserve]
	[ES3PropertiesAttribute("m_manager", "m_image", "m_monster", "m_soul", "m_magic", "m_undead")]
	public class ES3UserType_AffinityUI : ES3ComponentType
	{
		public static ES3Type Instance = null;

		public ES3UserType_AffinityUI() : base(typeof(AffinityUI)){ Instance = this; priority = 1;}


		protected override void WriteComponent(object obj, ES3Writer writer)
		{
			var instance = (AffinityUI)obj;
			
			writer.WritePropertyByRef("m_manager", instance.m_manager);
			writer.WritePropertyByRef("m_image", instance.m_image);
			writer.WritePropertyByRef("m_monster", instance.m_monster);
			writer.WritePropertyByRef("m_soul", instance.m_soul);
			writer.WritePropertyByRef("m_magic", instance.m_magic);
			writer.WritePropertyByRef("m_undead", instance.m_undead);
		}

		protected override void ReadComponent<T>(ES3Reader reader, object obj)
		{
			var instance = (AffinityUI)obj;
			foreach(string propertyName in reader.Properties)
			{
				switch(propertyName)
				{
					
					case "m_manager":
						instance.m_manager = reader.Read<TDTowerManager>();
						break;
					case "m_image":
						instance.m_image = reader.Read<UnityEngine.UI.Image>(ES3Type_Image.Instance);
						break;
					case "m_monster":
						instance.m_monster = reader.Read<UnityEngine.Sprite>(ES3Type_Sprite.Instance);
						break;
					case "m_soul":
						instance.m_soul = reader.Read<UnityEngine.Sprite>(ES3Type_Sprite.Instance);
						break;
					case "m_magic":
						instance.m_magic = reader.Read<UnityEngine.Sprite>(ES3Type_Sprite.Instance);
						break;
					case "m_undead":
						instance.m_undead = reader.Read<UnityEngine.Sprite>(ES3Type_Sprite.Instance);
						break;
					default:
						reader.Skip();
						break;
				}
			}
		}
	}


	public class ES3UserType_AffinityUIArray : ES3ArrayType
	{
		public static ES3Type Instance;

		public ES3UserType_AffinityUIArray() : base(typeof(AffinityUI[]), ES3UserType_AffinityUI.Instance)
		{
			Instance = this;
		}
	}
}