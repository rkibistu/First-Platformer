using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStateMachine_BASE : MonoBehaviour
{
    protected BaseState_Enemy currentState;
    //protected BaseState_Enemy oldState;

    void Start() {
        currentState = GetInitialState();
        //oldState = null;
        if (currentState != null)
            currentState.Enter();
    }

    public virtual void Update() {

        if (currentState != null) {
            currentState.UpdateLogic();


            //if (currentState != oldState) {
            //    print(currentState.name);
            //}

        }
        //oldState = currentState;
    }

    void FixedUpdate() {
        if (currentState != null)
            currentState.UpdatePhysics();
    }

    protected virtual BaseState_Enemy GetInitialState() {
        return null;
    }

    public void ChangeState(BaseState_Enemy newState) {
        currentState.Exit();

        currentState = newState;
        newState.Enter();
    }

    //DECOMENTEAZA SA APARA STAREA CURENTA
    private void OnGUI() {
        //GUILayout.BeginArea(new Rect(10f, 10f, 200f, 100f));
        //string content = currentState != null ? currentState.name : "(no current state)";
        //GUILayout.Label($"<color='black'><size=40>{content}</size></color>");
        //GUILayout.EndArea();
    }
    void OnDrawGizmosSelected() {

        if (currentState != null)
            currentState.DrawGizmos();
    }

    private void OnDestroy() {

    }
}
