using UnityEngine;

namespace SweetSugar.Scripts
{
    public class ButtonClickSound : StateMachineBehaviour
    {
        override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            SoundBase.Instance.PlayOneShot(SoundBase.Instance.click);

        }
    }
}
