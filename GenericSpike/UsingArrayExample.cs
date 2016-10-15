using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spikes.GenericSpike
{
    class UsingArrayExasmple
    {
        void Execute(Event event_)
        {
            var relations = FetchDbRelations(event_);
            var modifications = AdjustRelationsToEvent(relations, event_);
            UpdateDbTable(modifications);
        }

        private Relation[] FetchDbRelations(Event event_)
        {
            throw new NotImplementedException();
        }

        Relation[] AdjustRelationsToEvent(Relation[] relations, Event event_)
        {
            foreach (var relation in relations)
            {
                relation.Status = event_.Status;
                //relation.Modified = true;
            }    
            return relations.Where(x => x.Modified).ToArray();
        }

        void UpdateDbTable(Relation[] modifications)
        {
            //sql = "Update ....";
            //Dapper.Execute(sql, modifications);
        }
    }
}
