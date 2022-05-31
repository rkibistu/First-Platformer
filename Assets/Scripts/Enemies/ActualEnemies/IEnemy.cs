using System.Collections;
using System.Collections.Generic;
using UnityEngine;

interface IEnemy {
    void StartWalk(Vector2 direction = default(Vector2));
    void UpdateWalking();

    void StartIdle();

    void Chase(Vector2 targetPosition);
    bool CanChase();
    void SwapDirection();
    void StopMovement();
}

