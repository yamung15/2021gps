using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    public float playerMoveSpeed = 5f;
    private CharacterController cc;
    public float gravity = -9.8f;
    float velocity;
    public float jumpPower = 5;
    private bool isjump = false;
    // Start is called before the first frame update
    void Start()
    {
        cc = GetComponent<CharacterController>();
    }
    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        Vector3 dir = new Vector3(h, 0, v);
        dir.Normalize();
        if(cc.collisionFlags == CollisionFlags.Below)
        {
            velocity = 0;
            isjump = false;
        }
        if (!isjump && Input.GetButtonDown("Jump"))
        {
            velocity = jumpPower;
            isjump = true;
        }
        velocity += gravity * Time.deltaTime;
        dir.y = velocity;
        //dir = Camera.main.transform.TransformDirection(dir);
        cc.Move(dir * playerMoveSpeed * Time.deltaTime);
    }
}
