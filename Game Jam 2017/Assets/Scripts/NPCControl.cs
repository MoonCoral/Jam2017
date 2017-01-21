using UnityEngine;
using System.Collections;
using Interfaces;
using System;

public class NPCControl : MonoBehaviour, IEnemy
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

        AttackState attack = new AttackState();
        attack.AddTransition(Transition.SeekTransition, StateID.Seeking);
        fsm.AddState(attack);

        SeekState seek = new SeekState();
        seek.AddTransition(Transition.AttackTransition, StateID.Attacking);
        seek.AddTransition(Transition.WanderTransition, StateID.Patrolling);
        fsm.AddState(seek);

        player = GameObject.Find("Player(Clone)").gameObject;
    }

    private void DoUpdate()
    { 
        fsm.getCurrentState.Think(player, gameObject);
        fsm.getCurrentState.Do(player, gameObject);
    }

    

    public void ChangingState(Transition t)
    {
        fsm.ChangeState(t);
    }

    public void action()
    {
        DoUpdate();
    }
}
