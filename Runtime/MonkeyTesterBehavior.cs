using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace com.guidoarkesteijn.monkeytester.runtime
{
    public class MonkeyTesterBehavior : MonoBehaviour
    {
        [SerializeField] private RectTransform mouseCursorPosition;

        private MonkeyTesterSettings monkeyTesterSettings;

        protected void Awake()
        {
            monkeyTesterSettings = Resources.Load<MonkeyTesterSettings>(nameof(MonkeyTesterSettings));

            DontDestroyOnLoad(this.gameObject);
        }

        private void Start()
        {
            StartCoroutine(Test());
        }

        private IEnumerator Test()
        {
            float endTime = Time.realtimeSinceStartup + monkeyTesterSettings.TestTimeInSeconds;

            while (endTime > Time.realtimeSinceStartup)
            {
                yield return null;

                ExecuteAllEvents();
            }


            Debug.Log("STOP");
        }

        private void ExecuteAllEvents()
        {
            EventSystem eventSystem = EventSystem.current;

            GraphicRaycaster[] graphicRayCaster = FindObjectsOfType<GraphicRaycaster>();

            foreach (var item in graphicRayCaster)
            {
                PointerEventData data = new PointerEventData(eventSystem);
                data.position = new Vector2(Random.Range(0, Screen.width), Random.Range(0, Screen.height));

                mouseCursorPosition.anchoredPosition = data.position;

                List<RaycastResult> results = new List<RaycastResult>();

                Debug.Log(data.position);

                item.Raycast(data, results);

                if(results.Count > 0)
                {
                    foreach (var result in results)
                    {
                        Debug.Log("HIT: " + result.gameObject.name);
                        ExecuteEvents.Execute(result.gameObject, new PointerEventData(eventSystem), ExecuteEvents.pointerClickHandler);
                    }
                }
            }
        }
    }
}
