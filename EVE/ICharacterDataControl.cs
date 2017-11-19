using EVE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EVE
{
    public interface ICharacterDataControl
    {
        void refreshCharacters();

        Dictionary<int, Character> Characters { get; set; }

    }
}
