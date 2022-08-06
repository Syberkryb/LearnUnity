using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public HostileAnimal SelectedAnimal = null;

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
                    if(hit.transform.GetComponent<HostileAnimal>() != null){
                        SelectedAnimal = hit.transform.GetComponent<HostileAnimal>();
                    }
                }
            }
        }else{
            SelectedAnimal = null;
        }

        if(SelectedAnimal != null){
            Vector3 input = Input.mousePosition;
            input.z = 30;
            Vector3 worldPoint = Camera.main.ScreenToWorldPoint(input);
            Vector3 dragLocation = new Vector3(worldPoint.x, SelectedAnimal.transform.position.y, worldPoint.z);
            SelectedAnimal.transform.position = dragLocation;
        }

        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            Debug.DrawRay(ray.origin, ray.direction * float.MaxValue, Color.white, 2.0f);
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
