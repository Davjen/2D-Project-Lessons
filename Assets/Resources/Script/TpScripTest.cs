using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TpScripTest : MonoBehaviour
{
    Grid grid;
    public Transform exit;
    Transform targetMove;
    public bool UsedAlready;

    private void Start()
    {
        targetMove = GameObject.FindGameObjectWithTag("MoveTarget").transform;
        grid = transform.parent.GetComponent<Grid>();
    }
    // Start is called before the first frame update
    //private void OnTriggerEnter2D(Collider2D collision)
    //{
        
    //}

    void FallingAnimation(GameObject go)
    {

    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        Debug.Log("ciao");
        if (collision.tag == "Player")
        {
            Transform player = collision.transform;

            if (Vector3.Distance(transform.position,player.position)<=0.1f)
            {
                Debug.Log("fio<");
                targetMove.position = exit.position;
                //targetMove.position = grid.GetCellCenterWorld(grid.WorldToCell(exit.position));
                collision.transform.position = targetMove.position;
                //targetMove.position = transform.position;
                UsedAlready = true;
                //TO DO-->CHIAMARE IL METODO DELL'ANIMAZION DELLACADUTA.
            }

        }
    }

}
