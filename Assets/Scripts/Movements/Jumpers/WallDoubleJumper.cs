using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class WallDoubleJumper : WallJumper
{
    private enum Direction { left, right }
    private bool _isDoubleJumped;

    protected override bool TryToJump()
    {
        if (IsInAir)
        {
            if (_isDoubleJumped)
                return false;

            switch (GetCurrentDirection())
            {
                case Direction.right:
                    JumpLeft();
                    break;

                case Direction.left:
                    JumpRight();
                    break;
            }
            _isDoubleJumped = true;
            return true;
        }

        switch (GetCurrentDirection())
        {
            case Direction.right:
                JumpRight();
                break;

            case Direction.left:
                JumpLeft();
                break;
        }
        _isDoubleJumped = false;

        return true;
    }

    private Direction GetCurrentDirection()
        => WallNormal.x > 0 ? Direction.right : Direction.left;
}
