using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Vector3 _input;
    [SerializeField] private Rigidbody _rb;
    [SerializeField] public float speed = 15f; //Main speed 
    [SerializeField] private float _turnSpeed = 360f;
    [SerializeField] public GameObject mainCamPivot;
    [SerializeField] public float speedDecreaseMultiplier;
    [SerializeField] public float speedIncreaseMultiplier;

    public bool isKeyPressed;
    private bool isSpeedFull;
    public bool isGameOver = false;
    

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        PlayerRotation();
        

    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Obsticle")
        {
            isGameOver = true;
        }
    }

    private void FixedUpdate()
    {
        mainCamPivot.transform.position = gameObject.transform.position; //Camera poisition fixing to player object position.
        Move();

    }

    void Move() //Player move with rigidbody component.
    {
        _rb.MovePosition(transform.position + transform.forward * speed * Time.deltaTime); 
    }

    void PlayerRotation() //Player rotation also speed adjustment when rotate the car.
    {
        //Get "D" key to turn right and adjust speed  
        if (Input.GetKey(KeyCode.D))
        {
            isKeyPressed = true;
            transform.Rotate(Vector3.up * Time.deltaTime * _turnSpeed);
            DecreaseSpeed();

        }
        else
        {
            if (Input.GetKeyUp(KeyCode.D))
            {
                isKeyPressed = false;
            }
        }

        //Increase speed if "A-D" is not pressing.
        if(isKeyPressed == false)
        {
            IncreaseSpeed();
        }

        //Get "A" Key to turn left and adjust speed 
        if (Input.GetKey(KeyCode.A))
        {
            isKeyPressed = true;
            transform.Rotate(-Vector3.up * Time.deltaTime * _turnSpeed);
            DecreaseSpeed();
        }
        else
        {
            //Check "A" key is not pressing 
            if (Input.GetKeyUp(KeyCode.A))
            {
                isKeyPressed = false;
            }
        }

    }

    void DecreaseSpeed() //Decrease speed with time.
    {
        speed -= speedDecreaseMultiplier * Time.deltaTime;
    }

    void IncreaseSpeed() //Increase speed 
    {
        checkSpeed();
        if (isSpeedFull == false)
        {
            speed += speedIncreaseMultiplier * Time.deltaTime;
        }
        
       
    }

    void checkSpeed() //Check speed is max or not
    {
        if(speed >= 15f)
        {
            isSpeedFull = true;
        }else
        {
            isSpeedFull = false;
        }
    }
}
