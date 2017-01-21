using UnityEngine;
using UnityEditor;
using PropertyAttributes;

namespace PropertyDrawers
{
	[CustomPropertyDrawer(typeof(ReadOnlyAttribute))]
	public class ReadOnlyDrawer : PropertyDrawer {
		public override void OnGUI(Rect position, SerializedProperty prop, GUIContent label) {
			GUI.enabled = false;
			EditorGUI.PropertyField (position, prop, label, true);
			GUI.enabled = true;
		}
	}
}