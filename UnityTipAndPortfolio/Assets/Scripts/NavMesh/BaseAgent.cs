using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BaseAgent : MonoBehaviour
{
    [HideInInspector] protected NavMeshAgent Agent;
    
    public void Awake()
    {
        this.Agent = GetComponent<NavMeshAgent>();
    }
}
