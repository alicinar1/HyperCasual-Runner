using Runner.PlayerCont;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Runner.Energy
{
    public class EnergyController : MonoBehaviour
    {
        private void OnEnable()
        {
            Energy.OnEnergyCountUp += IncreaseEnergyCount;
        }

        private void OnDisable()
        {
            Energy.OnEnergyCountUp -= IncreaseEnergyCount;
        }

        private void IncreaseEnergyCount()
        {
            //Player.Instance.pla = 1;
            Player.Instance.IncreaseEnergyCount();
        }

        private void DecreaseEnergyCount()
        {
            //Player.Instance.PlayerSO.EnergyCount = -1;
            Player.Instance.DecreaseEnergyCount();
        }
    }
}
