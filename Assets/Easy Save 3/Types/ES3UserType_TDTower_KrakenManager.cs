using System;
using UnityEngine;

namespace ES3Types
{
	[UnityEngine.Scripting.Preserve]
	[ES3PropertiesAttribute("m_main", "m_kraken", "aimpos")]
	public class ES3UserType_TDTower_KrakenManager : ES3ComponentType
	{
		public static ES3Type Instance = null;

		public ES3UserType_TDTower_KrakenManager() : base(typeof(TDTower_KrakenManager)){ Instance = this; priority = 1;}


		protected override void WriteComponent(object obj, ES3Writer writer)
		{
			var instance = (TDTower_KrakenManager)obj;
			
			writer.WritePrivateFieldByRef("m_main", instance);
			writer.WritePrivateFieldByRef("m_kraken", instance);
			writer.WriteProperty("aimpos", instance.aimpos, ES3Type_Vector3.Instance);
		}

		protected override void ReadComponent<T>(ES3Reader reader, object obj)
		{
			var instance = (TDTower_KrakenManager)obj;
			foreach(string propertyName in reader.Properties)
			{
				switch(propertyName)
				{
					
					case "m_main":
					reader.SetPrivateField("m_main", reader.Read<TDTowerManager>(), instance);
					break;
					case "m_kraken":
					reader.SetPrivateField("m_kraken", reader.Read<TDTower_Kraken>(), instance);
					break;
					case "aimpos":
						instance.aimpos = reader.Read<UnityEngine.Vector3>(ES3Type_Vector3.Instance);
						break;
					default:
						reader.Skip();
						break;
				}
			}
		}
	}


	public class ES3UserType_TDTower_KrakenManagerArray : ES3ArrayType
	{
		public static ES3Type Instance;

		public ES3UserType_TDTower_KrakenManagerArray() : base(typeof(TDTower_KrakenManager[]), ES3UserType_TDTower_KrakenManager.Instance)
		{
			Instance = this;
		}
	}
}