using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MySingleton
{
    public int count = 0;
    public char evenOdd = ' ';

    public MySingleton(char evenOdd)
    {
        this.evenOdd = evenOdd;
    }

    public int countUp()
    {
        count++;
        if (count % 2 == 0 && evenOdd == 'E')
        {
            return count;
        }
        else if (count % 2 == 1 && evenOdd == 'O')
        {
            return count;
        }
        else
        {
            return -1;
        }
    }
}
