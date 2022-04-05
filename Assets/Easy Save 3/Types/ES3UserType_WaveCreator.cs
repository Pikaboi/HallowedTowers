using System;
using UnityEngine;

namespace ES3Types
{
	[UnityEngine.Scripting.Preserve]
	[ES3PropertiesAttribute("m_waves", "m_currentWave", "enemies", "enemyCount", "wave", "m_destination", "maxTimer", "timer", "waveIndex", "WavePlaying", "spawnsFinshed", "m_fog", "m_travelButton", "m_unlockRound", "roundPenalty", "penaltyCount", "m_waveIcon", "m_groundWaveIcon", "DistanceMultiplier", "m_fognotif", "m_skipnotif")]
	public class ES3UserType_WaveCreator : ES3ComponentType
	{
		public static ES3Type Instance = null;

		public ES3UserType_WaveCreator() : base(typeof(WaveCreator)){ Instance = this; priority = 1;}


		protected override void WriteComponent(object obj, ES3Writer writer)
		{
			var instance = (WaveCreator)obj;
			
			writer.WriteProperty("m_waves", instance.m_waves, ES3Internal.ES3TypeMgr.GetOrCreateES3Type(typeof(WaveManager[])));
			writer.WritePrivateFieldByRef("m_currentWave", instance);
			writer.WritePrivateField("enemies", instance);
			writer.WritePrivateField("enemyCount", instance);
			writer.WritePrivateField("wave", instance);
			writer.WritePropertyByRef("m_destination", instance.m_destination);
			writer.WritePrivateField("maxTimer", instance);
			writer.WritePrivateField("timer", instance);
			writer.WriteProperty("waveIndex", instance.waveIndex, ES3Type_int.Instance);
			writer.WriteProperty("WavePlaying", instance.WavePlaying, ES3Type_bool.Instance);
			writer.WriteProperty("spawnsFinshed", instance.spawnsFinshed, ES3Type_bool.Instance);
			writer.WritePropertyByRef("m_fog", instance.m_fog);
			writer.WritePropertyByRef("m_travelButton", instance.m_travelButton);
			writer.WriteProperty("m_unlockRound", instance.m_unlockRound, ES3Type_int.Instance);
			writer.WriteProperty("roundPenalty", instance.roundPenalty, ES3Type_int.Instance);
			writer.WritePrivateField("penaltyCount", instance);
			writer.WritePropertyByRef("m_waveIcon", instance.m_waveIcon);
			writer.WritePropertyByRef("m_groundWaveIcon", instance.m_groundWaveIcon);
			writer.WriteProperty("DistanceMultiplier", instance.DistanceMultiplier, ES3Type_float.Instance);
			writer.WritePropertyByRef("m_fognotif", instance.m_fognotif);
			writer.WritePropertyByRef("m_skipnotif", instance.m_skipnotif);
		}

		protected override void ReadComponent<T>(ES3Reader reader, object obj)
		{
			var instance = (WaveCreator)obj;
			foreach(string propertyName in reader.Properties)
			{
				switch(propertyName)
				{
					
					case "m_waves":
						instance.m_waves = reader.Read<WaveManager[]>();
						break;
					case "m_currentWave":
					reader.SetPrivateField("m_currentWave", reader.Read<WaveManager>(), instance);
					break;
					case "enemies":
					reader.SetPrivateField("enemies", reader.Read<TDEnemy[]>(), instance);
					break;
					case "enemyCount":
					reader.SetPrivateField("enemyCount", reader.Read<System.Single[]>(), instance);
					break;
					case "wave":
					reader.SetPrivateField("wave", reader.Read<System.Collections.Generic.List<TDEnemy>>(), instance);
					break;
					case "m_destination":
						instance.m_destination = reader.Read<UnityEngine.Transform>(ES3Type_Transform.Instance);
						break;
					case "maxTimer":
					reader.SetPrivateField("maxTimer", reader.Read<System.Single>(), instance);
					break;
					case "timer":
					reader.SetPrivateField("timer", reader.Read<System.Single>(), instance);
					break;
					case "waveIndex":
						instance.waveIndex = reader.Read<System.Int32>(ES3Type_int.Instance);
						break;
					case "WavePlaying":
						instance.WavePlaying = reader.Read<System.Boolean>(ES3Type_bool.Instance);
						break;
					case "spawnsFinshed":
						instance.spawnsFinshed = reader.Read<System.Boolean>(ES3Type_bool.Instance);
						break;
					case "m_fog":
						instance.m_fog = reader.Read<UnityEngine.GameObject>(ES3Type_GameObject.Instance);
						break;
					case "m_travelButton":
						instance.m_travelButton = reader.Read<SkipTravel>();
						break;
					case "m_unlockRound":
						instance.m_unlockRound = reader.Read<System.Int32>(ES3Type_int.Instance);
						break;
					case "roundPenalty":
						instance.roundPenalty = reader.Read<System.Int32>(ES3Type_int.Instance);
						break;
					case "penaltyCount":
					reader.SetPrivateField("penaltyCount", reader.Read<System.Int32>(), instance);
					break;
					case "m_waveIcon":
						instance.m_waveIcon = reader.Read<WaveAffIcons>();
						break;
					case "m_groundWaveIcon":
						instance.m_groundWaveIcon = reader.Read<WaveAffIcons>();
						break;
					case "DistanceMultiplier":
						instance.DistanceMultiplier = reader.Read<System.Single>(ES3Type_float.Instance);
						break;
					case "m_fognotif":
						instance.m_fognotif = reader.Read<FogLiftNotification>();
						break;
					case "m_skipnotif":
						instance.m_skipnotif = reader.Read<FogLiftNotification>();
						break;
					default:
						reader.Skip();
						break;
				}
			}
		}
	}


	public class ES3UserType_WaveCreatorArray : ES3ArrayType
	{
		public static ES3Type Instance;

		public ES3UserType_WaveCreatorArray() : base(typeof(WaveCreator[]), ES3UserType_WaveCreator.Instance)
		{
			Instance = this;
		}
	}
}