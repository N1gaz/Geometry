namespace Geometry.Abstracts
{
    /// <summary>
    /// Базовый класс для всех фигур. По умолчанию любая фигура обязана реализовывать функцию площади.
    /// </summary>
    public abstract class Figure
    {
        /// <summary>
        /// Площадь фигуры. Минимальная точность
        /// </summary>
        public abstract float Area { get; }
    }
}
