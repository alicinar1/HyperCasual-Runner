using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utilities.ObjectPool;


namespace Runner.Environment
{
    public class GroundObjectPool : ObjectPoolBase
    {
        private void Start()
        {
            CreateObjectPool();
        }
    }
}
