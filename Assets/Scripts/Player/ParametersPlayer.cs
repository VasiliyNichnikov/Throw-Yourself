using Particulars;
using UnityEngine;

namespace Player
{
    [CreateAssetMenu(fileName = "Player", menuName = "Parameters/Player", order = 1)]
    public class ParametersPlayer : ScriptableObject
    {
        public string Name => _name;
        public float HeightRay => _heightRay;
        public float ForceOfPush => _forceOfPust;
        public float MinRelativeVelocityForKilling => _minRelativeVelocityForKilling;
        public ActivatorParticle ActivatorParticle => _activatorParticle;
        public AudioClip HitEnemy => _hitEnemy;
        public AudioClip HitWall => _hitWall;

        [SerializeField, Header("Название параметра игрока")]
        private string _name;

        [SerializeField, Header("Высота на которой будет находиться линия после создания"), Range(0, 10)]
        private float _heightRay;

        [SerializeField, Header("Сила толчка после отпуска пальца"), Range(0, 100)]
        private float _forceOfPust;

        [SerializeField, Header("Минимальная сила удара для убийства врага"), Range(0, 50)]
        private float _minRelativeVelocityForKilling;
        
        [SerializeField, Header("Партикл срабатывающий при столкновение с игроком")] private ActivatorParticle _activatorParticle;
        [SerializeField, Header("Звук при столкновении с врагом")] private AudioClip _hitEnemy;
        [SerializeField, Header("Звук при столкновении со стеной")] private AudioClip _hitWall;
    }
}