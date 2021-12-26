using System;
using UnityEngine;

namespace Training.Conditions
{
    public class ConditionTrigger : TransitionCondition
    {
        private bool _playerInTrigger;
        private int _layerPLayer;
        
        
        public override bool CheckingTransitionCondition()
        {
            return _playerInTrigger;
        }

        private void Start()
        {
            _layerPLayer = LayerMask.NameToLayer("Player");
        }
        
        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.layer == _layerPLayer)
            {
                _playerInTrigger = true;
            }
        }
    }
}