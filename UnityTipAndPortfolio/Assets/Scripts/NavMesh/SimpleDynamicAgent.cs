using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleDynamicAgent : BaseAgent
{
    [SerializeField] Transform target;

    private void Update()
    {
        Agent.SetDestination(target.position);
    }
}
