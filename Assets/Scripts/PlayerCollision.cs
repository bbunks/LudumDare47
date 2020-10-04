using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    public SphereCollider topCollider, bottomCollider, frontCollider, backCollider, leftCollider, rightCollider;
    public CharacterController controller;
    Collider[] frontCollision, backCollision, leftCollision, rightCollision, sideCollision, topCollision, bottomCollision, collisions;
    int layerMask = ~(1 << 9);
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        frontCollision = Physics.OverlapSphere(frontCollider.transform.position, frontCollider.radius, layerMask);
        backCollision = Physics.OverlapSphere(backCollider.transform.position, backCollider.radius, layerMask);
        leftCollision = Physics.OverlapSphere(leftCollider.transform.position, leftCollider.radius, layerMask);
        rightCollision = Physics.OverlapSphere(rightCollider.transform.position, rightCollider.radius, layerMask);
        topCollision = Physics.OverlapSphere(topCollider.transform.position, topCollider.radius, layerMask);
        bottomCollision = Physics.OverlapSphere(bottomCollider.transform.position, bottomCollider.radius, layerMask);
        sideCollision = frontCollision.Concat(backCollision).Concat(leftCollision).Concat(rightCollision).Distinct().ToArray();
        collisions = sideCollision.Concat(topCollision).Concat(bottomCollision).Distinct().ToArray();
    }

    public Collider[] getFrontCollisions()
    {
        return frontCollision;
    }
    public Collider[] getBackCollisions()
    {
        return backCollision;
    }
    public Collider[] getLeftCollisions()
    {
        return leftCollision;
    }
    public Collider[] getRightCollisions()
    {
        return rightCollision;
    }
    public Collider[] getSideCollisions()
    {
        return sideCollision;
    }
    public Collider[] getTopCollisions()
    {
        return topCollision;
    }
    public Collider[] getBottomCollisions()
    {
        return bottomCollision;
    }
    public Collider[] getCollisions()
    {
        return collisions;
    }
}
