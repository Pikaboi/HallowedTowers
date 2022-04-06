using System;
using UnityEngine;

namespace ES3Types
{
	[UnityEngine.Scripting.Preserve]
	[ES3PropertiesAttribute("m_Attack", "m_atkBuff", "isMelee", "Bullet", "m_BulletRange", "m_Affinity", "m_audioClip", "m_particle", "shootpos", "m_Critical", "m_boxCollider")]
	public class ES3UserType_PlayerWeapon : ES3ComponentType
	{
		public static ES3Type Instance = null;

		public ES3UserType_PlayerWeapon() : base(typeof(PlayerWeapon)){ Instance = this; priority = 1;}


		protected override void WriteComponent(object obj, ES3Writer writer)
		{
			var instance = (PlayerWeapon)obj;
			
			writer.WriteProperty("m_Attack", instance.m_Attack, ES3Type_float.Instance);
			writer.WriteProperty("m_atkBuff", instance.m_atkBuff, ES3Type_float.Instance);
			writer.WriteProperty("isMelee", instance.isMelee, ES3Type_bool.Instance);
			writer.WritePropertyByRef("Bullet", instance.Bullet);
			writer.WriteProperty("m_BulletRange", instance.m_BulletRange, ES3Type_float.Instance);
			writer.WriteProperty("m_Affinity", instance.m_Affinity, ES3Internal.ES3TypeMgr.GetOrCreateES3Type(typeof(affinity.Affinity)));
			writer.WritePropertyByRef("m_audioClip", instance.m_audioClip);
			writer.WritePropertyByRef("m_particle", instance.m_particle);
			writer.WritePropertyByRef("shootpos", instance.shootpos);
			writer.WriteProperty("m_Critical", instance.m_Critical, ES3Type_bool.Instance);
			writer.WritePropertyByRef("m_boxCollider", instance.m_boxCollider);
		}

		protected override void ReadComponent<T>(ES3Reader reader, object obj)
		{
			var instance = (PlayerWeapon)obj;
			foreach(string propertyName in reader.Properties)
			{
				switch(propertyName)
				{
					
					case "m_Attack":
						instance.m_Attack = reader.Read<System.Single>(ES3Type_float.Instance);
						break;
					case "m_atkBuff":
						instance.m_atkBuff = reader.Read<System.Single>(ES3Type_float.Instance);
						break;
					case "isMelee":
						instance.isMelee = reader.Read<System.Boolean>(ES3Type_bool.Instance);
						break;
					case "Bullet":
						instance.Bullet = reader.Read<UnityEngine.GameObject>(ES3Type_GameObject.Instance);
						break;
					case "m_BulletRange":
						instance.m_BulletRange = reader.Read<System.Single>(ES3Type_float.Instance);
						break;
					case "m_Affinity":
						instance.m_Affinity = reader.Read<affinity.Affinity>();
						break;
					case "m_audioClip":
						instance.m_audioClip = reader.Read<UnityEngine.AudioClip>(ES3Type_AudioClip.Instance);
						break;
					case "m_particle":
						instance.m_particle = reader.Read<UnityEngine.ParticleSystem>(ES3Type_ParticleSystem.Instance);
						break;
					case "shootpos":
						instance.shootpos = reader.Read<UnityEngine.Transform>(ES3Type_Transform.Instance);
						break;
					case "m_Critical":
						instance.m_Critical = reader.Read<System.Boolean>(ES3Type_bool.Instance);
						break;
					case "m_boxCollider":
						instance.m_boxCollider = reader.Read<UnityEngine.BoxCollider>(ES3Type_BoxCollider.Instance);
						break;
					default:
						reader.Skip();
						break;
				}
			}
		}
	}


	public class ES3UserType_PlayerWeaponArray : ES3ArrayType
	{
		public static ES3Type Instance;

		public ES3UserType_PlayerWeaponArray() : base(typeof(PlayerWeapon[]), ES3UserType_PlayerWeapon.Instance)
		{
			Instance = this;
		}
	}
}