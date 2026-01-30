using UnityEngine;

public class PaneNumberFinder : MonoBehaviour
{
    public static int rotationSteps = 0; // 0-3, represents 0°, 90°, 180°, 270°

    public static int UnRotated(Vector2 position)
    {
        if (position.y > 2)
        {
            if (position.x < -2)
                return 0;
            if (position.x < 2)
                return 1;
            return 2;
        }
        if (position.y > -2)
        {
            if (position.x < -2)
                return 3;
            if (position.x < 2)
                return 4;
            return 5;
        }
        if (position.x < -2)
            return 6;
        if (position.x < 2)
            return 7;
        return 8;
    }

    public static int GetPaneNumber(Vector2 position)
    {
        int basePane = UnRotated(position);

        // Remap based on rotation steps
        int[] remapping = new int[9];

        if (rotationSteps == 0)
        {
            return basePane; // No rotation
        }
        else if (rotationSteps == 1) // 90° clockwise
        {
            remapping = new int[] { 6, 3, 0, 7, 4, 1, 8, 5, 2 };
        }
        else if (rotationSteps == 2) // 180°
        {
            remapping = new int[] { 8, 7, 6, 5, 4, 3, 2, 1, 0 };
        }
        else // rotationSteps == 3, 270° clockwise (or 90° counter-clockwise)
        {
            remapping = new int[] { 2, 5, 8, 1, 4, 7, 0, 3, 6 };
        }

        return remapping[basePane];
    }

    public static void Rotate(bool clockwise)
    {
        if (clockwise)
            rotationSteps = (rotationSteps + 3) % 4;
        else
            rotationSteps = (rotationSteps + 1) % 4; // +3 is same as -1 in mod 4
    }
}