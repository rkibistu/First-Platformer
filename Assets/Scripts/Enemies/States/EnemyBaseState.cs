using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBaseState : BaseState_Enemy {
    protected EnemyStateMachine sm;

    protected Vector2 initialPosition;
    protected enum Rotation { Horizontal = 0, Vertical };
    protected Rotation m_rotation;

    protected ChaseRectangle chaseRectangle;

    public EnemyBaseState(string name, EnemyStateMachine stateMachine) : base(name, stateMachine) {

        sm = (EnemyStateMachine)this.stateMachine;

        initialPosition = sm.transform.position;
        if (sm.transform.rotation.eulerAngles.z == 0 || sm.transform.rotation.eulerAngles.z == 180)
            m_rotation = Rotation.Horizontal;
        else
            m_rotation = Rotation.Vertical;

        chaseRectangle = new ChaseRectangle(initialPosition, sm.maxPatrolDistance, sm.chaseHeight);
    }
    public override void Enter() {
        base.Enter();

    }
    public override void UpdateLogic() {
        base.UpdateLogic();
    }

    public override void UpdatePhysics() {
        base.UpdatePhysics();
    }



    public override void DrawGizmos() {
        base.DrawGizmos();

        if (sm.patrolPerimeter == true) {

            Gizmos.color = Color.cyan;
            if (m_rotation == Rotation.Horizontal)
                Gizmos.DrawLine(new Vector2(initialPosition.x - sm.maxPatrolDistance, initialPosition.y), new Vector2(initialPosition.x + sm.maxPatrolDistance, initialPosition.y));
            else
                Gizmos.DrawLine(new Vector2(initialPosition.x, initialPosition.y - sm.maxPatrolDistance), new Vector2(initialPosition.x, initialPosition.y + sm.maxPatrolDistance));
        }

        if(sm.chasePerimeter == true) {

            Gizmos.DrawLine(chaseRectangle.bottomLeft, chaseRectangle.bottomRight);
            Gizmos.DrawLine(chaseRectangle.bottomLeft, chaseRectangle.topLeft);
            Gizmos.DrawLine(chaseRectangle.topRight, chaseRectangle.bottomRight);
            Gizmos.DrawLine(chaseRectangle.topRight, chaseRectangle.topLeft);
        }
    }




    public struct ChaseRectangle {

        public Vector2 bottomLeft;
        public Vector2 bottomRight;
        public Vector2 topLeft;
        public Vector2 topRight;

        public ChaseRectangle(Vector2 originPoint, float width, float height) {

            bottomLeft = new Vector2(originPoint.x - width, originPoint.y - 1);
            bottomRight = new Vector2(originPoint.x + width, originPoint.y - 1);
            topLeft = new Vector2(originPoint.x - width, originPoint.y + height);
            topRight = new Vector2(originPoint.x + width, originPoint.y + height);
        }

        public bool isInside(Vector2 position) {

            if (position.x <= bottomLeft.x)
                return false;
            if (position.x >= bottomRight.x)
                return false;
            if (position.y >= topLeft.y)
                return false;
            if (position.y <= bottomLeft.y)
                return false;


            return true;
        }

    }
}
