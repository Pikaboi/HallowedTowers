using System;
using UnityEngine;

namespace ES3Types
{
	[UnityEngine.Scripting.Preserve]
	[ES3PropertiesAttribute("m_tower", "m_UpgradePrice", "m_baseCost", "m_resource", "m_sound", "isMax")]
	public class ES3UserType_TDTower_LevelUp : ES3ComponentType
	{
		public static ES3Type Instance = null;

		public ES3UserType_TDTower_LevelUp() : base(typeof(TDTower_LevelUp)){ Instance = this; priority = 1;}


		protected override void WriteComponent(object obj, ES3Writer writer)
		{
			var instance = (TDTower_LevelUp)obj;
			
			writer.WritePrivateFieldByRef("m_tower", instance);
			writer.WritePrivateField("m_UpgradePrice", instance);
			writer.WritePrivateField("m_baseCost", instance);
			writer.WritePrivateFieldByRef("m_resource", instance);
			writer.WritePropertyByRef("m_sound", instance.m_sound);
			writer.WriteProperty("isMax", instance.isMax, ES3Type_bool.Instance);
		}

		protected override void ReadComponent<T>(ES3Reader reader, object obj)
		{
			var instance = (TDTower_LevelUp)obj;
			foreach(string propertyName in reader.Properties)
			{
				switch(propertyName)
				{
					
					case "m_tower":
					reader.SetPrivateField("m_tower", reader.Read<TDTower>(), instance);
					break;
					case "m_UpgradePrice":
					reader.SetPrivateField("m_UpgradePrice", reader.Read<System.Single>(), instance);
					break;
					case "m_baseCost":
					reader.SetPrivateField("m_baseCost", reader.Read<System.Single>(), instance);
					break;
					case "m_resource":
					reader.SetPrivateField("m_resource", reader.Read<PlayerResourceManager>(), instance);
					break;
					case "m_sound":
						instance.m_sound = reader.Read<UnityEngine.AudioSource>();
						break;
					case "isMax":
						instance.isMax = reader.Read<System.Boolean>(ES3Type_bool.Instance);
						break;
					default:
						reader.Skip();
						break;
				}
			}
		}
	}


	public class ES3UserType_TDTower_LevelUpArray : ES3ArrayType
	{
		public static ES3Type Instance;

		public ES3UserType_TDTower_LevelUpArray() : base(typeof(TDTower_LevelUp[]), ES3UserType_TDTower_LevelUp.Instance)
		{
			Instance = this;
		}
	}
}