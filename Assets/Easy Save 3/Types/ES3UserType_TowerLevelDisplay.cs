using System;
using UnityEngine;

namespace ES3Types
{
	[UnityEngine.Scripting.Preserve]
	[ES3PropertiesAttribute("m_manager", "t", "enabled", "name")]
	public class ES3UserType_TowerLevelDisplay : ES3ComponentType
	{
		public static ES3Type Instance = null;

		public ES3UserType_TowerLevelDisplay() : base(typeof(TowerLevelDisplay)){ Instance = this; priority = 1;}


		protected override void WriteComponent(object obj, ES3Writer writer)
		{
			var instance = (TowerLevelDisplay)obj;
			
			writer.WritePrivateFieldByRef("m_manager", instance);
			writer.WritePrivateFieldByRef("t", instance);
			writer.WriteProperty("enabled", instance.enabled, ES3Type_bool.Instance);
		}

		protected override void ReadComponent<T>(ES3Reader reader, object obj)
		{
			var instance = (TowerLevelDisplay)obj;
			foreach(string propertyName in reader.Properties)
			{
				switch(propertyName)
				{
					
					case "m_manager":
					reader.SetPrivateField("m_manager", reader.Read<TDTowerManager>(), instance);
					break;
					case "t":
					reader.SetPrivateField("t", reader.Read<TMPro.TMP_Text>(), instance);
					break;
					case "enabled":
						instance.enabled = reader.Read<System.Boolean>(ES3Type_bool.Instance);
						break;
					default:
						reader.Skip();
						break;
				}
			}
		}
	}


	public class ES3UserType_TowerLevelDisplayArray : ES3ArrayType
	{
		public static ES3Type Instance;

		public ES3UserType_TowerLevelDisplayArray() : base(typeof(TowerLevelDisplay[]), ES3UserType_TowerLevelDisplay.Instance)
		{
			Instance = this;
		}
	}
}