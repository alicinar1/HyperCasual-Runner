using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Utilities.DontDestroy
{
    public class DontDestroyOnLoad : MonoBehaviour
    {
        private void Awake()
        {
            DontDestroyOnLoad(gameObject);
        }
    }
}
