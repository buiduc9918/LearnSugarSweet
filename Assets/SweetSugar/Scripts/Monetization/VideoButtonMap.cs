using UnityEngine;
using UnityEngine.UI;

namespace SweetSugar.Scripts.Monetization
{
    public class VideoButtonMap : MonoBehaviour
    {
        public Animator anim;
        public Button button;
        private void OnEnable()
        {
            button.interactable = true;
            Invoke(nameof(Prepare), 2);
        }

        private void Prepare()
        {
            ShowButton();
        }

        private void ShowButton()
        {
            anim.SetTrigger("show");
        }

        public void Hide()
        {
            button.interactable = false;

        }
    }
}