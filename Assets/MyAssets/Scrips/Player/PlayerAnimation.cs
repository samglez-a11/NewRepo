using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private Animator _playerAnimator = new Animator();

    private void Start()
    {
        _playerAnimator = GetComponentInChildren<Animator>();
        if (_playerAnimator == null)
        {
            Debug.LogWarning("El jugador no tiene un primer hijo con animator");
        }
    }
    public void setSpeed(float speed)
    {
         _playerAnimator.SetFloat("Speed", speed);
     
        
    }
    public void setIsJump(bool band)
    {
        _playerAnimator.SetBool("isJump", band);
    }
}
