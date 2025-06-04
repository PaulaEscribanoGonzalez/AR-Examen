using UnityEngine;

public class ZoneSelector : MonoBehaviour
{
    public static ZoneSelector Instance;

    public int selectedZone = 0;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(this.gameObject);
    }
}
