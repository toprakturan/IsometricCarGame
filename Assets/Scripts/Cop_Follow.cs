using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Cop_Follow : MonoBehaviour
{

    //[SerializeField] public Transform target;
    NavMeshAgent nav;
    Player player;

    void Start()
    {
        nav = GetComponent<NavMeshAgent>();
        player = GameObject.FindObjectOfType<Player>();
    }

   
    void Update()
    {
        nav.SetDestination(player.transform.position);
    }
}
