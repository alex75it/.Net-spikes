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
            var relations = FetchDbRelation(event_);
            var modifications = AdjustRelationsToEvent(relations, event_);
            UpdateDbTable(modifications);
        }

        private Relation[] FetchDbRelation(Event event_)
        {
            throw new NotImplementedException();
        }

        Relation[] AdjustRelationsToEvent(Relation[] relations, Event event_)
        {
            var modification = new List<Modification>();
            foreach (var relation in relations)
            {
                relation.Status = event_.Status;
                relation.Modified = true;
            }    
            return relations.Where(x => Modified).ToArray();
        }

        void UpdateDbTable(Relation[] modifications)
        {
            //sql = "Update ....";
            //Dapper.Execute(sql, modifications);
        }
    }
}
