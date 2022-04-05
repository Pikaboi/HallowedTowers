using System;
using UnityEngine;

namespace ES3Types
{
	[UnityEngine.Scripting.Preserve]
	[ES3PropertiesAttribute("m_affinityButtons", "t", "m_updatedUGPrice")]
	public class ES3UserType_AffinityPriceTag : ES3ComponentType
	{
		public static ES3Type Instance = null;

		public ES3UserType_AffinityPriceTag() : base(typeof(AffinityPriceTag)){ Instance = this; priority = 1;}


		protected override void WriteComponent(object obj, ES3Writer writer)
		{
			var instance = (AffinityPriceTag)obj;
			
			writer.WritePrivateField("m_affinityButtons", instance);
			writer.WritePrivateFieldByRef("t", instance);
			writer.WritePrivateField("m_updatedUGPrice", instance);
		}

		protected override void ReadComponent<T>(ES3Reader reader, object obj)
		{
			var instance = (AffinityPriceTag)obj;
			foreach(string propertyName in reader.Properties)
			{
				switch(propertyName)
				{
					
					case "m_affinityButtons":
					reader.SetPrivateField("m_affinityButtons", reader.Read<ChangeAffinity[]>(), instance);
					break;
					case "t":
					reader.SetPrivateField("t", reader.Read<TMPro.TMP_Text>(), instance);
					break;
					case "m_updatedUGPrice":
					reader.SetPrivateField("m_updatedUGPrice", reader.Read<System.Single>(), instance);
					break;
					default:
						reader.Skip();
						break;
				}
			}
		}
	}


	public class ES3UserType_AffinityPriceTagArray : ES3ArrayType
	{
		public static ES3Type Instance;

		public ES3UserType_AffinityPriceTagArray() : base(typeof(AffinityPriceTag[]), ES3UserType_AffinityPriceTag.Instance)
		{
			Instance = this;
		}
	}
}