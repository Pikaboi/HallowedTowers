using System;
using UnityEngine;

namespace ES3Types
{
	[UnityEngine.Scripting.Preserve]
	[ES3PropertiesAttribute("m_child", "m_affinity", "m_base", "m_towerName", "m_cost", "m_sellCost", "m_UpgradeUI", "m_TriggerRange", "m_fireRate", "m_attack", "m_level", "m_UGParticle", "m_BuffParticle", "m_ShootParticle", "m_UGDiscount", "m_LevelDiscount", "m_AffinityDiscount", "baseModel", "Path1Model", "Path2Model", "Path3Model", "baseResource", "modelNum", "saved", "m_resource")]
	public class ES3UserType_TDTowerManager : ES3ComponentType
	{
		public static ES3Type Instance = null;

		public ES3UserType_TDTowerManager() : base(typeof(TDTowerManager)){ Instance = this; priority = 1;}


		protected override void WriteComponent(object obj, ES3Writer writer)
		{
			var instance = (TDTowerManager)obj;
			
			writer.WritePropertyByRef("m_child", instance.m_child);
			writer.WriteProperty("m_affinity", instance.m_affinity, ES3Internal.ES3TypeMgr.GetOrCreateES3Type(typeof(affinity.Affinity)));
			writer.WritePropertyByRef("m_base", instance.m_base);
			writer.WriteProperty("m_towerName", instance.m_towerName, ES3Type_string.Instance);
			writer.WriteProperty("m_cost", instance.m_cost, ES3Type_float.Instance);
			writer.WriteProperty("m_sellCost", instance.m_sellCost, ES3Type_float.Instance);
			writer.WritePropertyByRef("m_UpgradeUI", instance.m_UpgradeUI);
			writer.WriteProperty("m_TriggerRange", instance.m_TriggerRange, ES3Type_float.Instance);
			writer.WriteProperty("m_fireRate", instance.m_fireRate, ES3Type_float.Instance);
			writer.WriteProperty("m_attack", instance.m_attack, ES3Type_float.Instance);
			writer.WriteProperty("m_level", instance.m_level, ES3Type_int.Instance);
			writer.WritePropertyByRef("m_UGParticle", instance.m_UGParticle);
			writer.WritePropertyByRef("m_BuffParticle", instance.m_BuffParticle);
			writer.WritePropertyByRef("m_ShootParticle", instance.m_ShootParticle);
			writer.WriteProperty("m_UGDiscount", instance.m_UGDiscount, ES3Type_float.Instance);
			writer.WriteProperty("m_LevelDiscount", instance.m_LevelDiscount, ES3Type_float.Instance);
			writer.WriteProperty("m_AffinityDiscount", instance.m_AffinityDiscount, ES3Type_float.Instance);
			writer.WritePropertyByRef("baseModel", instance.baseModel);
			writer.WritePropertyByRef("Path1Model", instance.Path1Model);
			writer.WritePropertyByRef("Path2Model", instance.Path2Model);
			writer.WritePropertyByRef("Path3Model", instance.Path3Model);
			writer.WriteProperty("baseResource", instance.baseResource, ES3Type_string.Instance);
			writer.WriteProperty("modelNum", instance.modelNum, ES3Type_int.Instance);
			writer.WriteProperty("saved", instance.saved, ES3Type_bool.Instance);
			writer.WritePropertyByRef("m_resource", instance.m_resource);
		}

		protected override void ReadComponent<T>(ES3Reader reader, object obj)
		{
			var instance = (TDTowerManager)obj;
			foreach(string propertyName in reader.Properties)
			{
				switch(propertyName)
				{
					
					case "m_child":
						instance.m_child = reader.Read<UnityEngine.GameObject>(ES3Type_GameObject.Instance);
						break;
					case "m_affinity":
						instance.m_affinity = reader.Read<affinity.Affinity>();
						break;
					case "m_base":
						instance.m_base = reader.Read<UnityEngine.GameObject>(ES3Type_GameObject.Instance);
						break;
					case "m_towerName":
						instance.m_towerName = reader.Read<System.String>(ES3Type_string.Instance);
						break;
					case "m_cost":
						instance.m_cost = reader.Read<System.Single>(ES3Type_float.Instance);
						break;
					case "m_sellCost":
						instance.m_sellCost = reader.Read<System.Single>(ES3Type_float.Instance);
						break;
					case "m_UpgradeUI":
						instance.m_UpgradeUI = reader.Read<UnityEngine.GameObject>(ES3Type_GameObject.Instance);
						break;
					case "m_TriggerRange":
						instance.m_TriggerRange = reader.Read<System.Single>(ES3Type_float.Instance);
						break;
					case "m_fireRate":
						instance.m_fireRate = reader.Read<System.Single>(ES3Type_float.Instance);
						break;
					case "m_attack":
						instance.m_attack = reader.Read<System.Single>(ES3Type_float.Instance);
						break;
					case "m_level":
						instance.m_level = reader.Read<System.Int32>(ES3Type_int.Instance);
						break;
					case "m_UGParticle":
						instance.m_UGParticle = reader.Read<UnityEngine.ParticleSystem>(ES3Type_ParticleSystem.Instance);
						break;
					case "m_BuffParticle":
						instance.m_BuffParticle = reader.Read<UnityEngine.ParticleSystem>(ES3Type_ParticleSystem.Instance);
						break;
					case "m_ShootParticle":
						instance.m_ShootParticle = reader.Read<UnityEngine.ParticleSystem>(ES3Type_ParticleSystem.Instance);
						break;
					case "m_UGDiscount":
						instance.m_UGDiscount = reader.Read<System.Single>(ES3Type_float.Instance);
						break;
					case "m_LevelDiscount":
						instance.m_LevelDiscount = reader.Read<System.Single>(ES3Type_float.Instance);
						break;
					case "m_AffinityDiscount":
						instance.m_AffinityDiscount = reader.Read<System.Single>(ES3Type_float.Instance);
						break;
					case "baseModel":
						instance.baseModel = reader.Read<UnityEngine.GameObject>(ES3Type_GameObject.Instance);
						break;
					case "Path1Model":
						instance.Path1Model = reader.Read<UnityEngine.GameObject>(ES3Type_GameObject.Instance);
						break;
					case "Path2Model":
						instance.Path2Model = reader.Read<UnityEngine.GameObject>(ES3Type_GameObject.Instance);
						break;
					case "Path3Model":
						instance.Path3Model = reader.Read<UnityEngine.GameObject>(ES3Type_GameObject.Instance);
						break;
					case "baseResource":
						instance.baseResource = reader.Read<System.String>(ES3Type_string.Instance);
						break;
					case "modelNum":
						instance.modelNum = reader.Read<System.Int32>(ES3Type_int.Instance);
						break;
					case "saved":
						instance.saved = reader.Read<System.Boolean>(ES3Type_bool.Instance);
						break;
					case "m_resource":
						instance.m_resource = reader.Read<PlayerResourceManager>();
						break;
					default:
						reader.Skip();
						break;
				}
			}
		}
	}


	public class ES3UserType_TDTowerManagerArray : ES3ArrayType
	{
		public static ES3Type Instance;

		public ES3UserType_TDTowerManagerArray() : base(typeof(TDTowerManager[]), ES3UserType_TDTowerManager.Instance)
		{
			Instance = this;
		}
	}
}