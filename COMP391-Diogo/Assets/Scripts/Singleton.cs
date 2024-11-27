using UnityEngine;

public abstract class Singleton<T> : MonoBehaviour where T : Component
{
    public static T instance;
    protected virtual void Awake()
    {
        if (instance == null)
        {
            instance = this as T;
        }
        else
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }
}
