using Training.States;
using UnityEngine;
using UnityEngine.UI;

namespace Training
{
    public class ParentTraining : MonoBehaviour
    {
        [SerializeField] private ManagerTraining[] _managers;
        [SerializeField] private Text _textOutputData;
        private StateTraining[] _states;
        private StateMachineTraining _stateMachine;
        private int _selectedState;
        private bool _isTraining;


        public void NextState()
        {
            _selectedState++;
            if(_selectedState < _states.Length)
                _stateMachine.ChangeState(_states[_selectedState]);
        }

        public void End()
        {
            _isTraining = false;
        }
        
        public void ChangeInfoInText(string newText)
        {
            _textOutputData.text = newText;
        }

        private void Start()
        {
            if (_managers.Length == 0)
            {
                Debug.LogWarning("There is no training in this scene.");
                return;
            }

            _isTraining = true;
            InitStates();
        }

        private void InitStates()
        {
            _stateMachine = new StateMachineTraining();
            _states = new StateTraining[_managers.Length];
            for (int i = 0; i < _managers.Length; i++)
            {
                StateAppearanceText state = new StateAppearanceText(this, _stateMachine, _managers[i]);
                _states[i] = state;
            }

            _selectedState = 0;
            _stateMachine.Initialize(_states[_selectedState]);
        }

        private void Update()
        {
            if (_isTraining == false) return;
            _stateMachine.CurrentState.LogicUpdate();
        }
    }
}