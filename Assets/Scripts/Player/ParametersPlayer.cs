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

        public float MinimumForceTensionArrow
        {
            get
            {
                if (_minimumForceTensionArrow != 0)
                    return _minimumForceTensionArrow / 100f;
                return 0;
            }
        }

        public float TensionLevelForFirstFeedBackArrow
        {
            get
            {
                if (_tensionLevelForFirstFeedBackArrow != 0)
                    return _tensionLevelForFirstFeedBackArrow / 100f;
                return 0;
            }
        }

        public float TensionLevelForSecondFeedBackArrow
        {
            get
            {
                if (_tensionLevelForSecondFeedBackArrow != 0)
                    return _tensionLevelForSecondFeedBackArrow / 100f;
                return 0;
            }
        }

        public float TensionLevelForThirdFeedBackArrow
        {
            get
            {
                if (_tensionLevelForThirdFeedBackArrow != 0)
                    return _tensionLevelForThirdFeedBackArrow / 100f;
                return 0;
            }
        }

        public bool RelocationIsAllowed => _relocationIsAllowed;

        [SerializeField, Header("Название параметра игрока")]
        private string _name;

        [SerializeField, Header("Высота на которой будет находиться линия после создания"), Range(0, 10)]
        private float _heightRay;

        [SerializeField, Header("Сила толчка после отпуска пальца"), Range(0, 100)]
        private float _forceOfPust;

        [SerializeField, Header("Минимальная сила удара для убийства врага"), Range(0, 50)]
        private float _minRelativeVelocityForKilling;

        [SerializeField, Header("Можно ли переселиться в данный предмет")]
        private bool _relocationIsAllowed;

        [SerializeField, Header("Партикл срабатывающий при столкновение с врагом")]
        private ActivatorParticle _activatorParticle;

        [SerializeField, Header("Звук при столкновении с врагом")]
        private AudioClip _hitEnemy;

        [SerializeField, Header("Звук при столкновении со стеной")]
        private AudioClip _hitWall;

        [Space]
        [SerializeField, Header("Информация при наведение"),
         Tooltip("Минимальное натяжение, если натяжение меньше выбранного значения, эффекты воспроизводиться не будут"),
         Range(0, 100)]
        private float _minimumForceTensionArrow;

        [SerializeField, Header("При следующем натяжение будет активирован первый feedBack курсора"), Range(0, 100)]
        private float _tensionLevelForFirstFeedBackArrow;

        [SerializeField, Header("При следующем натяжение будет активирован второй feedBack курсора"), Range(0, 100)]
        private float _tensionLevelForSecondFeedBackArrow;

        [SerializeField, Header("При следующем натяжение будет активирован третий feedBack курсора"), Range(0, 100)]
        private float _tensionLevelForThirdFeedBackArrow;
    }
}