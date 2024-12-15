using System.Numerics;
using UnityEngine;

public interface ITrapable
{
    GameObject Heroe { get; }
    Moove mooveScript { get; }
    Transform trans { get; }
    UnityEngine.Vector2 TrapPosition { get; }
    string TrapName { get; }
    int TrapHealch {  get; }
    int TrapDamage { get; }
    

    

    void ActivateTrap();
}
