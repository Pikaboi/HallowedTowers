using System;
using UnityEngine;

namespace ES3Types
{
	[UnityEngine.Scripting.Preserve]
	[ES3PropertiesAttribute("m_weaponMenuPrefab", "m_price", "m_resource", "m_inventory", "pricetag", "m_UGmenuInstance")]
	public class ES3UserType_InventoryPurchase : ES3ComponentType
	{
		public static ES3Type Instance = null;

		public ES3UserType_InventoryPurchase() : base(typeof(InventoryPurchase)){ Instance = this; priority = 1;}


		protected override void WriteComponent(object obj, ES3Writer writer)
		{
			var instance = (InventoryPurchase)obj;
			
			writer.WritePropertyByRef("m_weaponMenuPrefab", instance.m_weaponMenuPrefab);
			writer.WriteProperty("m_price", instance.m_price, ES3Type_float.Instance);
			writer.WritePropertyByRef("m_resource", instance.m_resource);
			writer.WritePropertyByRef("m_inventory", instance.m_inventory);
			writer.WritePropertyByRef("pricetag", instance.pricetag);
			writer.WritePropertyByRef("m_UGmenuInstance", instance.m_UGmenuInstance);
		}

		protected override void ReadComponent<T>(ES3Reader reader, object obj)
		{
			var instance = (InventoryPurchase)obj;
			foreach(string propertyName in reader.Properties)
			{
				switch(propertyName)
				{
					
					case "m_weaponMenuPrefab":
						instance.m_weaponMenuPrefab = reader.Read<UnityEngine.GameObject>(ES3Type_GameObject.Instance);
						break;
					case "m_price":
						instance.m_price = reader.Read<System.Single>(ES3Type_float.Instance);
						break;
					case "m_resource":
						instance.m_resource = reader.Read<PlayerResourceManager>();
						break;
					case "m_inventory":
						instance.m_inventory = reader.Read<InventoryAdd>();
						break;
					case "pricetag":
						instance.pricetag = reader.Read<TMPro.TMP_Text>();
						break;
					case "m_UGmenuInstance":
						instance.m_UGmenuInstance = reader.Read<CreateWeaponUpgradeMenu>();
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