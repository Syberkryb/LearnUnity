using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeRayExample : MonoBehaviour
{
    public bool IsSelected = false;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider != null)
                {
                    IsSelected = true;
                }
            }
        }else{
            IsSelected = false;
        }

        if(IsSelected){
            GetComponent<Renderer>().sharedMaterial.color = Color.red;
            Vector3 input = Input.mousePosition;
            
            Vector3 worldPoint = Camera.main.ScreenToWorldPoint(input);
            Vector3 dragLocation = new Vector3(worldPoint.x, transform.position.y, worldPoint.z);
            transform.position = dragLocation;
        }else{
            GetComponent<Renderer>().sharedMaterial.color = Color.green;
        }
    }
}
