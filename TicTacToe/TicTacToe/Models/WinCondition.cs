using System;

namespace TicTacToe.Models;

/// <summary>
/// One win condition, for example 1, 5, 9 (diagonal)
/// </summary>
public class WinCondition
{
    /// <summary>
    /// First character position
    /// </summary>
    public int A { get; }
    
    /// <summary>
    /// Second character position
    /// </summary>
    public int B { get; }
    
    /// <summary>
    /// Third character position
    /// </summary>
    public int C { get; }

    public WinCondition
    (
        int a,
        int b,
        int c
    )
    {
        ValidateArgument(a, nameof(a));
        ValidateArgument(b, nameof(b));
        ValidateArgument(c, nameof(c));

        if (a == b || b == c || c == a)
        {
            throw new ArgumentException($"Some of coordinates are equal: A = { a }, B = { b }, C = { c } ");
        }
        
        A = a;
        B = b;
        C = c;
    }

    private static void ValidateArgument(int arg, string paramName)
    {
        if (arg < 0 || arg > 8)
        {
            throw new ArgumentOutOfRangeException(paramName, $"Incorrect character position: { arg }");
        }
    }
}