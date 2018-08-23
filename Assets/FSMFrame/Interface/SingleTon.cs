
/// <summary>
/// 单例模板
/// </summary>
/// <typeparam name="T"></typeparam>
public class SingleTon<T> where T:new()
{
    /// <summary>
    /// 单例
    /// </summary>
    private static T instance;

    /// <summary>
    /// 获取单例
    /// </summary>
    /// <returns></returns>
    public static T GetInstance()
    {
        if (instance == null)
        {
            instance = new T();
        }
        return instance;
    }

}
