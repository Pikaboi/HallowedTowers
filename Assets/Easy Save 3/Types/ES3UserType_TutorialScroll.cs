using System;
using UnityEngine;

namespace ES3Types
{
	[UnityEngine.Scripting.Preserve]
	[ES3PropertiesAttribute("seen")]
	public class ES3UserType_TutorialScroll : ES3ComponentType
	{
		public static ES3Type Instance = null;

		public ES3UserType_TutorialScroll() : base(typeof(TutorialScroll)){ Instance = this; priority = 1;}


		protected override void WriteComponent(object obj, ES3Writer writer)
		{
			var instance = (TutorialScroll)obj;
			
			writer.WriteProperty("seen", instance.seen, ES3Type_bool.Instance);
		}

		protected override void ReadComponent<T>(ES3Reader reader, object obj)
		{
			var instance = (TutorialScroll)obj;
			foreach(string propertyName in reader.Properties)
			{
				switch(propertyName)
				{
					
					case "seen":
						instance.seen = reader.Read<System.Boolean>(ES3Type_bool.Instance);
						break;
					default:
						reader.Skip();
						break;
				}
			}
		}
	}


	public class ES3UserType_TutorialScrollArray : ES3ArrayType
	{
		public static ES3Type Instance;

		public ES3UserType_TutorialScrollArray() : base(typeof(TutorialScroll[]), ES3UserType_TutorialScroll.Instance)
		{
			Instance = this;
		}
	}
}