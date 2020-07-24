using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class ConvertToRelativePosition : MonoBehaviour {

    private const string menuPath = "Tools/UI/";

    // Convert a UI element's pixel offsets into anchor-relative position values.
    [MenuItem(menuPath + "Convert to Relative Position")]
    static void Convert() {

        RectTransform rt = Selection.activeTransform.GetComponent<RectTransform>();
        RectTransform parentRt = Selection.activeTransform.parent.GetComponent<RectTransform>();
        Vector2 anchorMin = rt.anchorMin;
        Vector2 anchorMax = rt.anchorMax;
        Vector2 offsetMin = rt.offsetMin;
        Vector2 offsetMax = rt.offsetMax;
        Rect rect = parentRt.rect;

        // Left
        anchorMin.x += (offsetMin.x / rect.width);
        offsetMin.x = 0.0f;

        // Right
        anchorMax.x += (offsetMax.x / rect.width);
        offsetMax.x = 0.0f;

        // Top
        anchorMax.y += (offsetMax.y / rect.height);
        offsetMax.y = 0.0f;

        // Bottom
        anchorMin.y += (offsetMin.y / rect.height);
        offsetMin.y = 0.0f;

        // Set the values.
        rt.anchorMin = anchorMin;
        rt.anchorMax = anchorMax;
        rt.offsetMin = offsetMin;
        rt.offsetMax = offsetMax;

    }

    // Validate the menu item, so that it will be deactivated if the user doesn't have
    // an appropriate UI element selected.
    [MenuItem(menuPath + "Convert to Relative Position", true)]
    static bool ValidateConvert() {
        return ValidateMenuItems();
    }

    // Convert a UI element's anchor-relative position values into pixel offsets.
    [MenuItem(menuPath + "Convert to Absolute Position")]
    static void Reverse() {

        RectTransform rt = Selection.activeTransform.GetComponent<RectTransform>();
        RectTransform parentRt = Selection.activeTransform.parent.GetComponent<RectTransform>();
        Vector2 anchorMin = rt.anchorMin;
        Vector2 anchorMax = rt.anchorMax;
        Vector2 offsetMin = rt.offsetMin;
        Vector2 offsetMax = rt.offsetMax;
        Rect rect = parentRt.rect;

        // Left
        offsetMin.x += (anchorMin.x * rect.width);
        anchorMin.x = 0.0f;

        // Right
        offsetMax.x += (anchorMax.x * rect.width);
        anchorMax.x = 0.0f;

        // Top
        offsetMax.y += (anchorMax.y * rect.height);
        anchorMax.y = 0.0f;

        // Bottom
        offsetMin.y += (anchorMin.y * rect.height);
        anchorMin.y = 0.0f;

        // Set the values.
        rt.anchorMin = anchorMin;
        rt.anchorMax = anchorMax;
        rt.offsetMin = offsetMin;
        rt.offsetMax = offsetMax;

    }

    // Validate the menu item, so that it will be deactivated if the user doesn't have
    // an appropriate UI element selected.
    [MenuItem(menuPath + "Convert to Absolute Position", true)]
    static bool ValidateReverse() {
        return ValidateMenuItems();
    }

    // These conversion functions require a RectTransform with a RectTransform parent.
    static bool ValidateMenuItems() {

        if (Selection.activeTransform != null) {
            if (Selection.activeTransform.GetComponent<RectTransform>() != null) {
                if (Selection.activeTransform.parent.GetComponent<RectTransform>() != null) {
                    return true;
                }
            }
        }

        return false;

    }

}
