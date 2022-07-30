using UnityEngine;
using UnityEngine.AI;
[RequireComponent (typeof (NavMeshAgent))]
public class EnemyLogic : MonoBehaviour
{
    [Range(0, 360)] public float viewAngle = 90f;
    public float viewDistance = 15f;
    public float detectionDistance = 5f;
    public Transform eye;
    public Transform player;

    private NavMeshAgent navmesh;
    private float rotationSpeed;
    private Transform navMeshTransform;

    // Start is called before the first frame update
    private void Start()
    {
        navmesh = GetComponent<NavMeshAgent>();
        navmesh.updateRotation = false;
        rotationSpeed = navmesh.angularSpeed;
        navMeshTransform = navmesh.transform;
    }

    // Update is called once per frame
    private void Update()
    {

        float distanceToPlayer = Vector3.Distance(player.transform.position, navmesh.transform.position);
        if(distanceToPlayer <= detectionDistance || IsInView())
        {
            RotateToTarget();
            MoveToTarget();
        }
        DrawViewState();
    }
    private void RotateToTarget()
    {
        Vector3 viewVector = player.position - navMeshTransform.position;
        viewVector.y = 0; //Не смотрит вверх и вниз
        if (viewVector == Vector3.zero) return;
        navMeshTransform.rotation = Quaternion.RotateTowards
            (
            navMeshTransform.rotation,
            Quaternion.LookRotation(viewVector, Vector3.up),
            rotationSpeed * Time.deltaTime
            );
    }
    private bool IsInView()
    {
        float realAngle = Vector3.Angle(eye.forward, player.position - eye.position);
        RaycastHit hit;
        if (Physics.Raycast(eye.transform.position, player.position - eye.position, out hit, viewDistance))
        {
            if (realAngle < viewAngle / 2f && Vector3.Distance(eye.position, player.position) <= viewDistance && hit.transform == player.transform)
            {
                return true;
            }
        }
        return false;
    }
    private void MoveToTarget()
    {
        navmesh.SetDestination(player.position);
    }
    private void DrawViewState()
    {
        Vector3 left = eye.position + Quaternion.Euler(new Vector3(0, viewAngle / 2f, 0)) * (eye.forward * viewDistance);
        Vector3 right = eye.position + Quaternion.Euler(-new Vector3(0, viewAngle / 2f, 0)) * (eye.forward * viewDistance);
        Debug.DrawLine(eye.position, left, color: Color.red);
        Debug.DrawLine(eye.position, right, color: Color.red);
    }
}
