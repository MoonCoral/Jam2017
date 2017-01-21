using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class StateSystem
{
    private List<State> listOStates;
    private State currentState;
    public State getCurrentState { get { return currentState; } }
    private StateID currentStateID;
    public StateID getCurrentID { get { return currentStateID; } }

    public StateSystem()
    {
        listOStates = new List<State>();
    }

    public void AddState(State s)
    {
        if (s.getID == StateID.Nullid)
        {
            return;
        }
        if (listOStates.Count == 0)
        {
            listOStates.Add(s);
            currentState = s;
            currentStateID = s.getID;
            return;
        }
        foreach (State n in listOStates)
        {
            if (n.getID == s.getID)
            {
                return;
            }
        }
        listOStates.Add(s);
    }

    public void ChangeState(Transition trans)
    {
        StateID i = currentState.GetOutput(trans);
        currentStateID = i;
        foreach (State s in listOStates)
        {
            if (s.getID == currentStateID)
            {
               currentState = s;
                break;
            }
        }
    }
}
