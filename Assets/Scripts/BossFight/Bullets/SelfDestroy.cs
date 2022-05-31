using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDestroy : MonoBehaviour
{

    public void DestroyItself() {

        Animator anim = GetComponent<Animator>();
        if (anim != null)
            anim.Play("Dead");
        else
            Destroy(gameObject);
    }
}
