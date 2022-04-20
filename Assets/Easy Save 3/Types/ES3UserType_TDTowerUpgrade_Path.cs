using System;
using UnityEngine;

namespace ES3Types
{
	[UnityEngine.Scripting.Preserve]
	[ES3PropertiesAttribute("m_UGPaths", "PathNum", "m_UGString", "m_UGBought", "m_successor", "m_UGCost", "m_baseCost", "m_UGName", "m_UGCostString", "m_UGPrefab", "m_resource", "m_manager", "m_sound", "m_Locked", "m_Purchased", "resourcePath")]
	public class ES3UserType_TDTowerUpgrade_Path : ES3ComponentType
	{
		public static ES3Type Instance = null;

		public ES3UserType_TDTowerUpgrade_Path() : base(typeof(TDTowerUpgrade_Path)){ Instance = this; priority = 1;}


		protected override void WriteComponent(object obj, ES3Writer writer)
		{
			var instance = (TDTowerUpgrade_Path)obj;
			
			writer.WriteProperty("m_UGPaths", instance.m_UGPaths, ES3UserType_TDTowerUpgrade_PathArray.Instance);
			writer.WriteProperty("PathNum", instance.PathNum, ES3Type_int.Instance);
			writer.WriteProperty("m_UGString", instance.m_UGString, ES3Type_string.Instance);
			writer.WriteProperty("m_UGBought", instance.m_UGBought, ES3Type_bool.Instance);
			writer.WritePropertyByRef("m_successor", instance.m_successor);
			writer.WriteProperty("m_UGCost", instance.m_UGCost, ES3Type_float.Instance);
			writer.WriteProperty("m_baseCost", instance.m_baseCost, ES3Type_float.Instance);
			writer.WritePropertyByRef("m_UGName", instance.m_UGName);
			writer.WritePropertyByRef("m_UGCostString", instance.m_UGCostString);
			writer.WritePropertyByRef("m_UGPrefab", instance.m_UGPrefab);
			writer.WritePropertyByRef("m_resource", instance.m_resource);
			writer.WritePropertyByRef("m_manager", instance.m_manager);
			writer.WritePropertyByRef("m_sound", instance.m_sound);
			writer.WritePropertyByRef("m_Locked", instance.m_Locked);
			writer.WritePropertyByRef("m_Purchased", instance.m_Purchased);
			writer.WriteProperty("resourcePath", instance.resourcePath, ES3Type_string.Instance);
		}

		protected override void ReadComponent<T>(ES3Reader reader, object obj)
		{
			var instance = (TDTowerUpgrade_Path)obj;
			foreach(string propertyName in reader.Properties)
			{
				switch(propertyName)
				{
					
					case "m_UGPaths":
						instance.m_UGPaths = reader.Read<TDTowerUpgrade_Path[]>(ES3UserType_TDTowerUpgrade_PathArray.Instance);
						break;
					case "PathNum":
						instance.PathNum = reader.Read<System.Int32>(ES3Type_int.Instance);
						break;
					case "m_UGString":
						instance.m_UGString = reader.Read<System.String>(ES3Type_string.Instance);
						break;
					case "m_UGBought":
						instance.m_UGBought = reader.Read<System.Boolean>(ES3Type_bool.Instance);
						break;
					case "m_successor":
						instance.m_successor = reader.Read<TDTowerUpgrade>(ES3UserType_TDTowerUpgrade.Instance);
						break;
					case "m_UGCost":
						instance.m_UGCost = reader.Read<System.Single>(ES3Type_float.Instance);
						break;
					case "m_baseCost":
						instance.m_baseCost = reader.Read<System.Single>(ES3Type_float.Instance);
						break;
					case "m_UGName":
						instance.m_UGName = reader.Read<TMPro.TMP_Text>();
						break;
					case "m_UGCostString":
						instance.m_UGCostString = reader.Read<TMPro.TMP_Text>();
						break;
					case "m_UGPrefab":
						instance.m_UGPrefab = reader.Read<UnityEngine.GameObject>(ES3Type_GameObject.Instance);
						break;
					case "m_resource":
						instance.m_resource = reader.Read<PlayerResourceManager>();
						break;
					case "m_manager":
						instance.m_manager = reader.Read<TDTowerManager>(ES3UserType_TDTowerManager.Instance);
						break;
					case "m_sound":
						instance.m_sound = reader.Read<UnityEngine.AudioSource>();
						break;
					case "m_Locked":
						instance.m_Locked = reader.Read<UnityEngine.Sprite>(ES3Type_Sprite.Instance);
						break;
					case "m_Purchased":
						instance.m_Purchased = reader.Read<UnityEngine.Sprite>(ES3Type_Sprite.Instance);
						break;
					case "resourcePath":
						instance.resourcePath = reader.Read<System.String>(ES3Type_string.Instance);
						break;
					default:
						reader.Skip();
						break;
				}
			}
		}
	}


	public class ES3UserType_TDTowerUpgrade_PathArray : ES3ArrayType
	{
		public static ES3Type Instance;

		public ES3UserType_TDTowerUpgrade_PathArray() : base(typeof(TDTowerUpgrade_Path[]), ES3UserType_TDTowerUpgrade_Path.Instance)
		{
			Instance = this;
		}
	}
}