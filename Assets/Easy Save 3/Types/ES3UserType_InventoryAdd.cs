using System;
using UnityEngine;

namespace ES3Types
{
	[UnityEngine.Scripting.Preserve]
	[ES3PropertiesAttribute("saved")]
	public class ES3UserType_InventoryAdd : ES3ComponentType
	{
		public static ES3Type Instance = null;

		public ES3UserType_InventoryAdd() : base(typeof(InventoryAdd)){ Instance = this; priority = 1;}


		protected override void WriteComponent(object obj, ES3Writer writer)
		{
			var instance = (InventoryAdd)obj;
			
			writer.WriteProperty("saved", instance.saved, ES3Type_bool.Instance);
		}

		protected override void ReadComponent<T>(ES3Reader reader, object obj)
		{
			var instance = (InventoryAdd)obj;
			foreach(string propertyName in reader.Properties)
			{
				switch(propertyName)
				{
					
					case "saved":
						instance.saved = reader.Read<System.Boolean>(ES3Type_bool.Instance);
						break;
					default:
						reader.Skip();
						break;
				}
			}
		}
	}


	public class ES3UserType_InventoryAddArray : ES3ArrayType
	{
		public static ES3Type Instance;

		public ES3UserType_InventoryAddArray() : base(typeof(InventoryAdd[]), ES3UserType_InventoryAdd.Instance)
		{
			Instance = this;
		}
	}
}