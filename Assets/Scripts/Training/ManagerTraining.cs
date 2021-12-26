using UnityEngine;
using UnityEngine.Serialization;

namespace Training
{
    [System.Serializable]
    public class BlockTraining
    {
        public string TextRussian => _textRussian;
        public string TextEnglish => _textEnglish;

        [SerializeField] private string _name;
        [SerializeField] private string _textRussian;
        [SerializeField] private string _textEnglish;
    }

    [System.Serializable]
    public class ManagerTraining
    {
        public BlockTraining Text => _text;
        public TransitionCondition TransitionCondition => _transitionCondition;

        [SerializeField] private string _name;
        [FormerlySerializedAs("_blocks")] [SerializeField] private BlockTraining _text;

        [SerializeField]
        private TransitionCondition _transitionCondition;
    }
}