using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public enum Transition
{
    NullTransition,
    AttackTransition,
    WanderTransition,
    SeekTransition
}

public enum StateID
{
    Nullid,
    Attacking,
    Patrolling,
    Seeking
}

public abstract class State {
    private Dictionary<Transition, StateID> dict = new Dictionary<Transition, StateID>();
    protected StateID id;
    public StateID getID { get { return id; } }

    public void AddTransition(Transition t, StateID i)
    {
        if (t == Transition.NullTransition || i == StateID.Nullid || dict.ContainsKey(t))
        {
            return;
        }
        dict.Add(t, i);
    }

    public StateID GetOutput(Transition trans)
    {
        if (dict.ContainsKey(trans))
        {
            return dict[trans];
        }
        return StateID.Nullid;
    }

    public abstract void Think(GameObject player, GameObject thisEnemy);

    public abstract void Do(GameObject player, GameObject thisEnemy);

}
