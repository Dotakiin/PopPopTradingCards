using System;
using System.Collections.Generic;
using System.Text;
using Lib = PopPopTradingCardsLib.Models;

namespace PopPopTradingCardsDataAccess
{
    public interface IMapper
    {
        Lib.User Map(Entities.User u);

        Lib.MagicCard Map(Entities.MagicCard c);

        Lib.BaseballCard Map(Entities.BaseballCard c);

        Entities.MagicCard Map(Lib.MagicCard c);

        Entities.BaseballCard Map(Lib.BaseballCard c);
    }
}
