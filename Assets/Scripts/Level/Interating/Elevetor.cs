using System.Collections;
using UnityEngine;

public class Elevetor : MonoBehaviour, IInteraction
{
    public OpenRequire openType => OpenRequire.Closed;
    public Transform endPostion;
    [Min(0)]public float elevetorSpeed;

    private Vector3 _startPositionVector;
    private Vector3 _endPositionVector;
    private float _moveState = 0;

    public void HideInfo() { }
    public void ShowInfo() { }
    public void UseByCharacter(UseAction use, out bool isUsed) { isUsed = false; }

    private void Awake()
    {
        _startPositionVector = gameObject.transform.position;
        _endPositionVector = endPostion.position;
    }

    public void UseByAnotherObject()
    {
        Use();
    }

    private void Use()
    {
        StartCoroutine(MoveCoroutine());
        IEnumerator MoveCoroutine()
        {
            while(_moveState < 1)
            {                
                var lerp = Vector3.Lerp(_startPositionVector, _endPositionVector, _moveState);
                transform.position = lerp;
                _moveState += Time.deltaTime * elevetorSpeed;
                yield return new WaitForEndOfFrame();
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawLine(transform.position, endPostion.position);
    }
}
