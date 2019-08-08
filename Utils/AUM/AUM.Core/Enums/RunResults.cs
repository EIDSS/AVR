namespace AUM.Core.Enums
{
    public enum RunResults
    {
        /// <summary>
        /// Успешный запуск
        /// </summary>
        Success = 0,
        /// <summary>
        /// Запуск закончился ошибкой
        /// </summary>
        Fail = 1,
        /// <summary>
        /// Запуск был успешный, но обновлять не нужно
        /// </summary>
        NotNeed = 2
    }
}
