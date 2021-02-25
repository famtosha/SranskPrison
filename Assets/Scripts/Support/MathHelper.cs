public static class MathHelper
{
    public static bool RandomBool(float change)
    {
        return UnityEngine.Random.Range(0, 1f) < change;
    }

    public static bool RandomBool()
    {
        return RandomBool(0.5f);
    }
}