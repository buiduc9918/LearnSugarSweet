using SweetSugar.Scripts.System;
using System.Collections.Generic;
using UnityEngine;

namespace SweetSugar.Scripts
{
    public static class DebugLogKeeper
    {
        public static List<DebugElement> logListFalling = new List<DebugElement>();
        public static List<DebugElement> logListDestroying = new List<DebugElement>();
        public static List<DebugElement> logListBonus = new List<DebugElement>();
        private static DebugSettings _debugSettings;

        public static void Log(string str, LogType type, bool forceStackTrace = false)
        {
#if UNITY_EDITOR
            string extractStackTrace = null;
            switch (type)
            {
                case LogType.Falling:
                    if (_debugSettings.StackTrace || forceStackTrace)
                        extractStackTrace = StackTraceUtility.ExtractStackTrace();
                    logListFalling.Add(new DebugElement(str, extractStackTrace, Time.time));
                    break;
                case LogType.Destroying:
                    if (_debugSettings.StackTrace || forceStackTrace)
                        extractStackTrace = StackTraceUtility.ExtractStackTrace();
                    logListDestroying.Add(new DebugElement(str, extractStackTrace, Time.time));
                    break;
                case LogType.BonusAppearance:
                    if (_debugSettings.StackTrace || forceStackTrace)
                        extractStackTrace = StackTraceUtility.ExtractStackTrace();
                    logListBonus.Add(new DebugElement(str, extractStackTrace, Time.time));
                    break;
            }

            if (_debugSettings.ShowLogImmediately)
                Debug.Log(str);

#endif
        }

        public static string GetLog(string id, LogType type)
        {
            string txt = "";
            List<DebugElement> list = new List<DebugElement>();
            switch (type)
            {
                case LogType.Falling:
                    list = logListFalling;
                    break;
                case LogType.Destroying:
                    list = logListDestroying;
                    break;
                case LogType.BonusAppearance:
                    list = logListBonus;
                    break;
            }
            foreach (var item in list)
            {
                if (item.str.Contains(id))
                {
                    string v = item.str + "\n";
                    Debug.Log(item.time + " " + v);
                    v = "Stack trace: " + item.references + "\n";
                    Debug.Log(v);
                    txt += v;
                }
            }
            return txt;
        }

        public enum LogType
        {
            Falling,
            Destroying,
            BonusAppearance
        }

        public class DebugElement
        {
            public string str;
            public string references;
            public float time;

            public DebugElement(string str, string references, float time)
            {
                this.str = str;
                this.references = references;
                this.time = time;
            }
        }

        public static void Init()
        {
            _debugSettings = Resources.Load("Scriptable/DebugSettings") as DebugSettings;
        }
    }
}
