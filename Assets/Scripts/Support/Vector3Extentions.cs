using UnityEngine;

public static class Vector3Extentions
{
    public static Vector2 ToVector2(this Vector3 vector3)
    {
        return new Vector2(vector3.x, vector3.y);
    }
}

public static class GameObjectExtentions
{
    public static bool HasComponent<T>(this GameObject gameObject) where T : Component
    {
        bool result = false;
        if (gameObject.GetComponent<T>()) result = true;
        return result;
    }
}
