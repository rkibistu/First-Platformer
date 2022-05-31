using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : MonoBehaviour
{
    [Header("General")]
    public float speed = 2f;
    [Tooltip("Delay used when player stays above the enemy. Enemy will tourn around contiue under him.")]
    public float chaseTurnAround = 0.2f;


    [HideInInspector]
    public Rigidbody2D rigidBody;
    [HideInInspector]
    public CollisionDetector collisionDet;


    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        collisionDet = GetComponent<CollisionDetector>();
    }
    

    void Update()
    {
        
    }

    //public void Afiseaza(int x) {
    //    print(x);
    //}
    //public void Afiseaza(float x) {
    //    print(x);
    //}
    public void Afiseaza(string x) {

        print(x);
    }
}
