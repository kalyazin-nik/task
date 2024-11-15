namespace Task.Connector.Infrastructure.Extensions;

/// <summary>
/// Класс расширение интерфейса <see cref="IEnumerable{T}"/>.
/// </summary>
public static class EnumerableExtension
{
    /// <summary>
    /// Перечисление коллекции.
    /// </summary>
    /// <typeparam name="T">Дженерик параметр <see cref="{T}"/>.</typeparam>
    /// <param name="enumeration">Коллекция.</param>
    /// <param name="action">Действие совершаемое с элементом коллекции.</param>
    public static void ForEach<T>(this IEnumerable<T> enumeration, Action<T> action)
    {
        foreach (T item in enumeration)
        {
            action(item);
        }
    }
}
