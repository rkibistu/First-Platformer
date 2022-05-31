using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hitBoxPlayer : MonoBehaviour {


    private void OnTriggerEnter2D(Collider2D collision) {

       
        if (collision.gameObject.tag == "Enemy") {
          

            //print("L-am lovit!");
            //collision.gameObject.SetActive(false);
            EnemyStateMachine esm = collision.gameObject.GetComponent<EnemyStateMachine>();
            if (esm)
                esm.ChangeState(esm.deadState);

            SelfDestroy esm2 = collision.gameObject.GetComponent<SelfDestroy>();
            if (esm2)
                esm2.DestroyItself();

            BossStateMachine esm1 = collision.gameObject.GetComponent<BossStateMachine>();
            if (esm1) {
                esm1.GetDamage();
            }
        }
    }

}
