using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugRayExample : MonoBehaviour
{
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            Debug.DrawRay(ray.origin, ray.direction * 200, Color.white, 2.0f);
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider != null)
                {
                    Debug.Log("Hit a collider : " + hit.transform.gameObject.name);
                }
                else
                {
                    Debug.Log("Hit, but no collider?");
                }
            }
            else
            {
                Debug.Log("No hit");
            }
        }
    }
}
