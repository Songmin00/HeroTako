using UnityEngine;

public abstract class Singleton<T> : MonoBehaviour where T : MonoBehaviour
{
    private static T _instance;
    private static readonly object _lock = new object();
    private static bool _isQuitting = false;

    [Header("싱글톤 옵션")]
    [SerializeField] private bool _dontDestroyOnLoad = true;

    public static T Instance
    {
        get
        {
            
            if (_isQuitting)
            {
                Debug.LogWarning($"[Singleton] {typeof(T)} 인스턴스가 종료 중에 호출되었습니다. null을 리턴합니다.");
                return null;
            }

            
            if (_instance != null) return _instance;

            lock (_lock)
            {                
                if (_instance == null)
                {
                    
                    _instance = Object.FindFirstObjectByType<T>(FindObjectsInactive.Exclude);

                    
                    if (_instance == null)
                    {
                        GameObject go = new GameObject($"[Singleton] {typeof(T).Name}");
                        _instance = go.AddComponent<T>();
                    }
                }
                return _instance;
            }
        }
    }

    protected virtual void Awake()
    {
        
        if (_instance != null && _instance != this)
        {
            Debug.LogWarning($"[Singleton] {gameObject.name}의 중복 인스턴스가 감지되어 파괴되었습니다.");
            Destroy(gameObject);
            return;
        }

        _instance = this as T;

        
        if (_dontDestroyOnLoad)
        {
            if (transform.parent != null) transform.SetParent(null);
            DontDestroyOnLoad(gameObject);
        }
    }

    protected virtual void OnApplicationQuit()
    {
        _isQuitting = true;
    }

    protected virtual void OnDestroy()
    {        
        if (ReferenceEquals(_instance, this))
        {
            _instance = null;
        }
    }
}