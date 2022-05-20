using System;
using UnityEngine;

namespace ES3Types
{
	[UnityEngine.Scripting.Preserve]
	[ES3PropertiesAttribute("weaponid", "equipped")]
	public class ES3UserType_WheelEquipper : ES3ComponentType
	{
		public static ES3Type Instance = null;

		public ES3UserType_WheelEquipper() : base(typeof(WheelEquipper)){ Instance = this; priority = 1;}


		protected override void WriteComponent(object obj, ES3Writer writer)
		{
			var instance = (WheelEquipper)obj;
			
			writer.WriteProperty("weaponid", instance.weaponid, ES3Type_int.Instance);
			writer.WriteProperty("equipped", instance.equipped, ES3Type_bool.Instance);
		}

		protected override void ReadComponent<T>(ES3Reader reader, object obj)
		{
			var instance = (WheelEquipper)obj;
			foreach(string propertyName in reader.Properties)
			{
				switch(propertyName)
				{
					
					case "weaponid":
						instance.weaponid = reader.Read<System.Int32>(ES3Type_int.Instance);
						break;
					case "equipped":
						instance.equipped = reader.Read<System.Boolean>(ES3Type_bool.Instance);
						break;
					default:
						reader.Skip();
						break;
				}
			}
		}
	}


	public class ES3UserType_WheelEquipperArray : ES3ArrayType
	{
		public static ES3Type Instance;

		public ES3UserType_WheelEquipperArray() : base(typeof(WheelEquipper[]), ES3UserType_WheelEquipper.Instance)
		{
			Instance = this;
		}
	}
}