using UnityEngine;
using System.Collections;

public class AttackState : State
{

    public AttackState()
    {
        id = StateID.Attacking;
    }

    public override void Think(GameObject player, GameObject thisEnemy)
    {
        Debug.Log("ATTACKING");
        if (player.transform.position.x - thisEnemy.transform.position.x == 3 ||
            thisEnemy.transform.position.x - player.transform.position.x == 3 ||
            player.transform.position.z - thisEnemy.transform.position.z == 3 ||
            thisEnemy.transform.position.z - player.transform.position.z == 3) {
          thisEnemy.GetComponent<NPCControl>().ChangingState(Transition.SeekTransition);
        }
    }

    public override void Do(GameObject player, GameObject thisEnemy)
    {

    }
}