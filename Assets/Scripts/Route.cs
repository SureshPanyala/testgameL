using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Route : MonoBehaviour
{
    // Start is called before the first frame update
    private Transform[] childNodes;
    public List<Transform> childNodeList = new List<Transform>();


    private void Start()
    {
        FillNodes();
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        for (int i = 0; i < childNodeList.Count; i++)
        {
            
            Vector3 pos = childNodeList[i].position;
            if (i > 0)
            {
                Transform nextChild = transform.GetChild(i - 1);
                Vector3 prev = nextChild.position;

                // Draw the Gizmo line from the current child to the next child
                Gizmos.DrawLine(prev, pos);

            }

        }
    }
    void FillNodes()
    {
        childNodeList.Clear();
        childNodes = GetComponentsInChildren<Transform>();
        foreach (Transform child in childNodes)
        {
            if (child != this.transform)
            {
                childNodeList.Add(child);
            }
        }
    }
    public int RequestPosition(Transform nodeTransform)
    {
        return childNodeList.IndexOf(nodeTransform);
    }
}
