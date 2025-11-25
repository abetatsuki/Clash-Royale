using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class AnimationCon
{
    private Animator _animator;
    private CharactorMover _mover;
    public AnimationCon(Animator animator,CharactorMover mover)
    {
        _animator = animator;
        _mover = mover;
        _mover.ChangeSpeed += SetSpeed;
    }
    private void SetSpeed(float speed)
    {
        _animator.SetFloat("Blend", speed);
    }
    
}
