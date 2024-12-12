using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class player1Movement : MonoBehaviour
{
    private CharacterAnimations player_anim;
    private Rigidbody mainBody;
    public float walk_speed = 3f;
    public float z_speed = 1.5f;

    public float rotation_y = -90;
    public float rotation_speed = 15f;
    // Start is called before the first frame update
    void Awake()
    {
        mainBody = GetComponent<Rigidbody>();
        player_anim = GetComponentInChildren<CharacterAnimations>();
    }

    // Update is called once per frame
    void Update()
    {
        RotatePlayer();
        AnimatePlayerWalk();
    }
    void FixedUpdate() {
        DetectMovement();
    }

    void DetectMovement() {
        mainBody.velocity = new Vector3
        (Input.GetAxisRaw(Axis.HORIZONTAL_AXIS) * (-walk_speed),
        mainBody.velocity.y, 
        Input.GetAxisRaw(Axis.VERTICAL_AXIS) * (-z_speed));
    }
    void RotatePlayer() {
        if(Input.GetAxisRaw(Axis.HORIZONTAL_AXIS) > 0){
            transform.rotation = Quaternion.Euler(0f, -Mathf.Abs(rotation_y), 0f);
        } else if(Input.GetAxisRaw(Axis.HORIZONTAL_AXIS) < 0) {
            transform.rotation = Quaternion.Euler(0f, Mathf.Abs(rotation_y), 0f);
        }
    }
    void AnimatePlayerWalk()
    {
        if (Input.GetAxisRaw(Axis.HORIZONTAL_AXIS) != 0 || Input.GetAxisRaw(Axis.VERTICAL_AXIS) != 0)
        {
            player_anim.Walk(true);
        }
        else
        {
            player_anim.Walk(false);
        }
    }
}
