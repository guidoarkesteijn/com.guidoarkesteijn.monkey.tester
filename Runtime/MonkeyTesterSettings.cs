using UnityEngine;

namespace com.guidoarkesteijn.monkeytester.runtime
{
    [CreateAssetMenu(menuName = "Guido Arkesteijn/Monkey Tester Settings")]
    public class MonkeyTesterSettings : ScriptableObject
    {
        public bool SpawnOnStartup { get { return spawnOnStartup; } }
        [SerializeField] protected bool spawnOnStartup;
        public bool StartOnStartup { get { return startOnStartup; } }
        [SerializeField] protected bool startOnStartup;
        public int TestTimeInSeconds { get { return testTimeInSeconds; } }
        [SerializeField] private int testTimeInSeconds = 300;
    }
}
