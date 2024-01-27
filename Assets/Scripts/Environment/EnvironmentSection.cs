using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static System.Collections.Specialized.BitVector32;

public class EnvironmentSection: MonoBehaviour
{
    /**
     * The section's position
     */
    public Vector3 position;
    /**
     * The section's type
     */
    public SectionType type;
    /**
     * The section's direction
     */
    public Direction direction;

    /**
     * returns the next position from this section to a given direction
     */
    public Vector3 GetNextPosition(Direction nextDirection, int size)
    {
        Vector3 nextPosition = this.gameObject.transform.position;
        nextPosition.x += (nextDirection == Direction.West) ? -size : ((nextDirection == Direction.East) ? size : 0);
        nextPosition.z += (nextDirection == Direction.South) ? -size : ((nextDirection == Direction.North) ? size : 0);
        return nextPosition;
    }

    /**
     * Returns the next directions of this section
     */
    public List<Direction> GetNextDirections()
    {
        List<Direction> nextDirections = new List<Direction>();
        if(this.type != SectionType.Left
            && this.type != SectionType.Right
            && this.type != SectionType.LeftRight)
        {
            nextDirections.Add(this.direction);
        }

        if(this.type != SectionType.Straight
            && this.type != SectionType.Right
            && this.type != SectionType.StraightRight)
        {
            nextDirections.Add(this.GetLeft());
        }

        if (this.type != SectionType.Straight
            && this.type != SectionType.Left
            && this.type != SectionType.StraightLeft)
        {
            nextDirections.Add(this.GetRight());
        }

        return nextDirections;
    }

    /**
     * Returns the left direction
     */
    public Direction GetLeft()
    {
        switch(this.direction)
        {
            case Direction.North: return Direction.West;
            case Direction.South: return Direction.East;
            case Direction.West: return Direction.South;
            case Direction.East: return Direction.North;
            default: return this.direction;
        }
    }

    /**
     * Returns the right direction
     */
    public Direction GetRight()
    {
        switch (this.direction)
        {
            case Direction.North: return Direction.East;
            case Direction.South: return Direction.West;
            case Direction.West: return Direction.North;
            case Direction.East: return Direction.South;
            default: return this.direction;
        }
    }
}
