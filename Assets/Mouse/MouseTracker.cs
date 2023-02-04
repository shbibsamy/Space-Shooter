using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseTracker : MonoBehaviour
{
    private void Start() {
        Cursor.visible = false;
    }
    void Update()
    {
        Vector3 mouseWorldPosition = Camera.main.ScreenToWorldPoint (Input.mousePosition);
        mouseWorldPosition.z = 1f;
        transform.position = mouseWorldPosition;
    }
}
