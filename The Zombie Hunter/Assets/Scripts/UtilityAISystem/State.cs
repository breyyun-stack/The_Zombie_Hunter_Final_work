using UnityEngine;

public abstract class State : MonoBehaviour
{
    /// <summary>
    /// Расчитываем дистанцию для смены состояния с помощью кривых (в данном случае, у какого состояния больше радиус, то состояние и включается)
    /// </summary>
    public abstract float Evaluate();

    /// <summary>
    /// Действия, которые будут выполнятся при запущенном состоянии
    /// </summary>
    public abstract void Execute();

    /// <summary>
    /// Выход из состояния
    /// </summary>
    public abstract void Exit();
}
