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
       playerAnimator.SetBool("Shoot", KeyBoardManager.ShootPressed()); 
       playerAnimator.SetBool("Shoot", KeyBoardManager.PistolShootPressed()); 
    }
}
