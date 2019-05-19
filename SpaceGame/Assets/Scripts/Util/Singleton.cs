﻿using UnityEngine;

public abstract class Singleton<T> : MonoBehaviour where T : Component
{
    #region Properties
    private static T m_Instance;

    public static T Instance
    {
        get
        {
            if(m_Instance == null)
            {
                m_Instance = FindObjectOfType<T>();
                if (m_Instance == null)
                {
                    GameObject _obj = new GameObject
                    {
                        name = typeof(T).Name
                    };
                    m_Instance = _obj.AddComponent<T>();
                }
            }
            return m_Instance;
        }
    }
    #endregion

    #region Methods
    private void Awake()
    {
        if(m_Instance == null)
        {
            m_Instance = this as T;
        }
    }

    private void OnDestroy()
    {
        if(m_Instance == this)
        {
            m_Instance = null;
        }
    }
    #endregion
}
