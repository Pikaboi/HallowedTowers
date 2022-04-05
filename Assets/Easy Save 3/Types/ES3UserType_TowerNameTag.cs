using System;
using UnityEngine;

namespace ES3Types
{
	[UnityEngine.Scripting.Preserve]
	[ES3PropertiesAttribute("t", "m_manager", "enabled", "name")]
	public class ES3UserType_TowerNameTag : ES3ComponentType
	{
		public static ES3Type Instance = null;

		public ES3UserType_TowerNameTag() : base(typeof(TowerNameTag)){ Instance = this; priority = 1;}


		protected override void WriteComponent(object obj, ES3Writer writer)
		{
			var instance = (TowerNameTag)obj;
			
			writer.WritePrivateFieldByRef("t", instance);
			writer.WritePrivateFieldByRef("m_manager", instance);
			writer.WriteProperty("enabled", instance.enabled, ES3Type_bool.Instance);
		}

		protected override void ReadComponent<T>(ES3Reader reader, object obj)
		{
			var instance = (TowerNameTag)obj;
			foreach(string propertyName in reader.Properties)
			{
				switch(propertyName)
				{
					
					case "t":
					reader.SetPrivateField("t", reader.Read<TMPro.TMP_Text>(), instance);
					break;
					case "m_manager":
					reader.SetPrivateField("m_manager", reader.Read<TDTowerManager>(), instance);
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


	public class ES3UserType_TowerNameTagArray : ES3ArrayType
	{
		public static ES3Type Instance;

		public ES3UserType_TowerNameTagArray() : base(typeof(TowerNameTag[]), ES3UserType_TowerNameTag.Instance)
		{
			Instance = this;
		}
	}
}