using System;
using UnityEngine;

namespace ES3Types
{
	[UnityEngine.Scripting.Preserve]
	[ES3PropertiesAttribute()]
	public class ES3UserType_LineRenderer : ES3ComponentType
	{
		public static ES3Type Instance = null;

		public ES3UserType_LineRenderer() : base(typeof(UnityEngine.LineRenderer)){ Instance = this; priority = 1;}


		protected override void WriteComponent(object obj, ES3Writer writer)
		{
			var instance = (UnityEngine.LineRenderer)obj;
			
		}

		protected override void ReadComponent<T>(ES3Reader reader, object obj)
		{
			var instance = (UnityEngine.LineRenderer)obj;
			foreach(string propertyName in reader.Properties)
			{
				switch(propertyName)
				{
					
					default:
						reader.Skip();
						break;
				}
			}
		}
	}


	public class ES3UserType_LineRendererArray : ES3ArrayType
	{
		public static ES3Type Instance;

		public ES3UserType_LineRendererArray() : base(typeof(UnityEngine.LineRenderer[]), ES3UserType_LineRenderer.Instance)
		{
			Instance = this;
		}
	}
}