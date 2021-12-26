using UnityEngine;

public static class MyUtils
{
    public static Quaternion GetLookRotation(Vector3 from, Vector3 to)
    {
        Vector3 diff = to - from;
        diff.y = 0.0f;
        return Quaternion.LookRotation(diff, Vector3.up);
    }

    public static Vector3 GetVectorFromAngle(float angle)
    {
        float angleRad = angle * (Mathf.PI / 180f);
        return new Vector3(Mathf.Cos(angleRad), 0, Mathf.Sin(angleRad));
    }

    public static float GetAngleBetweenDirectionAndForward(Vector3 direction)
    {
        float angle = Vector3.Angle(direction, Vector3.forward);
        angle = direction.x > 0 ? angle : -angle;
        return angle;
    }

    public static Vector2 TranslationFromScreenPointToAnchored(Vector3 screenPos, float scaleFactor)
    {
        float h = Screen.height;
        float w = Screen.width;
        float x = screenPos.x - (w / 2);
        float y = screenPos.y - (h / 2);
        return new Vector2(x, y) / scaleFactor;
    }

    public static (Vector2 min, Vector2 max) GetAnchorsForAnObjectInViewport(Vector3 viewportPoint,
        RectTransform rectTransform)
    {
        Vector2 difference = rectTransform.anchorMax - rectTransform.anchorMin;
        Vector2 min = new Vector2(viewportPoint.x - difference.x / 2, viewportPoint.y - difference.y / 2);
        Vector2 max = new Vector2(viewportPoint.x + difference.x / 2, viewportPoint.y + difference.y / 2);
        return (min, max);
    }
}