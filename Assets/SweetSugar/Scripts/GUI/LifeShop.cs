using SweetSugar.Scripts.Core;
using TMPro;
using UnityEngine;

namespace SweetSugar.Scripts.GUI
{
    /// <summary>
    /// Life shop popup
    /// </summary>
    public class LifeShop : MonoBehaviour
    {
        public int CostIfRefill = 1;
        // Use this for initialization
        void OnEnable()
        {
            InitScript.Instance.AddLife(1);
            transform.Find("Image/Buttons/BuyLife/Price").GetComponent<TextMeshProUGUI>().text = "" + CostIfRefill;
            if (!LevelManager.THIS.enableInApps)
                transform.Find("Image/Buttons/BuyLife").gameObject.SetActive(false);

        }

    }
}
