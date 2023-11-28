using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bezier_curve : moving_path
{

    public override void copy_curve(moving_path curve)
    {   
        curve = (bezier_curve)curve;
        pointers = new List<Transform>();

        for(int i = 0 ; i < curve.pointers.Count; i++){
            Transform tmp = Instantiate(curve.pointers[i]);
            tmp.position = curve.pointers[i].position;
           
            pointers.Add(tmp);
        }
    }



    public static long nCr(int n, int r)
    {
        // naive: return Factorial(n) / (Factorial(r) * Factorial(n - r));
        return nPr(n, r) / Factorial(r);
    }

    public static long nPr(int n, int r)
    {
        // naive: return Factorial(n) / Factorial(n - r);
        return FactorialDivision(n, n - r);
    }

    private static long FactorialDivision(int topFactorial, int divisorFactorial)
    {
        long result = 1;
        for (int i = topFactorial; i > divisorFactorial; i--)
            result *= i;
        return result;
    }

    private static long Factorial(int i)
    {
        if (i <= 1)
            return 1;
        return i * Factorial(i - 1);
    }
    public override Vector2 get_position(float t){
        // 0 <= t <= 1  
        int n = pointers.Count - 1;

        Vector2 res = Vector2.zero;
        for(int i = 0 ; i <= n ; i ++){
            res += (nCr(n,i) * Mathf.Pow(1-t,n-i) * Mathf.Pow(t,i) * (Vector2)pointers[i].position );
        }
        return res ;
    }
}
