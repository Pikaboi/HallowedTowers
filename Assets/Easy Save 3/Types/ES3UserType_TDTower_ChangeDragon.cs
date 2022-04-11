using System;
using UnityEngine;

namespace ES3Types
{
	[UnityEngine.Scripting.Preserve]
	[ES3PropertiesAttribute("m_main", "m_dragon", "m_flightPath")]
	public class ES3UserType_TDTower_ChangeDragon : ES3ComponentType
	{
		public static ES3Type Instance = null;

		public ES3UserType_TDTower_ChangeDragon() : base(typeof(TDTower_ChangeDragon)){ Instance = this; priority = 1;}


		protected override void WriteComponent(object obj, ES3Writer writer)
		{
			var instance = (TDTower_ChangeDragon)obj;
			
			writer.WritePrivateFieldByRef("m_main", instance);
			writer.WritePrivateFieldByRef("m_dragon", instance);
			writer.WriteProperty("m_flightPath", instance.m_flightPath, ES3Internal.ES3TypeMgr.GetOrCreateES3Type(typeof(TDTowerDragon.FlightPath)));
		}

		protected override void ReadComponent<T>(ES3Reader reader, object obj)
		{
			var instance = (TDTower_ChangeDragon)obj;
			foreach(string propertyName in reader.Properties)
			{
				switch(propertyName)
				{
					
					case "m_main":
					reader.SetPrivateField("m_main", reader.Read<TDTowerManager>(), instance);
					break;
					case "m_dragon":
					reader.SetPrivateField("m_dragon", reader.Read<TDTowerDragon>(), instance);
					break;
					case "m_flightPath":
						instance.m_flightPath = reader.Read<TDTowerDragon.FlightPath>();
						break;
					default:
						reader.Skip();
						break;
				}
			}
		}
	}


	public class ES3UserType_TDTower_ChangeDragonArray : ES3ArrayType
	{
		public static ES3Type Instance;

		public ES3UserType_TDTower_ChangeDragonArray() : base(typeof(TDTower_ChangeDragon[]), ES3UserType_TDTower_ChangeDragon.Instance)
		{
			Instance = this;
		}
	}
}