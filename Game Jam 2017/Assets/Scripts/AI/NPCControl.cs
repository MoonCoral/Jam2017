using UnityEngine;
using System.Collections;

public class NPCControl : MonoBehaviour
{
    private GameObject player;
    private StateSystem fsm;

    private void Start()
    {
        fsm = new StateSystem();

        PatrolState patrol = new PatrolState();
        patrol.AddTransition(Transition.SeekTransition, StateID.Seeking);
        patrol.AddTransition(Transition.AttackTransition, StateID.Attacking);
        fsm.AddState(patrol);

        SeekState seek = new SeekState();
        seek.AddTransition(Transition.AttackTransition, StateID.Attacking);
        seek.AddTransition(Transition.WanderTransition, StateID.Patrolling);
        fsm.AddState(seek);

        AttackState attack = new AttackState();
        attack.AddTransition(Transition.SeekTransition, StateID.Seeking);
        fsm.AddState(attack);

        player = GameObject.Find("Player").gameObject;
    }

    private void Update()
    { 
        fsm.getCurrentState.Think(player, gameObject);
        fsm.getCurrentState.Do(player, gameObject);
    }

    public void ChangingState(Transition t)
    {
        fsm.ChangeState(t);
    }

}
