using UnityEngine;
using System.Collections;
using System;

public class SeekState : State
{
    //Tile n, e, s, w;
    private Vector3 lastSeen = GameObject.Find("Player").transform.position;
    public SeekState()
    {
        id = StateID.Seeking;
    }

    public override void Think(GameObject player, GameObject thisEnemy)
    { 
        Debug.Log("SEEKING");
        if (player.transform.position.x - thisEnemy.transform.position.x == 2 ||
            thisEnemy.transform.position.x - player.transform.position.x == 2 ||
            player.transform.position.y - thisEnemy.transform.position.y == 2 ||
            thisEnemy.transform.position.y - player.transform.position.y == 2) {
            thisEnemy.GetComponent<NPCControl>().ChangingState(Transition.AttackTransition);
        }
        

        if (thisEnemy.transform.position == (lastSeen))
        {
            thisEnemy.GetComponent<NPCControl>().ChangingState(Transition.WanderTransition);
        }
    }

    public override void Do(GameObject player, GameObject thisEnemy)
    {
        /*
          int best = 0;
          for each of the directional tiles, whichever one is closer is chosen
          move to closest state
        */
    }
}