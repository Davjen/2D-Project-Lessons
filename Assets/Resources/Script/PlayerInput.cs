using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public float Speed;
    public Transform moveTargetPoint;
    public bool IsMoving,IsFalling;
    public LayerMask collisions;

    Rigidbody2D rb;
    Vector2 direction;

    // Start is called before the first frame update
    void Start()
    {
        moveTargetPoint.parent = null;
        rb = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {

        transform.position = Vector3.MoveTowards(transform.position, moveTargetPoint.position, Speed * Time.deltaTime);

        if (Vector3.Distance(transform.position, moveTargetPoint.position) <= 0.05f)
        {
            IsMoving = false;
            if (Mathf.Abs(Input.GetAxisRaw("Horizontal")) == 1)
            {
                //move the move point
                if (!CollisionCheck(Input.GetAxisRaw("Horizontal"), true))
                {
                    moveTargetPoint.position += new Vector3(Input.GetAxisRaw("Horizontal"), 0, 0);
                    IsMoving = true;
                    
                }
            }
            else if (Mathf.Abs(Input.GetAxisRaw("Vertical")) == 1)
            {
                if (!CollisionCheck(Input.GetAxisRaw("Vertical"),false))
                {
                    moveTargetPoint.position += new Vector3(0, Input.GetAxisRaw("Vertical"), 0);
                    IsMoving = true;
                }
            }
        }
    }

    private Collider2D CollisionCheck(float direction, bool horizontal)
    {
        if (horizontal)
            return Physics2D.OverlapCircle(moveTargetPoint.position + new Vector3(direction, 0, 0), .2f, collisions);
        else
            return Physics2D.OverlapCircle(moveTargetPoint.position + new Vector3(0, direction), .2f, collisions);
    }



}
