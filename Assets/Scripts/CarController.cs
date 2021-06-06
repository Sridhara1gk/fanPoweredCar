using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    float startTime = 0;
    Rigidbody hitObject = null;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void Update()
    {

        updateRayCast();

    }
    // Update is called once per frame
    void updateRayCast()
    {
        if (Input.GetMouseButtonDown(0) && hitObject == null)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform.gameObject.GetComponent<Rigidbody>() != null && hit.transform.gameObject.name != "Switch")
                {
                    startTime = Time.time;
                    hitObject = hit.transform.gameObject.GetComponent<Rigidbody>();
                    Debug.Log("rigid body: " + hit.transform.name);
                }
                else
                {
                    Debug.Log("it is not rigid body: " + hit.transform.name);
                }
            }
        }
        if (Input.GetMouseButtonUp(0))
        {
            if (hitObject != null )
            {
                float magitude = Time.time - startTime;
                Vector3 dir = Camera.main.transform.forward;
                hitObject.AddForce(dir * magitude * 50, ForceMode.Impulse);
                Debug.Log("rigid body: " + hitObject.transform.name + ":" + (dir * magitude * 1000));
                startTime = 0;
                hitObject = null;
            }
        }
    }

   

}
