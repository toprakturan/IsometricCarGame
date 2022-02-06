using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerup_Speed : MonoBehaviour
{
    [SerializeField] private float _speedMultiplier = 2;
    [SerializeField] private float powerupDuration = 3f;
    [SerializeField] ParticleSystem speedPowerupLeft;
    [SerializeField] ParticleSystem speedPowerupRight;

    private void Start()
    {
        speedPowerupLeft.Stop();
        speedPowerupRight.Stop();
    }

    private void OnTriggerEnter(Collider other) //Check collision with player.
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine(Pickup(other));
        }
    }

    IEnumerator Pickup(Collider player)
    {
        //Play effect when power up pickedup with Instantiate
        speedPowerupLeft.Play();
        speedPowerupRight.Play();

        Player _player = player.GetComponent<Player>(); //Get player script
        _player.speed *= _speedMultiplier; //get player speed and multiple 

        //Set enable false for unexpected collision after powerup pickeup
        GetComponent<MeshRenderer>().enabled = false;
        GetComponent<Collider>().enabled = false;

        yield return new WaitForSeconds(powerupDuration); //Powerup duration
        speedPowerupLeft.Stop();
        speedPowerupRight.Stop();
        _player.speed /= _speedMultiplier; //Reverse powerup effect

        Destroy(gameObject); 
    }
}
