using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Core.DesignPattern;

namespace Managers
{
    public class GameManager : Singleton<GameManager>
    {
        private protected override void Awake()
        {
            base.Awake();
        }

        // Start is called before the first frame update
        void Start()
        {
            
        }

        // Update is called once per frame
        void Update()
        {
            
        }
        
    }
}
