using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spikes.GenericSpike
{
    class MylExample
    {
        void Execute(Event event_)
        {
            var relation = FetchDbRelation(event_);
            if (AdjustRelationToEvent(relation, event_))
                UpdateDbTable(relation);
        }

        bool AdjustRelationToEvent(Relation relation, Event event_)
        {
            bool isChanged = false;
            //if (relation != null && relation.Status != event_.Status)
            if (relation?.Status != event_.Status)
            {
                relation.Status = event_.Status;
                isChanged = true;
            }
            return isChanged;
        }

        void UpdateDbTable(Relation relation)
        {
            if (relation == null)
                throw new ArgumentNullException(nameof(relation)) ;

            //sql = "Update ....";
            //Dapper.Execute(sql, modification);            
        }

        private Relation FetchDbRelation(Event event_)
        {
            throw new NotImplementedException();
        } 
    }
}
