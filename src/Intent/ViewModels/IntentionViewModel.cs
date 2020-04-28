// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IntentionViewModel.cs" company="Joint Systems Integration Laboratory">
//   Copyright © 2020 Joint Systems Integration Laboratory
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Intent.ViewModels
{
    public class IntentionViewModel : IIntentionViewModel
    {
        public string Value { get; set; } = "Select this entry to enter your intention";
    }

    public interface IIntentionViewModel
    {
        string Value { get; set; }
    }
}