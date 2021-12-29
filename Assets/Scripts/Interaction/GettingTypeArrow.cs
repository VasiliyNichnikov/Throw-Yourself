using DirectionMovement;

namespace Interaction
{
    public static class GettingTypeArrow
    {
        public static TypesArrow Get(bool doubleClick)
        {
            TypesArrow typeArrow = TypesArrow.MotionSelection;
            if (doubleClick)
            {
                typeArrow = TypesArrow.Transformation;
            }

            return typeArrow;
        }
    }
}