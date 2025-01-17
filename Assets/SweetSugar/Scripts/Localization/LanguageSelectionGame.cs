using SweetSugar.Scripts.Level;
using SweetSugar.Scripts.Localization;
using SweetSugar.Scripts.System;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using TMPro;
using UnityEngine;

namespace DefaultNamespace
{
    public class LanguageSelectionGame : UnityEngine.MonoBehaviour
    {
        private IEnumerable<CultureInfo> cultures;
        private TMP_Dropdown Dropdown;
        private void Start()
        {
            Dropdown = GetComponent<TMP_Dropdown>();
            var txt = Resources.LoadAll<TextAsset>("Localization/");
            cultures = CultureInfo.GetCultures(CultureTypes.AllCultures).Where(i => txt.Any(x => x.name == i.DisplayName));
            var _debugSettings = Resources.Load("Scriptable/DebugSettings") as DebugSettings;
            Dropdown.captionText.text = cultures.First(i => i.EnglishName == LocalizationManager.GetSystemLanguage(_debugSettings).ToString()).Name.ToUpper();
            Dropdown.value = cultures.ToList().FindIndex(i => i.EnglishName == LocalizationManager.GetSystemLanguage(_debugSettings).ToString());
        }

        public void OnChangeLanguage()
        {
            LocalizationManager.LoadLanguage((SystemLanguage)Enum.Parse(typeof(SystemLanguage), GetSelectedLanguage().EnglishName));
            CrosssceneData.selectedLanguage = (SystemLanguage)Enum.Parse(typeof(SystemLanguage), GetSelectedLanguage().EnglishName);
        }

        private CultureInfo GetSelectedLanguage()
        {
            return cultures.ToArray()[Dropdown.value];
        }
    }
}