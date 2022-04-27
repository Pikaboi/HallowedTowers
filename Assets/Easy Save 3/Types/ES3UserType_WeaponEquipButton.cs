using System;
using UnityEngine;

namespace ES3Types
{
	[UnityEngine.Scripting.Preserve]
	[ES3PropertiesAttribute("m_Weapon", "m_Player", "m_rot", "t", "UpgradePrice", "UGCount", "attackBoost", "m_resource", "m_affinitySprite")]
	public class ES3UserType_WeaponEquipButton : ES3ComponentType
	{
		public static ES3Type Instance = null;

		public ES3UserType_WeaponEquipButton() : base(typeof(WeaponEquipButton)){ Instance = this; priority = 1;}


		protected override void WriteComponent(object obj, ES3Writer writer)
		{
			var instance = (WeaponEquipButton)obj;
			
			writer.WritePropertyByRef("m_Weapon", instance.m_Weapon);
			writer.WritePropertyByRef("m_Player", instance.m_Player);
			writer.WriteProperty("m_rot", instance.m_rot, ES3Type_Vector3.Instance);
			writer.WritePropertyByRef("t", instance.t);
			writer.WritePrivateField("UpgradePrice", instance);
			writer.WritePrivateField("UGCount", instance);
			writer.WriteProperty("attackBoost", instance.attackBoost, ES3Type_float.Instance);
			writer.WritePrivateFieldByRef("m_resource", instance);
			writer.WritePropertyByRef("m_affinitySprite", instance.m_affinitySprite);
		}

		protected override void ReadComponent<T>(ES3Reader reader, object obj)
		{
			var instance = (WeaponEquipButton)obj;
			foreach(string propertyName in reader.Properties)
			{
				switch(propertyName)
				{
					
					case "m_Weapon":
						instance.m_Weapon = reader.Read<UnityEngine.GameObject>(ES3Type_GameObject.Instance);
						break;
					case "m_Player":
						instance.m_Player = reader.Read<WorldCharacter>();
						break;
					case "m_rot":
						instance.m_rot = reader.Read<UnityEngine.Vector3>(ES3Type_Vector3.Instance);
						break;
					case "t":
						instance.t = reader.Read<TMPro.TMP_Text>();
						break;
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
					case "m_affinitySprite":
						instance.m_affinitySprite = reader.Read<UnityEngine.UI.Image>(ES3Type_Image.Instance);
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