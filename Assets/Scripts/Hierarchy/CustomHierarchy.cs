using UnityEngine;
using UnityEditor;

public class CustomHierarchy : MonoBehaviour
{
    private static Vector2 offset = new Vector2(0, 2);
    static CustomHierarchy()
    {
        EditorApplication.hierarchyWindowItemOnGUI += HandleHierarchyWindowItemOnGUI;
    }

    private static void HandleHierarchyWindowItemOnGUI(int instanceID, Rect selectionRect)
    {
        Color textColor = Color.white;
        Color background = Color.black;

        var obj = EditorUtility.InstanceIDToObject(instanceID);
        if(obj != null && obj.name.Contains("//"))
        {
            Rect offsetRect = new Rect(selectionRect.position + offset, selectionRect.size);
            EditorGUI.DrawRect(selectionRect, background);
            EditorGUI.LabelField(offsetRect, obj.name, new GUIStyle()
            {
                normal = new GUIStyleState() { textColor = textColor },
                fontStyle = FontStyle.Bold
            }
            );
        }
    }
}
