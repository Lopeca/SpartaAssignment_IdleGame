using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class AnimationStringData
{
    public static readonly int IsIdle = Animator.StringToHash("IsIdle");
    public static readonly int IsMove = Animator.StringToHash("IsMove");
    public static readonly int IsAttack = Animator.StringToHash("IsAttack");
    public static readonly int IsDie = Animator.StringToHash("IsDie");
}
