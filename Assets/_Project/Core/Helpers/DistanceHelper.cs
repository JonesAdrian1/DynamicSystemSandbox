using UnityEngine;

public static class DistanceHelper
{
    public static GameObject FindClosest(GameObject[] objects, Vector3 position)
    {
        GameObject closest = null;
        float minDistance = float.MaxValue;

        foreach (var obj in objects)
        {
            float dist = Vector3.Distance(position, obj.transform.position);
            if (dist < minDistance)
            {
                minDistance = dist;
                closest = obj;
            }
        }

        return closest;
    }
}