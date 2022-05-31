using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseState_Enemy
{
    public string name;

    protected EnemyStateMachine stateMachine;

    public BaseState_Enemy(string name, EnemyStateMachine stateMachine) {
        this.name = name;
        this.stateMachine = stateMachine;
    }

    public virtual void Enter() { }
    public virtual void UpdateLogic() { }
    public virtual void UpdatePhysics() { }
    public virtual void Exit() { }
    public virtual void DrawGizmos() { }
}
