using System.Diagnostics;
using System;
using System.Windows.Forms;
using System.Collections;
using System.Drawing;
using Microsoft.VisualBasic;
using System.Data;
using System.Collections.Generic;
using System.Threading;

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:2.0.50727.42
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------



namespace SoftwareLock_KeyGen
{
	namespace My
	{
		
		[System.Runtime.CompilerServices.CompilerGeneratedAttribute(), System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "8.0.0.0"), System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]internal sealed partial class MySettings : System.Configuration.ApplicationSettingsBase
		{
			
			
			private static MySettings defaultInstance = (MySettings) global::System.Configuration.ApplicationSettingsBase.Synchronized(new MySettings());
			
			#region "My.Settings Auto-Save Functionality"
			#if _MyType
			private static bool addedHandler;
			
			private static object addedHandlerLockObject = new object();
			
			[System.Diagnostics.DebuggerNonUserCodeAttribute(), System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]private static void AutoSaveSettings(System.Object sender, System.EventArgs e)
			{
				if ((new Microsoft.VisualBasic.ApplicationServices.WindowsFormsApplicationBase()).SaveMySettingsOnExit)
				{
					Settings.Default.Save();
				}
			}
			#endif
			#endregion
			
			public static MySettings @Default
			{
				get
				{
					
					#if _MyType
					if (! addedHandler)
					{
						object synclockObject = addedHandlerLockObject;
						Monitor.Enter(synclockObject);
						try
						{
							if (! addedHandler)
							{
								(new Microsoft.VisualBasic.ApplicationServices.WindowsFormsApplicationBase).Shutdown += new System.EventHandler(AutoSaveSettings);
								addedHandler = true;
							}
						}
						finally
						{
							Monitor.Exit(synclockObject);
						}
					}
					#endif
					return defaultInstance;
				}
			}
		}
	}
	
	namespace My
	{
		
		[Microsoft.VisualBasic.HideModuleNameAttribute(), System.Diagnostics.DebuggerNonUserCodeAttribute(), System.Runtime.CompilerServices.CompilerGeneratedAttribute()]internal sealed class MySettingsProperty
		{
			
			[global::System.ComponentModel.Design.HelpKeywordAttribute("My.Settings")]internal static SoftwareLock_KeyGen.My.MySettings Settings
			{
				get
				{
					return global::SoftwareLock_KeyGen.My.MySettings.Default;
				}
			}
		}
	}
	
}