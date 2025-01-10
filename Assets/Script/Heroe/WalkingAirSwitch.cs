using UnityEngine;
using Unity.VisualScripting;
public class WalkingAirSwitch : MonoBehaviour
{
    public Jump Jump;
    public float timeFallPassed;
    public float reservTimeJump;
    public float timeGroundOut;
    public void ZYOn()
    {

        if (timeFallPassed > reservTimeJump || Jump.reservTimeJumpPermisison == false)
        {
            Moove.singleton.rb.constraints = RigidbodyConstraints2D.None;
            Moove.singleton.rb.constraints = RigidbodyConstraints2D.FreezeRotation;
        }
    }
    void Start()
    {
        timeFallPassed = Time.time - timeGroundOut;
    }
}
