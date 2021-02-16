using System;
using UnityEngine;

public class InterationData<T> where T : class
{
    public T nowTouch;

    public Action<T> UnTouch;
    public Action<T> Touch;

    public InterationData(Action<T> UnTouch, Action<T> Touch)
    {
        this.UnTouch = UnTouch;
        this.Touch = Touch;
    }

    public void Change(T newInteraction)
    {
        if (nowTouch != null) UnTouch(nowTouch);
        nowTouch = newInteraction;
        if (nowTouch != null) Touch(nowTouch);
    }

    public void OnEnter(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out T interaction)) Change(interaction);
    }

    public void OnExit(Collider2D collision)
    {
        if (nowTouch != null && collision.gameObject.GetComponent<T>() == nowTouch) Change(null);
    }
}