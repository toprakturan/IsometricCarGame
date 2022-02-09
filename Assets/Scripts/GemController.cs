using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GemController : MonoBehaviour
{

    Player player;
    private float magnetSpeed = 50f;
    private void Awake()
    {
        player = FindObjectOfType<Player>();
    }

    //Collision check with gem - player and magnet gem to player. (Check out GemCollect script to understand all system)
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            transform.position = Vector3.MoveTowards(transform.position, other.transform.position, magnetSpeed * Time.deltaTime);
        }
    }
}
