using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationController : MonoBehaviour
{
    [SerializeField] private Animator playerAnimator;

    void Update()
    {
       playerAnimator.SetBool("Aiming",KeyBoardManager.AimPressed());
       playerAnimator.SetBool("Crouch", KeyBoardManager.CrouchPressed());
       playerAnimator.SetBool("Reload", KeyBoardManager.ReloadPressed());
       playerAnimator.SetBool("Meelee", KeyBoardManager.MeeleePressed());
       playerAnimator.SetBool("Grenade", KeyBoardManager.GrenadePressed());
       playerAnimator.SetBool("ShowLove", KeyBoardManager.ShowLovePressed());
        
       if(KeyBoardManager.RifleActive)
       {
           playerAnimator.SetBool("Shoot", KeyBoardManager.ShootPressed());
       }
       if(KeyBoardManager.PistolActive || KeyBoardManager.SniperActive || KeyBoardManager.HeavyActive)
       {
           playerAnimator.SetBool("Shoot", KeyBoardManager.SingleShootPressed());
       }
       playerAnimator.SetBool("RifleActive", KeyBoardManager.RifleActive);
       playerAnimator.SetBool("PistolActive", KeyBoardManager.PistolActive);
       playerAnimator.SetBool("HeavyActive", KeyBoardManager.HeavyActive);
       playerAnimator.SetBool("SniperActive", KeyBoardManager.SniperActive);
    }
}
