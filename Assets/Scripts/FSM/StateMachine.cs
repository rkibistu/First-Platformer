using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using System.IO;

public class StateMachine : MonoBehaviour {
    protected BaseState currentState;
    protected BaseState oldState;

    [SerializeField]
    protected bool showDetails = false;

     void Start() {
        currentState = GetInitialState();
        oldState = null;
        if (currentState != null)
            currentState.Enter();

        currentState.StateStart();
    }

    public virtual void Update() {

        if (currentState != null) {
            currentState.UpdateLogic();


            if (currentState != oldState) {
                //if(showDetails)
                //print(currentState.name );
            }

        }
        oldState = currentState;
    }

    void FixedUpdate() {
        if (currentState != null)
            currentState.UpdatePhysics();
    }

    protected virtual BaseState GetInitialState() {
        return null;
    }

    public void ChangeState(BaseState newState) {
        currentState.Exit();

        currentState = newState;
        newState.Enter();
    }

    //DECOMENTEAZA SA APARA STAREA CURENTA
    private void OnGUI() {

        if (showDetails) {

            GUILayout.BeginArea(new Rect(10f, 10f, 200f, 100f));
            string content = currentState != null ? currentState.name : "(no current state)";
            GUILayout.Label($"<color='black'><size=40>{content}</size></color>");
            GUILayout.EndArea();
        }
    }
    void OnDrawGizmosSelected() {

        if (currentState != null)
            currentState.DrawGizmos();
    }

    private void OnDestroy() {

    }

    public void printCurrentState() {

        print(currentState.name);
    }
}
