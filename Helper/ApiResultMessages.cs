using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ToDoBack.Helper
{
    /// <summary>
    /// Hata Kodu 6 Karakter Olucak
    /// ilk 2 karakter ekranı
    /// 3. karakter Hatayı (I:Info,W=Warning,E=Error..)
    /// Son 3 karakter Hata Kodunu Belirtir.
    /// </summary>
    public class ApiResultMessages
    {
        /// <summary>
        /// Başarılı
        /// </summary>
        public const string Ok = "Ok";
        /// <summary>
        /// ToDo Warning
        /// ToDo not found
        /// </summary>
        public const string TWW001 = "TWW001";
    }
}
