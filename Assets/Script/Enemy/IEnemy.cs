using System.Numerics;
using UnityEngine;

public interface IEnemy
{
    GameObject Heroe { get; }
    Transform EnemyTransform { get; }
    Rigidbody2D EnemyRigidbody { get; }
    string EnemyName { get; }
    int EnemyHealch { get; }
    int EnemyDamage { get; }
    float EnemySpeed { get; }
    float EnemyMaxVelocityX {  get; }
    float EnemyMaxVelocityY {  get; }




    void EnemyCollisions();
}
