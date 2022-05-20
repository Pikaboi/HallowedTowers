using System;
using UnityEngine;

namespace ES3Types
{
	[UnityEngine.Scripting.Preserve]
	[ES3PropertiesAttribute("m_Weapon")]
	public class ES3UserType_RadialEquipper : ES3ComponentType
	{
		public static ES3Type Instance = null;

		public ES3UserType_RadialEquipper() : base(typeof(RadialEquipper)){ Instance = this; priority = 1;}


		protected override void WriteComponent(object obj, ES3Writer writer)
		{
			var instance = (RadialEquipper)obj;
			
			writer.WritePropertyByRef("m_Weapon", instance.m_Weapon);
		}

		protected override void ReadComponent<T>(ES3Reader reader, object obj)
		{
			var instance = (RadialEquipper)obj;
			foreach(string propertyName in reader.Properties)
			{
				switch(propertyName)
				{
					
					case "m_Weapon":
						instance.m_Weapon = reader.Read<WeaponEquipButton>(ES3UserType_WeaponEquipButton.Instance);
						break;
					default:
						reader.Skip();
						break;
				}
			}
		}
	}


	public class ES3UserType_RadialEquipperArray : ES3ArrayType
	{
		public static ES3Type Instance;

		public ES3UserType_RadialEquipperArray() : base(typeof(RadialEquipper[]), ES3UserType_RadialEquipper.Instance)
		{
			Instance = this;
		}
	}
}