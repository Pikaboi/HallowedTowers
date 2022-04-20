using System;
using UnityEngine;

namespace ES3Types
{
	[UnityEngine.Scripting.Preserve]
	[ES3PropertiesAttribute("m_OnClick", "m_Transition", "m_Colors", "m_SpriteState", "m_AnimationTriggers", "m_Interactable", "m_TargetGraphic", "onClick", "navigation", "transition", "colors", "spriteState", "animationTriggers", "targetGraphic", "interactable", "isPointerInside", "isPointerDown", "hasSelection", "image", "enabled", "name")]
	public class ES3UserType_Button : ES3ComponentType
	{
		public static ES3Type Instance = null;

		public ES3UserType_Button() : base(typeof(UnityEngine.UI.Button)){ Instance = this; priority = 1;}


		protected override void WriteComponent(object obj, ES3Writer writer)
		{
			var instance = (UnityEngine.UI.Button)obj;
			
			writer.WritePrivateField("m_OnClick", instance);
			writer.WritePrivateField("m_Transition", instance);
			writer.WritePrivateField("m_Colors", instance);
			writer.WritePrivateField("m_SpriteState", instance);
			writer.WritePrivateField("m_AnimationTriggers", instance);
			writer.WritePrivateField("m_Interactable", instance);
			writer.WritePrivateFieldByRef("m_TargetGraphic", instance);
			writer.WriteProperty("onClick", instance.onClick, ES3Internal.ES3TypeMgr.GetOrCreateES3Type(typeof(UnityEngine.UI.Button.ButtonClickedEvent)));
			writer.WriteProperty("navigation", instance.navigation, ES3Internal.ES3TypeMgr.GetOrCreateES3Type(typeof(UnityEngine.UI.Navigation)));
			writer.WriteProperty("transition", instance.transition, ES3Internal.ES3TypeMgr.GetOrCreateES3Type(typeof(UnityEngine.UI.Selectable.Transition)));
			writer.WriteProperty("colors", instance.colors, ES3Internal.ES3TypeMgr.GetOrCreateES3Type(typeof(UnityEngine.UI.ColorBlock)));
			writer.WriteProperty("spriteState", instance.spriteState, ES3Internal.ES3TypeMgr.GetOrCreateES3Type(typeof(UnityEngine.UI.SpriteState)));
			writer.WriteProperty("animationTriggers", instance.animationTriggers, ES3Internal.ES3TypeMgr.GetOrCreateES3Type(typeof(UnityEngine.UI.AnimationTriggers)));
			writer.WritePropertyByRef("targetGraphic", instance.targetGraphic);
			writer.WriteProperty("interactable", instance.interactable, ES3Type_bool.Instance);
			writer.WritePrivateProperty("isPointerInside", instance);
			writer.WritePrivateProperty("isPointerDown", instance);
			writer.WritePrivateProperty("hasSelection", instance);
			writer.WritePropertyByRef("image", instance.image);
			writer.WriteProperty("enabled", instance.enabled, ES3Type_bool.Instance);
		}

		protected override void ReadComponent<T>(ES3Reader reader, object obj)
		{
			var instance = (UnityEngine.UI.Button)obj;
			foreach(string propertyName in reader.Properties)
			{
				switch(propertyName)
				{
					
					case "m_OnClick":
					reader.SetPrivateField("m_OnClick", reader.Read<UnityEngine.UI.Button.ButtonClickedEvent>(), instance);
					break;
					case "m_Transition":
					reader.SetPrivateField("m_Transition", reader.Read<UnityEngine.UI.Selectable.Transition>(), instance);
					break;
					case "m_Colors":
					reader.SetPrivateField("m_Colors", reader.Read<UnityEngine.UI.ColorBlock>(), instance);
					break;
					case "m_SpriteState":
					reader.SetPrivateField("m_SpriteState", reader.Read<UnityEngine.UI.SpriteState>(), instance);
					break;
					case "m_AnimationTriggers":
					reader.SetPrivateField("m_AnimationTriggers", reader.Read<UnityEngine.UI.AnimationTriggers>(), instance);
					break;
					case "m_Interactable":
					reader.SetPrivateField("m_Interactable", reader.Read<System.Boolean>(), instance);
					break;
					case "m_TargetGraphic":
					reader.SetPrivateField("m_TargetGraphic", reader.Read<UnityEngine.UI.Graphic>(), instance);
					break;
					case "onClick":
						instance.onClick = reader.Read<UnityEngine.UI.Button.ButtonClickedEvent>();
						break;
					case "navigation":
						instance.navigation = reader.Read<UnityEngine.UI.Navigation>();
						break;
					case "transition":
						instance.transition = reader.Read<UnityEngine.UI.Selectable.Transition>();
						break;
					case "colors":
						instance.colors = reader.Read<UnityEngine.UI.ColorBlock>();
						break;
					case "spriteState":
						instance.spriteState = reader.Read<UnityEngine.UI.SpriteState>();
						break;
					case "animationTriggers":
						instance.animationTriggers = reader.Read<UnityEngine.UI.AnimationTriggers>();
						break;
					case "targetGraphic":
						instance.targetGraphic = reader.Read<UnityEngine.UI.Graphic>();
						break;
					case "interactable":
						instance.interactable = reader.Read<System.Boolean>(ES3Type_bool.Instance);
						break;
					case "isPointerInside":
					reader.SetPrivateProperty("isPointerInside", reader.Read<System.Boolean>(), instance);
					break;
					case "isPointerDown":
					reader.SetPrivateProperty("isPointerDown", reader.Read<System.Boolean>(), instance);
					break;
					case "hasSelection":
					reader.SetPrivateProperty("hasSelection", reader.Read<System.Boolean>(), instance);
					break;
					case "image":
						instance.image = reader.Read<UnityEngine.UI.Image>(ES3Type_Image.Instance);
						break;
					case "enabled":
						instance.enabled = reader.Read<System.Boolean>(ES3Type_bool.Instance);
						break;
					default:
						reader.Skip();
						break;
				}
			}
		}
	}


	public class ES3UserType_ButtonArray : ES3ArrayType
	{
		public static ES3Type Instance;

		public ES3UserType_ButtonArray() : base(typeof(UnityEngine.UI.Button[]), ES3UserType_Button.Instance)
		{
			Instance = this;
		}
	}
}