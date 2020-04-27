// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IntentionRepository.cs" company="Joint Systems Integration Laboratory">
//   Copyright © 2020 Joint Systems Integration Laboratory
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using System.Collections.Generic;

namespace Intent.Models
{
    public class IntentionRepository : IIntentionRepository
    {
        private readonly List<string> intentions;

        public IntentionRepository()
        {
            this.intentions = new List<string>();
        }

        public IEnumerable<string> GetIntentions()
        {
            return this.intentions;
        }

        public void TryAddIntention(string intention)
        {
            this.intentions.Add(intention);
        }
    }

    public interface IIntentionRepository
    {
        IEnumerable<string> GetIntentions();
        void TryAddIntention(string intention);
    }
}