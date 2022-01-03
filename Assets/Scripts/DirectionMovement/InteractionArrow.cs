using UnityEngine;

namespace DirectionMovement
{
    public class InteractionArrow : MonoBehaviour
    {
        private Transform _thisTransform;
        private CreatorArrow _creatorArrow;
        private MeshRenderer _renderer;
        private Transform _parentArrow;

        private ChangerVisibility _visibility;
        private StretchingAnimation _stretching;

        public void SetVisible(bool state)
        {
            if (IsParentArrowCreated() == false) return;
            _visibility.ToChange(state);
        }

        public void Stretch(Vector3 direction)
        {
            if (IsParentArrowCreated() == false) return;
            _stretching.Stretch(direction);
        }

        public void ChangePosition()
        {
            if (IsParentArrowCreated() == false) return;
            Vector3 center = _renderer.bounds.center;
            _parentArrow.position = new Vector3(center.x, _creatorArrow.Height, center.z);
        }

        public void ChangeAngleZ(Vector3 direction)
        {
            if (IsParentArrowCreated() == false) return;
            float newAngleY = MyUtils.GetAngleBetweenDirectionAndForward(direction);
            _parentArrow.rotation = Quaternion.Euler(0, newAngleY, 0);
        }

        public void Install(TypesArrow type)
        {
            if (IsParentArrowCreated())
                Remove();
            
            var arrows = _creatorArrow.Create(type, _thisTransform.position, _thisTransform.rotation);
            _parentArrow = arrows.parent;
            _visibility = arrows.created.GetComponent<ChangerVisibility>();
            _stretching = arrows.created.GetComponent<StretchingAnimation>();
            SetVisible(true);
        }

        public void Remove()
        {
            if (IsParentArrowCreated() == false) return;
            Destroy(_parentArrow.gameObject);
        }

        private bool IsParentArrowCreated()
        {
            return _parentArrow != null;
        }

        private void Start()
        {
            _thisTransform = transform;
            _creatorArrow = FindObjectOfType<CreatorArrow>();
            _renderer = GetComponent<MeshRenderer>();
        }
    }
}