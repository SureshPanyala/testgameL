using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stone : MonoBehaviour
{
    public Route commonRoute;
    public Route finalRoute;
    public List<Node> fullRoute = new List<Node>();

    public Node startNode;
    public Node baseNode;
    public Node currentNode;
    public Node goalNode;
    int startNodeIndex;
    int routerPosition;
    int steps;
    int donesteps;
    bool isOut;
    bool isMoving;
    bool hasTurn;
    public GameObject selector;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Hello" );
        startNodeIndex = commonRoute.RequestPosition(startNode.transform);
        Debug.Log("Hello" + startNodeIndex);
        CreateFullRoute();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.S) && !isMoving)
        {
            steps = Random.Range(1, 7);
            Debug.Log("steps"+ steps);
            if (donesteps + steps < fullRoute.Count)
            {
                StartCoroutine(Move());
            }
            else
            {
                Debug.Log("Number is too High");
            }
        }
    }
    private void CreateFullRoute()
    {
        for(int i = 0; i < commonRoute.childNodeList.Count; i++)
        {
            Debug.Log("i" + i);
            int tempPos = startNodeIndex + i;
            tempPos %= commonRoute.childNodeList.Count;
            fullRoute.Add(commonRoute.childNodeList[tempPos].GetComponent<Node>());
        }
        for (int i = 0; i < finalRoute.childNodeList.Count; i++)
        {
            
            fullRoute.Add(finalRoute.childNodeList[i].GetComponent<Node>());
        }
    }
    IEnumerator Move()
    {
        if (isMoving)
        {
            yield break;
        }
        isMoving = true;
        while (steps > 0)
        {
            routerPosition++;
            Vector3 nextPos = fullRoute[routerPosition].gameObject.transform.position;
            while (MoveToNextNode(nextPos, 8f)) 
            {
                yield return null;
            }
            yield return new WaitForSeconds(0.1f);
            steps--;
            donesteps++;
        }
        isMoving = false;
    }

    bool MoveToNextNode(Vector3 goalPos,float speed)
    {
        return goalPos != (transform.position = Vector3.MoveTowards(transform.position, goalPos, speed * Time.deltaTime));
        

    }
    public bool ReturnIsOut()
    {
        return isOut;
    }

}
