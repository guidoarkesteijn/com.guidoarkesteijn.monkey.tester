using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace com.guidoarkesteijn.monkeytester.runtime
{
    public class MonkeyTesterBehavior : MonoBehaviour
    {
        [SerializeField] private bool Enabled;
        [SerializeField] private RectTransform mouseCursorPosition;
        
        private MonkeyTesterSettings monkeyTesterSettings;

        private bool started = false;
        private float endTime = -1;

        protected void Awake()
        {
            monkeyTesterSettings = Resources.Load<MonkeyTesterSettings>(nameof(MonkeyTesterSettings));
            Enabled = monkeyTesterSettings.StartOnStartup;

            DontDestroyOnLoad(this.gameObject);
        }

        protected void Update()
        {
            if (Enabled)
            {
                if(!started)
                {
                    StartMonkeyTest();
                }

                if (endTime > Time.realtimeSinceStartup)
                {
                    ExecuteTest();
                }
                else
                {
                    StopMonkeyTest();
                }
            }
            else
            {
                if(started)
                {
                    StopMonkeyTest();
                }
            }
        }

        protected void OnGUI()
        {
            GUILayout.BeginArea(new Rect(10, 10, 250, 100));
            {
                string text = !Enabled ? "Start Monkey Test" : "Stop Monkey Test";

                if(GUILayout.Button(text))
                {
                    Enabled = !Enabled;
                }
            }
            GUILayout.EndArea();
        }

        private void StartMonkeyTest()
        {
            started = true;
            endTime = Time.realtimeSinceStartup + monkeyTesterSettings.TestTimeInSeconds;
        }

        private void StopMonkeyTest()
        {
            Enabled = false;
            started = false;
            endTime = -1;
        }

        private void ExecuteTest()
        {
            EventSystem eventSystem = EventSystem.current;

            var screenPosition = new Vector2(UnityEngine.Random.Range(0, Screen.width), UnityEngine.Random.Range(0, Screen.height));

            PointerEventData data = new PointerEventData(eventSystem)
            {
                position = screenPosition,
                pressPosition = screenPosition
            };

            mouseCursorPosition.anchoredPosition = data.position;

            List<RaycastResult> results = new List<RaycastResult>();

            Debug.Log(data.position);

            eventSystem.RaycastAll(data, results);

            if (results.Count > 0)
            {
                results = results.OrderBy(x => x.distance).ToList();

                var result = results.FirstOrDefault();

                foreach (var item in GetInputHandles())
                {
                    item.Execute(result.gameObject, eventSystem, data);
                }
            }
        }

        private List<IInputHandle> GetInputHandles()
        {
            return new List<IInputHandle>()
            {
                new BaseInputHandle(),
                new PointerInputHandle(),
                new MoveInputHandle()
            };
        }
    }
}
