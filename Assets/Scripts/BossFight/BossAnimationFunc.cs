using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAnimationFunc : MonoBehaviour
{
    BossStateMachine m_sm;
    void Start()
    {
        m_sm = GetComponentInParent<BossStateMachine>();
    }


}
