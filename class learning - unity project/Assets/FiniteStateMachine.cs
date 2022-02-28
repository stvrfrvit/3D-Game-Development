using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FiniteStateMachine : MonoBehaviour
{
    private IState entryState;
    private IState currentState;

    private void Awake()
    {
        entryState = new GreenState(this);
    }

    // Start is called before the first frame update
    void Start()
    {
        SetState(entryState);
    }

    // Update is called once per frame
    void Update()
    {
        if(currentState != null)
        {
            currentState.OnStateUpdate();
        }
    }

    public void SetState(IState state)
    {
        if(currentState != null)
        {
            currentState.OnStateExit();
        }
        currentState = state;
        currentState.OnStateEnter();
    }
}

public interface IState
{
   
    public void OnStateEnter();
    public void OnStateUpdate();
    public void OnStateExit();
}

public class RedState : IState
{
    private FiniteStateMachine  instance;
    public RedState(FiniteStateMachine fsm)
    {
        instance = fsm;
    }

    public void OnStateEnter()
    {
        instance.GetComponent<MeshRenderer>().material.color = Color.red;
    }
    public void OnStateUpdate()
    {
        Debug.Log("red go");
        if (Input.GetKeyDown(KeyCode.Space) == true)
        {
            instance.SetState(new GreenState(instance)); //transtation to new state
        }
    }
        public void OnStateExit()
        {
            Debug.Log("red done");
        }
}
public class GreenState : IState
{
    private FiniteStateMachine instance;
    private FiniteStateMachine finiteStateMachine;

    public GreenState(FiniteStateMachine fsm)

    {
        instance = fsm;
    }

    public void OnStateEnter()
    {
        instance.GetComponent<MeshRenderer>().material.color = Color.green;
    }
    public void OnStateUpdate()
    {
        Debug.Log("green go");
        if (Input.GetKeyDown(KeyCode.Space) == true)
        {
            instance.SetState(new RedState(instance));
        }
    }
        public void OnStateExit()
        {
            Debug.Log("green done");
        }
}
