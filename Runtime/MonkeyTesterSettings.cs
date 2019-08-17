using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace com.guidoarkesteijn.monkeytester.runtime
{
    public class MonkeyTesterSettings : ScriptableObject
    {
        public bool SpawnOnStartup { get { return spawnOnStartup; } }
        [SerializeField] protected bool spawnOnStartup;
        public bool StartOnStartup { get { return startOnStartup; } }
        [SerializeField] protected bool startOnStartup;
        public int TestTimeInSeconds { get { return testTimeInSeconds; } }
        [SerializeField] private int testTimeInSeconds = 300;

#if UNITY_EDITOR
        public void SetTestTimeInSeconds(int value)
        {
            testTimeInSeconds = value;
        }
#endif
    }
}
