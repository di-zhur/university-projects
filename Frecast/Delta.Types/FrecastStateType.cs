using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delta.Types
{
    public struct FrecastStateType
    {
        /// <summary>
        /// Выполняется
        /// </summary>
        public static readonly int Running = 1;

        /// <summary>
        /// Завершено
        /// </summary>
        public static readonly int Complete = 2;

        /// <summary>
        /// Ошибка
        /// </summary>
        public static readonly int Error = 3;
    }
}
