using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace com.guidoarkesteijn.monkeytester.runtime
{
    public class MonkeyTesterSettings : ScriptableObject
    {
        public int TestTimeInSeconds { get { return testTimeInSeconds; } }
        [SerializeField] private int testTimeInSeconds = 300;

        public int ClicksPerSeconds { get { return clicksPerSeconds; } }
        [SerializeField] private int clicksPerSeconds = 10;

#if UNITY_EDITOR
        public void SetClicksPerSeconds(int value)
        {
            clicksPerSeconds = value;
        }

        public void SetTestTimeInSeconds(int value)
        {
            testTimeInSeconds = value;
        }
#endif
    }
}
