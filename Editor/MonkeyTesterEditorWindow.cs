using com.guidoarkesteijn.monkeytester.runtime;
using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using System.Collections;

namespace com.guidoarkesteijn.monkeytester.editor
{
    public class MonkeyTesterWindow : EditorWindow
    {
        [MenuItem("Window/Guido Arkesteijn/Monkey Tester")]
        public static void CreateMonkeyTesterWindow()
        {
            var monkeyTesterWindow = GetWindow<MonkeyTesterWindow>("Monkey Tester");
            monkeyTesterWindow.Show();
        }

        [MenuItem("Monkey Tester/Run")]
        public static void Run()
        {
            EditorApplication.EnterPlaymode();
        }

        private MonkeyTesterSettings monkeyTesterSettings;

        protected void OnEnable()
        {
            Debug.Log("OnEnable");
            monkeyTesterSettings = Resources.Load<MonkeyTesterSettings>(nameof(MonkeyTesterSettings));
        }

        protected void OnGUI()
        {
            monkeyTesterSettings.SetTestTimeInSeconds(EditorGUILayout.IntField("Test TIme In Seconds", monkeyTesterSettings.TestTimeInSeconds));
        }
    }
}
