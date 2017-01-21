using UnityEngine;
using System.Collections;

public class PatrolState : State
{

    private Vector3 target;

    public PatrolState()
    {
        id = StateID.Patrolling;
    }
    
    public override void Think(GameObject player, GameObject thisEnemy)
    {
        Debug.Log("PATROLLING");
        if ((((player.transform.position.x - thisEnemy.transform.position.x).Equals(2) && (player.transform.position.y - thisEnemy.transform.position.y).Equals(0)) ||
            ((thisEnemy.transform.position.x - player.transform.position.x).Equals(2) && (player.transform.position.y - thisEnemy.transform.position.y).Equals(0)) ||
            ((player.transform.position.y - thisEnemy.transform.position.y).Equals(2) && (player.transform.position.x - thisEnemy.transform.position.x).Equals(0)) ||
            ((thisEnemy.transform.position.y - player.transform.position.y).Equals(2) && (player.transform.position.x - thisEnemy.transform.position.x).Equals(0))))
        {
            thisEnemy.GetComponent<NPCControl>().ChangingState(Transition.AttackTransition);
        }
        /*
        if (player.sonaring) {
          thisEnemy.GetComponent<NPCControl>().ChangeState(Transition.SeekTransition);
        }
        */
    }
    
    public override void Do(GameObject player, GameObject thisEnemy)
    {
        if (target == new Vector3(0, 0, 0))
        {
            target = new Vector3(Random.Range(0, 35), Random.Range(0, -42), 0);
        }
        Debug.Log(target + " " + thisEnemy.transform.position);
        if (((Mathf.Abs(target.x - thisEnemy.transform.position.x) < Mathf.Abs(target.y - thisEnemy.transform.position.y)) &&
            !Mathf.Abs(target.x - thisEnemy.transform.position.x).Equals(0)) || 
            Mathf.Abs(target.y - thisEnemy.transform.position.y).Equals(0))
        {
            if (target.x < thisEnemy.transform.position.x)
            {
            thisEnemy.transform.position = new Vector3(thisEnemy.transform.position.x - 1,
                thisEnemy.transform.position.y, 0);
            }
            else if (target.x > thisEnemy.transform.position.x)
            {
            thisEnemy.transform.position = new Vector3(thisEnemy.transform.position.x + 1,
                thisEnemy.transform.position.y, 0);
            }
        }
        else if (((Mathf.Abs(target.x - thisEnemy.transform.position.x) >
                   Mathf.Abs(target.y - thisEnemy.transform.position.y)) &&
                  !Mathf.Abs(target.y - thisEnemy.transform.position.y).Equals(0)) ||
                 Mathf.Abs(target.x - thisEnemy.transform.position.x).Equals(0))
        {
            if (target.y < thisEnemy.transform.position.y)
            {
                thisEnemy.transform.position = new Vector3(thisEnemy.transform.position.x,
                    thisEnemy.transform.position.y - 1, 0);
            }
            else if (target.y > thisEnemy.transform.position.y)
            {
                thisEnemy.transform.position = new Vector3(thisEnemy.transform.position.x,
                    thisEnemy.transform.position.y + 1, 0);
            }
        }
    }
}
