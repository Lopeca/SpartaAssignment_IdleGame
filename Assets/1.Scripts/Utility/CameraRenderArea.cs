using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteAlways]
[RequireComponent(typeof(Camera))]
public class CameraRenderArea : MonoBehaviour
{
    [Range(0, 1)] public float widthRatio = 0.7f;
    private Camera cam;

    private void Awake()
    {
        cam = GetComponent<Camera>();
        ApplyRect();
    }
#if UNITY_EDITOR
    private void OnValidate()
    {
        ApplyRect();
    }
#endif
    private void ApplyRect()
    {
        if(cam)
            cam.rect = new Rect(0, 0, widthRatio, cam.rect.height);
    }
}
