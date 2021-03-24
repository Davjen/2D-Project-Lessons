using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public float Speed;
    public Transform moveTargetPoint;
    public bool IsMoving, IsFalling;
    public LayerMask collisions;
    public LayerMask movableObjs;

    SpriteRenderer sr;

    Vector2 direction;
    bool playFallingAnimation;
    public bool isMinimized;


    // Start is called before the first frame update
    private void OnEnable()
    {
        EventManager.current.onFalling += PlayFallingAnimation;
    }

    private void OnDisable()
    {
        EventManager.current.onFalling -= PlayFallingAnimation;
    }
    void Start()
    {
        moveTargetPoint.parent = null;
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {

        transform.position = Vector3.MoveTowards(transform.position, moveTargetPoint.position, Speed * Time.deltaTime);

        if (Vector3.Distance(transform.position, moveTargetPoint.position) <= 0.005f)
        {

            if (Mathf.Abs(Input.GetAxisRaw("Horizontal")) == 1)
            {
                SpriteOrientation(Input.GetAxisRaw("Horizontal"));
                //move the move point
                if (!CollisionCheck(Input.GetAxisRaw("Horizontal"), true))
                {
                    moveTargetPoint.position += new Vector3(Input.GetAxisRaw("Horizontal"), 0, 0);


                }
            }
            else if (Mathf.Abs(Input.GetAxisRaw("Vertical")) == 1)
            {
                if (!CollisionCheck(Input.GetAxisRaw("Vertical"), false))
                {
                    moveTargetPoint.position += new Vector3(0, Input.GetAxisRaw("Vertical"), 0);
                }
            }
        }

        if (playFallingAnimation)
        {
            ScaleModifier();
        }
    }



    void SpriteOrientation(float direction)
    {
        if (direction < 0)
            sr.flipX = true;
        else
            sr.flipX = false;
    }
    private bool CollisionCheck(float direction, bool horizontal) //VEDERE MEGLIO
    {
        if (horizontal)
            return Physics2D.OverlapCircle(moveTargetPoint.position + new Vector3(direction, 0, 0), .2f, collisions);
        else
            return Physics2D.OverlapCircle(moveTargetPoint.position + new Vector3(0, direction), .2f, collisions);
    }  

    void PlayFallingAnimation()
    {
        playFallingAnimation = true;
    }

    void ScaleModifier()
    {
        if (transform.localScale.x > 0.01 && transform.localScale.y > 0.01)
            transform.localScale *= 0.9f;
        else
        {
            //transform.localScale = Vector3.one;
            EventManager.current.OnComplete();
            playFallingAnimation = false;
        }
    }

    public bool FallingAnimationEnded()
    {
        if (transform.localScale.x > 0.01 && transform.localScale.y > 0.01)
        {
            transform.localScale *= 0.9f;
            return false;
        }
        else
            return true;
    }
}
