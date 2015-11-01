using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGames.Social
{
    /// <summary>
    /// Atrybut złożony
    /// </summary>
    [Serializable]
    public class ContactData
    {
        public string Email { get; set; }
        public string Phone { get; set; }
    }
}
