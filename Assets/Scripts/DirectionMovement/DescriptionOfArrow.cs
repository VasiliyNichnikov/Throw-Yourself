using UnityEngine;

namespace DirectionMovement
{
    [System.Serializable]
    public class DescriptionOfArrow
    {
        public TypesArrow Type => _type;
        public GameObject Prefab => _prefab;
        
        [SerializeField] private string _name;
        [SerializeField] private TypesArrow _type;
        [SerializeField] private GameObject _prefab;
    }
}