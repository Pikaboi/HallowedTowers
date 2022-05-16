using System;
using UnityEngine;

namespace ES3Types
{
	[UnityEngine.Scripting.Preserve]
	[ES3PropertiesAttribute("bought")]
	public class ES3UserType_InventoryPurchase : ES3ComponentType
	{
		public static ES3Type Instance = null;

		public ES3UserType_InventoryPurchase() : base(typeof(InventoryPurchase)){ Instance = this; priority = 1;}


		protected override void WriteComponent(object obj, ES3Writer writer)
		{
			var instance = (InventoryPurchase)obj;
			
			writer.WriteProperty("bought", instance.bought, ES3Type_bool.Instance);
		}

		protected override void ReadComponent<T>(ES3Reader reader, object obj)
		{
			var instance = (InventoryPurchase)obj;
			foreach(string propertyName in reader.Properties)
			{
				switch(propertyName)
				{
					
					case "bought":
						instance.bought = reader.Read<System.Boolean>(ES3Type_bool.Instance);
						break;
					default:
						reader.Skip();
						break;
				}
			}
		}
	}


	public class ES3UserType_InventoryPurchaseArray : ES3ArrayType
	{
		public static ES3Type Instance;

		public ES3UserType_InventoryPurchaseArray() : base(typeof(InventoryPurchase[]), ES3UserType_InventoryPurchase.Instance)
		{
			Instance = this;
		}
	}
}