using System;
using UnityEngine;

namespace ES3Types
{
	[UnityEngine.Scripting.Preserve]
	[ES3PropertiesAttribute("m_weapon", "t")]
	public class ES3UserType_ShowWeaponAttack : ES3ComponentType
	{
		public static ES3Type Instance = null;

		public ES3UserType_ShowWeaponAttack() : base(typeof(ShowWeaponAttack)){ Instance = this; priority = 1;}


		protected override void WriteComponent(object obj, ES3Writer writer)
		{
			var instance = (ShowWeaponAttack)obj;
			
			writer.WritePropertyByRef("m_weapon", instance.m_weapon);
			writer.WritePropertyByRef("t", instance.t);
		}

		protected override void ReadComponent<T>(ES3Reader reader, object obj)
		{
			var instance = (ShowWeaponAttack)obj;
			foreach(string propertyName in reader.Properties)
			{
				switch(propertyName)
				{
					
					case "m_weapon":
						instance.m_weapon = reader.Read<WeaponEquipButton>(ES3UserType_WeaponEquipButton.Instance);
						break;
					case "t":
						instance.t = reader.Read<TMPro.TMP_Text>();
						break;
					default:
						reader.Skip();
						break;
				}
			}
		}
	}


	public class ES3UserType_ShowWeaponAttackArray : ES3ArrayType
	{
		public static ES3Type Instance;

		public ES3UserType_ShowWeaponAttackArray() : base(typeof(ShowWeaponAttack[]), ES3UserType_ShowWeaponAttack.Instance)
		{
			Instance = this;
		}
	}
}