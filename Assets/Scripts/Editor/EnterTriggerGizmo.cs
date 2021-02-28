using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System;

public class EnterTriggerActionGizmoDrawer
{
    [DrawGizmo(GizmoType.NonSelected)]
    public static void DrawTriggerGizmo(EnterTriggerAction trigger, GizmoType type)
    {
        var collider = trigger.gameObject.GetComponent<BoxCollider2D>();
        var up = collider.size.x / 2;
        var right = collider.size.y / 2;

        Func<Vector3,Vector3> x = trigger.transform.TransformPoint;
        Vector2[] points = new Vector2[]
        {
            x(new Vector2(up, right)),
            x(new Vector2(up, -right)),
            x(new Vector2(-up, right)),
            x(new Vector2(-up, -right))
        };

        Gizmos.color = new Color(1,0,1);
        Gizmos.DrawLine(points[0], points[1]);
        Gizmos.DrawLine(points[2], points[0]);
        Gizmos.DrawLine(points[3], points[2]);
        Gizmos.DrawLine(points[3], points[1]);
    }
}
