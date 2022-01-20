using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerup_Boost : MonoBehaviour
{

    [SerializeField] private float _boostMultiplier = 15;
    [SerializeField] private float powerupDuration = 2f;

    private void OnTriggerEnter(Collider other) //Check collision with player.
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine(Pickup(other));
        }
    }

    IEnumerator Pickup(Collider player)
    {
        //Play effect when power up pickedup with Instantiate here ! 

        Player _player = player.GetComponent<Player>(); //Get player script
        _player.speed *= _boostMultiplier; //get player speed and multiple 

        //Set enable false for unexpected collision after powerup pickeup
        GetComponent<MeshRenderer>().enabled = false;
        GetComponent<Collider>().enabled = false;

        yield return new WaitForSeconds(powerupDuration); //Powerup duration
        _player.speed /= _boostMultiplier; //Reverse powerup effect

        Destroy(gameObject);
    }
}
