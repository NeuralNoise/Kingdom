using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class Movable : MonoBehaviour, IMovable
{
    #region Properties
    NavMeshAgent m_navMeshAgent;
    #endregion

    #region Public Methods
    public void Move(Vector3 destination)
    {
        m_navMeshAgent.SetDestination(destination);
    }
    #endregion

    #region Private Methods
    void Awake()
    {
        m_navMeshAgent = GetComponent<NavMeshAgent>();
        if(m_navMeshAgent == null)
        {
            Debug.LogWarning("Movable on " + name + " can't find the NavMeshAgent component");
        }
    }
    #endregion
}
