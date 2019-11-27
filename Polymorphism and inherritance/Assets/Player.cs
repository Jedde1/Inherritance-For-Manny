using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Humanoid
{
    public int walkSpeed;
    private Vector3 _moveDir;
    private CharacterController _charC;
    // Start is called before the first frame update
    void Start()
    {
        _charC = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    public override void Update()
    {
        Move();  
    }
    private void Move()
    {
        speed = walkSpeed;
        _moveDir = transform.TransformDirection(new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")) * speed);
        //Apply Gravity
        _moveDir.y -= _gravity * Time.deltaTime;
        //apply Movement
        _charC.Move(_moveDir * Time.deltaTime);
    }
}
