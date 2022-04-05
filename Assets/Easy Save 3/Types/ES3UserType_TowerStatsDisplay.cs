using System;
using UnityEngine;

namespace ES3Types
{
	[UnityEngine.Scripting.Preserve]
	[ES3PropertiesAttribute("m_manager", "atk", "spd", "range", "enabled", "name")]
	public class ES3UserType_TowerStatsDisplay : ES3ComponentType
	{
		public static ES3Type Instance = null;

		public ES3UserType_TowerStatsDisplay() : base(typeof(TowerStatsDisplay)){ Instance = this; priority = 1;}


		protected override void WriteComponent(object obj, ES3Writer writer)
		{
			var instance = (TowerStatsDisplay)obj;
			
			writer.WritePrivateFieldByRef("m_manager", instance);
			writer.WritePropertyByRef("atk", instance.atk);
			writer.WritePropertyByRef("spd", instance.spd);
			writer.WritePropertyByRef("range", instance.range);
			writer.WriteProperty("enabled", instance.enabled, ES3Type_bool.Instance);
		}

		protected override void ReadComponent<T>(ES3Reader reader, object obj)
		{
			var instance = (TowerStatsDisplay)obj;
			foreach(string propertyName in reader.Properties)
			{
				switch(propertyName)
				{
					
					case "m_manager":
					reader.SetPrivateField("m_manager", reader.Read<TDTowerManager>(), instance);
					break;
					case "atk":
						instance.atk = reader.Read<TMPro.TMP_Text>();
						break;
					case "spd":
						instance.spd = reader.Read<TMPro.TMP_Text>();
						break;
					case "range":
						instance.range = reader.Read<TMPro.TMP_Text>();
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


	public class ES3UserType_TowerStatsDisplayArray : ES3ArrayType
	{
		public static ES3Type Instance;

		public ES3UserType_TowerStatsDisplayArray() : base(typeof(TowerStatsDisplay[]), ES3UserType_TowerStatsDisplay.Instance)
		{
			Instance = this;
		}
	}
}