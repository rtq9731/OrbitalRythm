using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationEffectScript : EffectScript
{
    Animator anim = null;

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    protected override IEnumerator EffectCor()
    {
        anim.SetTrigger("Effect");

        yield return new WaitUntil(() => anim.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1f);

        gameObject.SetActive(false);
    }
}
