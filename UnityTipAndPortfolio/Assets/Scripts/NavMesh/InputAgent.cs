using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputAgent : BaseAgent
{
    private Transform cam;
    private Vector2 inputVec; 

    void Start()
    {
        cam = Camera.main.transform;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 dirVec = cam.right * inputVec.x + cam.forward * inputVec.y;
        Agent.SetDestination(transform.position + dirVec.normalized);
    }

    void OnMove(InputValue value)
    {
        inputVec = value.Get<Vector2>();
    }
}
