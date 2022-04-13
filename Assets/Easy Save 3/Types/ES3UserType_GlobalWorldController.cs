using System;
using UnityEngine;

namespace ES3Types
{
	[UnityEngine.Scripting.Preserve]
	[ES3PropertiesAttribute("waveCreators", "m_sceneControl", "RoundNum", "GameOver", "m_playButton")]
	public class ES3UserType_GlobalWorldController : ES3ComponentType
	{
		public static ES3Type Instance = null;

		public ES3UserType_GlobalWorldController() : base(typeof(GlobalWorldController)){ Instance = this; priority = 1;}


		protected override void WriteComponent(object obj, ES3Writer writer)
		{
			var instance = (GlobalWorldController)obj;
			
			writer.WriteProperty("waveCreators", instance.waveCreators, ES3UserType_WaveCreatorArray.Instance);
			writer.WritePropertyByRef("m_sceneControl", instance.m_sceneControl);
			writer.WriteProperty("RoundNum", instance.RoundNum, ES3Type_int.Instance);
			writer.WritePrivateField("GameOver", instance);
			writer.WritePrivateFieldByRef("m_playButton", instance);
		}

		protected override void ReadComponent<T>(ES3Reader reader, object obj)
		{
			var instance = (GlobalWorldController)obj;
			foreach(string propertyName in reader.Properties)
			{
				switch(propertyName)
				{
					
					case "waveCreators":
						instance.waveCreators = reader.Read<WaveCreator[]>(ES3UserType_WaveCreatorArray.Instance);
						break;
					case "m_sceneControl":
						instance.m_sceneControl = reader.Read<SceneControl>();
						break;
					case "RoundNum":
						instance.RoundNum = reader.Read<System.Int32>(ES3Type_int.Instance);
						break;
					case "GameOver":
					reader.SetPrivateField("GameOver", reader.Read<System.Boolean>(), instance);
					break;
					case "m_playButton":
					reader.SetPrivateField("m_playButton", reader.Read<RoundPlayButton>(), instance);
					break;
					default:
						reader.Skip();
						break;
				}
			}
		}
	}


	public class ES3UserType_GlobalWorldControllerArray : ES3ArrayType
	{
		public static ES3Type Instance;

		public ES3UserType_GlobalWorldControllerArray() : base(typeof(GlobalWorldController[]), ES3UserType_GlobalWorldController.Instance)
		{
			Instance = this;
		}
	}
}