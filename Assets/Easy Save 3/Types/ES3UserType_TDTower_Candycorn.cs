using System;
using UnityEngine;

namespace ES3Types
{
	[UnityEngine.Scripting.Preserve]
	[ES3PropertiesAttribute("Path1UG3", "Path3UG1", "Path3UG2", "groupBonus", "Path3UG3", "m_baseTriggerRange", "effectiveRange", "bossPresent", "m_Trigger", "m_TriggerRange", "m_level", "m_Projectile", "m_fireRate", "m_fireRateBuff", "m_attack", "m_atkBuff", "m_aimer", "m_InRange", "m_RadiusViewer", "m_Affinity", "rotaterLookAt", "m_resource", "m_FireTimer")]
	public class ES3UserType_TDTower_Candycorn : ES3ComponentType
	{
		public static ES3Type Instance = null;

		public ES3UserType_TDTower_Candycorn() : base(typeof(TDTower_Candycorn)){ Instance = this; priority = 1;}


		protected override void WriteComponent(object obj, ES3Writer writer)
		{
			var instance = (TDTower_Candycorn)obj;
			
			writer.WriteProperty("Path1UG3", instance.Path1UG3, ES3Type_bool.Instance);
			writer.WriteProperty("Path3UG1", instance.Path3UG1, ES3Type_bool.Instance);
			writer.WriteProperty("Path3UG2", instance.Path3UG2, ES3Type_bool.Instance);
			writer.WriteProperty("groupBonus", instance.groupBonus, ES3Type_float.Instance);
			writer.WriteProperty("Path3UG3", instance.Path3UG3, ES3Type_bool.Instance);
			writer.WriteProperty("m_baseTriggerRange", instance.m_baseTriggerRange, ES3Type_float.Instance);
			writer.WriteProperty("effectiveRange", instance.effectiveRange, ES3Type_float.Instance);
			writer.WriteProperty("bossPresent", instance.bossPresent, ES3Type_bool.Instance);
			writer.WritePropertyByRef("m_Trigger", instance.m_Trigger);
			writer.WriteProperty("m_TriggerRange", instance.m_TriggerRange, ES3Type_float.Instance);
			writer.WriteProperty("m_level", instance.m_level, ES3Type_int.Instance);
			writer.WritePropertyByRef("m_Projectile", instance.m_Projectile);
			writer.WriteProperty("m_fireRate", instance.m_fireRate, ES3Type_float.Instance);
			writer.WriteProperty("m_fireRateBuff", instance.m_fireRateBuff, ES3Type_float.Instance);
			writer.WriteProperty("m_attack", instance.m_attack, ES3Type_float.Instance);
			writer.WriteProperty("m_atkBuff", instance.m_atkBuff, ES3Type_float.Instance);
			writer.WritePropertyByRef("m_aimer", instance.m_aimer);
			writer.WriteProperty("m_InRange", instance.m_InRange, ES3Type_bool.Instance);
			writer.WritePropertyByRef("m_RadiusViewer", instance.m_RadiusViewer);
			writer.WriteProperty("m_Affinity", instance.m_Affinity, ES3Type_enum.Instance);
			writer.WriteProperty("rotaterLookAt", instance.rotaterLookAt, ES3Type_Vector3.Instance);
			writer.WritePrivateFieldByRef("m_resource", instance);
			writer.WriteProperty("m_FireTimer", instance.m_FireTimer, ES3Type_float.Instance);
		}

		protected override void ReadComponent<T>(ES3Reader reader, object obj)
		{
			var instance = (TDTower_Candycorn)obj;
			foreach(string propertyName in reader.Properties)
			{
				switch(propertyName)
				{
					
					case "Path1UG3":
						instance.Path1UG3 = reader.Read<System.Boolean>(ES3Type_bool.Instance);
						break;
					case "Path3UG1":
						instance.Path3UG1 = reader.Read<System.Boolean>(ES3Type_bool.Instance);
						break;
					case "Path3UG2":
						instance.Path3UG2 = reader.Read<System.Boolean>(ES3Type_bool.Instance);
						break;
					case "groupBonus":
						instance.groupBonus = reader.Read<System.Single>(ES3Type_float.Instance);
						break;
					case "Path3UG3":
						instance.Path3UG3 = reader.Read<System.Boolean>(ES3Type_bool.Instance);
						break;
					case "m_baseTriggerRange":
						instance.m_baseTriggerRange = reader.Read<System.Single>(ES3Type_float.Instance);
						break;
					case "effectiveRange":
						instance.effectiveRange = reader.Read<System.Single>(ES3Type_float.Instance);
						break;
					case "bossPresent":
						instance.bossPresent = reader.Read<System.Boolean>(ES3Type_bool.Instance);
						break;
					case "m_Trigger":
						instance.m_Trigger = reader.Read<UnityEngine.SphereCollider>(ES3Type_SphereCollider.Instance);
						break;
					case "m_TriggerRange":
						instance.m_TriggerRange = reader.Read<System.Single>(ES3Type_float.Instance);
						break;
					case "m_level":
						instance.m_level = reader.Read<System.Int32>(ES3Type_int.Instance);
						break;
					case "m_Projectile":
						instance.m_Projectile = reader.Read<UnityEngine.GameObject>(ES3Type_GameObject.Instance);
						break;
					case "m_fireRate":
						instance.m_fireRate = reader.Read<System.Single>(ES3Type_float.Instance);
						break;
					case "m_fireRateBuff":
						instance.m_fireRateBuff = reader.Read<System.Single>(ES3Type_float.Instance);
						break;
					case "m_attack":
						instance.m_attack = reader.Read<System.Single>(ES3Type_float.Instance);
						break;
					case "m_atkBuff":
						instance.m_atkBuff = reader.Read<System.Single>(ES3Type_float.Instance);
						break;
					case "m_aimer":
						instance.m_aimer = reader.Read<UnityEngine.GameObject>(ES3Type_GameObject.Instance);
						break;
					case "m_InRange":
						instance.m_InRange = reader.Read<System.Boolean>(ES3Type_bool.Instance);
						break;
					case "m_RadiusViewer":
						instance.m_RadiusViewer = reader.Read<UnityEngine.GameObject>(ES3Type_GameObject.Instance);
						break;
					case "m_Affinity":
						instance.m_Affinity = reader.Read<affinity.Affinity>(ES3Type_enum.Instance);
						break;
					case "rotaterLookAt":
						instance.rotaterLookAt = reader.Read<UnityEngine.Vector3>(ES3Type_Vector3.Instance);
						break;
					case "m_resource":
					reader.SetPrivateField("m_resource", reader.Read<PlayerResourceManager>(), instance);
					break;
					case "m_FireTimer":
						instance.m_FireTimer = reader.Read<System.Single>(ES3Type_float.Instance);
						break;
					default:
						reader.Skip();
						break;
				}
			}
		}
	}


	public class ES3UserType_TDTower_CandycornArray : ES3ArrayType
	{
		public static ES3Type Instance;

		public ES3UserType_TDTower_CandycornArray() : base(typeof(TDTower_Candycorn[]), ES3UserType_TDTower_Candycorn.Instance)
		{
			Instance = this;
		}
	}
}