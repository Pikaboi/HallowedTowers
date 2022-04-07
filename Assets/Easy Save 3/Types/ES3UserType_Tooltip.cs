using System;
using UnityEngine;

namespace ES3Types
{
	[UnityEngine.Scripting.Preserve]
	[ES3PropertiesAttribute("m_button", "m_tooltip", "m_tooltipText")]
	public class ES3UserType_Tooltip : ES3ComponentType
	{
		public static ES3Type Instance = null;

		public ES3UserType_Tooltip() : base(typeof(Tooltip)){ Instance = this; priority = 1;}


		protected override void WriteComponent(object obj, ES3Writer writer)
		{
			var instance = (Tooltip)obj;
			
			writer.WritePropertyByRef("m_button", instance.m_button);
			writer.WritePropertyByRef("m_tooltip", instance.m_tooltip);
			writer.WritePrivateFieldByRef("m_tooltipText", instance);
		}

		protected override void ReadComponent<T>(ES3Reader reader, object obj)
		{
			var instance = (Tooltip)obj;
			foreach(string propertyName in reader.Properties)
			{
				switch(propertyName)
				{
					
					case "m_button":
						instance.m_button = reader.Read<UnityEngine.UI.Button>(ES3UserType_Button.Instance);
						break;
					case "m_tooltip":
						instance.m_tooltip = reader.Read<UnityEngine.UI.Image>(ES3Type_Image.Instance);
						break;
					case "m_tooltipText":
					reader.SetPrivateField("m_tooltipText", reader.Read<TMPro.TMP_Text>(), instance);
					break;
					default:
						reader.Skip();
						break;
				}
			}
		}
	}


	public class ES3UserType_TooltipArray : ES3ArrayType
	{
		public static ES3Type Instance;

		public ES3UserType_TooltipArray() : base(typeof(Tooltip[]), ES3UserType_Tooltip.Instance)
		{
			Instance = this;
		}
	}
}