using System;
using UnityEngine;

namespace ES3Types
{
	[UnityEngine.Scripting.Preserve]
	[ES3PropertiesAttribute("m_webPlacement", "m_sentry", "sentryResource", "m_sentryTime", "m_sentryTimer", "m_sentryPos", "sentryTotal", "m_sentries", "Path3UG3", "m_Trigger", "m_TriggerRange", "m_level", "m_Projectile", "m_fireRate", "m_fireRateBuff", "m_attack", "m_atkBuff", "m_aimer", "m_InRange", "m_RadiusViewer", "m_Affinity", "rotaterLookAt", "m_resource", "m_FireTimer", "resourceString")]
	public class ES3UserType_TDTower_SpiderWeb : ES3ComponentType
	{
		public static ES3Type Instance = null;

		public ES3UserType_TDTower_SpiderWeb() : base(typeof(TDTower_SpiderWeb)){ Instance = this; priority = 1;}


		protected override void WriteComponent(object obj, ES3Writer writer)
		{
			var instance = (TDTower_SpiderWeb)obj;
			
			writer.WriteProperty("m_webPlacement", instance.m_webPlacement, ES3Type_Vector3.Instance);
			writer.WritePropertyByRef("m_sentry", instance.m_sentry);
			writer.WriteProperty("sentryResource", instance.sentryResource, ES3Type_string.Instance);
			writer.WriteProperty("m_sentryTime", instance.m_sentryTime, ES3Type_float.Instance);
			writer.WriteProperty("m_sentryTimer", instance.m_sentryTimer, ES3Type_float.Instance);
			writer.WriteProperty("m_sentryPos", instance.m_sentryPos, ES3Type_Vector3.Instance);
			writer.WriteProperty("sentryTotal", instance.sentryTotal, ES3Type_int.Instance);
			writer.WriteProperty("m_sentries", instance.m_sentries, ES3Internal.ES3TypeMgr.GetOrCreateES3Type(typeof(System.Collections.Generic.List<UnityEngine.GameObject>)));
			writer.WriteProperty("Path3UG3", instance.Path3UG3, ES3Type_bool.Instance);
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
			writer.WriteProperty("m_Affinity", instance.m_Affinity, ES3Internal.ES3TypeMgr.GetOrCreateES3Type(typeof(affinity.Affinity)));
			writer.WriteProperty("rotaterLookAt", instance.rotaterLookAt, ES3Type_Vector3.Instance);
			writer.WritePrivateFieldByRef("m_resource", instance);
			writer.WriteProperty("m_FireTimer", instance.m_FireTimer, ES3Type_float.Instance);
			writer.WriteProperty("resourceString", instance.resourceString, ES3Type_string.Instance);
		}

		protected override void ReadComponent<T>(ES3Reader reader, object obj)
		{
			var instance = (TDTower_SpiderWeb)obj;
			foreach(string propertyName in reader.Properties)
			{
				switch(propertyName)
				{
					
					case "m_webPlacement":
						instance.m_webPlacement = reader.Read<UnityEngine.Vector3>(ES3Type_Vector3.Instance);
						break;
					case "m_sentry":
						instance.m_sentry = reader.Read<UnityEngine.GameObject>(ES3Type_GameObject.Instance);
						break;
					case "sentryResource":
						instance.sentryResource = reader.Read<System.String>(ES3Type_string.Instance);
						break;
					case "m_sentryTime":
						instance.m_sentryTime = reader.Read<System.Single>(ES3Type_float.Instance);
						break;
					case "m_sentryTimer":
						instance.m_sentryTimer = reader.Read<System.Single>(ES3Type_float.Instance);
						break;
					case "m_sentryPos":
						instance.m_sentryPos = reader.Read<UnityEngine.Vector3>(ES3Type_Vector3.Instance);
						break;
					case "sentryTotal":
						instance.sentryTotal = reader.Read<System.Int32>(ES3Type_int.Instance);
						break;
					case "m_sentries":
						instance.m_sentries = reader.Read<System.Collections.Generic.List<UnityEngine.GameObject>>();
						break;
					case "Path3UG3":
						instance.Path3UG3 = reader.Read<System.Boolean>(ES3Type_bool.Instance);
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
						instance.m_Affinity = reader.Read<affinity.Affinity>();
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
					case "resourceString":
						instance.resourceString = reader.Read<System.String>(ES3Type_string.Instance);
						break;
					default:
						reader.Skip();
						break;
				}
			}
		}
	}


	public class ES3UserType_TDTower_SpiderWebArray : ES3ArrayType
	{
		public static ES3Type Instance;

		public ES3UserType_TDTower_SpiderWebArray() : base(typeof(TDTower_SpiderWeb[]), ES3UserType_TDTower_SpiderWeb.Instance)
		{
			Instance = this;
		}
	}
}