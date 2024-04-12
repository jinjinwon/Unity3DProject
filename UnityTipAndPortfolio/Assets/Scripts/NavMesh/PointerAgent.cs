using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointerAgent : BaseAgent
{
    RaycastHit rayHit = new RaycastHit();

    void Update()
    {
        if(Input.GetMouseButtonDown(0) == true)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if(Physics.Raycast(ray.origin, ray.direction,out rayHit) == true)
            {
                Agent.destination = rayHit.point;
            }
        }
    }
}
