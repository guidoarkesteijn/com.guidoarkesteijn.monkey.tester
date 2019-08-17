using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace com.guidoarkesteijn.monkeytester.runtime
{
    public class MonkeyTester
    {
        private static MonkeyTesterSettings monkeyTesterSettings;

        private const string MONKEY_TESTER_RESOURCE_PATH = "MonkeyTester/MonkeyTesterPrefab";

        [RuntimeInitializeOnLoadMethod]
        public static void Execute()
        {
            monkeyTesterSettings = Resources.Load<MonkeyTesterSettings>(nameof(MonkeyTesterSettings));
            if(monkeyTesterSettings.SpawnOnStartup)
            {
                GameObject prefab = Resources.Load<GameObject>(MONKEY_TESTER_RESOURCE_PATH);

                if(prefab != null)
                {
                    GameObject instance = Object.Instantiate(prefab, Vector3.zero, Quaternion.identity);
                }
            }
        }
    }
}
