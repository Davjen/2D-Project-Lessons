using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TpScripTest : MonoBehaviour
{

    public Transform exit;
    Transform targetMove;
    bool usedAlready, canTeleport, scaling;
    private bool firstTIme = true;

    //VERSIONE PATACCA
    public GameObject player;
    PlayerInput pScript;
    bool checkProximity;
    private void OnEnable()
    {
        EventManager.current.onComplete += FallingAnimationEnded;
    }
    private void OnDisable()
    {
        EventManager.current.onComplete -= FallingAnimationEnded;
    }
    private void Start()
    {
        pScript = player.GetComponent<PlayerInput>();
        targetMove = GameObject.FindGameObjectWithTag("MoveTarget").transform;
    }
    private void Update()
    {
        if(checkProximity)
        {
            if(Vector3.Distance(transform.position, player.transform.position) <= 0.1f)
            {
                if(pScript.FallingAnimationEnded())
                {
                    Teleport();
                }
            }
        }
    }

    void Teleport()
    {
        targetMove.position = exit.position;
        player.transform.position = new Vector3(targetMove.position.x, targetMove.position.y + 2, 0);
    }

    void FallingAnimationEnded()
    {
        canTeleport = true;
    }
    //private void OnTriggerStay2D(Collider2D collision)
    //{

    //    if (collision.tag == "Player")
    //    {
    //        Transform player = collision.transform;

    //        if (Vector3.Distance(transform.position, player.position) <= 0.1f && firstTIme)
    //        {
    //            Debug.Log(canTeleport);
    //            Debug.Log(firstTIme);
    //            EventManager.current.OnFalling();
    //            if (canTeleport)
    //            {
    //                firstTIme = false;
    //                Debug.Log("entrato" + firstTIme);

    //                targetMove.position = exit.position;
    //                //targetMove.position = grid.GetCellCenterWorld(grid.WorldToCell(exit.position));
    //                //collision.transform.position =new Vector3(targetMove.position.x,targetMove.position.y+2,0);
    //                collision.transform.position = new Vector3(targetMove.position.x, targetMove.position.y + 2, 0);
    //                //targetMove.position = transform.position;
    //                //usedAlready = true;
    //                canTeleport = false;
    //            }
    //        }
    //        //TO DO-->CHIAMARE IL METODO DELL'ANIMAZION DELLACADUTA.

    //    }
    //}
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag=="Player")
        {
            checkProximity = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        collision.transform.localScale = Vector3.one;
        checkProximity = false;
        //firstTIme = true;
    }


}
