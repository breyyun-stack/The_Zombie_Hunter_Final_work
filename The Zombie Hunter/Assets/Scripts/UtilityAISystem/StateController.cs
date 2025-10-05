using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class StateController : MonoBehaviour
{
    // Список с состояниями
    [SerializeField] private List<State> _state;

    private State stateCurrent = null;
   
    void Update()
    {        
        float maxRadius = 0;

        foreach (var state in _state) 
        {
            var radius = state.Evaluate();

            if (maxRadius < radius)
            {
                // При смене состояния нужно, сначала, завершить все в текущем состоянии (например анимации)
                if (stateCurrent != null) stateCurrent.Exit();

                maxRadius = radius;

                stateCurrent = state;
            }
        }

        if (stateCurrent != null) 
        { 
            stateCurrent.Execute();  
        }        
    }
}

