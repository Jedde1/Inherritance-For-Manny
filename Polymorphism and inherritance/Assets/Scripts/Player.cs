using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Humanoid
{
    public int walkSpeed;//Determines the movement speed for both the player
    private Vector3 _moveDir;//Allows movement on all axis
    private CharacterController _charC;//Allows the character to move
    // Start is called before the first frame update
    void Start()
    {
        _charC = GetComponent<CharacterController>();//Looks for a charactercontroller component on the player
    }

    // Update is called once per frame
    public override void Update()
    {
        Move();  //Overides the Humanoid script
    }
    private void Move()
    {
        speed = walkSpeed;//Takes the speed set in humanoid script to determine move speed
        _moveDir = transform.TransformDirection(new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")) * speed);//Uses inputs determined in engine setttings as the movement keys
        //Apply Gravity
        _moveDir.y -= _gravity * Time.deltaTime;
        //apply Movement
        _charC.Move(_moveDir * Time.deltaTime);
    }
}
