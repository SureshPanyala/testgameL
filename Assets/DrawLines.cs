using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawLines : MonoBehaviour
{
    private Transform[] childNodes;
    public List<Transform> childNodeList = new List<Transform>();


    private void Start()
    {
        FillNodes();
    }
    void FillNodes()
    {
        childNodeList.Clear();
           childNodes = GetComponentsInChildren<Transform>();
        foreach(Transform child in childNodes)
        {
            if (child != this.transform)
            {
                childNodeList.Add(child);
            }
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        for (int i = 0; i < transform.childCount; i++)
        {
            Transform child = transform.GetChild(i);
            Vector3 startPos = child.position;
            if (i > 0)
            {
                Transform nextChild = transform.GetChild(i - 1);
                Vector3 endPos = nextChild.position;

                // Draw the Gizmo line from the current child to the next child
                Gizmos.DrawLine(endPos,startPos);

            }
            
        }
    }

}
