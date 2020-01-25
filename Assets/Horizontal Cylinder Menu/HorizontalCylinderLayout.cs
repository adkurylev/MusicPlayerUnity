using System.Collections;
using System.Collections.Generic;
using MusicPlayer;
using UnityEngine;

public class HorizontalCylinderLayout : MonoBehaviour
{
    [Header("Menu Item")]
    [SerializeField]
    protected GameObject menuItemPrefab;
    [SerializeField, Range(0f, 1f)]
    protected float scaleFactor = 1f;
    [SerializeField, Tooltip("This value is used when the component fails to determine the vertical size of a menu item prefab or when the checkbox above is unchecked")]
    protected float height = 0f;

    [Header("Layout")]
    [SerializeField]
    protected float cylinderRadius = 1f;
    [SerializeField, Tooltip("Angular offset from the horizon line. It determines where the first element is placed [In degrees]")]
    protected float startFromAngle = 0f;
    [SerializeField, Tooltip("Margin between two consecutive menu times [In degrees]")]
    protected float angularMargin = 0f;

    [Header("Data Provider")]
    [SerializeField]
    protected uint repeat = 10; // TODO: Remove! For testing purposes only

    protected virtual void OnEnable()
    {
        if (menuItemPrefab == null)
        {
            Debug.LogError("HorizontalCylinderLayout: The 'Prefab' field cannot be left unassigned. Disabling the script");
            enabled = false;
            return;
        }

        if (scaleFactor <= 0f)
        {
            Debug.LogError("HorizontalCylinderLayout: The 'ScaleFactor' field has to be greater than zero. Disabling the script");
            enabled = false;
            return;
        }

        InstantiateMenuItems();
    }

    protected virtual void InstantiateMenuItems()
    {
        Vector3 menuItemLocalPosition = Quaternion.Euler(startFromAngle, 0f, 0f) * Vector3.forward * cylinderRadius;
        Quaternion pitchRotation = Quaternion.Euler(DealingWithAngles.CalcAngularSize(height, cylinderRadius) + angularMargin, 0f, 0f);
    }
}
