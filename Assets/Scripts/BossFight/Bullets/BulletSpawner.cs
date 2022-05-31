using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject m_groundFollowerBullet;
    [SerializeField]
    private GameObject m_shotBullet;
    [SerializeField]
    private GameObject m_fallingBullet;

    private Vector2 m_upLeft = new Vector2(-19f, 20f);
    private Vector2 m_upRight = new Vector2(21f, 20f);
    private float m_spaceBetween = 1f;
    private int m_maximFallingBulletsInRow = 41;
    void Start()
    {
        
    }

    public void SpawnShotBullet() {

        GameObject.Instantiate(m_shotBullet, transform.position, Quaternion.identity);
    }
    public void SpawnGroundFollowerBullet() {

        GameObject.Instantiate(m_groundFollowerBullet, transform.position, Quaternion.identity);
    }
    public void SpawnFallingBullets(int numberOfBullets) {

        if (numberOfBullets > m_maximFallingBulletsInRow)
            numberOfBullets = m_maximFallingBulletsInRow;

        for(int i = 0; i < numberOfBullets; i++) {

            int x = Random.Range(-19, 22);
            GameObject.Instantiate(m_fallingBullet, new Vector3(x, 20, 0), Quaternion.identity);
        }
               
    }
}
