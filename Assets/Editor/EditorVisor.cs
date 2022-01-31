using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
namespace SOHNE.Accessibility.Colorblindness
{
    [CustomEditor(typeof(CambiarModo))]
    public class EditorVisor : Editor
    {
		public override void OnInspectorGUI()
		{
			base.OnInspectorGUI();
			if (GUILayout.Button("Cambiar"))
			{
				CambiarModo cmd = (CambiarModo)target;
				cmd.Cambiar();
			}
		}
	} 
}
