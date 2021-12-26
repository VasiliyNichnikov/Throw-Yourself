using System;
using UnityEngine;

namespace DirectionMovement
{
    public class KeeperOfInformationAboutArrows : MonoBehaviour
    {
        [SerializeField] private DescriptionOfArrow[] _arrows;

        public GameObject GetPrefabArrowByType(TypesArrow type)
        {
            foreach (var arrow in _arrows)
            {
                if (arrow.Type == type)
                    return arrow.Prefab;
            }

            throw new Exception("An arrow with the selected type was not found!");
        }
    }
}