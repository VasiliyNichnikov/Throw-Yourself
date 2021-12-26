using UnityEngine;

namespace DirectionMovement
{
    [RequireComponent(typeof(KeeperOfInformationAboutArrows))]
    public class CreatorArrow : MonoBehaviour
    {
        public float Height => _height;
        [SerializeField, Range(0, 10)] private float _height;
        private KeeperOfInformationAboutArrows _infoAboutArrows;
        private Transform _thisTransform;

        private void Start()
        {
            _thisTransform = transform;
            _infoAboutArrows = GetComponent<KeeperOfInformationAboutArrows>();
        }

        public (Transform parent, GameObject created) Create(TypesArrow type, Vector3 position, Quaternion rotation)
        {
            Transform parentArrow = new GameObject("Parent Arrow").transform;

            parentArrow.position = position;
            GameObject prefab = _infoAboutArrows.GetPrefabArrowByType(type);
            Transform createdArrow = Instantiate(prefab, position, rotation).transform;
            createdArrow.rotation = Quaternion.identity;
            createdArrow.SetParent(parentArrow);
            parentArrow.SetParent(_thisTransform);
            return (parentArrow, createdArrow.gameObject);
        }
    }
}