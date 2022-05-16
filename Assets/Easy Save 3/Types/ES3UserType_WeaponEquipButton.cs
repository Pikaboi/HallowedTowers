using System;
using UnityEngine;

namespace ES3Types
{
	[UnityEngine.Scripting.Preserve]
	[ES3PropertiesAttribute("UpgradePrice", "UGCount", "attackBoost", "m_resource", "id")]
	public class ES3UserType_WeaponEquipButton : ES3ComponentType
	{
		public static ES3Type Instance = null;

		public ES3UserType_WeaponEquipButton() : base(typeof(WeaponEquipButton)){ Instance = this; priority = 1;}


		protected override void WriteComponent(object obj, ES3Writer writer)
		{
			var instance = (WeaponEquipButton)obj;
			
			writer.WritePrivateField("UpgradePrice", instance);
			writer.WritePrivateField("UGCount", instance);
			writer.WriteProperty("attackBoost", instance.attackBoost, ES3Type_float.Instance);
			writer.WritePrivateFieldByRef("m_resource", instance);
			writer.WriteProperty("id", instance.id, ES3Type_int.Instance);
		}

		protected override void ReadComponent<T>(ES3Reader reader, object obj)
		{
			var instance = (WeaponEquipButton)obj;
			foreach(string propertyName in reader.Properties)
			{
				switch(propertyName)
				{
					
					case "UpgradePrice":
					reader.SetPrivateField("UpgradePrice", reader.Read<System.Single>(), instance);
					break;
					case "UGCount":
					reader.SetPrivateField("UGCount", reader.Read<System.Int32>(), instance);
					break;
					case "attackBoost":
						instance.attackBoost = reader.Read<System.Single>(ES3Type_float.Instance);
						break;
					case "m_resource":
					reader.SetPrivateField("m_resource", reader.Read<PlayerResourceManager>(), instance);
					break;
					case "id":
						instance.id = reader.Read<System.Int32>(ES3Type_int.Instance);
						break;
					default:
						reader.Skip();
						break;
				}
			}
		}
	}


	public class ES3UserType_WeaponEquipButtonArray : ES3ArrayType
	{
		public static ES3Type Instance;

		public ES3UserType_WeaponEquipButtonArray() : base(typeof(WeaponEquipButton[]), ES3UserType_WeaponEquipButton.Instance)
		{
			Instance = this;
		}
	}
}