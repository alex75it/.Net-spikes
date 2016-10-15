using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spikes.GenericSpike
{
    class InitialExample
    {
        void Execute(Event event_)
        {
            var relation = FetchDbRelation(event_);
            var modification = AdjustRelationToEvent(relation, event_);
            if (modification != null)
                UpdateDbTable(modification);
        }

        private Relation FetchDbRelation(Event event_)
        {
            throw new NotImplementedException();
        }

        Relation AdjustRelationToEvent(Relation relation, Event event_)
        {
            if (relation == null)
                return null;

            if (relation.Status != event_.Status)
            {
                relation.Status = event_.Status;
                return relation;
            }
            return null;
        }

        void UpdateDbTable(Relation modification)
        {
            if (modification == null)
                return;

            //sql = "Update ....";
            //Dapper.Execute(sql, modification);
        }        
    }
}
