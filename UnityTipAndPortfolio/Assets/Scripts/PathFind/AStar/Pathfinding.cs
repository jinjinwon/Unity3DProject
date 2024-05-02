using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using static UnityEngine.InputSystem.InputControlScheme;
using Cysharp.Threading.Tasks;

public class Pathfinding : MonoBehaviour {

	public Transform start, destination;

    private Vector3 cacheStart, cacheDest;
	private Grid grid;
    private Coroutine traceCoroutine = null;  // 현재 추적 코루틴을 저장
    private float minChangeThreshold = 0.1f; // 최소 거리 변화 기준

    void Awake () 
	{
		grid = GetComponent<Grid> ();	
	}

    #region 동기
    //   void Update()
    //{
    //       // 변화 감지를 위한 거리 계산
    //       if (Vector3.Distance(start.position, cacheStart) > minChangeThreshold ||
    //           Vector3.Distance(destination.position, cacheDest) > minChangeThreshold)
    //       {

    //           if (traceCoroutine != null)
    //           {
    //               StopCoroutine(traceCoroutine);  // 이전 코루틴 중단
    //               traceCoroutine = null;
    //           }
    //           FindPath(start.position, destination.position);
    //           cacheStart = start.position;
    //           cacheDest = destination.position;
    //       }
    //   }

    //   public void StartPathFind()
    //   {
    //       if (start.position != cacheStart || destination.position != cacheDest)
    //       {
    //           if (traceCoroutine != null)
    //           {
    //               StopCoroutine(traceCoroutine);  // 기존에 실행 중인 코루틴이 있으면 중단
    //           }
    //           FindPath(start.position, destination.position);
    //           cacheStart = start.position;
    //           cacheDest = destination.position;
    //       }
    //   }

    //   void FindPath(Vector3 startPos, Vector3 targetPos)
    //{
    //	Node startNode = grid.GetNodeFromPosition(startPos);
    //	Node targetNode = grid.GetNodeFromPosition(targetPos);

    //	List<Node> openSet = new List<Node> ();
    //	HashSet<Node> closedSet = new HashSet<Node>();

    //       openSet.Add (startNode);
    //       while (openSet.Count > 0) 
    //       {
    //           #region 가장 낮은 값을 가진 노드를 선택한다.
    //           Node currentNode = openSet[0]; 
    //           for (int i = 1; i < openSet.Count; i++)
    //           {
    //               if (openSet[i].fCost < currentNode.fCost || (openSet[i].fCost == currentNode.fCost && openSet[i].hCost < currentNode.hCost))
    //               {
    //                   currentNode = openSet[i];
    //               }
    //           }
    //           #endregion

    //           #region 가장 낮은 값을 가진 노드가 종착노드면 탐색을 종료한다.
    //           if (currentNode == targetNode)
    //           {
    //               RetracePath(startNode, targetNode);
    //               return;
    //           }
    //           #endregion

    //           #region 현재 노드를 오픈 셋에서 빼서 클로즈드 셋으로 이동한다.
    //           openSet.Remove(currentNode);
    //           closedSet.Add(currentNode);
    //           #endregion

    //           #region 이웃노드를 가져와서 값을 계산한 후 오픈 셋에 추가한다.
    //           foreach (Node n in grid.GetNeighbours(currentNode))
    //           {
    //               if (!n.isWalkable || closedSet.Contains(n))
    //               {
    //                   continue;
    //               }

    //               int g = currentNode.gCost + GetDistance(currentNode, n);
    //               int h = GetDistance(n, targetNode);
    //               int f = g + h;

    //               // 오픈 셋에 이미 중복 노드가 있는 경우 값이 작은 쪽으로 변경한다.
    //               if (!openSet.Contains(n))
    //               {
    //                   n.gCost = g;
    //                   n.hCost = h;
    //                   n.parent = currentNode;
    //                   openSet.Add(n);
    //               }
    //               else
    //               {
    //                   if(n.fCost > f)
    //                   {
    //                       n.gCost = g;
    //                       n.parent = currentNode;
    //                   }
    //               }
    //           }
    //           #endregion
    //       }
    //   }
    #endregion

    #region 비동기
    void Update()
    {
        // 거리 검사
        if (Vector3.Distance(start.position, cacheStart) > minChangeThreshold ||
            Vector3.Distance(destination.position, cacheDest) > minChangeThreshold)
        {
            // 이미 루틴이 돌고 있따면
            if (traceCoroutine != null)
            {
                StopCoroutine(traceCoroutine);  // 이전 코루틴 중단
                traceCoroutine = null;
            }
            // 길찾기 시작 및 캐시변수에 저장
            FindPath(start.position, destination.position).Forget();
            cacheStart = start.position;
            cacheDest = destination.position;
        }
    }

    async UniTaskVoid FindPath(Vector3 startPos, Vector3 targetPos)
    {
        // 비동기로 위치 계산
        PathResult result = await UniTask.Run(() => ComputePath(startPos, targetPos));
        RetracePath(result.startNode, result.endNode);
    }

    PathResult ComputePath(Vector3 startPos, Vector3 targetPos)
    {
        Node startNode = grid.GetNodeFromPosition(startPos);
        Node targetNode = grid.GetNodeFromPosition(targetPos);

        List<Node> openSet = new List<Node>();
        HashSet<Node> closedSet = new HashSet<Node>();

        openSet.Add(startNode);
        while (openSet.Count > 0)
        {
            Node currentNode = openSet[0];
            for (int i = 1; i < openSet.Count; i++)
            {
                if (openSet[i].fCost < currentNode.fCost || (openSet[i].fCost == currentNode.fCost && openSet[i].hCost < currentNode.hCost))
                {
                    currentNode = openSet[i];
                }
            }

            if (currentNode == targetNode)
            {
                return new PathResult { startNode = startNode, endNode = targetNode };
            }

            openSet.Remove(currentNode);
            closedSet.Add(currentNode);

            foreach (Node neighbor in grid.GetNeighbours(currentNode))
            {
                if (!neighbor.isWalkable || closedSet.Contains(neighbor))
                {
                    continue;
                }

                int newCostToNeighbor = currentNode.gCost + GetDistance(currentNode, neighbor);
                if (newCostToNeighbor < neighbor.gCost || !openSet.Contains(neighbor))
                {
                    neighbor.gCost = newCostToNeighbor;
                    neighbor.hCost = GetDistance(neighbor, targetNode);
                    neighbor.parent = currentNode;

                    if (!openSet.Contains(neighbor))
                    {
                        openSet.Add(neighbor);
                    }
                }
            }
        }
        throw new System.Exception("No path found");
    }

    struct PathResult
    {
        public Node startNode, endNode;
    }
    #endregion

    void RetracePath(Node startNode, Node endNode)
	{
		List<Node> path = new List<Node> ();
		Node currentNode = endNode;

		while (currentNode != startNode) {
			path.Add (currentNode);
			currentNode = currentNode.parent;
		}

		path.Reverse ();
		grid.path = path;
        // 추적 시작
        traceCoroutine = StartCoroutine(TraceStart());
    }

    IEnumerator TraceStart()
    {
        int targetIndex = 0;
        float moveSpeed = 5f; // 조정 가능한 속도 파라미터

        while (targetIndex < grid.path.Count)
        {
            Vector3 currentWayPoint = grid.path[targetIndex].position;
            while (start.position != currentWayPoint)
            {
                if (isActiveAndEnabled == false)
                    yield break;

                start.position = Vector3.MoveTowards(start.position, currentWayPoint, moveSpeed * Time.deltaTime);
                yield return null;
            }
            targetIndex++;
        }
    }

    int GetDistance(Node nodeA, Node nodeB)
	{
		int dstX = Mathf.Abs(nodeA.gridX - nodeB.gridX);
		int dstY = Mathf.Abs(nodeA.gridY - nodeB.gridY);

		if(dstX > dstY)
		{
			return 14*dstY + 10*(dstX - dstY);
		}

		return 14*dstX + 10*(dstY - dstX);
	}
}
