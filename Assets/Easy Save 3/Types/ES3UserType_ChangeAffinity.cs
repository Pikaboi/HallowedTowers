using System;
using UnityEngine;

namespace ES3Types
{
	[UnityEngine.Scripting.Preserve]
	[ES3PropertiesAttribute("m_affinity", "m_manager", "m_PriceTag", "m_resource", "m_upgradePrice", "m_baseCost", "m_Sound")]
	public class ES3UserType_ChangeAffinity : ES3ComponentType
	{
		public static ES3Type Instance = null;

		public ES3UserType_ChangeAffinity() : base(typeof(ChangeAffinity)){ Instance = this; priority = 1;}


		protected override void WriteComponent(object obj, ES3Writer writer)
		{
			var instance = (ChangeAffinity)obj;
			
			writer.WritePrivateField("m_affinity", instance);
			writer.WritePrivateFieldByRef("m_manager", instance);
			writer.WritePrivateFieldByRef("m_PriceTag", instance);
			writer.WritePrivateFieldByRef("m_resource", instance);
			writer.WriteProperty("m_upgradePrice", instance.m_upgradePrice, ES3Type_float.Instance);
			writer.WriteProperty("m_baseCost", instance.m_baseCost, ES3Type_float.Instance);
			writer.WritePropertyByRef("m_Sound", instance.m_Sound);
		}

		protected override void ReadComponent<T>(ES3Reader reader, object obj)
		{
			var instance = (ChangeAffinity)obj;
			foreach(string propertyName in reader.Properties)
			{
				switch(propertyName)
				{
					
					case "m_affinity":
					reader.SetPrivateField("m_affinity", reader.Read<affinity.Affinity>(), instance);
					break;
					case "m_manager":
					reader.SetPrivateField("m_manager", reader.Read<TDTowerManager>(), instance);
					break;
					case "m_PriceTag":
					reader.SetPrivateField("m_PriceTag", reader.Read<AffinityPriceTag>(), instance);
					break;
					case "m_resource":
					reader.SetPrivateField("m_resource", reader.Read<PlayerResourceManager>(), instance);
					break;
					case "m_upgradePrice":
						instance.m_upgradePrice = reader.Read<System.Single>(ES3Type_float.Instance);
						break;
					case "m_baseCost":
						instance.m_baseCost = reader.Read<System.Single>(ES3Type_float.Instance);
						break;
					case "m_Sound":
						instance.m_Sound = reader.Read<UnityEngine.AudioSource>();
						break;
					default:
						reader.Skip();
						break;
				}
			}
		}
	}


	public class ES3UserType_ChangeAffinityArray : ES3ArrayType
	{
		public static ES3Type Instance;

		public ES3UserType_ChangeAffinityArray() : base(typeof(ChangeAffinity[]), ES3UserType_ChangeAffinity.Instance)
		{
			Instance = this;
		}
	}
}